using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CuttingTrees : MonoBehaviour
{
    public Animator anim, hit, animProgress;
    public GameObject tree, btn;
    public AudioSource[] audioTree;
    public int hpTree = 10;
    public Image image;
    public float progress = 1.0f;


    public void OnEnable()
    {
        anim.GetComponent<Animator>();
        hit.GetComponent<Animator>();
        animProgress.GetComponent<Animator>();
        audioTree = tree.GetComponents<AudioSource>();       
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
                anim.SetTrigger("HittingTree");
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
