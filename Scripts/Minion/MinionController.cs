using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{
    public Transform[] points;
    public int nextIndex = 3;

    public float speed = 3.0f;
	public float damping = 5.0f;

	private Transform minion;
	private Transform player;
	public NavMeshAgent navi;
	private MinionAnimator animator;

    private MinionState miniState;

    public Transform pivot;
    public GameObject MinionUIPrefab;

    private Vector3 movePos;
	private bool isAtk = false;
    // public bool isDead = false;
    private bool isD = false;

    public float detectRange = 4.0f;
    public float dist;

    public LayerMask mask;

    void Start()
    {
        minion = GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        navi = GetComponent<NavMeshAgent>();

        animator = GetComponent<MinionAnimator>();
        miniState = GetComponent<MinionState>();

        pivot = transform.Find("mUiPivot").transform;

        MinionUIPrefab = Resources.Load("Prefab/UI/MinBar") as GameObject;
        Instantiate(MinionUIPrefab, pivot);

        //points = GameObject.Find("Waypoints").GetComponentsInChildren<Transform>();

    }

	[PunRPC]
	void Update()
	{
        if (miniState.minstate == MinionState.MinState.Death)
        {
            speed = 0.0f;
            //navi.isStopped = true;
            return;
        }

        isAtk = false;
        isD = false;

        // 범위 안에 들어 온 것을 검색
        // 미니온을 중심으로, 거리만큼, 누구만
        Collider[] collider = Physics.OverlapSphere(minion.position, detectRange, mask);

        // 배열을 돈다.
        foreach (Collider target in collider)
        {
            
            CharacterStates st = target.transform.GetComponent<CharacterStates>();
            TowerState ts = target.transform.GetComponent<TowerState>();

            if (target.tag == "Player" && st.charstate == CharacterStates.CharState.Death)
                return;

            // 타겟이 있고 타겟이 플레이어 이면
            if (target != null && target.tag == "Player" && st.charstate != CharacterStates.CharState.Death 
                || target != null && target.tag == "Tower" && !ts.IsDeath)
            {
                if (miniState.minstate == MinionState.MinState.Death)
                    return;
                isD = true;
                player = target.GetComponent<Transform>();

                // 타겟과 미니언(자신) 사이의 거리
                dist = Vector3.Distance(minion.position, player.position);
                if (dist <= 2.0f)
                {
                    isAtk = true;
                    //navi.isStopped = true;
                }
            }
            else
            {
                navi.SetDestination(points[nextIndex].position);
                navi.isStopped = false;
                animator.PlayAnim(MinionState.MinState.Move);
            }
        }

        if (isD)
        {
            //Debug.Log("isD: " + isD);

            
            //Quaternion rotation = Quaternion.LookRotation(movePos - minion.position);
            //minion.rotation = Quaternion.Slerp(minion.rotation, rotation, Time.deltaTime * damping);
            //minion.Translate(Vector3.forward * Time.deltaTime * speed);

            if (isAtk)
            {
                navi.isStopped = true;
                animator.PlayAnim(MinionState.MinState.Attack);
                Quaternion rotation = Quaternion.LookRotation(player.position - minion.position);
                minion.rotation = Quaternion.Slerp(minion.rotation, rotation, Time.deltaTime * damping);
                minion.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else
            {
                navi.SetDestination(player.position);
                navi.isStopped = false;
                isD = true;
            }
            
        }
        else
        {
            navi.SetDestination(points[nextIndex].position);
            navi.isStopped = false;
            animator.PlayAnim(MinionState.MinState.Move);
            
        }


 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            //nextIndex = (++nextIndex >= points.Length) ? 9 : nextIndex;
            nextIndex++;
        }
    }
}