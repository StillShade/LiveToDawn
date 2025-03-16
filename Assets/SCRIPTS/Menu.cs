using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CharacterPnl;
    public Animator animCharactPnl, animInventory;
    public GameObject BtnCharacterPnl, BtnInventory;
    public GameObject CharacterDownPnl;
    public GameObject pnlOptions;
    public GameObject btnLeftPnl;
    public GameObject pnlMap;
    public GameObject locationForest;

    //public void OpenCharacterPnl()
    //{
    //    CharacterDownPnl.SetActive(true);
    //}

    //public void CloseCharacterPnl()
    //{
    //    CharacterDownPnl.SetActive(false);
    //}

    public void OpenPnlOptions()
    {
        pnlOptions.SetActive(true);
    }
    public void ClosePnlOptions()
    {
        pnlOptions.SetActive(false);
    }  
    
    public void ActivLeftBtn()
    {
        btnLeftPnl.SetActive(true);
    }

    public void DeactivLeftBtn()
    {
        btnLeftPnl.SetActive(false);
    }

    public void OpenPnlMap()
    {
        pnlMap.SetActive(true);
    }

    public void ClosePnlMap()
    {
        pnlMap.SetActive(false);
    }

    public void OpenLocationForest()
    {
        pnlMap.SetActive(false);
        locationForest.SetActive(true);
    }

    public void CloseLocationForest()
    {
        locationForest.SetActive(false);
    }

    public void OpenCharacterPnl()
    {
        animCharactPnl.SetTrigger("openingInventory");
        BtnCharacterPnl.SetActive(true);
    }

    public void CloseCharacterPnl()
    {
        animCharactPnl.SetTrigger("hidingInventory");
        BtnCharacterPnl.SetActive(false);
    }

    public void OpenInventory()
    {
        animInventory.SetTrigger("inventory");
        BtnInventory.SetActive(true);
    }
    public void CloseInventory()
    {
        animInventory.SetTrigger("closeInventory");
        BtnInventory.SetActive(false);
    }

    void Start()
    {
        animCharactPnl.GetComponent<Animator>();
        animInventory.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }


}
