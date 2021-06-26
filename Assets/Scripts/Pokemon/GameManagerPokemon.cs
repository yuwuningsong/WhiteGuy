using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPokemon : MonoBehaviour
{
    public static GameManagerPokemon gameManager;

    [SerializeField] GameObject map = null;
    [SerializeField] GameObject fightScene = null;
    [SerializeField] GameObject fsCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFightScene()
    {
        fsCamera.SetActive(true);
        map.SetActive(false);
        fightScene.SetActive(true);
    }
}
