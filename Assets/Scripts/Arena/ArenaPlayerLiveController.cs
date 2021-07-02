using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaPlayerLiveController : MonoBehaviour
{
    public float health = 0;
    [SerializeField] float totalHealth = 0;

    private bool isDead = false;

    private bool gameover = false;
    private Animator anim;
    private GameObject refreshPoint;
    public GameObject gameOverImage = null;

    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
        anim = GetComponent<Animator>();
        refreshPoint = GameObject.Find("Castles/BaseRed");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) isDead = true;
        Dead();
        Restart();
    }

    void Dead()
    {
        if (isDead && !gameover)
        {
            //死亡处理
            anim.SetBool("isDead", true);
            gameOverImage.SetActive(true);
            gameover = true;
        }
    }

    void Restart()
    {
        if (gameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Arena");
        }
    }
}
