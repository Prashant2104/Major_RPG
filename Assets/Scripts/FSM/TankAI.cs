using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public Transform Turret;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(this.transform.position, Player.transform.position));
    }
    public GameObject GetPlayer()
    {
        return Player;
    }
    private void Fire()
    {
        Instantiate(Bullet, Turret);
    }
    public void StartFire()
    {
        InvokeRepeating(nameof(Fire), 0.5f, 0.5f);
    }
    public void StopFire()
    {
        CancelInvoke(nameof(Fire));
    }
}
