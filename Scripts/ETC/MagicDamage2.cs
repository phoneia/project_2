using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage2 : MonoBehaviour
{
    public int damage;
    public float damageTime;

    public GameObject parent;


    int a = 0;

    void Update()
    {
        damageTime -= Time.deltaTime;
        if (damageTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        StartCoroutine(MDamage(other));
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    StartCoroutine(MDamage(other));
    //}

    //void OnTriggerExit(Collider other)
    //{

    //}


    private IEnumerator MDamage(Collider other)
    {

        //Debug.Log(a);
        while (true)
        {
            a++;
            if (other.gameObject.tag == "Enemy")
            {
                other.SendMessage("MinDamage", damage);

            }
            yield return new WaitForSeconds(damageTime);
        }

    }

}
