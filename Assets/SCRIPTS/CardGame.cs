using UnityEngine;

public class CardGame : MonoBehaviour
{
    public int side = 0;
    public GameObject revers;
    public Animator card;

    public void RotationsCard()
    {
        if (side== 0)
        {
            card.SetTrigger("Rotations");
            side = 1;
        }
        else if (side== 1) 
        {
            card.SetTrigger("BackRotations");
            side = 0;
        }     
    }
}
