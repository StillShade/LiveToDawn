using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource[] audios;
    public GameObject CharacterPnl;
    public Animator animCharactPnl;
    public GameObject BtnCharacterPnl, BtnInventory, BtnMapClose;
    public GameObject CharacterDownPnl;
    public GameObject pnlOptions;
    public GameObject btnLeftPnl;
    public GameObject pnlMap;
    public GameObject locationForest;
    public int mapMode = 0;

    //public void OpenCharacterPnl()
    //{
    //    CharacterDownPnl.SetActive(true);
    //}

    //public void CloseCharacterPnl()
    //{
    //    CharacterDownPnl.SetActive(false);
    //}

    public void OpenShelter()
    {
        audios[0].Play();
        pnlMap.SetActive(false);
        locationForest.SetActive(false);
        BtnMapClose.SetActive(false);
        mapMode = 0;
    }

    public void OpenPnlOptions()
    {
        audios[0].Play();
        pnlOptions.SetActive(true);
    }
    public void ClosePnlOptions()
    {
        audios[0].Play();
        pnlOptions.SetActive(false);
    }    

    public void OpenPnlMap()
    {
        mapMode = 1;
        audios[0].Play();
        pnlMap.SetActive(true);
        BtnMapClose.SetActive(true);
        CloseCharacterPnl();
        CloseInventory();
    }

    public void ClosePnlMap()
    {        
        pnlMap.SetActive(false);
        BtnMapClose.SetActive(false);
    }

    public void OpenLocationForest()
    {
        audios[0].Play();
        pnlMap.SetActive(false);
        locationForest.SetActive(true);
        BtnMapClose.SetActive(false);
        mapMode = 1;
    }

    public void CloseLocationForest()
    {
        audios[0].Play();
        locationForest.SetActive(false);
    }

    public void OpenLeftPnl()
    {
        audios[1].Play();
        animCharactPnl.SetTrigger("unwrap");
        btnLeftPnl.SetActive(false);
    }
    public void CloseLeftPnl()
    {
        audios[1].Play();
        animCharactPnl.SetTrigger("rollup");
        btnLeftPnl.SetActive(true);
    }

    public void OpenCharacterPnl()
    {
        audios[1].Play();
        BtnCharacterPnl.SetActive(true);
        animCharactPnl.SetTrigger("openingChar");
        btnLeftPnl.SetActive(true);
        BtnInventory.SetActive(false);
        ClosePnlMap();
    }

    public void CloseCharacterPnl()
    {
        if(mapMode == 1)
        {
            BtnCharacterPnl.SetActive(false);
            animCharactPnl.SetTrigger("MapMode");
        }
        else
        {
            BtnCharacterPnl.SetActive(false);
            animCharactPnl.SetTrigger("closeChar");
        }        
    }

    public void OpenInventory()
    {
        audios[1].Play();
        BtnInventory.SetActive(true);
        animCharactPnl.SetTrigger("openInventory");
        BtnCharacterPnl.SetActive(false);
        ClosePnlMap();
    }
    public void CloseInventory()
    {
        if (mapMode == 1)
        {
            BtnInventory.SetActive(false);
            BtnCharacterPnl.SetActive(false);
            animCharactPnl.SetTrigger("MapMode2");
        }
        else
        {
            BtnInventory.SetActive(false);
            animCharactPnl.SetTrigger("closeInventory");
            BtnCharacterPnl.SetActive(false);
        }        
    }

    void Start()
    {
        audios = myCamera.GetComponents<AudioSource>();
        animCharactPnl.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }


}
