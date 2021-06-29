using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPokemon : MonoBehaviour
{
    public static GameManagerPokemon gameManager;
    public bool isWin = false;

    [SerializeField] GameObject map = null;
    [SerializeField] GameObject fightScene = null;
    [SerializeField] GameObject fsCamera = null;
    [SerializeField] GameObject winPanel = null;

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
        fsCamera.SetActive(true);
        map.SetActive(false);
        fightScene.SetActive(true);
    }

    void CloseFightScene()
    {
        fsCamera.SetActive(false);
        map.SetActive(true);
        fightScene.SetActive(false);
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
}
