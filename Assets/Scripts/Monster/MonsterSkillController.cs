using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillController : MonoBehaviour
{
    [SerializeField] int index = 0;
    [SerializeField] float skillCD = 0f;
    [SerializeField] GameObject warning = null;

    [Header("Skill One")]
    [SerializeField] Transform skillOne = null;
    [SerializeField] GameObject stone = null;
    [SerializeField] float fallingCD = 0f;
    [SerializeField] int stoneNum = 0;

    [Header("Skill Two")]


    private List<Action> skills = new List<Action>();
    private bool isEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        skills.Add(SkillOne);
        BeginAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 技能协程
    void BeginAttack()
    {
        StartCoroutine("StartSkill");
    }

    // 使用技能
    IEnumerator StartSkill()
    {
        yield return new WaitForSeconds(3f);
        while (!GetComponent<MonsterLiveController>().isDead)
        {
            if (isEnd)
            {
                Debug.Log("Skill Begin!");
                warning.SetActive(true);
                skills[index].Invoke();
                isEnd = false;
            }
            yield return new WaitForSeconds(skillCD);
        }
    }

    // 技能1
    void SkillOne()
    {
        StartCoroutine("FallingStones");
    }

    // 技能1 落石生成子弹
    IEnumerator FallingStones()
    {
        int index = 0;
        while (index < stoneNum && !GetComponent<MonsterLiveController>().isDead)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-10, 7), 7.3f, 0);
            GameObject newStone = Instantiate(stone, position, new Quaternion(), skillOne);
            newStone.GetComponent<Bullet>().monster = GetComponent<MonsterLiveController>();
            index++;
            yield return new WaitForSeconds(fallingCD);
        }
        isEnd = true;
    }
}
