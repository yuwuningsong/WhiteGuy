using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLiveController : MonoBehaviour
{
    public int health = 0;
    public bool isDead = false;

    [SerializeField] int totalHealth = 0;
    [SerializeField] int attack = 0; // 攻击力
    [SerializeField] List<GameObject> booms = new List<GameObject>();

    private int index = 0;
    private bool flag = false;

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
        if (collision.CompareTag("Weapon"))
        {
            int attack = collision.gameObject.GetComponent<WeaponAttackController>().attack;
            Hurt(attack);
            collision.gameObject.GetComponentInParent<PlayerHurtController>().Recover(attack);
        }
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHurtController>().Hurt(attack);
            Recover(attack);
        }
        if (collision.CompareTag("Pet"))
        {
            int attack = collision.gameObject.GetComponent<Pet>().attackNum;
            Hurt(attack);
            PetManager.petManager.player.Recover(attack);
        }
    }

    // 受伤
    public void Hurt(int attack)
    {
        health -= attack;
        GetComponent<Animator>().SetTrigger("isHurt");
    }

    // 恢复
    public void Recover(int num)
    {
        health += num;
    }

    void Dead()
    {
        if (isDead && !flag)
        {
            health = 0;
            StartCoroutine("DeadEffect");
            Debug.Log("Monster is DEAD!");
            flag = true;
        }
    }

    IEnumerator DeadEffect()
    {
        while (index < booms.Count)
        {
            booms[index].SetActive(true);
            index++;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.4f);
        GameManagerPokemon.gameManager.isWin = true;
        gameObject.SetActive(false);
    }
}
