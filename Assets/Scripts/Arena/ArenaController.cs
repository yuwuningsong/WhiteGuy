using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    private int round = 1;
    private int totalEnemyInRoundOne = 4;
    private int totalEnemyInRoundTwo = 14;
    private int totalEnemyInRoundThree = 30;
    public int enemyInScene = 0;

    [Header("Enemy")]
    [SerializeField] Transform swordsman = null;
    [SerializeField] Transform archer = null;
    [SerializeField] Transform shieldman = null;
    [SerializeField] Transform magician = null;

    [Header("RefreshPoint")]
    [SerializeField] Transform point1 = null;
    [SerializeField] Transform point2 = null;
    [SerializeField] Transform point3 = null;

    //public Animator anim2;
    //public Animator anim1;
    //public Animator anim3;
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshNewEnemy();
    }

    void RefreshNewEnemy()
    {
        if (round == 1 && enemyInScene == 0)
        {
            switch (totalEnemyInRoundOne)
            {
                case 4:
                    ChooseRefreshPoint(2, CreateNewEnemy(1)); //单刷剑士
                    totalEnemyInRoundOne--;
                    break;
                case 3:
                    ChooseRefreshPoint(2, CreateNewEnemy(2)); //单刷盾兵
                    totalEnemyInRoundOne--;
                    break;
                case 2:
                    ChooseRefreshPoint(2, CreateNewEnemy(3)); //单刷弓箭手
                    totalEnemyInRoundOne--;
                    break;
                case 1:
                    ChooseRefreshPoint(2, CreateNewEnemy(4)); //单刷法师
                    totalEnemyInRoundOne--;
                    break;
                case 0:
                    round++;
                    break;
                default:
                    break;
            }
            return;
        }

        if (round == 2 && totalEnemyInRoundTwo > 0 && enemyInScene <= 1)
        {
            int random1 = Random.Range(1, 3); //选择刷新点
            int random2 = Random.Range(1, 3); //选择怪物类型
            if (random2 == 1)
            {
                ChooseRefreshPoint(random1, CreateNewEnemy(1), CreateNewEnemy(4));
            }
            else
            {
                ChooseRefreshPoint(random1, CreateNewEnemy(2), CreateNewEnemy(3));
            }
            totalEnemyInRoundTwo -= 2;
            return;
        }

        if (round == 2 && totalEnemyInRoundTwo == 0 && enemyInScene == 0)
        {
            round++;
        }

        if (round == 3 && totalEnemyInRoundThree > 10 && enemyInScene <= 3)
        {
            int random1 = Random.Range(1, 4); //选择刷新点
            int random2 = Random.Range(1, 5); //选择怪物类型
            ChooseRefreshPoint(random1, CreateNewEnemy(random2));
            totalEnemyInRoundThree--;
            return;
        }

        //右边城堡塌掉 跑出右边 进入新场景
        if (round == 3 && totalEnemyInRoundThree <= 10 && totalEnemyInRoundThree > 0 && enemyInScene <= 5)  //   9)
        {
            GameObject.Find("Background_a/air_wall/right").SetActive(false);
            //transform.localScale = new Vector3(transform.localScale.x, 0.8f, 1f);
            //anim2.SetBool("isDead", true);
            int random1 = Random.Range(1, 4); //选择刷新点
            int random2 = Random.Range(1, 5); //选择怪物类型
            ChooseRefreshPoint(random1, CreateNewEnemy(random2));
            totalEnemyInRoundThree--;
            return;
        }
    }

    Transform CreateNewEnemy(int type)
    {
        switch (type)
        {
            case 1:
                Transform newEnemy1 = Instantiate(swordsman);
                return newEnemy1;
            case 2:
                Transform newEnemy2 = Instantiate(archer);
                return newEnemy2;
            case 3:
                Transform newEnemy3 = Instantiate(shieldman);
                return newEnemy3;
            case 4:
                Transform newEnemy4 = Instantiate(magician);
                return newEnemy4;
            default:
                return null;
        }

    }

    void ChooseRefreshPoint(int type, Transform tf)
    {
        switch (type)
        {
            case 1:
                tf.position = new Vector2(point1.position.x, point1.position.y);
                tf.localScale = new Vector3(1, 1, 1);
                //anim1.SetBool("isOpen", true);
                break;
            case 2:
                tf.position = new Vector2(point2.position.x, point2.position.y);
                tf.localScale = new Vector3(-1, 1, 1);
                //anim2.SetBool("isOpen", true);
                break;
            case 3:
                tf.position = new Vector2(point3.position.x, point3.position.y);
                tf.localScale = new Vector3(-1, 1, 1);
                //anim3.SetBool("isOpen", true);
                break;
            default:
                break;
        }
        enemyInScene++;
    }

    void ChooseRefreshPoint(int type, Transform tf1, Transform tf2)
    {
        switch (type)
        {
            case 1:
                tf1.position = new Vector2(point1.position.x, point1.position.y);
                tf1.localScale = new Vector3(1, 1, 1);
                tf2.position = new Vector2(point1.position.x, point1.position.y);
                tf2.localScale = new Vector3(1, 1, 1);
                //anim1.SetBool("isOpen", true);
                break;
            case 2:
                tf1.position = new Vector2(point2.position.x, point2.position.y);
                tf1.localScale = new Vector3(-1, 1, 1);
                tf2.position = new Vector2(point2.position.x, point2.position.y);
                tf2.localScale = new Vector3(-1, 1, 1);
                //anim2.SetBool("isOpen", true);
                break;
            case 3:
                tf1.position = new Vector2(point3.position.x, point3.position.y);
                tf1.localScale = new Vector3(-1, 1, 1);
                tf2.position = new Vector2(point3.position.x, point3.position.y);
                tf2.localScale = new Vector3(-1, 1, 1);
                //anim3.SetBool("isOpen", true);
                break;
            default:
                break;
        }
        enemyInScene += 2;
        //ChooseRefreshPoint(type, tf1);
        //ChooseRefreshPoint(type, tf2);
    }
}
