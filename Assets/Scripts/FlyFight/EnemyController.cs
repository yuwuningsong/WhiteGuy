using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform EnemyA;
    public Transform EnemyB; 
    public Transform EnemyC;

    //EnemyA
    private int AWaveNum =100;//敌人的波次
    private int   AFlyCount =5;//一波敌人的数量
    private float AFlyWait =0.2f;//一波中，单个敌人生成的时间间隔
    private float AStartWait = 0;//开始的暂停时间
    private float AWaveWait = 1f;//两批敌人之间的时间间隔
    
    //EnemyB
    private int BWaveNum = 16;//敌人的波次
    private int  BFlyCount = 10;//一波敌人的数量
    private float BFlyWait = 4f;//一波中，单个敌人生成的时间间隔
    private float BStartWait = 10f;//开始的暂停时间
    private float BWaveWait = 5f;//两批敌人之间的时间间隔

    //EnemyC
    private int CWaveNum = 8;//敌人的波次
    private int  CFlyCount =7;//一波敌人的数量
    private float CFlyWait = 1f;//一波中，单个敌人生成的时间间隔
    private float CStartWait = 120;//开始的暂停时间
    private float CWaveWait = 2f;//两批敌人之间的时间间隔

    //EnemyC
    private int DWaveNum = 6;//敌人的波次
    private int DFlyCount = 15;//一波敌人的数量
    private float DFlyWait = 0.5f;//一波中，单个敌人生成的时间间隔
    private float DStartWait = 180;//开始的暂停时间
    private float DWaveWait = 2f;//两批敌人之间的时间间隔

    void Start()
    {
        StartCoroutine(CreatEnemyA());
        StartCoroutine(CreatEnemyB());
        StartCoroutine(CreatEnemyC());
        StartCoroutine(CreatEnemyD());
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
    IEnumerator CreatEnemyD()
    {
        for (int num = 0; num < DWaveNum; num++)
        {
            yield return new WaitForSeconds(DStartWait);
            while (true)
            {
                for (int i = 0; i < DFlyCount; i++)
                {
                    Transform transform1 = Instantiate(EnemyC);
                    float h = Random.Range(-4.4f, 4.5f);
                    transform1.position = new Vector2(9.1f, h);
                    yield return new WaitForSeconds(DFlyWait);
                }
                yield return new WaitForSeconds(DWaveWait);
            }
        }
    }
}
