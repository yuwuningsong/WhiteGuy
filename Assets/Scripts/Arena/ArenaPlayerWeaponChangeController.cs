using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayerWeaponChangeController : MonoBehaviour
{
    public Transform sword = null;
    public Transform bow = null;
    public Transform wand = null;
    public Transform shield = null;

    // Start is called before the first frame update
    void Start()
    {
        setAllNotActive();
        sword.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setAllNotActive()
    {
        sword.gameObject.SetActive(false);
        bow.gameObject.SetActive(false);
        wand.gameObject.SetActive(false);
        shield.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftWeapon"))
        {
            if (Input.GetButtonDown("E"))
            {
                //换武器
                int type = collision.gameObject.GetComponentInParent<ArenaLeftWeaponController>().weaponType;
                setAllNotActive();
                switch (type)
                {
                    case 1:
                        sword.gameObject.SetActive(true);
                        break;
                    case 2:
                        bow.gameObject.SetActive(true);
                        break;
                    case 3:
                        shield.gameObject.SetActive(true);
                        break;
                    case 4:
                        wand.gameObject.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
