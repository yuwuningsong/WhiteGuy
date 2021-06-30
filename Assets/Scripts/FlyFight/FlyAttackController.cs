using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttackController : MonoBehaviour
{

    //预置体
    public GameObject bullet;
    public int value = 3;
   
    private float FireRate = 0.2f;//子弹发射间隔
    private float NextFire;
   
    void Start()
    {
        
    }

    void Update()
    {
        Fire();

    }
    public void Fire()
    {
        if (Input.GetKey (KeyCode.Space)&&Time.time>NextFire )
        {
            NextFire = Time.time + FireRate;
            Instantiate(bullet, new Vector2(transform.position.x + (float)0.8, transform.position.y), Quaternion.Euler(0, 0, -90));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyBullet"||collision.tag =="enemyFly")
        {
            Destroy(collision.gameObject);
            value--;
        }
    }

   
}
