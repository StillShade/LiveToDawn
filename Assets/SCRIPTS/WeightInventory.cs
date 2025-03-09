using UnityEngine;

public class WeightInventory : MonoBehaviour
{
    public float fv;


    public void OnEnable()
    {
        CharPlayer.FV += fv;
    }

    public void OnDisable()
    {
        CharPlayer.FV -= fv;
    }
}
