using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCastleOpenController : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndOpen()
    {
        anim.SetBool("isOpen", false);
        Debug.Log(anim.GetBool("isOpen"));
    }
}
