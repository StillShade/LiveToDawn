using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CuttingTrees : MonoBehaviour
{
    public Animator anim, hit;
    public AudioSource treeFall, hittingTree;
    public int hpTree = 5;
    public Image image;


    public void OnEnable()
    {
        anim.GetComponent<Animator>();
        hit.GetComponent<Animator>();
        treeFall.GetComponent<AudioSource>();
        hittingTree.GetComponent<AudioSource>();        
    }

    public void cuttingTree()
    {   
        if(hpTree != 0)
        {
            if (hpTree == 1)
            {
                hittingTree.Play();
                hit.SetTrigger("Hit");
                hpTree--;
                anim.SetTrigger("HittingTree");
                treeFall.Play();
            }
            else
            {
                hittingTree.Play();
                hit.SetTrigger("Hit");
                hpTree--;
                image.fillAmount -= 0.025f;
            }
        }
        else
        {

        }
        
    }
}
