using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPanelController : MonoBehaviour
{
    [SerializeField] GameObject petPanel = null;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SwitchPetPanel();
    }

    public void SwitchPetPanel()
    {
        if (isOpen == true && petPanel.activeInHierarchy == true)
        {
            petPanel.SetActive(false);
            isOpen = false;
            return;
        }
        petPanel.SetActive(true);
        isOpen = true;
    }
}
