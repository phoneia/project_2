using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Photon.MonoBehaviour
{
		
	[SerializeField]
	private Transform[] genPoints;

	void Awake()
	{
		createPlayer();

		PhotonNetwork.isMessageQueueRunning = true;
	}

	public void createPlayer()
    {
		PhotonNetwork.Instantiate("Prefab/Characters/" + PlayerSelect.Instance.playerName,
			 GenPoint(), Quaternion.identity, 0);
		

		Debug.Log("playerName: " + PlayerSelect.Instance.playerName);
    }
		
	public Vector3 GenPoint()
	{
		int point = Random.Range(0, genPoints.Length);
                
		return genPoints[point].position;
	}
}