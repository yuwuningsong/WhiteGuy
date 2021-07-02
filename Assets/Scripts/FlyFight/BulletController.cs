using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.up * Speed * Time.deltaTime);
        DestoryBullet();
    }



    void DestoryBullet()
    {
        if (gameObject.transform.position.x < -10 || gameObject.transform.position.x >10)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        Destroy(gameObject);

    }
   
}
