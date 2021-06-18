using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUIEvent : MonoBehaviour
{
    [SerializeField] PlayerWalkController player = null;
    private bool startAnim = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("startAnim", startAnim);
        GetInput();
    }

    // 获取输入
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // 按下Z播放动画
        {
            startAnim = true;
        }
    }

    void CloseStartCurtain()
    {
        gameObject.SetActive(false);
        player.canMove = true;
    }
}
