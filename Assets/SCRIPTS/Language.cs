using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private static int selectLanguage = 2;
    public GameObject btnRus;
    public GameObject btnEng;

    [Header("Options")]
    public Text txLanguage;
    [Header("Êíîïêè ıêèïèğîâêè")]
    public Text head, face, eyes, light_clothing, warm_clothes, outerwear, armor, unloading_vest, gloves, pants, socks, boots, backpack, transport, basicWeapon, additionalWeapons;
    [Header("Ïàíåëü îïèñàíèÿ ıêèïèğîâêè")]
    public Text drop, clothe, drop2, takeOff;

    void Awake()
    {
        if (PlayerPrefs.HasKey("selectLanguage"))
        {
            selectLanguage = PlayerPrefs.GetInt("selectLanguage");
        }

        if (SelectLanguage == 1)
            ActiveRus();
        else if (SelectLanguage == 2)
            ActiveEng();
    }

    public static int SelectLanguage
    {
        get
        {
            return selectLanguage;
        }
        set
        {
            selectLanguage = value;
            PlayerPrefs.SetInt("selectLanguage", selectLanguage);
        }
    }

    public void ActiveRus()
    {
        SelectLanguage = 1;
        btnRus.SetActive(true);
        btnEng.SetActive(false);
        SelectRus();
    }
    public void ActiveEng()
    {
        SelectLanguage = 2;
        btnRus.SetActive(false);
        btnEng.SetActive(true);
        SelectEng();
    }

    public void SelectRus()
    {
        txLanguage.text = "ßÇÛÊ";
        head.text = "ÃÎËÎÂÀ";
        face.text = "ËÈÖÎ";
        eyes.text = "ÃËÀÇÀ";
        light_clothing.text = "ËÅÃÊÀß ÎÄÅÆÄÀ";
        warm_clothes.text = "ÒÅÏËÀß ÎÄÅÆÄÀ";
        outerwear.text = "ÂÅĞÕÍßß ÎÄÅÆÄÀ";
        armor.text = "ÁĞÎÍß";
        unloading_vest.text = "ĞÀÇÃĞÓÇÊÀ";
        gloves.text = "ÏÅĞ×ÀÒÊÈ";
        pants.text = "ØÒÀÍÛ";
        socks.text = "ÍÎÑÊÈ";
        boots.text = "ÁÎÒÈÍÊÈ";
        backpack.text = "ĞŞÊÇÀÊ";
        transport.text = "ÒĞÀÍÑÏÎĞÒ";
        basicWeapon.text = "ÎÑÍÎÂÍÎÅ ÎĞÓÆÈÅ";
        additionalWeapons.text = "ÄÎÏÎËÍÈÒÅËÜÍÎÅ ÎĞÓÆÈÅ";
        drop.text = "ÂÛÊÈÍÓÒÜ";
        drop2.text = "ÂÛÊÈÍÓÒÜ";
        clothe.text = "ÎÄÅÒÜ";
        takeOff.text = "ÑÍßÒÜ";
    }
    public void SelectEng()
    {
        txLanguage.text = "LANGUAGE";
        head.text = "HEAD";
        face.text = "FACE";
        eyes.text = "EYES";
        light_clothing.text = "LIGHT CLOTHING";
        warm_clothes.text = "WARM CLOTHES";
        outerwear.text = "OUTERWEAR";
        armor.text = "ARMOR";
        unloading_vest.text = "UNLOADING";
        gloves.text = "GLOVES";
        pants.text = "PANTS";
        socks.text = "SOCKS";
        boots.text = "BOOTS";
        backpack.text = "BACKPACK";
        transport.text = "TRANSPORT";
        basicWeapon.text = "BASIC WEAPON";
        additionalWeapons.text = "ADDITIONAL WEAPONS";
        drop.text = "DROP";
        drop2.text = "DROP";
        clothe.text = "CLOTHE";
        takeOff.text = "TAKE OFF";
    }
}
