using UnityEngine;
using UnityEngine.UI;

public class CharEcip : MonoBehaviour
{
    public int af;
    public int at;
    public int ar;
    public float ms;
    public float mv;
    public float fv;


    public void OnEnable()
    {
        CharPlayer.AF += af;
        CharPlayer.AT += at;
        CharPlayer.AR += ar;
        CharPlayer.MS += ms;
        CharPlayer.MV += mv;
        CharPlayer.FV += fv;
    }

    public void OnDisable()
    {
        CharPlayer.AF -= af;
        CharPlayer.AT -= at;
        CharPlayer.AR -= ar;
        CharPlayer.MS -= ms;
        CharPlayer.MV -= mv;
        CharPlayer.FV -= fv;
    }
}
