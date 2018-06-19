using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource audsrc;

	public AudioClip mariaPick;
	public AudioClip mariaAttack1;
	public AudioClip mariaAttack2;
	public AudioClip mariaAttack3;
	public AudioClip mariaAttack4;

	public AudioClip ganfaulPick;
	public AudioClip ganfaulAttack1;
	public AudioClip ganfaulAttack2;
	public AudioClip ganfaulAttack3;
	public AudioClip ganfaulAttack4;


	void Awake()
	{
		audsrc = GetComponent<AudioSource>();
	}

	// Ganfaul

	public void GanfaulPickPlay()
	{
        audsrc.PlayOneShot(ganfaulPick);
	}

	public void GanfaulAttack1Play()
	{
        audsrc.PlayOneShot(ganfaulAttack1);
	}

	public void GanfaulAttack2Play()
	{
        audsrc.PlayOneShot(ganfaulAttack2);
	}

	public void GanfaulAttack3Play()
	{
        audsrc.PlayOneShot(ganfaulAttack3);
	}

	public void GanfaulAttack4Play()
	{
        audsrc.PlayOneShot(ganfaulAttack4);
	}


	// Maria

	public void MariaPickPlay()
	{
        audsrc.PlayOneShot(mariaPick);
	}

	public void MariaAttack1Play()
	{
        audsrc.PlayOneShot(mariaAttack1);
	}

	public void MariaAttack2Play()
	{
        audsrc.PlayOneShot(mariaAttack2);
	}

	public void MariaAttack3Play()
	{
        audsrc.PlayOneShot(mariaAttack3);
	}

	public void MariaAttack4Play()
	{
        audsrc.PlayOneShot(mariaAttack4);
	}
}
