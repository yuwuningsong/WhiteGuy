using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FlyAttackController : MonoBehaviour
{

    //预置体
    public GameObject bullet;
    public int value = 10;//血量
    public Slider HP;
    [SerializeField] bool gameover = false;
    private float FireRate = 0.15f;//子弹发射间隔
    private float NextFire;
   
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
        if(gameover)
            SceneManager.LoadScene("FlyFight");

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
            HP.value--;
        }
        if(value<1)
            gameover = true;
    }

   
}
