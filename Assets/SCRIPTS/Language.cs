using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private static int selectLanguage = 2;
    public GameObject btnRus;
    public GameObject btnEng;

    [Header("ÕËÊÌˇˇ Ô‡ÌÂÎ¸")]
    public Text characterBtn, characterBtnClose, shelterBtn, mapBtn, mapBtnClose, inventoryBtn, inventoryBtnClose;
    [Header("Options")]
    public Text txLanguage;
    [Header(" ÌÓÔÍË ˝ÍËÔËÓ‚ÍË")]
    public Text head, face, eyes, light_clothing, warm_clothes, outerwear, armor, unloading_vest, gloves, lingerie, pants, socks, boots, backpack, transport, Watch, Light, GPS, Weapon1, Weapon2, Weapon3, Weapon4;
    [Header("œ‡ÌÂÎ¸ ÓÔËÒ‡ÌËˇ ˝ÍËÔËÓ‚ÍË")]
    public Text drop, clothe, drop2, takeOff;
    [Header("ÀÓÍ‡ˆËË")]
    public Text shelter, forest;
    [Header("œ‡ÌÂÎ¸ ı‡‡ÍÚÂËÒÚËÍ")]
    public Text tabHealth, tabSkills, tabInfo;
    [Header(" ¿–“€")]
    public Text WOLF, PINE, BUSH, BIGSTONE, STONES, MUSHROOMS, DEER, TRADER, HUT, BUNKER;

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
        txLanguage.text = "ﬂ«€ ";
        head.text = "√ŒÀŒ¬¿";
        face.text = "À»÷Œ";
        eyes.text = "√À¿«¿";
        light_clothing.text = "À≈√ ¿ﬂ Œƒ≈∆ƒ¿";
        warm_clothes.text = "“≈œÀ¿ﬂ Œƒ≈∆ƒ¿";
        outerwear.text = "¬≈–’Õﬂﬂ Œƒ≈∆ƒ¿";
        armor.text = "¡–ŒÕﬂ";
        unloading_vest.text = "–¿«√–”« ¿";
        gloves.text = "œ≈–◊¿“ »";
        lingerie.text = "Õ»∆Õ≈≈ ¡≈À‹≈";
        pants.text = "ÿ“¿Õ€";
        socks.text = "ÕŒ— »";
        boots.text = "¡Œ“»Õ »";
        backpack.text = "–ﬁ «¿ ";
        Watch.text = "◊¿—€";
        Light.text = "—¬≈“";
        GPS.text = "GPS";
        transport.text = "“–¿Õ—œŒ–“";
        Weapon1.text = "1-Œ≈ Œ–”∆»≈";
        Weapon2.text = "2-Œ≈ Œ–”∆»≈";
        Weapon3.text = " Œ¡”–¿";
        Weapon4.text = "ÕŒ∆";
        drop.text = "¬€ »Õ”“‹";
        drop2.text = "¬€ »Õ”“‹";
        clothe.text = "Œƒ≈“‹";
        takeOff.text = "—Õﬂ“‹";
        shelter.text = "”¡≈∆»Ÿ≈";
        forest.text = "À≈—";
        characterBtn.text = "œ≈–—ŒÕ¿∆";
        characterBtnClose.text = "«¿ –€“‹";
        inventoryBtn.text = "› »œ»–Œ¬ ¿";
        inventoryBtnClose.text = "«¿ –€“‹";
        shelterBtn.text = "”¡≈∆»Ÿ≈";
        mapBtn.text = " ¿–“¿";
        mapBtnClose.text = " ¿–“¿";
        tabHealth.text = "«ƒŒ–Œ¬‹≈";
        tabSkills.text = "Õ¿¬€ »";
        tabInfo.text = "»Õ‘Œ";
        WOLF.text = "¬ŒÀ ";
        PINE.text = "—Œ—Õ¿";
        BUSH.text = " ”—“";
        BIGSTONE.text = "¡ŒÀ  ¿Ã≈Õ‹";
        STONES.text = " ¿ÃÕ»";
        MUSHROOMS.text = "√–»¡€";
        DEER.text = "ŒÀ≈Õ‹";
        TRADER.text = "“Œ–√Œ¬≈÷";
        HUT.text = "’»∆»Õ¿";
        BUNKER.text = "¡”Õ ≈–";
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
        shelter.text = "SHELTER";
        forest.text = "FOREST";
        characterBtn.text = "CHARACTER";
        characterBtnClose.text = "CLOSE";
        inventoryBtn.text = "EQUIPMENT";
        inventoryBtnClose.text = "CLOSE";
        shelterBtn.text = "SHELTER";
        mapBtn.text = "MAP";
        mapBtnClose.text = "MAP";
        tabHealth.text = "HEALTH";
        tabSkills.text = "SKILLS";
        tabInfo.text = "INFO";
        WOLF.text = "WOLF";
        PINE.text = "PINE";
        BUSH.text = "BUSH";
        BIGSTONE.text = "BIG STONE";
        STONES.text = "STONES";
        MUSHROOMS.text = "MUSHROOMS";
        DEER.text = "DEER";
        TRADER.text = "TRADER";
        HUT.text = "HUT";
        BUNKER.text = "BUNKER";
    }
}
