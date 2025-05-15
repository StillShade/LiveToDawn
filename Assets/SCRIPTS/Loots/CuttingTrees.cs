using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CuttingTrees : MonoBehaviour
{
    public Animator hit, animProgress;
    public GameObject tree, btn, pineTree;
    public AudioSource[] audioTree;
    public int hpTree = 10;
    public Image image;
    public float progress = 1.0f;


    public void OnEnable()
    {
        hit.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioTree = tree.GetComponents<AudioSource>();       
    }

    public void OnDisable()
    {
        hpTree = 10;
        pineTree.SetActive(true);
        btn.SetActive(true);
        image.fillAmount = 1.00f;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(progress);

        btn.SetActive(true);
    }

    public void cuttingTree()
    {   
        if(hpTree != 0)
        {
            if (hpTree == 1)
            {
                audioTree[0].Play();
                hit.SetTrigger("Hit");
                hpTree--;
                hit.SetTrigger("HittingTree");
                audioTree[1].Play();
            }
            else
            {     
                audioTree[0].Play();
                hit.SetTrigger("Hit");
                animProgress.SetTrigger("start");
                hpTree--;
                image.fillAmount -= 0.01f;
                btn.SetActive(false);
                StartCoroutine(Delay());
            }
        }
        else
        {

        }        
    }    
}
