using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPokemon : MonoBehaviour
{
    public static GameManagerPokemon gameManager;
    public bool isWin = false;

    [SerializeField] GameObject map = null;
    [SerializeField] GameObject fightScene = null;
    [SerializeField] GameObject fsCamera = null;
    [SerializeField] GameObject winPanel = null;

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
    }

    public void OpenFightScene()
    {
        Debug.Log("Open Fight Scene!");
        newFightScene = Instantiate(fightScene);
        newFsCamera = Instantiate(fsCamera);

        map.SetActive(false);
    }

    void CloseFightScene()
    {
        Destroy(newFsCamera);
        map.SetActive(true);
        Destroy(newFightScene);
        //刘心雨-测试
        //SceneManager.LoadScene(3);
    }

    void Win()
    {
        if (isWin)
        {
            newWinPanel = Instantiate(winPanel);
            isWin = false;
            CloseFightScene();
        }
    }
}
