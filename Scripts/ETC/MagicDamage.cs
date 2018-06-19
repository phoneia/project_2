using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{
    public int damage;
    public float delay;
    public float speed;

    public GameObject parent;


    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //transform.localPosition = Vector3.forward * speed;

        delay -= Time.deltaTime;
        if (delay <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("MinDamage", damage);
            Destroy(this.gameObject);
        }
    }
}
