using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public static PetManager petManager;
    private Pet pet;

    // Start is called before the first frame update
    void Awake()
    {
        petManager = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 存储宠物信息
    public void SavePetInfo(Pet pet)
    {
        this.pet = pet;
        Debug.Log(pet.sprite);
    }
}
