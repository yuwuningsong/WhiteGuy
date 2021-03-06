using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactMonsterSystem : MonoBehaviour
{
    public bool hasContactMonster = false;

    [Header("Contact Monster Rate")]    // 遇怪概率
    [SerializeField] float grassRate = 0f;
    [SerializeField] float soilRate = 0f;

    [Header("System Settings")]
    [SerializeField] float contactCD = 0f; // 遇怪CD
    [SerializeField] GameObject surpriseBallon = null; // 惊叹气泡

    private Rigidbody2D rb;
    private bool isSoil = false;
    private Coroutine coroutine;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        coroutine = StartCoroutine("ContactMonster");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 协程遇怪
    IEnumerator ContactMonster()
    {
        InitiateContactMonster();
        yield return new WaitForSeconds(4f);
        while (true)
        {
            yield return new WaitForSeconds(contactCD);
            float rate = Random.value;
            if (rate <= GetMonsterRate())
            {
                hasContactMonster = true;
                GetComponent<PlayerWalkController>().canMove = false;
                surpriseBallon.SetActive(true);
            }
        }
    }

    // 遇怪结束，重新初始化遇怪
    void InitiateContactMonster()
    {
        if (hasContactMonster)
        {
            hasContactMonster = false;
            GetComponent<PlayerWalkController>().canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isSoil = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isSoil = false;
        }
    }

    // 获得当前地形遇怪概率
    float GetMonsterRate()
    {
        if (isSoil) return soilRate;
        return grassRate;
    }
}
