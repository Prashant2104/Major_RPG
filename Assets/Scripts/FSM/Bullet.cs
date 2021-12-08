using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;

    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 1000);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(Explosion)
        {
            GameObject e = Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(e, 1f);
        }
        Destroy(this.gameObject);
    }
}
