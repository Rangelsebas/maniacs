using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    void Start()
    {
        healthText.text = SaveScript.PlayerHealth + "%";
    }

    void Update()
    {
        if (SaveScript.healtChange == true)
        {
            SaveScript.healtChange = false;
            healthText.text = SaveScript.PlayerHealth + "%";
        }
    }
}
