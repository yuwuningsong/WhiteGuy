using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int attack = 0;
    [SerializeField] GameObject boom = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHurtController>().health -= attack;
            Instantiate(boom, transform.position, new Quaternion());
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Weapon"))
        {
            Instantiate(boom, transform.position, new Quaternion());
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("AirWall"))
        {
            Destroy(gameObject);
        }
    }

    // 销毁子弹
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
