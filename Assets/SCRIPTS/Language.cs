using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private static int selectLanguage = 2;
    public GameObject btnRus;
    public GameObject btnEng;

    [Header("Íèæíÿÿ ïàíåëü")]
    public Text characterBtn, characterBtnClose, shelterBtn, mapBtn, mapBtnClose, inventoryBtn, inventoryBtnClose;
    [Header("Options")]
    public Text txLanguage;
    [Header("Êíîïêè ıêèïèğîâêè")]
    public Text head, face, eyes, light_clothing, warm_clothes, outerwear, armor, unloading_vest, gloves, lingerie, pants, socks, boots, backpack, transport, Watch, Light, GPS, Weapon1, Weapon2, Weapon3, Weapon4, rollUp, btnActionExit;
    [Header("Ïàíåëü îïèñàíèÿ ıêèïèğîâêè")]
    public Text drop, clothe, drop2, takeOff;
    [Header("Ëîêàöèè")]
    public Text shelter, forest;

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
        lingerie.text = "ÍÈÆÍÅÅ ÁÅËÜÅ";
        pants.text = "ØÒÀÍÛ";
        socks.text = "ÍÎÑÊÈ";
        boots.text = "ÁÎÒÈÍÊÈ";
        backpack.text = "ĞŞÊÇÀÊ";
        Watch.text = "×ÀÑÛ";
        Light.text = "ÑÂÅÒ";
        GPS.text = "GPS";
        transport.text = "ÒĞÀÍÑÏÎĞÒ";
        Weapon1.text = "1-ÎÅ ÎĞÓÆÈÅ";
        Weapon2.text = "2-ÎÅ ÎĞÓÆÈÅ";
        Weapon3.text = "ÊÎÁÓĞÀ";
        Weapon4.text = "ÍÎÆ";
        drop.text = "ÂÛÊÈÍÓÒÜ";
        drop2.text = "ÂÛÊÈÍÓÒÜ";
        clothe.text = "ÎÄÅÒÜ";
        takeOff.text = "ÑÍßÒÜ";
        rollUp.text = "ÑÂÅĞÍÓÒÜ";
        shelter.text = "Óáåæèùå";
        forest.text = "Ëåñ";
        characterBtn.text = "ÏÅĞÑÎÍÀÆ";
        characterBtnClose.text = "ÇÀÊĞÛÒÜ";
        inventoryBtn.text = "ÈÍÂÅÍÒÀĞÜ";
        inventoryBtnClose.text = "ÇÀÊĞÛÒÜ";
        shelterBtn.text = "ÓÁÅÆÈÙÅ";
        mapBtn.text = "ÊÀĞÒÀ";
        mapBtnClose.text = "ÇÀÊĞÛÒÜ";
        btnActionExit.text = "ÂÛÉÒÈ ÈÇ ÏÎÌÅÙÅÍÈß";
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
        lingerie.text = "LINGERIE";
        pants.text = "PANTS";
        socks.text = "SOCKS";
        boots.text = "BOOTS";
        backpack.text = "BACKPACK";
        Watch.text = "WATCH";
        Light.text = "LIGHT";
        GPS.text = "GPS";
        transport.text = "TRANSPORT";
        Weapon1.text = "1ST WEAPON";
        Weapon2.text = "2ST WEAPON";
        Weapon3.text = "HOLSTER";
        Weapon4.text = "KNIFE";
        drop.text = "DROP";
        drop2.text = "DROP";
        clothe.text = "CLOTHE";
        takeOff.text = "TAKE OFF";
        rollUp.text = "ROLL UP";
        shelter.text = "Shelter";
        forest.text = "Forest";
        characterBtn.text = "CHARACTER";
        characterBtnClose.text = "CLOSE";
        inventoryBtn.text = "INVENTORY";
        inventoryBtnClose.text = "CLOSE";
        shelterBtn.text = "SHELTER";
        mapBtn.text = "MAP";
        mapBtnClose.text = "CLOSE";
        btnActionExit.text = "EXIT THE ROOM";
    }
}
