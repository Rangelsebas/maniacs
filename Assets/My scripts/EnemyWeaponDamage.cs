using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int weaponDamge = 1;
    [SerializeField] Animator hurtAnim;
    [SerializeField] AudioSource myPlayer;

    private bool hitActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                hurtAnim.SetTrigger("Hurt");
                SaveScript.PlayerHealth -= weaponDamge;
                SaveScript.healtChange = true;
                myPlayer.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }
}
