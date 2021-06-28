using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    public static FollowManager followManager;
    public Rigidbody2D player;
    public GameObject petPrefab;
    public GameObject pet;
    //宠物跟随的目标
    public Transform target;
    //宠物跟随的偏移量
    public Vector3 offset;

    // Start is called before the first frame update
    private void Awake()
    {
        followManager = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        pet = Instantiate(petPrefab);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //宠物跟随的偏移量
        offset = target.forward * (-1f) + target.up * 1f;
        //改变宠物的位置，让宠物移动
        pet.transform.position = Vector3.Lerp(pet.transform.position, target.position + offset, Time.deltaTime);
        //宠物方向
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)                                                                   // Change Direction
        {
            Vector3 scale = pet.GetComponent<Transform>().localScale;
            pet.GetComponent<Transform>().localScale = new Vector3(horizontalInput * Mathf.Abs(scale.x), scale.y, 1);
        }
    }
    private void Update()
    {
        //宠物跟随的目标
        target = player.transform;        
    }
}
