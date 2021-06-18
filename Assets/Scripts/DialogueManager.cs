using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool isTalking = false;
    public bool isOver = false;
    public static DialogueManager dialogueManager;

    [Header("Character")]
    [SerializeField] GameObject NPC = null;
    [SerializeField] PlayerWalkController player = null;

    [Header("DialogueUI")]
    [SerializeField] GameObject textBox = null;
    [SerializeField] Text text = null;

    [Header("TextFile")]
    [SerializeField] TextAsset textFile = null;

    private int index = 0;
    private List<string> textLines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = this;
        GetTextFromFile(textFile);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OpenTextBox();
        ToNextWord();
        SkipDialogue();
    }

    // 导入文本文件
    void GetTextFromFile(TextAsset textFile)
    {
        textLines.Clear(); // 清空
        var lines = textFile.text.Split('\n');
        foreach(var line in lines)
        {
            Debug.Log($"Line:{line.Replace("：", "：\n")}");
            textLines.Add(line.Replace("：", "：\n"));
        }
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
        if (!isOver && !isTalking && FaceNPC() && Input.GetKeyDown(KeyCode.Z))
        {
            textBox.SetActive(true);
            isTalking = true;
            player.canMove = false;
        }
    }

    // 按下Esc关闭对话框
    void SkipDialogue()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseTextBox();
        }
    }

    // 按下Z跳到下一句对话
    void ToNextWord()
    {
        if (Input.GetKeyDown(KeyCode.Z) && IsOver())
        {
            CloseTextBox();
        }
        if (isTalking && Input.GetKeyDown(KeyCode.Z))
        {
            text.text = textLines[index];
            index++;
        }
    }

    // 判断对话是否结束
    bool IsOver()
    {
        if (isTalking && index >= textLines.Count) return true;
        return false;
    }

    // 关闭对话框
    void CloseTextBox()
    {
        textBox.SetActive(false);
        isTalking = false;
        player.canMove = true;
        index = 0;
        isOver = true;
    }
}
