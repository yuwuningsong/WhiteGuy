using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourBackgroundController : MonoBehaviour
{
    public static float speed = 10f;      //背景移动速度
    //[SerializeField] bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        //遍历背景，子物体
        foreach (Transform tran in transform)
        {
            //如果血量为0
            //if (ParkourPlayerController.Hp == 0)
            //{
            //    //return;
            //    //isDead = true;
            //    //bool GetIsDead() => isDead;
            //}

            //获取子物体的位置
            Vector3 pos = tran.position;

            //按照速度向左侧移动
            pos.x -= speed * Time.deltaTime;
            //判断是否出了屏幕
            //if (pos.x < -322f)
            //{
            //    //把图片移动到右边
            //    pos.x += 322f * 2;
            //}
            //位置赋给子物体
            tran.position = pos;
        }
    }

    //public bool GetIsDead() => isDead;
}
