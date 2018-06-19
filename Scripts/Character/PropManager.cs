using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PropManager : MonoBehaviour
{
	private CharacterStates status;
	private Transform player;
	private NavMeshAgent navi;
	private Animator anim;


	private bool isPwrUp;               // 파워업


	private bool isAtkSpdPwrUp;              // 파워업 상태 종류
	private bool isMoveSpdPwrUp;


	private float baseMSpeed;			// 파워업 데이터 관련
	private float upMSpeed;

	private float baseASpeed;
	private float upASpeed;


	private float pwrUpTime;            // 파워업 타이머
	private float pwrUpMSTimer;			// 이속 업
	private float pwrUpASTimer;			// 공속 업



	private bool isTrapDebuff;          // 트랩

	private bool isFrostTrap;			// 트랩 상태 종류
	private bool isBurnTrap;
	private bool isPoisonTrap;
	private bool isStaticTrap;
	private bool isMoveSpdTrap;
	private bool isAtkSpdTrap;


	private float downMSpeed;            // 트랩 데이터 관련
	private int basePdmg;
	private int baseMdmg;                     


	private float regTimer;				 // 트랩 타이머
	private float allTrapTimer;
	private float asSlowTimer;
	private float msSlowTimer;
	private float frostTimer;

	void Awake()
	{
		status = GetComponent<CharacterStates>();
		player = GetComponent<Transform>();
		navi = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();


		isPwrUp = false;
		pwrUpMSTimer = 0.0f;
		pwrUpASTimer = 0.0f;

		isAtkSpdPwrUp = false;
		isMoveSpdPwrUp = false;

		baseMSpeed = navi.speed;
		baseASpeed = anim.speed;


		isTrapDebuff = false;
		allTrapTimer = 0.0f;
		asSlowTimer = 0.0f;
		msSlowTimer = 0.0f;
		frostTimer = 0.0f;


		isMoveSpdTrap = false;
		isAtkSpdTrap = false;
		isFrostTrap = false;
		isBurnTrap = false;
		isPoisonTrap = false;
		isStaticTrap = false;
	}

	void Update()
	{
		if (isMoveSpdPwrUp)								// 파워업 업데이트
		{
			MoveSpeedPowerUpTimer();
		}

		if (isAtkSpdPwrUp)
		{
			AttackSpeedPowerUpTimer();
		}

		// -------------------------------------------------------------------

		if (isMoveSpdTrap)								// 트랩 업데이트
		{
			MoveSpeedTrapTimer();
		}

		if (isAtkSpdTrap)
		{
			AttackSpeedTrapTimer();
		}
	}

	// 일반 타이머
	//void RegTimer()
	//{
	//	regTimer += Time.deltaTime;
	//	//Debug.Log(timer);
	//}

	// 트랩 디버프 시간 표시
	//void AllTrapTimer()
	//{
	//	if (allTrapTimer <= 10.0f)
	//	{
	//		Debug.Log((10 - allTrapTimer) + " seconds left");
	//	}
	//}

	void MoveSpeedPowerUpTimer()
	{
		pwrUpMSTimer += Time.deltaTime;

		if (pwrUpMSTimer >= 10.0f)
		{
			isMoveSpdPwrUp = false;
			navi.speed = baseMSpeed;
			pwrUpMSTimer = 0.0f;
			isPwrUp = false;
		}
	}

	void AttackSpeedPowerUpTimer()
	{
		pwrUpASTimer += Time.deltaTime;

		if (pwrUpASTimer >= 10.0f)
		{
			isAtkSpdPwrUp = false;
			anim.SetBool("Atk Fast", false);       // 공속 증가된 공격 멈춤
			anim.SetBool("Atk1", true);				// 일반 공격 재시작
			pwrUpASTimer = 0.0f;
			isPwrUp = false;

		}
	}

	void MoveSpeedTrapTimer()
	{
		msSlowTimer += Time.deltaTime;

		Debug.Log((msSlowTimer));

		if (msSlowTimer >= 10.0f)
		{
			isMoveSpdTrap = false;
			msSlowTimer = 0.0f;                   // 이속 트랩 해제
			navi.speed = baseMSpeed;              // 이속 원상태 복귀
		}
	}

	void AttackSpeedTrapTimer()
	{
		asSlowTimer += Time.deltaTime;

		if (asSlowTimer >= 10.0f)
		{
			isAtkSpdTrap = true;
			anim.SetBool("Atk1 Slow", false);        // 공속 증가된 공격 실행
			anim.SetBool("Atk1", true);				 // 일반 공격 멈춤
			asSlowTimer = 0.0f;
		}
	}


	//------------------------------------------------------------------------------
	// 파워업 프로퍼티
	public float IncreasedAttackSpeed							// 공속
	{
		get { return baseASpeed; }
		set { baseASpeed = value; }
	}

	public bool IsAtkSpdPwrUp                                // 공속 
	{
		get { return isAtkSpdPwrUp; }
	}


	//------------------------------------------------------------------------------
	// 트랩 프로퍼티
	public float DecreasedAttackSpeed
	{
		get { return baseASpeed; }
		set { baseASpeed = value; }
	}

	public bool IsAtkSpdTrap
	{
		get { return isAtkSpdTrap; }
	}
	//------------------------------------------------------------------------------


	// 프롭 충돌
	void OnTriggerEnter(Collider other)
	{
		// 파워업에 닿으면 
		if (other.gameObject.tag == "PowerUp" && !isPwrUp)
		{
			isPwrUp = true;							 // 파워업 적용

			Destroy(other.gameObject);

			// 이속 증가 파워업
			if (other.gameObject.name == "MoveSpeedUP")
			{
				isMoveSpdPwrUp = true;
				pwrUpMSTimer = 0.0f;				// 이속 업 타이머 초기화 및 시작
				navi.speed *= 4.0f;					// 이속 증가
				upMSpeed = navi.speed;
			}

			// 공속 증가 파워업
			if (other.gameObject.name == "AttackSpeedUP")
			{
				isAtkSpdPwrUp = true;
				pwrUpASTimer = 0.0f;				// 공속 업 타이머 초기화 및 시작

				anim.SetBool("Atk1", false);		// 일반 공격 멈춤
				anim.SetBool("Atk Fast", true);	// 공속 증가된 공격 실행
			}
		}

		// 트랩에 닿으면 
		if (other.gameObject.tag == "TRAP!")
		{
			isTrapDebuff = true;                     // 트랩 적용
			allTrapTimer = 0.0f;                     // 전역 트랩 타이머 초기화

			Destroy(other.gameObject);

			// 이속 저하 트랩
			if (other.gameObject.name == "MoveSpeedDOWN")
			{
				if (isMoveSpdTrap == true)             // 이속 트랩 상태 중
				{
					msSlowTimer = 0.0f;                 // 이속 트랩 타이머 갱신
					navi.speed -= (navi.speed / 2);     // 이속 저하 중첩
					//downMSpeed = navi.speed;
				}

				if (isMoveSpdTrap == false)
				{
					isMoveSpdTrap = true;              // 이속 트랩 상태아니면 true로 만듦
					navi.speed -= (navi.speed / 2);     // 이속 저하
					//downMSpeed = navi.speed;
				}
			}

			// 공속 저하 트랩
			if (other.gameObject.name == "AttackSpeedDOWN")
			{
				isAtkSpdTrap = true;
				asSlowTimer = 0.0f;

				anim.SetBool("Atk1", false);			 // 일반 공격 중지
				anim.SetBool("Atk Slow", true);         // 공속 저하
			}
		}
	}
}
