using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackController : MonoBehaviour
{
    public int attack = 0; // 攻击力
    public int defense = 0;

    [SerializeField] GameObject effect = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BeginEffect();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            BeginEffect();
        }
    }

    void BeginEffect()
    {
        GameObject newEffect = Instantiate(effect, transform.position, new Quaternion());
        if (transform.parent.localScale.x < 0) newEffect.transform.localScale = new Vector3(-1, 1, 1);
        Debug.Log(transform.parent.localScale.x);
    }
}
