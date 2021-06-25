using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update in a certain time interval
    private void FixedUpdate()
    {
        Run();
    }

    // Control kid to run
    void Run()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);                          // Move

        if (horizontalInput != 0)                                                                   // Change Direction
        {
            Vector3 scale = GetComponent<Transform>().localScale;
            GetComponent<Transform>().localScale = new Vector3(horizontalInput * Mathf.Abs(scale.x), scale.y, 1);
        }
    }
}
