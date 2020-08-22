using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;

    //audioclip
    [SerializeField] AudioClip appleBite;
    [SerializeField] AudioClip batteryChange;
    [SerializeField] AudioClip weaponChange;
    [SerializeField] AudioClip gunShoot;
    [SerializeField] AudioClip arrowShoot;

    //apples
    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject appleButton1;
    [SerializeField] GameObject appleImage2;
    [SerializeField] GameObject appleButton2;
    [SerializeField] GameObject appleImage3;
    [SerializeField] GameObject appleButton3;
    [SerializeField] GameObject appleImage4;
    [SerializeField] GameObject appleButton4;
    [SerializeField] GameObject appleImage5;
    [SerializeField] GameObject appleButton5;
    [SerializeField] GameObject appleImage6;
    [SerializeField] GameObject appleButton6;

    //batteries
    [SerializeField] GameObject batteryImage1;
    [SerializeField] GameObject batteryButton1;
    [SerializeField] GameObject batteryImage2;
    [SerializeField] GameObject batteryButton2;
    [SerializeField] GameObject batteryImage3;
    [SerializeField] GameObject batteryButton3 ;
    [SerializeField] GameObject batteryImage4;
    [SerializeField] GameObject batteryButton4;

    //weapons
    [SerializeField] GameObject knifeImage;
    [SerializeField] GameObject knifeButton;
    [SerializeField] GameObject batImage;
    [SerializeField] GameObject batButton;
    [SerializeField] GameObject axeImage;
    [SerializeField] GameObject axeButton;
    [SerializeField] GameObject gunImage;
    [SerializeField] GameObject gunButton;
    [SerializeField] GameObject crossbowImage;
    [SerializeField] GameObject crossbowButton;

    //keys
    [SerializeField] GameObject CabinKeyImage;
    [SerializeField] GameObject HouseKeyImage;
    [SerializeField] GameObject RoomKeyImage;

    //ammo
    //arrows
    [SerializeField] GameObject arrowImage1;
    [SerializeField] GameObject arrowButton1;
    //gun ammo
    [SerializeField] GameObject gunAmmoImage1;
    [SerializeField] GameObject gunAmmoButton1;
    [SerializeField] GameObject gunAmmoImage2;
    [SerializeField] GameObject gunAmmoButton2;
    [SerializeField] GameObject gunAmmoImage3;
    [SerializeField] GameObject gunAmmoButton3;
    [SerializeField] GameObject gunAmmoImage4;
    [SerializeField] GameObject gunAmmoButton4;
    
    //player arms
    //melee
    [SerializeField] GameObject playerArms;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject axe;
    //guns
    [SerializeField] GameObject gun;
    [SerializeField] GameObject crossbow;

    //audiosource
    private AudioSource myPlayer;

    bool isInventroyOn = false;

    [SerializeField] Animator anim;

    void Start()
    {   
        myPlayer = GetComponent<AudioSource>();

        inventoryMenu.SetActive(false);
        isInventroyOn = false;
        Cursor.visible = false;

        //apples
        //1
        appleImage1.SetActive(false);
        appleButton1.SetActive(false);

        //2
        appleImage2.SetActive(false);
        appleButton2.SetActive(false);

        //3
        appleImage3.SetActive(false);
        appleButton3.SetActive(false);

        //4
        appleImage4.SetActive(false);
        appleButton4.SetActive(false);

        //5
        appleImage5.SetActive(false);
        appleButton5.SetActive(false);

        //6
        appleImage6.SetActive(false);
        appleButton6.SetActive(false);


        //batteries
        //1
        batteryImage1.SetActive(false);
        batteryButton1.SetActive(false);

        //2
        batteryImage2.SetActive(false);
        batteryButton2.SetActive(false);

        //3
        batteryImage3.SetActive(false);
        batteryButton3.SetActive(false);

        //4
        batteryImage4.SetActive(false);
        batteryButton4.SetActive(false);


        //weapons
        //knife
        knifeImage.SetActive(false);
        knifeButton.SetActive(false);

        //bat
        batImage.SetActive(false);
        batButton.SetActive(false);

        //axe
        axeImage.SetActive(false);
        axeButton.SetActive(false);

        //gun
        gunImage.SetActive(false);
        gunButton.SetActive(false);

        //crossbow
        crossbowImage.SetActive(false);
        crossbowButton.SetActive(false);


        //keys
        //cabin key
        CabinKeyImage.SetActive(false);

        //house key
        HouseKeyImage.SetActive(false);

        //room key
        RoomKeyImage.SetActive(false);


        //ammo
        //arrows
        arrowImage1.SetActive(false);
        arrowButton1.SetActive(false);

        //gun
        gunAmmoImage1.SetActive(false);
        gunAmmoButton1.SetActive(false);

        gunAmmoImage2.SetActive(false);
        gunAmmoButton2.SetActive(false);

        gunAmmoImage3.SetActive(false);
        gunAmmoButton3.SetActive(false);

        gunAmmoImage4.SetActive(false);
        gunAmmoButton4.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isInventroyOn == false)
            {
                inventoryMenu.SetActive(true);
                isInventroyOn = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else
            {
                inventoryMenu.SetActive(false);
                isInventroyOn = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }

        CheckInventory();
        CheckWeapon();
        CheckKeys();
        CheckAmmo();
    }

    private void CheckAmmo()
    {
        //gun ammo
        //can take 0 slots
        if (SaveScript.gunAmmo == 0)
        {
            gunAmmoImage1.SetActive(false);
            gunAmmoButton1.SetActive(false);

            gunAmmoImage2.SetActive(false);
            gunAmmoButton2.SetActive(false);

            gunAmmoImage3.SetActive(false);
            gunAmmoButton3.SetActive(false);

            gunAmmoImage4.SetActive(false);
            gunAmmoButton4.SetActive(false);
        }

        //can take 1 slot
        if (SaveScript.gunAmmo == 1)
        {
            gunAmmoImage1.SetActive(true);
            gunAmmoButton1.SetActive(true);

            gunAmmoImage2.SetActive(false);
            gunAmmoButton2.SetActive(false);

            gunAmmoImage3.SetActive(false);
            gunAmmoButton3.SetActive(false);

            gunAmmoImage4.SetActive(false);
            gunAmmoButton4.SetActive(false);
        }

        //can take 2 slot
        if (SaveScript.gunAmmo == 2)
        {
            gunAmmoImage1.SetActive(true);
            gunAmmoButton1.SetActive(false);

            gunAmmoImage2.SetActive(true);
            gunAmmoButton2.SetActive(true);

            gunAmmoImage3.SetActive(false);
            gunAmmoButton3.SetActive(false);

            gunAmmoImage4.SetActive(false);
            gunAmmoButton4.SetActive(false);
        }
        
        //can take 3 slot
        if (SaveScript.gunAmmo == 3)
        {
            gunAmmoImage1.SetActive(true);
            gunAmmoButton1.SetActive(false);

            gunAmmoImage2.SetActive(true);
            gunAmmoButton2.SetActive(false);

            gunAmmoImage3.SetActive(true);
            gunAmmoButton3.SetActive(true);

            gunAmmoImage4.SetActive(false);
            gunAmmoButton4.SetActive(false);
        }

        //can take 4 slot
        if (SaveScript.gunAmmo == 4)
        {
            gunAmmoImage1.SetActive(true);
            gunAmmoButton1.SetActive(false);

            gunAmmoImage2.SetActive(true);
            gunAmmoButton2.SetActive(false);

            gunAmmoImage3.SetActive(true);
            gunAmmoButton3.SetActive(false);

            gunAmmoImage4.SetActive(true);
            gunAmmoButton4.SetActive(true);
        }


        //arrow ammo
        if (SaveScript.arrowAmmo == false)
        {
            arrowImage1.SetActive(false);
            arrowButton1.SetActive(false);
        }

        if (SaveScript.arrowAmmo == true)
        {
            arrowImage1.SetActive(true);
            arrowButton1.SetActive(true);
        }
    }

    private void CheckKeys()
    {
        if (SaveScript.cabinKey == true)
        {
            CabinKeyImage.SetActive(true);
        }

        if (SaveScript.houseKey == true)
        {
            HouseKeyImage.SetActive(true);
        }

        if (SaveScript.roomKey == true)
        {
            RoomKeyImage.SetActive(true);
        }
    }

    private void CheckInventory()
    {
        //apples
        if (SaveScript.apples == 0)
        {
            //you can take 0 slot of apple
            appleImage1.SetActive(false);
            appleButton1.SetActive(false);
            appleImage2.SetActive(false);
            appleButton2.SetActive(false);
            appleImage3.SetActive(false);
            appleButton3.SetActive(false);
            appleImage4.SetActive(false);
            appleButton4.SetActive(false);
            appleImage5.SetActive(false);
            appleButton5.SetActive(false);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 1)
        {
            //you can take 1 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(true);
            appleImage2.SetActive(false);
            appleButton2.SetActive(false);
            appleImage3.SetActive(false);
            appleButton3.SetActive(false);
            appleImage4.SetActive(false);
            appleButton4.SetActive(false);
            appleImage5.SetActive(false);
            appleButton5.SetActive(false);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 2)
        {
            //you can take 2 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(false);
            appleImage2.SetActive(true);
            appleButton2.SetActive(true);
            appleImage3.SetActive(false);
            appleButton3.SetActive(false);
            appleImage4.SetActive(false);
            appleButton4.SetActive(false);
            appleImage5.SetActive(false);
            appleButton5.SetActive(false);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 3)
        {
            //you can take 3 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(false);
            appleImage2.SetActive(true);
            appleButton2.SetActive(false);
            appleImage3.SetActive(true);
            appleButton3.SetActive(true);
            appleImage4.SetActive(false);
            appleButton4.SetActive(false);
            appleImage5.SetActive(false);
            appleButton5.SetActive(false);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 4)
        {
            //you can take 4 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(false);
            appleImage2.SetActive(true);
            appleButton2.SetActive(false);
            appleImage3.SetActive(true);
            appleButton3.SetActive(false);
            appleImage4.SetActive(true);
            appleButton4.SetActive(true);
            appleImage5.SetActive(false);
            appleButton5.SetActive(false);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 5)
        {
            //you can take 5 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(false);
            appleImage2.SetActive(true);
            appleButton2.SetActive(false);
            appleImage3.SetActive(true);
            appleButton3.SetActive(false);
            appleImage4.SetActive(true);
            appleButton4.SetActive(false);
            appleImage5.SetActive(true);
            appleButton5.SetActive(true);
            appleImage6.SetActive(false);
            appleButton6.SetActive(false);
        }

        if (SaveScript.apples == 6)
        {
            //you can take 6 slot of apple
            appleImage1.SetActive(true);
            appleButton1.SetActive(false);
            appleImage2.SetActive(true);
            appleButton2.SetActive(false);
            appleImage3.SetActive(true);
            appleButton3.SetActive(false);
            appleImage4.SetActive(true);
            appleButton4.SetActive(false);
            appleImage5.SetActive(true);
            appleButton5.SetActive(false);
            appleImage6.SetActive(true);
            appleButton6.SetActive(true);
        }

        //batteries
        if (SaveScript.batteries == 0)
        {
            //you can take 0 slots of battery
            batteryImage1.SetActive(false);
            batteryButton1.SetActive(false); 

            batteryImage2.SetActive(false);
            batteryButton2.SetActive(false);

            batteryImage3.SetActive(false);
            batteryButton3.SetActive(false);

            batteryImage4.SetActive(false);
            batteryButton4.SetActive(false);
        }

        if (SaveScript.batteries == 1)
        {
            //you can take 1 slots of battery
            batteryImage1.SetActive(true);
            batteryButton1.SetActive(true); 

            batteryImage2.SetActive(false);
            batteryButton2.SetActive(false);

            batteryImage3.SetActive(false);
            batteryButton3.SetActive(false);

            batteryImage4.SetActive(false);
            batteryButton4.SetActive(false);
        }

        //batteries
        if (SaveScript.batteries == 2)
        {
            //you can take 2 slots of battery
            batteryImage1.SetActive(true);
            batteryButton1.SetActive(false); 

            batteryImage2.SetActive(true);
            batteryButton2.SetActive(true);

            batteryImage3.SetActive(false);
            batteryButton3.SetActive(false);

            batteryImage4.SetActive(false);
            batteryButton4.SetActive(false);
        }

        //batteries
        if (SaveScript.batteries == 3)
        {
            //you can take 3 slots of battery
            batteryImage1.SetActive(true);
            batteryButton1.SetActive(false); 

            batteryImage2.SetActive(true);
            batteryButton2.SetActive(false);

            batteryImage3.SetActive(true);
            batteryButton3.SetActive(true);

            batteryImage4.SetActive(false);
            batteryButton4.SetActive(false);
        }

        //batteries
        if (SaveScript.batteries == 4)
        {
            //you can take 4 slots of battery
            batteryImage1.SetActive(true);
            batteryButton1.SetActive(false); 

            batteryImage2.SetActive(true);
            batteryButton2.SetActive(false);

            batteryImage3.SetActive(true);
            batteryButton3.SetActive(false);

            batteryImage4.SetActive(true);
            batteryButton4.SetActive(true);
        }
    }

    private void CheckWeapon()
    {
        if (SaveScript.knife == true)
        {
            knifeImage.SetActive(true);
            knifeButton.SetActive(true);
        }
        if (SaveScript.bat == true)
        {
            batImage.SetActive(true);
            batButton.SetActive(true);
        }
        if (SaveScript.axe == true)
        {
            axeImage.SetActive(true);
            axeButton.SetActive(true);
        }
        if (SaveScript.gun == true)
        {
            gunImage.SetActive(true);
            gunButton.SetActive(true);
        }
        if (SaveScript.crossbow == true)
        {
            crossbowImage.SetActive(true);
            crossbowButton.SetActive(true);
        }
    }

    //refill player health while eating an apple
    public void HealtUpdate()
    {
        if (SaveScript.PlayerHealth < 100)
        {
            SaveScript.PlayerHealth += 10;
            SaveScript.healtChange = true;
            SaveScript.apples -= 1;
            myPlayer.clip = appleBite;
            myPlayer.Play();
        }

        if (SaveScript.PlayerHealth > 100)
        {
            SaveScript.PlayerHealth = 100;
        }
    }

    //refill battery charge while taking a battery
    public void BatteryUpdate()
    {
        SaveScript.batteryRefill = true;
        SaveScript.batteries -=  1;
        myPlayer.clip = batteryChange;
        myPlayer.Play(); 
    }

    public void AssignKnife()
    {
        playerArms.SetActive(true);
        knife.SetActive(true);
        anim.SetBool("Melee", true);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
    }

    public void AssignBat()
    {
        playerArms.SetActive(true);
        bat.SetActive(true);
        anim.SetBool("Melee", true);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
    }

    public void AssignAxe()
    {
        playerArms.SetActive(true);
        axe.SetActive(true);
        anim.SetBool("Melee", true);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
    }

    public void AssignGun()
    {
        playerArms.SetActive(true);
        gun.SetActive(true);
        anim.SetBool("Melee", false);
        myPlayer.clip = gunShoot;
        myPlayer.Play();
    }

    public void AssignCrossbow()
    {
        playerArms.SetActive(true);
        crossbow.SetActive(true);
        anim.SetBool("Melee", false);
        myPlayer.clip = arrowShoot;
        myPlayer.Play();
    }

    public void WeaponsOff()
    {
        axe.SetActive(false);
        bat.SetActive(false);
        knife.SetActive(false);
        gun.SetActive(false);
        crossbow.SetActive(false);
    }
}
