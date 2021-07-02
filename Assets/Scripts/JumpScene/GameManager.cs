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
    [SerializeField] GameObject[] CameraPositons = new GameObject[4];
    [SerializeField] GameObject[] StartPositons = new GameObject[4];
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
        GameObject.Find("Main Camera").transform.position = CameraPositons[levelCurrent].transform.position;
        Levels[levelCurrent].SetActive(true);
        Vector3 positonStart = StartPositons[levelCurrent].transform.position;
        player.transform.position = new Vector3(positonStart.x, positonStart.y, player.transform.position.z);

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
            PlayerPrefs.SetInt("levelCurrent", 0);
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
        //更新相机和主角位置
        GameObject.Find("Main Camera").transform.position = CameraPositons[levelCurrent].transform.position;
        Vector3 positonStart = StartPositons[levelCurrent].transform.position;
        player.transform.position = new Vector3(positonStart.x, positonStart.y, player.transform.position.z);

        PlayerPrefs.SetInt("levelCurrent", levelCurrent);
        player.GetComponent<FinishController>().isFinish = false;
    }

}
