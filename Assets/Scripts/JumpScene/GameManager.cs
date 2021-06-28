using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject gameOverImage = null;
    [SerializeField] bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Dead();
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
            return;

        SceneManager.LoadScene("HorizontalJump");
        Debug.Log("ReStart!");
    }

}
