using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    public static FollowManager followManager;
    public Rigidbody2D player;
    public GameObject pet;
    //宠物跟随的目标
    public Transform target;
    //宠物跟随的偏移量
    public Vector3 offset;

    // Start is called before the first frame update
    private void Awake()
    {
        if (followManager != null)
        {
            Destroy(this);
            return;
        }
        followManager = this;
        pet.SetActive(false);
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (PetManager.petManager.GetPet() == null)
            return;
        pet.GetComponent<PetManager>().CopyPetInfo();
        pet.SetActive(true);

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //宠物跟随的偏移量
        offset = target.forward * (-0.8f) + target.up * 0.8f;
        //改变宠物的位置，让宠物移动
        pet.transform.position = Vector3.Lerp(pet.transform.position, target.position + offset, Time.deltaTime * 2);
        //宠物方向
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        // Change Direction
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
