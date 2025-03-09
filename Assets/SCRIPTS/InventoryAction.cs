using UnityEngine;

public class InventoryAction : MonoBehaviour
{
    public static int socks = 1;
    public static int socksUnit1 = 1;
    public static int boots = 1;
    public static int bootsUnit1 = 1;
    public static int pants = 1;
    public static int pantsUnit1 = 1;
    public static int gloves;
    public static int glovesUnit1;
    public static int lightClothing = 1;
    public static int lightClothingUnit1 = 1;
    public static int faceMask;
    public static int faceMaskUnit1;
    public static int warmClothes;
    public static int warmClothesUnit1;
    public static int armor;
    public static int armorUnit1;
    public static int unloadingVest;
    public static int unloadingVestUnit1;
    public static int outerwear;
    public static int outerwearUnit1;
    public static int backpack;
    public static int backpackUnit1;
    public static int glasses;
    public static int glassesUnit1;
    public static int headdress;
    public static int headdressUnit1;
    public static int transport;
    public static int transportUnit1;

    public string thingInvent;
    public string thingEcip;
    public GameObject pnlInvent;
    public GameObject pnlEcip;

    public GameObject socks1, socks1i;
    public GameObject boots1, boots1i;
    public GameObject pants1, pants1i;
    public GameObject gloves1, gloves1i;
    public GameObject lightClothing1, lightClothing1i;
    public GameObject faceMask1, faceMask1i;
    public GameObject warmClothes1, warmClothes1i;
    public GameObject armor1, armor1i;
    public GameObject unloadingVest1, unloadingVest1i;
    public GameObject outerwear1, outerwear1i;
    public GameObject backpack1, backpack1i;
    public GameObject glasses1, glasses1i;
    public GameObject headdress1, headdress1i;
    public GameObject transport1, transport1i;

    public void IdentifyThingInvent(string ITI)
    {
        pnlInvent.SetActive(true);
        thingInvent = ITI;
    }
    public void IdentifyThingEcip(string ITE)
    {
        pnlEcip.SetActive(true);
        thingEcip = ITE;
    }

    public void ClotheThing()
    {

    }

    public void ClotheSocks()
    {
        switch (Socks)
        {
            case 1:
                socks1.SetActive(true);
                break;
        }
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("socks"))
        {
            socks = PlayerPrefs.GetInt("socks");
        }
        if (PlayerPrefs.HasKey("socksUnit1"))
        {
            socksUnit1 = PlayerPrefs.GetInt("socksUnit1");
        }
        if (PlayerPrefs.HasKey("boots"))
        {
            boots = PlayerPrefs.GetInt("boots");
        }
        if (PlayerPrefs.HasKey("bootsUnit1"))
        {
            bootsUnit1 = PlayerPrefs.GetInt("bootsUnit1");
        }
        if (PlayerPrefs.HasKey("pants"))
        {
            pants = PlayerPrefs.GetInt("pants");
        }
        if (PlayerPrefs.HasKey("pantsUnit1"))
        {
            pantsUnit1 = PlayerPrefs.GetInt("pantsUnit1");
        }
        if (PlayerPrefs.HasKey("gloves"))
        {
            gloves = PlayerPrefs.GetInt("gloves");
        }
        if (PlayerPrefs.HasKey("glovesUnit1"))
        {
            glovesUnit1 = PlayerPrefs.GetInt("glovesUnit1");
        }
        if (PlayerPrefs.HasKey("lightClothing"))
        {
            lightClothing = PlayerPrefs.GetInt("lightClothing");
        }
        if (PlayerPrefs.HasKey("lightClothingUnit1"))
        {
            lightClothingUnit1 = PlayerPrefs.GetInt("lightClothingUnit1");
        }
        if (PlayerPrefs.HasKey("faceMask"))
        {
            faceMask = PlayerPrefs.GetInt("faceMask");
        }
        if (PlayerPrefs.HasKey("faceMaskUnit1"))
        {
            faceMaskUnit1 = PlayerPrefs.GetInt("faceMaskUnit1");
        }
        if (PlayerPrefs.HasKey("warmClothes"))
        {
            warmClothes = PlayerPrefs.GetInt("warmClothes");
        }
        if (PlayerPrefs.HasKey("warmClothesUnit1"))
        {
            warmClothesUnit1 = PlayerPrefs.GetInt("warmClothesUnit1");
        }
        if (PlayerPrefs.HasKey("armor"))
        {
            armor = PlayerPrefs.GetInt("armor");
        }
        if (PlayerPrefs.HasKey("armorUnit1"))
        {
            armorUnit1 = PlayerPrefs.GetInt("armorUnit1");
        }
        if (PlayerPrefs.HasKey("unloadingVest"))
        {
            unloadingVest = PlayerPrefs.GetInt("unloadingVest");
        }
        if (PlayerPrefs.HasKey("unloadingVestUnit1"))
        {
            unloadingVestUnit1 = PlayerPrefs.GetInt("unloadingVestUnit1");
        }
        if (PlayerPrefs.HasKey("outerwear"))
        {
            outerwear = PlayerPrefs.GetInt("outerwear");
        }
        if (PlayerPrefs.HasKey("outerwearUnit1"))
        {
            outerwearUnit1 = PlayerPrefs.GetInt("outerwearUnit1");
        }
        if (PlayerPrefs.HasKey("backpack"))
        {
            backpack = PlayerPrefs.GetInt("backpack");
        }
        if (PlayerPrefs.HasKey("backpackUnit1"))
        {
            backpackUnit1 = PlayerPrefs.GetInt("backpackUnit1");
        }
        if (PlayerPrefs.HasKey("glasses"))
        {
            glasses = PlayerPrefs.GetInt("glasses");
        }
        if (PlayerPrefs.HasKey("glassesUnit1"))
        {
            glassesUnit1 = PlayerPrefs.GetInt("glassesUnit1");
        }
        if (PlayerPrefs.HasKey("headdress"))
        {
            headdress = PlayerPrefs.GetInt("headdress");
        }
        if (PlayerPrefs.HasKey("headdressUnit1"))
        {
            headdressUnit1 = PlayerPrefs.GetInt("headdressUnit1");
        }
        if (PlayerPrefs.HasKey("transport"))
        {
            transport = PlayerPrefs.GetInt("transport");
        }
        if (PlayerPrefs.HasKey("transportUnit1"))
        {
            transportUnit1 = PlayerPrefs.GetInt("transportUnit1");
        }
    }

    public static int Socks
    {
        get
        {
            return socks;
        }
        set
        {
            socks = value;
            PlayerPrefs.SetInt("socks", socks);
        }
    }
    public static int SocksUnit1
    {
        get
        {
            return socksUnit1;
        }
        set
        {
            socksUnit1 = value;
            PlayerPrefs.SetInt("socksUnit1", socksUnit1);
        }
    }

    public static int Boots
    {
        get
        {
            return boots;
        }
        set
        {
            boots = value;
            PlayerPrefs.SetInt("boots", boots);
        }
    }
    public static int BootsUnit1
    {
        get
        {
            return bootsUnit1;
        }
        set
        {
            bootsUnit1 = value;
            PlayerPrefs.SetInt("bootsUnit1", bootsUnit1);
        }
    }

    public static int Pants
    {
        get
        {
            return pants;
        }
        set
        {
            pants = value;
            PlayerPrefs.SetInt("pants", pants);
        }
    }
    public static int PantsUnit1
    {
        get
        {
            return pantsUnit1;
        }
        set
        {
            pantsUnit1 = value;
            PlayerPrefs.SetInt("pantsUnit1", pantsUnit1);
        }
    }

    public static int Gloves
    {
        get
        {
            return gloves;
        }
        set
        {
            gloves = value;
            PlayerPrefs.SetInt("gloves", gloves);
        }
    }
    public static int GlovesUnit1
    {
        get
        {
            return glovesUnit1;
        }
        set
        {
            glovesUnit1 = value;
            PlayerPrefs.SetInt("glovesUnit1", glovesUnit1);
        }
    }

    public static int LightClothing
    {
        get
        {
            return lightClothing;
        }
        set
        {
            lightClothing = value;
            PlayerPrefs.SetInt("lightClothing", lightClothing);
        }
    }
    public static int LightClothingUnit1
    {
        get
        {
            return lightClothingUnit1;
        }
        set
        {
            lightClothingUnit1 = value;
            PlayerPrefs.SetInt("lightClothingUnit1", lightClothingUnit1);
        }
    }

    public static int FaceMask
    {
        get
        {
            return faceMask;
        }
        set
        {
            faceMask = value;
            PlayerPrefs.SetInt("faceMask", faceMask);
        }
    }
    public static int FaceMaskUnit1
    {
        get
        {
            return faceMaskUnit1;
        }
        set
        {
            faceMaskUnit1 = value;
            PlayerPrefs.SetInt("faceMaskUnit1", faceMaskUnit1);
        }
    }

    public static int WarmClothes
    {
        get
        {
            return warmClothes;
        }
        set
        {
            warmClothes = value;
            PlayerPrefs.SetInt("warmClothes", warmClothes);
        }
    }
    public static int WarmClothesUnit1
    {
        get
        {
            return warmClothesUnit1;
        }
        set
        {
            warmClothesUnit1 = value;
            PlayerPrefs.SetInt("warmClothesUnit1", warmClothesUnit1);
        }
    }

    public static int Armor
    {
        get
        {
            return armor;
        }
        set
        {
            armor = value;
            PlayerPrefs.SetInt("armor", armor);
        }
    }
    public static int ArmorUnit1
    {
        get
        {
            return armorUnit1;
        }
        set
        {
            armorUnit1 = value;
            PlayerPrefs.SetInt("armorUnit1", armorUnit1);
        }
    }

    public static int UnloadingVest
    {
        get
        {
            return unloadingVest;
        }
        set
        {
            unloadingVest = value;
            PlayerPrefs.SetInt("unloadingVest", unloadingVest);
        }
    }
    public static int UnloadingVestUnit1
    {
        get
        {
            return unloadingVestUnit1;
        }
        set
        {
            unloadingVestUnit1 = value;
            PlayerPrefs.SetInt("unloadingVestUnit1", unloadingVestUnit1);
        }
    }

    public static int Outerwear
    {
        get
        {
            return outerwear;
        }
        set
        {
            outerwear = value;
            PlayerPrefs.SetInt("outerwear", outerwear);
        }
    }
    public static int OuterwearUnit1
    {
        get
        {
            return outerwearUnit1;
        }
        set
        {
            outerwearUnit1 = value;
            PlayerPrefs.SetInt("outerwearUnit1", outerwearUnit1);
        }
    }

    public static int Backpack
    {
        get
        {
            return backpack;
        }
        set
        {
            backpack = value;
            PlayerPrefs.SetInt("backpack", backpack);
        }
    }
    public static int BackpackUnit1
    {
        get
        {
            return backpackUnit1;
        }
        set
        {
            backpackUnit1 = value;
            PlayerPrefs.SetInt("backpackUnit1", backpackUnit1);
        }
    }

    public static int Glasses
    {
        get
        {
            return glasses;
        }
        set
        {
            glasses = value;
            PlayerPrefs.SetInt("glasses", glasses);
        }
    }
    public static int GlassesUnit1
    {
        get
        {
            return glassesUnit1;
        }
        set
        {
            glassesUnit1 = value;
            PlayerPrefs.SetInt("glassesUnit1", glassesUnit1);
        }
    }

    public static int Headdress
    {
        get
        {
            return headdress;
        }
        set
        {
            headdress = value;
            PlayerPrefs.SetInt("headdress", headdress);
        }
    }
    public static int HeaddressUnit1
    {
        get
        {
            return headdressUnit1;
        }
        set
        {
            headdressUnit1 = value;
            PlayerPrefs.SetInt("headdressUnit1", headdressUnit1);
        }
    }

    public static int Transport
    {
        get
        {
            return transport;
        }
        set
        {
            transport = value;
            PlayerPrefs.SetInt("transport", transport);
        }
    }
    public static int TransportUnit1
    {
        get
        {
            return transportUnit1;
        }
        set
        {
            transportUnit1 = value;
            PlayerPrefs.SetInt("transportUnit1", transportUnit1);
        }
    }
}
