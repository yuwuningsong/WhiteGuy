using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPanelController : MonoBehaviour
{
    [SerializeField] GameObject petPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    // 获得点击输入
    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetMouseButtonDown");
            Vector2 mousePos2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(Vector2.zero, mousePos2D);
            if (hit.collider != null)
            {
                Debug.Log($"RaycaseHit:{hit.collider.name}");
            }
        }
    }

    public void OpenPetPanel()
    {
        petPanel.SetActive(true);
    }
}
