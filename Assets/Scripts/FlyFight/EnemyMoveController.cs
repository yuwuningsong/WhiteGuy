using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public GameObject EnemyBullet;
    public float Speed;
    public int EnemyValue;
    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(0, 10);
        if (random < 4)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(EnemyBullet, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.Euler(0, 0, 90));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        DestoryEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mybullet")
        {
            EnemyValue--;
            Destroy(collision.gameObject);

        }
        if (EnemyValue <= 0)
        {

            Destroy(gameObject);
        }
        
        
    }

    void DestoryEnemy()
    {
        if (gameObject.transform.position.x < -10)
            Destroy(gameObject);
    }
}
