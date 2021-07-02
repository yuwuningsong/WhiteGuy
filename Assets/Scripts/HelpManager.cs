using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public static HelpManager helpManager;
    public GameObject player = null;
    public bool isHelpingJump = false;
    public int moveCount = 0;
    public float helpDistance = 2;
    //计时恢复
    public float timer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        helpManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            SetHelpingJumpTrue();
        }
        HelpJump();
        Recover();
    }

    public void SetHelpingJumpTrue()
    {
        isHelpingJump = true;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    public void HelpJump()
    {
        //不在帮助状态
        if (!isHelpingJump)
            return;

        //在帮助状态
        //已经位移过
        if (moveCount >= 1)
            return;        
        Vector3 position = this.transform.position;        
        if (player.transform.localScale.x>=0)
        {
            //方向向右
            moveCount++;
            transform.position = new Vector3(position.x + helpDistance, position.y, position.z);
        }
        else
        {
            //方向向左
            moveCount++;
            transform.position = new Vector3(position.x - 1f, position.y, position.z);
        }
    }

    public void FreePet()
    {
        isHelpingJump = false;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    //限时恢复
    public void Recover()
    {
        //不在帮助状态
        if (!isHelpingJump)
            return;
        //在帮助状态
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            FreePet();
            moveCount = 0;
            timer = 3.0f;
        }
    }
}
