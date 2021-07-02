using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPokemon : MonoBehaviour
{
    public static GameManagerPokemon gameManager;
    public bool isWin = false;
    public bool isLose = false;

    [SerializeField] GameObject map = null;
    [SerializeField] GameObject fightScene = null;
    [SerializeField] GameObject fsCamera = null;
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject petManager = null;
    [SerializeField] GameObject followManager = null;
    [SerializeField] GameObject anim = null;

    private GameObject newFightScene;
    private GameObject newFsCamera;
    private GameObject newWinPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        Win();
        Lose();
    }

    public void OpenFightScene()
    {
        Debug.Log("Open Fight Scene!");
        newFightScene = Instantiate(fightScene);
        newFsCamera = Instantiate(fsCamera);
        petManager.SetActive(false);
        followManager.SetActive(false);
        map.SetActive(false);
    }

    public void CloseFightScene()
    {
        Destroy(newFsCamera);
        map.SetActive(true);
        petManager.SetActive(true);
        followManager.SetActive(true);
        Destroy(newFightScene);
        //刘心雨-测试
        //SceneManager.LoadScene(3);
    }

    void Win()
    {
        if (isWin)
        {
            winPanel.SetActive(true);
            isWin = false;
            CloseFightScene();
        }
    }

    void Lose()
    {
        if (isLose)
        {
            losePanel.SetActive(true);
        }
    }

    public void GotoNextScene()
    {
        anim.SetActive(true);
    }
}
