using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveController : Photon.MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Vector3 movePos = Vector3.zero;

    private Transform player;
    private Transform enemy;

    //public float speed = 3.0f;
    public float damping = 5.0f;

    private Animator anim;
    private NavMeshAgent navi;


    private CharacterAnimatior animator;

    private CharacterStates state;

    private MinionState miniState;

    private PropManager prop;

    private CharacterTotalState total;

    public Transform camPivot;

    private bool clickEnemy = false;

    private bool isAtk = false;

    public float detectRange = 2.0f;

    public LayerMask mask;


    // 0531 스킬
    [SerializeField]
    private GameObject prefab1;

    [SerializeField]
    private Transform atkPoint1;

    private MagicDamage basicAtk;
    private MagicDamage2 Skill1Atk;
    private MagicDamage2 Skill2Atk;
    private MagicDamage Skill3Atk;

    [SerializeField]
    private GameObject prefab2;

    [SerializeField]
    private Transform atkPoint2;

    private ParticleSystem Skill1;

    [SerializeField]
    private GameObject prefab3;

    [SerializeField]
    private Transform atkPoint3;

    private ParticleSystem Skill2;

    [SerializeField]
    private GameObject prefab4;

    [SerializeField]
    private Transform atkPoint4;

    private ParticleSystem Skill3;

    [SerializeField]
    private float power;

    public MagicDamage m1;

    public SkillManager skillManager;

    GameObject parent;

    public GameObject click;

    [SerializeField]
    private Transform[] genPoints;


    void Start()
    {
        player = GetComponent<Transform>();
        // enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        navi = GetComponent<NavMeshAgent>();

        animator = GetComponent<CharacterAnimatior>();

        state = GetComponent<CharacterStates>();

        // miniState = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MinionState>();

        prop = GetComponent<PropManager>();

        if (photonView.isMine)
        {
            Camera.main.GetComponent<FollowCamera>().player = camPivot;
        }

        skillManager = GameObject.Find("UI/CharacterStateInfo/Skll").GetComponent<SkillManager>();

        total = GetComponent<CharacterTotalState>();

        parent = transform.root.gameObject;

        genPoints = GameObject.Find("PlayerGenpoints").GetComponentsInChildren<Transform>();



    }

    void Update()
    {
        if (state.charstate == CharacterStates.CharState.Death)
        {
            StartCoroutine(PlayerDeath());
            return;
        }
           

        Collider[] collider = Physics.OverlapSphere(player.position, detectRange, mask);

        foreach (Collider target in collider)
        {
            if (target.tag == "Enemy")
            {
                enemy = target.GetComponent<Transform>();
                miniState = target.GetComponent<MinionState>();

            }

        }

        if (!IsAttack())
        {
            OnSkill1();
            OnSkill2();
            OnSkill3();
            OnAtk();
        }

        Move();

    }

    public IEnumerator PlayerDeath()
    {
        if (state.charstate == CharacterStates.CharState.Idle)
            yield return null;

        yield return new WaitForSeconds(5);
        state.CurrentHp = state.MaxHp;
        state.CurrentMp = state.MaxMp;
        navi.SetDestination(transform.position);
        state.IsAttack = false;
        state.Speed = 3.0f;
        animator.PlayAnim(CharacterStates.CharState.Idle);
        transform.position = GenPoint();
       

    }
    public Vector3 GenPoint()
    {
        int point = Random.Range(0, genPoints.Length);

        return genPoints[0].position;
    }
    void Move()
    {
        if (!photonView.isMine)
            return;
        navi.speed = state.Speed;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit, 100.0f, 1 << 8))
        {
            //if (state.charstate == CharaterState.CharState.Death)
            //    return;

            GameObject clickEffect = Instantiate(click, hit.point, Quaternion.identity);
            Destroy(clickEffect, 1);

            movePos = hit.point;

            animator.PlayAnim(CharacterStates.CharState.Move);
            navi.SetDestination(movePos);
            navi.isStopped = false;
            clickEnemy = false;
        }

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit, 100.0f, 1 << 11))
        {

            clickEnemy = true;
        }

        if (navi.remainingDistance <= 0.1f && navi.velocity.magnitude >= 0.1f)
        {
            //if (state.charstate == CharaterState.CharState.Death)
            //    return;

            animator.PlayAnim(CharacterStates.CharState.Idle);
        }
    }

    public void OnAtk()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.PlayAnim(CharacterStates.CharState.Attack1);
        }
    }

    public void PlayAtk()
    {
        // atkPoint1.position, Quaternion.identity
        // basicAtk = Instantiate(prefab1, parent.transform).GetComponent<MagicDamage>();
        basicAtk = Instantiate(prefab1, atkPoint1.position, player.transform.rotation).GetComponent<MagicDamage>();
        basicAtk.damage += total.Ta;
        basicAtk.parent = parent;

        // basicAtk.GetComponent<Rigidbody>().velocity = atkPoint1.forward * power;
    }

    public void OnSkill1()
    {
        if (!photonView.isMine)
            return;



        if (Input.GetKeyDown(KeyCode.W) && skillManager.skill[0].isUseable && skillManager.skill[0].mp <= state.CurrentMp)
        {
            movePos = transform.position; // 버튼이 눌러지면 Navi의 이동 좌표를
            navi.SetDestination(movePos); // 현재의 좌펴로 바꾼다.
                                          //anim.SetTrigger("Atk2");
                                          //animator.PlayAnim(CharacterStates.CharState.Attack2);
                                          //anim.SetBool("Move", false); // 이동 에니메이션은끈다.
                                          //player.LookAt(enemy.position);
            skillManager.UsingSkill(0);
        }
    }

    public void PlaySkill1()
    {
        Skill1Atk = Instantiate(prefab2, atkPoint2.position, player.transform.rotation).GetComponent<MagicDamage2>();
        Skill1Atk.damage += total.Ta;
        Skill1Atk.parent = parent;
    }

    public void OnSkill2()
    {
        if (!photonView.isMine)
            return;

        if (Input.GetKeyDown(KeyCode.E) && skillManager.skill[1].isUseable && skillManager.skill[1].mp <= state.CurrentMp)
        {
            movePos = transform.position;
            navi.SetDestination(movePos);
            //animator.PlayAnim(CharacterStates.CharState.Attack3);
            //anim.SetBool("Move", false);
            //player.LookAt(enemy.position);
            skillManager.UsingSkill(1);
        }
    }

    public void PlaySkill2()
    {
        Skill2Atk = Instantiate(prefab3, atkPoint3.position, player.transform.rotation).GetComponent<MagicDamage2>();
        Skill2Atk.damage += total.Ta;
        Skill2Atk.parent = parent;
    }

    public void OnSkill3()
    {
        if (!photonView.isMine)
            return;

        if (Input.GetKeyDown(KeyCode.R) && skillManager.skill[2].isUseable && skillManager.skill[2].mp <= state.CurrentMp)
        {
            movePos = transform.position;
            navi.SetDestination(movePos);
            //animator.PlayAnim(CharacterStates.CharState.Attack4);
            //anim.SetBool("Move", false);
            //player.LookAt(enemy.position);
            skillManager.UsingSkill(2);
        }
    }

    public void PlaySkill3()
    {
        Skill3Atk = Instantiate(prefab4, atkPoint4.position, player.transform.rotation).GetComponent<MagicDamage>();
        // Skill3Atk.GetComponent<Rigidbody>().velocity = atkPoint4.forward * power;
        Skill3Atk.damage += total.Ta;
        Skill3Atk.parent = parent;
    }

    bool IsAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Atk2") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Atk3") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Atk4"))
        {
            return true;
        }

        return false;

    }

    public void RestAttack()
    {
        if (!photonView.isMine)
            return;

        for (int i = 0; i < skillManager.skill.Count; i++)
        {
            skillManager.skill[i].isDamage = false;
        }

        navi.SetDestination(transform.position);
        state.IsAttack = false;
        state.Speed = 3.0f;
        animator.PlayAnim(CharacterStates.CharState.Idle);
    }
    

}