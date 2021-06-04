using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkController : MonoBehaviour
{
    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }

    [SerializeField] int walkSpeed = 0;
    [SerializeField] Sprite up = null;
    [SerializeField] Sprite down = null;
    [SerializeField] Sprite left = null;
    [SerializeField] Sprite right = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TO DO: 碰撞闪烁
        // TO DO: 地图素材层级
        WalkX();
        WalkY();
    }

    // WASD移动
    void WalkX()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        if (HorizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().sprite = left;
            transform.position -= new Vector3(walkSpeed * Time.deltaTime, 0, 0); // 左转
        }
        else if (HorizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().sprite = right;
            transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0); // 右转
        }
    }
    void WalkY()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        if (VerticalInput < 0)
        {
            GetComponent<SpriteRenderer>().sprite = down;
            transform.position -= new Vector3(0, walkSpeed * Time.deltaTime, 0); // 向下走
        }
        else if (VerticalInput > 0)
        {
            GetComponent<SpriteRenderer>().sprite = up;
            transform.position += new Vector3(0, walkSpeed * Time.deltaTime, 0); // 向上走
        }
    }
}
