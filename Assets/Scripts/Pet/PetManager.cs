using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public static PetManager petManager;
    public List<Pet> pets = new List<Pet>();

    [SerializeField] Pet pet;

    void Awake()
    {
        petManager = this;
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        CopyPetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 同步宠物信息
    public void CopyPetInfo()
    {
        pet.attackNum = GetPet().attackNum;
        pet.defenceNum = GetPet().defenceNum;
        pet.attackType = GetPet().attackType;
        pet.sprite = GetPet().sprite;
        pet.index = GetPet().index;

        pet.gameObject.GetComponent<SpriteRenderer>().sprite = pet.sprite;
    }

    // 存储宠物信息
    public void SavePetInfo(Pet pet)
    {
        Debug.Log("save pet!");
        PlayerPrefs.SetInt("Pet", pet.index);
    }

    // 获取宠物信息
    public Pet GetPet()
    {
        return pets[PlayerPrefs.GetInt("Pet")];
    }
}
