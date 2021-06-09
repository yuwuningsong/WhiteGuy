using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkController : MonoBehaviour
{
    [SerializeField] GameObject pressTip; // 按下Z的提示
    public bool canTalk = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressTip.SetActive(true);
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressTip.SetActive(false);
            canTalk = false;
        }
    }
}
