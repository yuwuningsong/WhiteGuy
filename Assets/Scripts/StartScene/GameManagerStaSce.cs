using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStaSce : MonoBehaviour
{
    [SerializeField] GameObject village = null;
    [SerializeField] GameObject PetPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartChoosePet();
    }

    // 对话完成切换至选择灵宠场景
    void StartChoosePet()
    {
        if (DialogueManager.dialogueManager.isOver)
        {
            village.SetActive(false);
            PetPanel.SetActive(true);
        }
    }
}
