using UnityEngine;
using System.Collections;

public class Hut : MonoBehaviour
{
    public GameObject btnActionExit;
    public GameObject img1, img2, img3, img4, img5;
    public GameObject hut, door, btn, btnDoor, wall;
    public AudioSource audioHut, audioDoor;
    public Animator animHut, animProgress;
    public int hpHut;

    void OnEnable()
    {
        animHut.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioHut = hut.GetComponent<AudioSource>();
        audioDoor = door.GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        //btn.SetActive(true);
        //img5.SetActive(true);
        //img4.SetActive(true);
        //img3.SetActive(true);
        //img2.SetActive(true);
        //img1.SetActive(true);
        //door.SetActive(true);
        //hpHut = 6;
        animHut.SetTrigger("default");
        wall.SetActive(true);
        btnDoor.SetActive(true);
        door.SetActive(true);
    }

    IEnumerator TimeClick()
    {
        yield return new WaitForSeconds(1.4f);

        switch (hpHut)
        {
            case 0:
                btn.SetActive(false);
                break;
            case 1:
                img5.SetActive(false);
                btn.SetActive(true);
                break;
            case 2:
                img4.SetActive(false);
                btn.SetActive(true);
                break;
            case 3:
                img3.SetActive(false);
                btn.SetActive(true);
                break;
            case 4:
                img2.SetActive(false);
                btn.SetActive(true);
                break;
            case 5:
                img1.SetActive(false);
                btn.SetActive(true);
                break;
        }
    }    

    public void DamageHut()
    {
        hpHut -= 1;

        switch (hpHut)
        {
            case 1:
                animHut.SetTrigger("board5");
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("start");
                audioHut.Play();
                btn.SetActive(false);
                btnDoor.SetActive(true);
                break;
            case 2:
                animHut.SetTrigger("board4");
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("start");
                audioHut.Play();
                btn.SetActive(false);
                break;
            case 3:
                animHut.SetTrigger("board3");
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("start");
                audioHut.Play();
                btn.SetActive(false);
                break;
            case 4:
                animHut.SetTrigger("board2");
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("start");
                audioHut.Play();
                btn.SetActive(false);
                break;
            case 5:
                animHut.SetTrigger("board1"); 
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("start");
                audioHut.Play();
                btn.SetActive(false);
                break;
        }
    }

    IEnumerator DeletWall()
    {
        yield return new WaitForSeconds(3.1f);

        wall.SetActive(false);
        door.SetActive(false);
        btnActionExit.SetActive(true);
    }

    public void Entrance()
    {
        StartCoroutine(DeletWall());
        animHut.SetTrigger("entrance");
        audioDoor.Play();
        btnDoor.SetActive(false);
    }

    public void ExitTheRoom()
    {
        btnActionExit.SetActive(false);
        door.SetActive(true);
        wall.SetActive(true);
        animHut.SetTrigger("exit");        
        audioDoor.Play();
        btnDoor.SetActive(true);
    }
}
