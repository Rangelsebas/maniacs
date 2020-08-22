using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //audioclips
    [SerializeField] AudioClip cabinSound;
    [SerializeField] AudioClip roomSound;
    [SerializeField] AudioClip houseSound;

    [SerializeField] bool cabin;
    [SerializeField] bool room;
    [SerializeField] bool house;

    private Animator anim;
    //audiosource
    private AudioSource myPlayer;
    
    //booleans
    public bool isOpen = false;
    public bool locked;

    //strings
    public string doorType;

    void Start()
    {
        anim = GetComponent<Animator>();
        myPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        //cabin key
        if (cabin == true)
        {
            doorType = "Cabin";
            if (SaveScript.cabinKey == true)
            {
                locked = false;
            }
        }

        //room key
        if (room == true)
        {
            doorType = "Room";
            if (SaveScript.roomKey == true)
            {
                locked = false;
            }
        }

        //house key
        if (house == true)
        {
            doorType = "House";
            if (SaveScript.houseKey == true)
            {
                locked = false;
            }
        }
    }

    public void DoorOpen()
    {
        if (isOpen == false)
        {
            anim.SetTrigger("Open");
            isOpen = true;
            //cabin sound
            if (cabin == true)
            {
                myPlayer.clip = cabinSound;
                myPlayer.Play();
            }
            //room sound
            if (room == true)
            {
                myPlayer.clip = roomSound;
                myPlayer.Play();
            }
            //house sound
            if (house == true)
            {
                myPlayer.clip = houseSound;
                myPlayer.Play();
            }
        }
        else if (isOpen == true)
        {
            anim.SetTrigger("Close");
            isOpen = false;
            //cabin sound
            if (cabin == true)
            {
                myPlayer.clip = cabinSound;
                myPlayer.Play();
            }
            //room sound
            if (room == true)
            {
                myPlayer.clip = roomSound;
                myPlayer.Play();
            }
            //house sound
            if (house == true)
            {
                myPlayer.clip = houseSound;
                myPlayer.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (locked ==false)
            {
                if (isOpen == false)
                {
                    anim.SetTrigger("Open");
                    isOpen = true;
                }
            }
        }
    }
}
