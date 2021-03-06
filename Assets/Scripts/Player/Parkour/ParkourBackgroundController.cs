using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourBackgroundController : MonoBehaviour
{
    [SerializeField] public static float speed = 10f;      //背景移动速度

    // Update is called once per frame
    void Update()
    {
        //遍历背景，子物体
        foreach (Transform tran in transform)
        {
            //获取子物体的位置
            Vector3 pos = tran.position;

            //按照速度向左侧移动
            pos.x -= speed * Time.deltaTime;

            //位置赋给子物体
            tran.position = pos;
        }
    }
}
