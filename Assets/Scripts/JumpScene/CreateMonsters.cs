using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonsters : MonoBehaviour
{
    public Transform producePosition = null;
    public GameObject MonsterPrefab = null;
    public int MonsterNum = 6;
    public int MonsterSpeed = 4;
    public float timerSource = 0;
    public float timer = 0.5f;
    public int count = 0;
    private bool CheckPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        timerSource = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer >= 0)
            return;
        ProduceMonster();
        timer = timerSource;
    }

    public void ProduceMonster()
    {
        if (CheckPlayer && count < MonsterNum)
        {
            count++;
            GameObject monster = Instantiate(MonsterPrefab, producePosition.transform.position, Quaternion.identity, this.transform);
            monster.GetComponent<RunRightController>().wayPoints[0] = GameObject.Find("FinalPoint0-1");
            monster.GetComponent<RunRightController>().wayPoints[1] = GameObject.Find("FinalPoint0-2");
        }
    }

    public void SetCheckPlayerTrue()
    {
        CheckPlayer = true;
    }
}
