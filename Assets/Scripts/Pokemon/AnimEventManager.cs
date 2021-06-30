using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 打开战斗界面
    void OpenFightScene()
    {
        gameObject.SetActive(false);
        GameManagerPokemon.gameManager.OpenFightScene();
    }

    // 销毁物体
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // 关闭物体
    void Unseen()
    {
        gameObject.SetActive(false);
    }

    void LoadNextScene()
    {
        GameManagerStaSce.gameManager.LoadNextScene();
    }
}
