using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickups : MonoBehaviour
{   
    RaycastHit  hit;

    [SerializeField] float distance = 4.0f;
    [SerializeField] GameObject pickupMessage;
    [SerializeField] GameObject playerArms;
    [SerializeField] GameObject doorMessage;
    [SerializeField] TextMeshProUGUI doorText;

    //audiosource
    private AudioSource myPlayer;
    
    private float rayDistance;
    private bool canSeePickup = false;
    private bool canSeeDoor = false;

    void Start()
    {
        pickupMessage.SetActive(false);
        doorMessage.SetActive(false);
        playerArms.SetActive(false);
        rayDistance = distance;
        myPlayer = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            //can see apple message
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.apples < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.apples += 1;
                        myPlayer.Play();
                    }
                }
            }
            //can see battery message
            else if (hit.transform.tag == "Battery")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.batteries += 1;
                        myPlayer.Play();
                    }
                }
            }
            //can see knife message
            else if (hit.transform.tag == "Knife")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.knife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.knife = true;
                        myPlayer.Play();
                    }
                }
            }
            //can see gun message
            else if (hit.transform.tag == "Gun")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.gun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.gun = true;
                        myPlayer.Play();
                    }
                }
            }
            //can see crossbow message
            else if (hit.transform.tag == "Crossbow")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.crossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.crossbow = true;
                        myPlayer.Play();
                    }
                }
            }
            //can see bat message
            else if (hit.transform.tag == "Bat")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.bat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.bat = true;
                        myPlayer.Play();
                    }
                }
            }
            //can see axe message
            else if (hit.transform.tag == "Axe")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.axe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.axe = true;
                        myPlayer.Play();
                    }
                }
            }

            //can see cabin key message
            else if (hit.transform.tag == "Cabin Key")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.cabinKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.cabinKey = true;
                        myPlayer.Play();
                    }
                }
            }

            //can see house key message
            else if (hit.transform.tag == "House Key")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.houseKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.houseKey = true;
                        myPlayer.Play();
                    }
                }
            }

            //can see room key message
            else if (hit.transform.tag == "Room Key")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.roomKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.roomKey = true;
                        myPlayer.Play();
                    }
                }
            }

            //can see arrow ammo message
            else if (hit.transform.tag == "Arrow Ammo")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.arrowAmmo == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.arrowAmmo = true;
                        myPlayer.Play();
                    }
                }
            }

            //can see gun ammo message
            else if (hit.transform.tag == "Gun Ammo")
            {
                canSeePickup =  true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.gunAmmo < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.gunAmmo =+ 1;
                        myPlayer.Play();
                    }
                }
            }

            else if (hit.transform.tag == "Door")
            {
                if (hit.transform.gameObject.GetComponent<DoorScript>().locked == false)
                {
                    canSeeDoor =  true;
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == false)
                    {
                        doorText.text = "Press E to open";
                    }
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == true)
                    {
                        doorText.text = "Press E to close";
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessage("DoorOpen");
                    }
                }
                else if (hit.transform.gameObject.GetComponent<DoorScript>().locked == true)
                {
                    doorText.text = "You need the key... ";
                }
            }

            else
            {
                canSeePickup = false;
                canSeeDoor = false;
            }          
        }

        //can see pickup message
        if (canSeePickup == true)
        {
            pickupMessage.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeePickup == false)
        {
            pickupMessage.SetActive(false);
            rayDistance = distance;
        }

        //can see door message
        if (canSeeDoor == true)
        {
            doorMessage.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeeDoor == false)
        {
            doorMessage.SetActive(false);
            rayDistance = distance;
        }
    }
}
