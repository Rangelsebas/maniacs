using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{   
    [SerializeField] PostProcessVolume myVolume;
    [SerializeField] PostProcessProfile standard;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject enemyFlashlight;

    bool nightVisionActive = false;
    bool isFlashlightActive = false;

    void Start()
    {
        nightVisionOverlay.SetActive(false);
        flashlight.SetActive(false); 
        enemyFlashlight.SetActive(false); 
    }

    void Update()
    {
        if (SaveScript.batteryPower > 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (nightVisionActive == false)
                {
                    myVolume.profile = nightVision;
                    nightVisionActive = true;
                    nightVisionOverlay.SetActive(true);
                    SaveScript.nvLightOn = true;
                }
                else
                {
                    myVolume.profile = standard;
                    nightVisionActive = false;
                    nightVisionOverlay.SetActive(false);
                    SaveScript.nvLightOn = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isFlashlightActive == false)
                {
                    isFlashlightActive = true;
                    flashlight.SetActive(true);
                    enemyFlashlight.SetActive(true); 
                    SaveScript.flashLightOn = true;
                }
                else
                {
                    isFlashlightActive = false;
                    flashlight.SetActive(false);
                    enemyFlashlight.SetActive(false); 
                    SaveScript.flashLightOn = false;
                }
            }
        }

        if (SaveScript.batteryPower <= 0.0f)
        {
            myVolume.profile = standard;
            nightVisionActive = false;
            nightVisionOverlay.SetActive(false);
            SaveScript.nvLightOn = false;  

            isFlashlightActive = false;
            flashlight.SetActive(false);
            enemyFlashlight.SetActive(false); 
            SaveScript.flashLightOn = false;        
        }
    }
}
