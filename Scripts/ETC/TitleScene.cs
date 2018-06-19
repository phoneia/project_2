using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
	public GameObject panel;
	private Animation anim;

	void Awake()
	{
		anim = transform.GetComponent<Animation>();	
	}

	public void StartButton()
	{
		anim.Play("Start");
		Invoke("SceneChange", 0.5f);
	}

	public void SceneChange()
	{
		SceneManager.LoadScene("LobbyScene");
	}

	public void OptionButton()
	{
		anim.Play("Start");
		panel.SetActive(true);
	}

	public void escButton()
	{
		panel.SetActive(false);
	}

	public void QuitButton()
	{
		anim.Play("Start");
		Application.Quit();
	}
}
