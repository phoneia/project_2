using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Connect : MonoBehaviour
{
	[SerializeField]
	private string version;

	public InputField userId;

	void Awake()
	{
		PhotonNetwork.ConnectUsingSettings(version);
	}

	void OnJoinedLobby()
	{
		Debug.Log("Entered Lobby!");
		userId.text = GetUserId();
	}

	string GetUserId()
	{
		string userId = PlayerPrefs.GetString("USER_ID");

		if(string.IsNullOrEmpty(userId))
		{
			userId = "USER_" + Random.Range(0, 999).ToString("000");
		}
		return userId;
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("No Rooms!");

		PhotonNetwork.CreateRoom("My Room");
	}

	void OnJoinedRoom()
	{
		StartCoroutine(this.LoadGameScene());
	}

	IEnumerator LoadGameScene()
	{
		PhotonNetwork.isMessageQueueRunning = false;
		AsyncOperation load = SceneManager.LoadSceneAsync("GameScene");
		yield return load;
	}

	public void OnClickJoinRandomRoom()
	{
		PhotonNetwork.player.NickName = userId.text;
		PlayerPrefs.SetString("USER_ID", userId.text);

		PhotonNetwork.JoinRandomRoom();
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}