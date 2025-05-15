using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private static int selectLanguage = 2;
    public GameObject btnRus;
    public GameObject btnEng;

    [Header("������ ������")]
    public Text characterBtn, characterBtnClose, shelterBtn, mapBtn, mapBtnClose, inventoryBtn, inventoryBtnClose;
    [Header("Options")]
    public Text txLanguage;
    [Header("������ ����������")]
    public Text head, face, eyes, light_clothing, warm_clothes, outerwear, armor, unloading_vest, gloves, lingerie, pants, socks, boots, backpack, transport, Watch, Light, GPS, Weapon1, Weapon2, Weapon3, Weapon4, rollUp, btnActionExit;
    [Header("������ �������� ����������")]
    public Text drop, clothe, drop2, takeOff;
    [Header("�������")]
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
        txLanguage.text = "����";
        head.text = "������";
        face.text = "����";
        eyes.text = "�����";
        light_clothing.text = "������ ������";
        warm_clothes.text = "������ ������";
        outerwear.text = "������� ������";
        armor.text = "�����";
        unloading_vest.text = "���������";
        gloves.text = "��������";
        lingerie.text = "������ �����";
        pants.text = "�����";
        socks.text = "�����";
        boots.text = "�������";
        backpack.text = "������";
        Watch.text = "����";
        Light.text = "����";
        GPS.text = "GPS";
        transport.text = "���������";
        Weapon1.text = "1-�� ������";
        Weapon2.text = "2-�� ������";
        Weapon3.text = "������";
        Weapon4.text = "���";
        drop.text = "��������";
        drop2.text = "��������";
        clothe.text = "�����";
        takeOff.text = "�����";
        rollUp.text = "��������";
        shelter.text = "�������";
        forest.text = "���";
        characterBtn.text = "��������";
        characterBtnClose.text = "�������";
        inventoryBtn.text = "���������";
        inventoryBtnClose.text = "�������";
        shelterBtn.text = "�������";
        mapBtn.text = "�����";
        mapBtnClose.text = "�������";
        btnActionExit.text = "����� �� ���������";
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
