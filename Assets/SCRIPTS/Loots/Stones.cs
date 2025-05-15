using UnityEngine;
using System.Collections;

public class Stones : MonoBehaviour
{
    public GameObject stones, btn, img1, img2, img3, img4, img5, img6;
    public AudioSource audioStones;
    public Animator anim, animProgress;
    public int hpStones = 6;

    void OnEnable()
    {
        anim.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioStones = stones.GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        hpStones = 6;
        btn.SetActive(true);
        img6.SetActive(true);
        img5.SetActive(true);
        img4.SetActive(true);
        img3.SetActive(true);
        img2.SetActive(true);
        img1.SetActive(true);
    }

    IEnumerator TimeClick()
    {
        yield return new WaitForSeconds(0.5f);

        btn.SetActive(true);

        switch (hpStones)
        {
            case 0:
                img6.SetActive(false);
                break;
            case 1:
                img5.SetActive(false);
                break;
            case 2:
                img4.SetActive(false);
                break;
            case 3:
                img3.SetActive(false);
                break;
            case 4:
                img2.SetActive(false);
                break;
            case 5:
                img1.SetActive(false);
                break;
        }
    }    

    public void CollectingStones()
    {
        switch (hpStones)
        {
            case 0:
                break;
            case 1:    
                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone6");
                btn.SetActive(false);                
                break;
            case 2:
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("startStone");

                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone5");
                btn.SetActive(false);
                break;
            case 3:
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("startStone");

                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone4");
                btn.SetActive(false);
                break;
            case 4:
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("startStone");

                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone3");
                btn.SetActive(false);
                break;
            case 5:
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("startStone");

                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone2");
                btn.SetActive(false);
                break;
            case 6:
                StartCoroutine(TimeClick());
                animProgress.SetTrigger("startStone");

                hpStones -= 1;
                audioStones.Play();
                anim.SetTrigger("stone1");
                btn.SetActive(false);
                break;
        }
    }
}
