using UnityEngine;

public class PickingMushrooms : MonoBehaviour
{    
    public GameObject mushroom, btn;
    public AudioSource audioPicking;
    public Animator anim;
    public int hpMushroom;

    void Start()
    {
        audioPicking.GetComponent<Animator>();
        audioPicking = mushroom.GetComponent<AudioSource>();
    }    

    public void PickingMushroomsActive()
    {
        if (hpMushroom != 0)
        {
            anim.SetTrigger("start");
            audioPicking.Play();
            btn.SetActive(false);
        }        
        else
        {

        }
    }    
}
