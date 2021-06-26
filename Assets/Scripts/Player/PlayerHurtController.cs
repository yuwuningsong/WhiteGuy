using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtController : MonoBehaviour
{
    public int health = 0;
    [SerializeField] int totalHealth = 0;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalHealth < health) totalHealth = health;
        if (health <= 0) isDead = true;
        Dead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Monster"))
        {
            int attack = collision.GetComponent<MonsterAttackController>().attack;
            health -= attack;
            collision.GetComponentInParent<MonsterLiveController>().health += attack;
        }*/
    }

    void Dead()
    {
        if (isDead)
        {
            Debug.Log("YOU DEAD!");
        }
    }
}
