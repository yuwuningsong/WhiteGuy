using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPanelController : MonoBehaviour
{
    public static Pet pet;
    [SerializeField] GameObject petPanel = null;
    private bool isOpen = false;
    private PetPanelInformation info;

    // Start is called before the first frame update
    void Start()
    {
        info = petPanel.GetComponent<PetPanelInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SwitchPetPanel();
        UpdatePetInformation();
    }

    // 开启/关闭面板
    public void SwitchPetPanel()
    {
        if (isOpen == true && petPanel.activeInHierarchy == true && !info.hasChanged)
        {
            petPanel.SetActive(false);
            isOpen = false;
            return;
        }
        petPanel.SetActive(true);
        isOpen = true;
        pet = GetComponent<Pet>();
    }

    // 更新宠物面板信息
    void UpdatePetInformation()
    {
        info.UpdatePetInformation(pet.attackNum, pet.defenceNum, pet.attackType, pet.sprite);
        PetManager.petManager.SavePetInfo(pet);
    }
}
