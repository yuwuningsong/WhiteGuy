using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public GameObject EnemyBullet;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(0, 10);
        if (random < 4)
            Instantiate(EnemyBullet, new Vector2(transform.position.x - (float)0.5, transform.position.y), Quaternion.Euler (0, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mybullet")
        {
            Destroy(gameObject);
        }
    }
}
