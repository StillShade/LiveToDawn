using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CharacterPnl;
    public GameObject CharacterDownPnl;
    public GameObject pnlOptions;

    public void OpenCharacterPnl()
    {
        CharacterDownPnl.SetActive(true);
    }

    public void CloseCharacterPnl()
    {
        CharacterDownPnl.SetActive(false);
    }

    public void OpenPnlOptions()
    {
        pnlOptions.SetActive(true);
    }
    public void ClosePnlOptions()
    {
        pnlOptions.SetActive(false);
    }    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


}
