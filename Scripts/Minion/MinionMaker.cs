using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMaker : MonoBehaviour
{
	//public Transform[] genPoints;
    public GameObject minions;

	public float makeTime ;

    public int maxMakeNum;
    public float makeMake;

    void Start()
    {
        StartCoroutine(MinionMake());
    }

    IEnumerator MinionMake()
    {
		while (true)
		{
			yield return new WaitForSeconds(makeTime);
			StartCoroutine(Minionminion());
			maxMakeNum = 3;
		}
    }

    IEnumerator Minionminion()          // 코루틴 이름이 이상하다.
    {
        while(maxMakeNum > 0)
        {
            yield return new WaitForSeconds(makeMake);
            GameObject minion = Instantiate(minions, transform.position, Quaternion.identity);
            minion.GetComponent<MinionController>().points = transform.GetComponentsInChildren<Transform>();
            maxMakeNum--;
        }
    }

	//public Vector3 GetGenPoint()
	//{
	//	int point = Random.Range(0, genPoints.Length);

	//	return genPoints[point].position;
	//}
}
