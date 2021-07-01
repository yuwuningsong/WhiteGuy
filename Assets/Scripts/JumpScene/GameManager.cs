using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject gameOverImage = null;
    [SerializeField] bool gameover = false;
    [SerializeField] GameObject[] Levels = new GameObject[4];
    public bool[] finishs = new bool[4];
    public int levelCurrent;

    private void Awake()
    {
        gameManager = this;
        levelCurrent = 0;
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
            finishs[i] = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        levelCurrent = PlayerPrefs.GetInt("levelCurrent");
        Levels[levelCurrent].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        Finish();
        ReStart();
    }

    void Dead()
    {
        if (gameover || !player.GetComponent<HurtController>().GetIsDead())
            return;
        player.SetActive(false);
        gameOverImage.SetActive(true);
        gameover = true;
    }

    void ReStart()
    {
        if (!gameover || !Input.GetKeyDown(KeyCode.R))
        {
            //从第一关开始
            //PlayerPrefs.SetInt("levelCurrent", 0);
            return;
        }
            

        SceneManager.LoadScene("HorizontalJump");
        Debug.Log("ReStart!");
    }

    void Finish()
    {
        if (finishs[levelCurrent] || !player.GetComponent<FinishController>().isFinish)
            return;
        finishs[levelCurrent] = true;
        Levels[levelCurrent].SetActive(false);
        Levels[levelCurrent + 1].SetActive(true);
        levelCurrent++;
        PlayerPrefs.SetInt("levelCurrent", levelCurrent);
        player.GetComponent<FinishController>().isFinish = false;
    }

}
