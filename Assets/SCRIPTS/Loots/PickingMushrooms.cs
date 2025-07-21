using UnityEngine;

public class PickingMushrooms : MonoBehaviour
{    
    public GameObject mushroom, btn, img;
    public AudioSource audioPicking;
    public Animator anim;
    public int hpMushroom = 1;

    void OnEnable()
    {
        audioPicking.GetComponent<Animator>();
        audioPicking = mushroom.GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        hpMushroom = 1;
        img.SetActive(true);
        btn.SetActive(true);
        anim.SetTrigger("default");
    }

    public void PickingMushroomsActive()
    {
        if (hpMushroom != 0)
        {
            hpMushroom -= 1;
            anim.SetTrigger("start");
            audioPicking.Play();
            btn.SetActive(false);
        }        
        else
        {

        }
    }    
}
