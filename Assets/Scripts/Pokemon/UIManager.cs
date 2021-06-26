using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerHurtController player = null;
    [SerializeField] MonsterLiveController monster = null;

    [Header("UI Component")]
    [SerializeField] Slider slider = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthSliderChange();
    }

    // 血条数据同步
    void HealthSliderChange()
    {
        float num = ((float)player.health) / monster.health;
        slider.value = num;
    }
}
