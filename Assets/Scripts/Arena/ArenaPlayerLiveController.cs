using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayerLiveController : MonoBehaviour
{
    public float health = 0;
    [SerializeField] float totalHealth = 0;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) isDead = true;
        Dead();
    }

    void Dead()
    {
        if (isDead)
        {
            //死亡处理
        }
    }
}
