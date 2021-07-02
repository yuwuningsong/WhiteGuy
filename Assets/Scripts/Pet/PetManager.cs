using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public static PetManager petManager;
    public List<Pet> pets = new List<Pet>();
    public PlayerHurtController player = null;

    [SerializeField] Pet pet = null;
    [SerializeField] Transform monster = null;
    [SerializeField] float skillCD = 0f;

    private float timeCount = 0f;
    private bool onCD = false;

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
        GetInput();
        CDCount();
    }

    // 获取技能输入
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PetAttack();
        if (Input.GetKeyDown(KeyCode.Alpha2)) PetDefend();
        //if (Input.GetKeyDown(KeyCode.Alpha3)) 
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

    // 灵宠攻击
    public void PetAttack()
    {
        if (monster == null) return;
        if (!onCD)
        {
            pet.SetTarget(monster);
            onCD = true;
        }
    }

    // 灵宠防御
    public void PetDefend()
    {
        if (!onCD)
        {
            player.isProtect = true;
            onCD = true;
        }
    }

    // 技能CD计时
    void CDCount()
    {
        if (onCD)
        {
            timeCount += Time.deltaTime;
        }

        if (timeCount >= skillCD)
        {
            onCD = false;
            timeCount = 0f;
        }
    }
}
