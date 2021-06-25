using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightController : MonoBehaviour
{
    [SerializeField] GameObject sword = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    // 获得输入
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.F)) // 按下F攻击
        {
            Fight();
        }
    }

    // 攻击
    void Fight()
    {
        sword.SetActive(true);
    }
}
