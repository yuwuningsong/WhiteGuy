using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonsters : MonoBehaviour
{
    public Transform producePosition = null;
    public GameObject MonsterPrefab = null;
    public int MonsterNum = 10;
    public int MonsterSpeed = 2;
    public int count = 0;
    private bool CheckPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProduceMonster();
    }

    public void ProduceMonster()
    {
        if(CheckPlayer && count <= MonsterNum)
        {
            count++;
            GameObject monster = Instantiate(MonsterPrefab, producePosition);
            monster.GetComponent<RunRightController>().wayPoints[0].transform.position = GameObject.Find("FinalPoint0-1").transform.position;
            monster.GetComponent<RunRightController>().wayPoints[1].transform.position = GameObject.Find("FinalPoint0-2").transform.position;            
        }
    }

    public void SetCheckPlayerTrue()
    {
        CheckPlayer = true;
    }
}
