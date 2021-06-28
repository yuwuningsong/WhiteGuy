using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttackController : MonoBehaviour
{

    //预置体
    public GameObject bullet;
    public int value = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, new Vector2(transform.position.x+(float)0.8,transform .position .y), Quaternion.Euler(0, 0, -90));
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
