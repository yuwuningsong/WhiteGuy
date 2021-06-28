using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyMoveController : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    private Rigidbody2D rb;

    [Header("Player Follow")]
    [SerializeField] Transform playerFollow = null;

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

    void Run()
    {
        float x = playerFollow.position.x - rb.transform.position.x;
        float horizontalInput = 0;
        if (x > 0) horizontalInput = 1;
        if (x < 0) horizontalInput = -1;

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);                          // Move

        if (horizontalInput != 0)                                                                   // Change Direction
        {
            Vector3 scale = GetComponent<Transform>().localScale;
            GetComponent<Transform>().localScale = new Vector3(horizontalInput * Mathf.Abs(scale.x), scale.y, 1);
        }
    }
}
