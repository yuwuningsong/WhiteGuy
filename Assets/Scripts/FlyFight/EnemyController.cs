using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreatEnemy()
    {
        while (true)
        {
            for(int i = 0; i < 3; i++)
            {
                Transform transform1 = Instantiate(Enemy);
                float h = Random.Range((float)-4.4,(float)4.5);
                transform1.position = new Vector2((float)9.1,h);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
