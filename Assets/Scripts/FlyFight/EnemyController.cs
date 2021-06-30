using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform EnemyA;
    public Transform EnemyB; 
    public Transform EnemyC;

    public int AWaveNum = 14;//敌人的波次
    private int   AFlyCount =20;//一波敌人的数量
    private float AFlyWait =0.5f;//一波中，单个敌人生成的时间间隔
    private float AStartWait = 0;//开始的暂停时间
    private float AWaveWait = 3f;//两批敌人之间的时间间隔

    public int BWaveNum = 16;//敌人的波次
    private int  BFlyCount = 10;//一波敌人的数量
    private float BFlyWait = 0.5f;//一波中，单个敌人生成的时间间隔
    private float BStartWait = 10f;//开始的暂停时间
    private float BWaveWait = 10f;//两批敌人之间的时间间隔

    public int CWaveNum = 12;//敌人的波次
    private int  CFlyCount =15;//一波敌人的数量
    private float CFlyWait = 0.5f;//一波中，单个敌人生成的时间间隔
    private float CStartWait = 180;//开始的暂停时间
    private float CWaveWait = 2f;//两批敌人之间的时间间隔
    void Start()
    {
        StartCoroutine(CreatEnemyA());
        StartCoroutine(CreatEnemyB());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreatEnemyA()
    {
        for (int num = 0; num < AWaveNum; num++)
        {
            yield return new WaitForSeconds(AStartWait);
            while (true)
            {
                for (int i = 0; i < AFlyCount; i++)
                {
                    Transform transform1 = Instantiate(EnemyA);
                    float h = Random.Range(-4.1f, 4.1f);
                    transform1.position = new Vector2(9.1f, h);
                    yield return new WaitForSeconds(AFlyWait);
                }
                yield return new WaitForSeconds(AWaveWait);
            }
        }
    }

    IEnumerator CreatEnemyB()
    {
        for (int num = 0; num < BWaveNum; num++)
        {
            yield return new WaitForSeconds(BStartWait);
            while (true)
            {
                for (int i = 0; i < BFlyCount; i++)
                {
                    Transform transform1 = Instantiate(EnemyB);
                    float h = Random.Range(-4.4f,4.5f);
                    transform1.position = new Vector2(9.1f, h);
                    yield return new WaitForSeconds(BFlyWait);
                }
                yield return new WaitForSeconds(BWaveWait);
            }
        }
    }
    IEnumerator CreatEnemyC()
    {
        for (int num = 0; num < CWaveNum; num++)
        {
            yield return new WaitForSeconds(CStartWait);
            while (true)
            {
                for (int i = 0; i < CFlyCount; i++)
                {
                    Transform transform1 = Instantiate(EnemyC);
                    float h = Random.Range(-4.4f, 4.5f);
                    transform1.position = new Vector2(9.1f, h);
                    yield return new WaitForSeconds(CFlyWait);
                }
                yield return new WaitForSeconds(CWaveWait);
            }
        }
    }
}
