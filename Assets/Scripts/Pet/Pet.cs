using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public int attackNum; // 攻击力
    public int defenceNum; // 防御力
    public string attackType; // 攻击方式
    public Sprite sprite;
    public int index; // 序号
    public bool isAttack = false;
    public bool moveToTarget = false;

    [SerializeField] float speed = 0f;
    [SerializeField] float attackSpeed = 0f;

    private Vector3 direction;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveToTarget) MoveToTarget();
        if (isAttack) Attack();
    }

    // 设置攻击目标
    public void SetTarget(Transform monster)
    {
        if (!moveToTarget)
        {
            moveToTarget = true;
            target = monster.position - new Vector3(3, 0, 0);
            direction = (target - gameObject.transform.position).normalized;
            Debug.Log(target);
            Debug.Log(direction);
        }
    }

    // 移动至怪物
    void MoveToTarget()
    {
        gameObject.transform.Translate(direction * Time.deltaTime * speed);
        if (gameObject.transform.position.x >= target.x)
        {
            isAttack = true;
            moveToTarget = false;
        }
    }

    // 攻击
    void Attack()
    {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * attackSpeed);
        if (gameObject.transform.position.x >= target.x + 1.5f)
        {
            attackSpeed = -attackSpeed;
        }
        if (gameObject.transform.position.x <= target.x)
        {
            isAttack = false;
            attackSpeed = -attackSpeed;
        }
    }
}
