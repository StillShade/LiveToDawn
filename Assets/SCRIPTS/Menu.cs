using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CharacterPnl;
    public GameObject CharacterDownPnl;

    public void OpenCharacterPnl()
    {
        CharacterPnl.SetActive(true);
        CharacterDownPnl.SetActive(true);
    }

    public void CloseCharacterPnl()
    {
        CharacterPnl.SetActive(false);
        CharacterDownPnl.SetActive(false);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


}
