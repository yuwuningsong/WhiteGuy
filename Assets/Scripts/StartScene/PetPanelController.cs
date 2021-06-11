using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPanelController : MonoBehaviour
{
    [SerializeField] GameObject petPanel = null;
    private bool isOpen = false;
    private Pet pet;
    private PetPanelInformation info;

    // Start is called before the first frame update
    void Start()
    {
        pet = GetComponent<Pet>();
        info = petPanel.GetComponent<PetPanelInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        UpdatePetInformation();
        SwitchPetPanel();
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
    }

    // 更新宠物面板信息
    void UpdatePetInformation()
    {
        info.UpdatePetInformation(pet.attackNum, pet.defenceNum, pet.attackType, pet.sprite);
    }
}
