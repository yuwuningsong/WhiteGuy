using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0RunController : MonoBehaviour
{
    private Transform son;
    public bool moveToLeft = true;
    private float speed = 2;

    private void Start()
    {
        son = this.transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (son.position.x <= -3 && moveToLeft)
        {
            moveToLeft = false;
            Vector3 scale = this.GetComponent<Transform>().localScale;
            this.GetComponent<Transform>().localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, 1);
        }
        else if (son.position.x >= 1 && !moveToLeft)
        {
            moveToLeft = true;
            Vector3 scale = this.GetComponent<Transform>().localScale;
            this.GetComponent<Transform>().localScale = new Vector3(Mathf.Abs(scale.x), scale.y, 1);
        }
            
        son.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;
    }
}
