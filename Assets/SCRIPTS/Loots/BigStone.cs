using UnityEngine;
using System.Collections;

public class BigStone : MonoBehaviour
{
    public GameObject img1, img2, img3, img4, img5, img6;
    public GameObject bigStone, stone, btn;
    public AudioSource audioStone, damageStone;
    public Animator anim, animProgress;
    public int hpStone;

    void OnEnable()
    {
        bigStone.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioStone = bigStone.GetComponent<AudioSource>();
        damageStone = stone.GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        btn.SetActive(true);
        img1.SetActive(true);
        img2.SetActive(true);
        img3.SetActive(true);
        img4.SetActive(true);
        img5.SetActive(true);
        img6.SetActive(true);
        hpStone = 10;
    }

    IEnumerator TimeClick()
    {
        yield return new WaitForSeconds(1.1f);

        btn.SetActive(true);
    }

    public void HittingRock()
    {
        if (hpStone > 1)
        {
            animProgress.SetTrigger("start");
            audioStone.Play();
            anim.SetTrigger("hit");
            DamageStone();
            btn.SetActive(false);
            StartCoroutine(TimeClick());
        }
        else if (hpStone == 1)
        {
            audioStone.Play();
            anim.SetTrigger("hit");
            DamageStone();
            btn.SetActive(false);
        }
        else
        {

        }
    }

    public void DamageStone()
    {
        hpStone -= 1;

        switch (hpStone)
        {
            case 0:
                damageStone.Play();
                img1.SetActive(false);
                break;
            case 1:
                img2.SetActive(false);
                break;
            case 3:
                img3.SetActive(false);
                break;
            case 5:
                img4.SetActive(false);
                break;
            case 7:
                img5.SetActive(false);
                break;
            case 9:
                img6.SetActive(false);
                break;
        }
    }
}
