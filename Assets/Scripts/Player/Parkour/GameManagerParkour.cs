using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerParkour : MonoBehaviour
{
    [SerializeField] GameObject NPC = null;
    [SerializeField] GameObject anim = null;

    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ParkourEnvironmentController.speed = 0f;
            SceneManager.LoadScene(4);
            //anim.SetActive(true);
        }
    }
}
