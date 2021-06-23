using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkController : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 lookDirection;
    public bool canMove = true;

    [SerializeField] int walkSpeed = 0;

    private Rigidbody2D rb;
    private Vector2 currentInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            GetInput();
        }
        else
        {
            currentInput = Vector2.zero;
            velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        Walk();
    }

    // 移动输入检测
    void GetInput()
    {
        // 输入检测
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        velocity = movement;

        if (!(Mathf.Approximately(movement.x, 0.0f) && (Mathf.Approximately(movement.y, 0.0f))))    // 当主角移动时
        {
            lookDirection.Set(movement.x, movement.y);
            lookDirection.Normalize();
        }

        currentInput = movement;
    }

    // WASD移动
    void Walk()
    {
        Vector2 position = rb.position;
        position += currentInput * walkSpeed * Time.deltaTime;
        rb.MovePosition(position);
    }
}
