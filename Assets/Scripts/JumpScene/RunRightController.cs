using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRightController : MonoBehaviour
{
    private Transform son;
    public bool moveToLeft = true;
    private float speed = 2;
    public List<GameObject> wayPoints = new List<GameObject>(2);
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
        if (son.position.x <= wayPoints[0].transform.position.x && moveToLeft)
        {
            moveToLeft = false;
            Vector3 scale = this.GetComponent<Transform>().localScale;
            this.GetComponent<Transform>().localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, 1);
        }
        else if (son.position.x >= wayPoints[1].transform.position.x && !moveToLeft)
        {
            moveToLeft = true;
            Vector3 scale = this.GetComponent<Transform>().localScale;
            this.GetComponent<Transform>().localScale = new Vector3(Mathf.Abs(scale.x), scale.y, 1);
        }

        son.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;
    }
}
