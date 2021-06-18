using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStaSce : MonoBehaviour
{
    public GameObject village = null;
    public GameObject PetPanel = null;
    public bool hasChoose = false;
    public static GameManagerStaSce gameManager;

    [SerializeField] GameObject wall = null;
    [SerializeField] GameObject door = null;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        StartChoosePet();
        LeaveScene();
    }

    // 对话完成切换至选择灵宠场景
    void StartChoosePet()
    {
        if (!hasChoose && DialogueManager.dialogueManager.isOver)
        {
            village.SetActive(false);
            PetPanel.SetActive(true);
            DialogueManager.dialogueManager.isOver = false;
        }
    }

    // 选择灵宠完成
    public void FinishChoosePet()
    {
        village.SetActive(true);
        PetPanel.SetActive(false);
        hasChoose = true;
        DialogueManager.dialogueManager.InitializeText();
    }

    // 判断该场景剧情结束
    void LeaveScene()
    {
        if (hasChoose && DialogueManager.dialogueManager.isOver)
        {
            wall.SetActive(false);
            door.SetActive(true);
        }
    }
}
