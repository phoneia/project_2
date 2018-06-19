using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    [SerializeField] private float cheakRadius;
    [SerializeField] private LayerMask cheakLayer;

    [SerializeField] private Animator shopAni;

    private bool isActivePanel = false;     // 상점 UI Canvas ON / OFF
    private bool isShopMove = false;        // 상점 에니메니션 움직이는지

    private GameObject shop;

    private float posX;

    void Start()
    {
        shop = transform.Find("Shop Canvas/ShopUI").gameObject;
        shopAni = shop.GetComponent<Animator>();

    }

    void Update()
    {
        Collider[] collier = Physics.OverlapSphere(transform.position, cheakRadius, cheakLayer);

        foreach (Collider player in collier)
        {
            if (player.tag == "Player")
            {
                shop.SetActive(true);
                return;
            }
        }

        // 상점 범위에서 벗어 날 경우
        // 상점창을 닫고 기본 상태로 돌아간다.
        shop.SetActive(false);
        isActivePanel = false;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cheakRadius);
    }

    // 버튼 이벤트용 메서드
    // 버튼을 클릭하면 상점창이 나오고 들어 간다.
    public void MovePanel()
    {
        if (!isActivePanel)
        {
            isActivePanel = true;
            shopAni.SetBool("isShopOpen", true);
        }

        else if (isActivePanel)
        {
            isActivePanel = false;
            shopAni.SetBool("isShopOpen", false);
        }


    }

}
