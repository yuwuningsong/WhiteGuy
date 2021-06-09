using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool isTalking = false;

    [Header("Character")]
    [SerializeField] GameObject NPC = null;
    [SerializeField] PlayerWalkController player = null;

    [Header("DialogueUI")]
    [SerializeField] GameObject textBox = null;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenTextBox();
        CloseTextBox();
    }

    // 判断是否面对NPC并且在Talk范围内
    bool FaceNPC()
    {
        if (!NPC.GetComponent<NPCTalkController>().canTalk) return false; // 不在Talk范围内

        Vector3 distance = NPC.transform.position - player.transform.position; // 主角指向NPC的向量
        //Debug.Log($"distance:{distance}");
        Vector3 direction = player.lookDirection; // 主角朝向
        //Debug.Log($"direction:{direction}");
        float angle = Vector3.Angle(direction, distance);
        //Debug.Log($"Angle: {angle}");
        if (angle < 90) return true;
        return false;
    }

    // 按下Z键弹出对话框
    void OpenTextBox()
    {
        if (FaceNPC() && Input.GetKeyDown(KeyCode.Z))
        {
            textBox.SetActive(true);
            isTalking = true;
            player.canMove = false;
        }
    }

    // 按下Esc关闭对话框
    void CloseTextBox()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Escape))
        {
            textBox.SetActive(false);
            isTalking = false;
            player.canMove = true;
        }
    }
}
