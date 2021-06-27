using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int attack = 0;

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
            gameObject.SetActive(false);
        }
        if (collision.collider.CompareTag("AirWall"))
        {
            gameObject.SetActive(false);
        }
    }
}
