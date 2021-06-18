using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetPanelInformation : MonoBehaviour
{
    public bool hasChanged = false;
    [SerializeField] Text attackNum = null;
    [SerializeField] Text defenceNum = null;
    [SerializeField] Text attackType = null;
    [SerializeField] Image image = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 更新宠物面板信息
    public void UpdatePetInformation(int attackNum, int defenceNum, string attackType, Sprite sprite)
    {
        if (this.image.sprite != sprite)
        {
            hasChanged = true;
        }
        else
        {
            hasChanged = false;
        }

        this.attackNum.text = attackNum.ToString();
        this.defenceNum.text = defenceNum.ToString();
        this.attackType.text = attackType;
        this.image.sprite = sprite;
    }
}
