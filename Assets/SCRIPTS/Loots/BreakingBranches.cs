using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreakingBranches : MonoBehaviour
{
    public GameObject img1, img2, img3, img4;
    public GameObject shrub, btn;
    public AudioSource audioShub;
    public Animator anim, animProgress;
    public int hpShrub;

    void OnEnable()
    {
        shrub.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioShub = shrub.GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        hpShrub = 4;
        btn.SetActive(true);
        img1.SetActive(true);
        img2.SetActive(true);
        img3.SetActive(true);
        img4.SetActive(true);
    }

    IEnumerator TimeClick()
    {
        yield return new WaitForSeconds(1.1f);

        btn.SetActive(true);
    }

    public void breakingBranches()
    {
        if(hpShrub != 0)
        {
            animProgress.SetTrigger("start");
            audioShub.Play();
            anim.SetTrigger("break");
            StartCoroutine(Delay());
            btn.SetActive(false);
            StartCoroutine(TimeClick());
        }
        else if(hpShrub == 1)
        {
            audioShub.Play();
            anim.SetTrigger("break");
            StartCoroutine(Delay());
            btn.SetActive(false);
            StartCoroutine(TimeClick());
        }
        else
        {

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.0f);

        breakingBranchesActive();
    }

    public void breakingBranchesActive()
    {
        switch (hpShrub)
        {
            case 0:
                break;
            case 1:                
                hpShrub -= 1;
                img1.SetActive(false);
                break;
            case 2:
                hpShrub -= 1;
                img2.SetActive(false);
                break;
            case 3:
                hpShrub -= 1;
                img3.SetActive(false);
                break;
            case 4:
                hpShrub -= 1;
                img4.SetActive(false);
                break;
        }    
    }
}
