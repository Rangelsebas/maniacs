using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image batteryUI;
    [SerializeField] float drainTime = 180.0f;
    [SerializeField] float power;

    void Update()
    {
        if (SaveScript.batteryRefill == true)
        {
            SaveScript.batteryRefill = false;
            batteryUI.fillAmount = 1.0f;
        }
        if (SaveScript.flashLightOn == true || SaveScript.nvLightOn == true)
        {
            batteryUI.fillAmount -= 1.0f / drainTime * Time.deltaTime;
            power = batteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }
    }
}
