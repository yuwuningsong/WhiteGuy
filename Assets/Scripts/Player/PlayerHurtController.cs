using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurtController : MonoBehaviour
{
    public int health = 0;
    public bool isHurt = false;
    public bool isProtect = false;
    [SerializeField] int totalHealth = 0;
    [SerializeField] bool isDead = false;
    [SerializeField] GameObject defence = null;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isProtect) defence.SetActive(true);
        if (totalHealth < health) totalHealth = health;
        if (health <= 0) isDead = true;
        Dead();
    }

    // 受伤
    public void Hurt(int attack)
    {
        if (isProtect)
        {
            isProtect = false;
            defence.SetActive(false);
        }
        else
        {
            health -= attack;
            isHurt = true;
            GetComponent<Animator>().SetTrigger("isHurt");
        }
    }

    // 恢复
    public void Recover(int num)
    {
        health += num;
    }

    // 死亡
    void Dead()
    {
        if (isDead)
        {
            Debug.Log("YOU DEAD!");
            GameManagerPokemon.gameManager.isLose = true;
        }
    }
}
