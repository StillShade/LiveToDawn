using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource[] audios;
    public GameObject CharacterPnl;
    public Animator animCharactPnl, ANIMinventory;
    public GameObject BtnPlayerPnl, BtnEquipment, BtnCloseInventory, BtnMapClose, BtnMap, BtnShelter, BtnCloseSearch;
    public GameObject CharacterDownPnl, tabHealth, tabSkills, tabInfo;
    public GameObject pnlOptions;
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

    public void OpenTabHeat()
    {
        audios[2].Play();
        tabHealth.SetActive(true);
        tabSkills.SetActive(false);
        tabInfo.SetActive(false);
    }

    public void OpenTabSkill()
    {
        audios[2].Play();
        tabHealth.SetActive(false);
        tabSkills.SetActive(true);
        tabInfo.SetActive(false);
    }

    public void OpenTabInfo()
    {
        audios[2].Play();
        tabHealth.SetActive(false);
        tabSkills.SetActive(false);
        tabInfo.SetActive(true);
    }

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
        OpenInventory();
        CloseLeftPnl();
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
        BtnMap.SetActive(false);
        BtnMapClose.SetActive(false);
        BtnShelter.SetActive(false);
        CloseInventory();
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
        BtnEquipment.SetActive(true);
        BtnPlayerPnl.SetActive(false);
        CharacterPnl.SetActive(false);
    }
    public void CloseLeftPnl()
    {
        audios[1].Play();
        animCharactPnl.SetTrigger("rollup");
        BtnEquipment.SetActive(false);
        BtnPlayerPnl.SetActive(false);
        CharacterPnl.SetActive(false);
    }

    public void OpenCharacterPnl()
    {
        audios[0].Play();
        BtnPlayerPnl.SetActive(true);
        CharacterPnl.SetActive(true);
    }

    public void CloseCharacterPnl()
    {
        audios[0].Play();
        BtnPlayerPnl.SetActive(false);
        CharacterPnl.SetActive(false);
    }

    public void OpenInventory()
    {
        audios[1].Play();
        ANIMinventory.SetTrigger("OpenInventory");
        BtnCloseInventory.SetActive(true);
    }
    public void CloseInventory()
    {
        audios[1].Play();
        ANIMinventory.SetTrigger("CloseInventory");
        BtnCloseInventory.SetActive(false);
    }

    public void OpenSearch()
    {
        audios[0].Play();
        ANIMinventory.SetTrigger("OpenSearchInventory");
        animCharactPnl.SetTrigger("OpenSearch");
        BtnCloseSearch.SetActive(true);
    }

    public void CloseSearch()
    {
        audios[1].Play();
        ANIMinventory.SetTrigger("CloseSearchInventory");
        animCharactPnl.SetTrigger("CloseSearch");
        BtnCloseSearch.SetActive(false);
        BtnCloseInventory.SetActive(true);
        BtnEquipment.SetActive(false);
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
