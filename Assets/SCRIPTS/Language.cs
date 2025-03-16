using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    private static int selectLanguage = 2;
    public GameObject btnRus;
    public GameObject btnEng;

    [Header("������ ������")]
    public Text characterBtn, characterBtnClose, shelterBtn, mapBtn, inventoryBtn, inventoryBtnClose;
    [Header("Options")]
    public Text txLanguage;
    [Header("������ ����������")]
    public Text head, face, eyes, light_clothing, warm_clothes, outerwear, armor, unloading_vest, gloves, pants, socks, boots, backpack, transport, basicWeapon, additionalWeapons, rollUp;
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
        pants.text = "�����";
        socks.text = "�����";
        boots.text = "�������";
        backpack.text = "������";
        transport.text = "���������";
        basicWeapon.text = "1-�� ������";
        additionalWeapons.text = "2-�� ������";
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
        basicWeapon.text = "1ST WEAPON";
        additionalWeapons.text = "2ST WEAPON";
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
    }
}
