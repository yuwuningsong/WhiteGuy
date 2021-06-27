using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillController : MonoBehaviour
{
    [SerializeField] Transform skillOne = null;
    [SerializeField] GameObject stone = null;
    [SerializeField] float fallingCD = 0f;
    [SerializeField] int stoneNum = 0;

    private List<Action> skills = new List<Action>();

    // Start is called before the first frame update
    void Start()
    {
        skills.Add(SkillOne);
        StartSkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 使用技能
    void StartSkill()
    {
        skills[0].Invoke();
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
        while (index < stoneNum)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-10, 7), 7.3f, 0);
            Instantiate(stone, position, new Quaternion(), skillOne);
            index++;
            yield return new WaitForSeconds(fallingCD);
        }
    }
}
