using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWeaponAttackController : MonoBehaviour
{
    public int attack = 0; // 攻击力
    [SerializeField] GameObject recentAttack = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            recentAttack = collision.gameObject;
        }
    }
}
