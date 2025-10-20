using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharPlayer : MonoBehaviour
{
    private static int hp = 100;
    private static int maxhp = 100;
    private static int fd = 100;
    private static int maxfd = 100;
    private static int wr = 100;
    private static int maxwr = 100;
    private static int eg = 100;
    private static int maxeg = 100;
    private static int rd = 0;
    private static int af = 0;
    private static int at = 0;
    private static int ar = 0;    
    private static int dm = 0;
    private static float ms = 5;
    private static float mv = 25;
    private static float fv = 0;
    private static int cl = 0;

    public int hpP;
    public int fdP;
    public int wrP;
    public int egP;
    public int rdP;
    public int afP;
    public int atP;
    public int arP;
    public int dmP;
    public float msP;
    public float mvP;
    public float fvP;
    public int clP;

    private static int socks = 0;
    private static int boots = 0;
    private static int pants = 0;
    private static int gloves = 0;
    private static int lightClothing = 0;
    private static int faceMask = 0;
    private static int warmClothes = 0;
    private static int armor = 0;
    private static int unloadingVest = 0;
    private static int outerwear = 0;
    private static int backpack = 0;
    private static int glasses = 0;
    private static int headdress = 0;
    private static int transport = 0;

    public Text hpTx;
    public Text maxhpTx;
    public Text fdTx;
    public Text maxfdTx;
    public Text wrTx;
    public Text maxwrTx;
    public Text egTx;
    public Text maxegTx;
    public Text rdTx;
    public Text afTx;
    public Text atTx;
    public Text arTx;
    public Text msTx;
    public Text dmTx;
    public Text mvTx;

    public GameObject socks1;
    public GameObject boots1;
    public GameObject pants1;
    public GameObject gloves1;
    public GameObject lightClothing1;
    public GameObject faceMask1;
    public GameObject warmClothes1;
    public GameObject armor1;
    public GameObject unloadingVest1;
    public GameObject outerwear1;
    public GameObject backpack1;
    public GameObject glasses1;
    public GameObject headdress1;


    void Awake()
    {
        if (PlayerPrefs.HasKey("hp"))
        {
            hp = PlayerPrefs.GetInt("hp");
        }
        if (PlayerPrefs.HasKey("maxhp"))
        {
            maxhp = PlayerPrefs.GetInt("maxhp");
        }
        
        if (PlayerPrefs.HasKey("fd"))
        {
            fd = PlayerPrefs.GetInt("fd");
        }
        if (PlayerPrefs.HasKey("maxfd"))
        {
            maxfd = PlayerPrefs.GetInt("maxfd");
        }

        if (PlayerPrefs.HasKey("wr"))
        {
            wr = PlayerPrefs.GetInt("wr");
        }
        if (PlayerPrefs.HasKey("maxwr"))
        {
            maxwr = PlayerPrefs.GetInt("maxwr");
        }

        if (PlayerPrefs.HasKey("eg"))
        {
            eg = PlayerPrefs.GetInt("eg");
        }
        if (PlayerPrefs.HasKey("maxeg"))
        {
            maxeg = PlayerPrefs.GetInt("maxeg");
        }

        if (PlayerPrefs.HasKey("rd"))
        {
            rd = PlayerPrefs.GetInt("rd");
        }
        ///
        if (PlayerPrefs.HasKey("af"))
        {
            af = PlayerPrefs.GetInt("af");
        }
        if (PlayerPrefs.HasKey("at"))
        {
            at = PlayerPrefs.GetInt("at");
        }
        if (PlayerPrefs.HasKey("ar"))
        {
            ar = PlayerPrefs.GetInt("ar");
        }
        if (PlayerPrefs.HasKey("dm"))
        {
            dm = PlayerPrefs.GetInt("dm");
        }
        if (PlayerPrefs.HasKey("ms"))
        {
            ms = PlayerPrefs.GetFloat("ms");
        }
        if (PlayerPrefs.HasKey("mv"))
        {
            mv = PlayerPrefs.GetFloat("mv");
        }
        if (PlayerPrefs.HasKey("fv"))
        {
            fv = PlayerPrefs.GetFloat("fv");
        }
        if (PlayerPrefs.HasKey("cl"))
        {
            cl = PlayerPrefs.GetInt("cl");
        }


        if (PlayerPrefs.HasKey("socks"))
        {
            socks = PlayerPrefs.GetInt("socks");
        }
        if (PlayerPrefs.HasKey("boots"))
        {
            boots = PlayerPrefs.GetInt("boots");
        }
        if (PlayerPrefs.HasKey("pants"))
        {
            pants = PlayerPrefs.GetInt("pants");
        }
        if (PlayerPrefs.HasKey("gloves"))
        {
            gloves = PlayerPrefs.GetInt("gloves");
        }
        if (PlayerPrefs.HasKey("lightClothing"))
        {
            lightClothing = PlayerPrefs.GetInt("lightClothing");
        }
        if (PlayerPrefs.HasKey("faceMask"))
        {
            faceMask = PlayerPrefs.GetInt("faceMask");
        }
        if (PlayerPrefs.HasKey("warmClothes"))
        {
            warmClothes = PlayerPrefs.GetInt("warmClothes");
        }
        if (PlayerPrefs.HasKey("armor"))
        {
            armor = PlayerPrefs.GetInt("armor");
        }
        if (PlayerPrefs.HasKey("unloadingVest"))
        {
            unloadingVest = PlayerPrefs.GetInt("unloadingVest");
        }
        if (PlayerPrefs.HasKey("outerwear"))
        {
            outerwear = PlayerPrefs.GetInt("outerwear");
        }
        if (PlayerPrefs.HasKey("backpack"))
        {
            backpack = PlayerPrefs.GetInt("backpack");
        }
        if (PlayerPrefs.HasKey("glasses"))
        {
            glasses = PlayerPrefs.GetInt("glasses");
        }
        if (PlayerPrefs.HasKey("headdress"))
        {
            headdress = PlayerPrefs.GetInt("headdress");
        }
        if (PlayerPrefs.HasKey("transport"))
        {
            transport = PlayerPrefs.GetInt("transport");
        }

        hpP = hp;
        fdP = fd;
        wrP = wr;
        egP = eg;
        rdP = rd;
        afP = af;
        atP = at;
        arP = ar;
        dmP = dm;
        msP = ms;
        mvP = mv;
        fvP = fv;
        clP = cl;

        AllThing();
    }

    void Update()
    {
        hpTx.text = "" + HP;
        //maxhpTx.text = "" + maxHP;
        fdTx.text = "" + FD;
        //maxfdTx.text = "" + maxFD;
        wrTx.text = "" + WR;
        //maxwrTx.text = "" + maxWR;
        egTx.text = "" + EG;
        //maxegTx.text = "" + maxEG;
        rdTx.text = "" + RD;
        afTx.text = "" + AF;
        atTx.text = "" + AT;
        arTx.text = "" + AR;
        dmTx.text = "" + DM;
        msTx.text = "" + MS;
        mvTx.text = FV.ToString("0.0") + " / " + MV.ToString("0.0");
    }

    public void ByDefault()
    {
        AF = 0;
        AT = 0;
        AR = 0;
        DM = 0;
        MS = 5;
        MV = 25;
    }

    public void CloseSocks()
    {
        switch (Socks)
        {
            case 0:
                Socks = 0;
                socks1.SetActive(false);
                break;
        }
    }

    public void ActiveSocks()
    {
        switch (Socks)
        {
            case 0:
                CloseSocks();
                break;
            case 1:
                CloseSocks();
                Socks = 1;
                socks1.SetActive(true);
                break;
        }
    }

    public void CloseBoots()
    {
        switch (Boots)
        {
            case 0:
                Boots = 0;
                boots1.SetActive(false);
                break;
        }
    }

    public void ActiveBoots()
    {
        switch (Boots)
        {
            case 0:
                CloseBoots();
                break;
            case 1:
                CloseBoots();
                Boots = 1;
                boots1.SetActive(true);
                break;
        }
    }

    public void ClosePants()
    {
        switch (Pants)
        {
            case 0:
                Pants = 0;
                pants1.SetActive(false);
                break;
        }
    }

    public void ActivePants()
    {
        switch (Pants)
        {
            case 0:
                ClosePants();
                break;
            case 1:
                ClosePants();
                Pants = 1;
                pants1.SetActive(true);
                break;
        }
    }

    public void CloseGloves()
    {
        switch (Gloves)
        {
            case 0:
                Gloves = 0;
                gloves1.SetActive(false);
                break;
        }
    }

    public void ActiveGloves()
    {
        switch (Gloves)
        {
            case 0:
                CloseGloves();
                break;
            case 1:
                CloseGloves();
                Gloves = 1;
                gloves1.SetActive(true);
                break;
        }
    }

    public void CloseLightClothing()
    {
        switch (LightClothing)
        {
            case 0:
                LightClothing = 0;
                lightClothing1.SetActive(false);
                break;
        }
    }

    public void ActiveLightClothing()
    {
        switch (LightClothing)
        {
            case 0:
                CloseLightClothing();
                break;
            case 1:
                CloseLightClothing();
                LightClothing = 1;
                lightClothing1.SetActive(true);
                break;
        }
    }

    public void CloseFaceMask()
    {
        switch (FaceMask)
        {
            case 0:
                FaceMask = 0;
                faceMask1.SetActive(false);
                break;
        }
    }

    public void ActiveFaceMask()
    {
        switch (FaceMask)
        {
            case 0:
                CloseFaceMask();
                break;
            case 1:
                CloseFaceMask();
                FaceMask = 1;
                faceMask1.SetActive(true);
                break;
        }
    }

    public void CloseWarmClothes()
    {
        switch (WarmClothes)
        {
            case 0:
                WarmClothes = 0;
                warmClothes1.SetActive(false);
                break;
        }
    }

    public void ActiveWarmClothes()
    {
        switch (WarmClothes)
        {
            case 0:
                CloseWarmClothes();
                break;
            case 1:
                CloseWarmClothes();
                WarmClothes = 1;
                warmClothes1.SetActive(true);
                break;
        }
    }
    public void CloseArmor()
    {
        switch (Armor)
        {
            case 0:
                Armor = 0;
                armor1.SetActive(false);
                break;
        }
    }

    public void ActiveArmor()
    {
        switch (Armor)
        {
            case 0:
                CloseArmor();
                break;
            case 1:
                CloseArmor();
                Armor = 1;
                armor1.SetActive(true);
                break;
        }
    }

    public void CloseUnloadingVest()
    {
        switch (UnloadingVest)
        {
            case 0:
                UnloadingVest = 0;
                unloadingVest1.SetActive(false);
                break;
        }
    }

    public void ActiveUnloadingVest()
    {
        switch (UnloadingVest)
        {
            case 0:
                CloseUnloadingVest();
                break;
            case 1:
                CloseUnloadingVest();
                UnloadingVest = 1;
                unloadingVest1.SetActive(true);
                break;
        }
    }

    public void CloseOuterwear()
    {
        switch (Outerwear)
        {
            case 0:
                Outerwear = 0;
                outerwear1.SetActive(false);
                break;
        }
    }

    public void ActiveOuterwear()
    {
        switch (Outerwear)
        {
            case 0:
                CloseOuterwear();
                break;
            case 1:
                CloseOuterwear();
                Outerwear = 1;
                outerwear1.SetActive(true);
                break;
        }
    }

    public void CloseBackpack()
    {
        switch (Backpack)
        {
            case 0:
                Backpack = 0;
                backpack1.SetActive(false);
                break;
        }
    }

    public void ActiveBackpack()
    {
        switch (Backpack)
        {
            case 0:
                CloseBackpack();
                break;
            case 1:
                CloseBackpack();
                Backpack = 1;
                backpack1.SetActive(true);
                break;
        }
    }

    public void CloseGlasses()
    {
        switch (Glasses)
        {
            case 0:
                Glasses = 0;
                glasses1.SetActive(false);
                break;
        }
    }

    public void ActiveGlasses()
    {
        switch (Glasses)
        {
            case 0:
                CloseGlasses();
                break;
            case 1:
                CloseGlasses();
                Glasses = 1;
                glasses1.SetActive(true);
                break;
        }
    }

    public void CloseHeaddress()
    {
        switch (Headdress)
        {
            case 0:
                Headdress = 0;
                headdress1.SetActive(false);
                break;
        }
    }

    public void ActiveHeaddress()
    {
        switch (Headdress)
        {
            case 0:
                CloseHeaddress();
                break;
            case 1:
                CloseHeaddress();
                Headdress = 1;
                headdress1.SetActive(true);
                break;
        }
    }

    public void AllThing()
    {
        ActiveSocks();
        ActiveBoots();
        ActivePants();
        ActiveGloves();
        ActiveLightClothing();
        ActiveFaceMask();
        ActiveWarmClothes();
        ActiveArmor();
        ActiveUnloadingVest();
        ActiveOuterwear();
        ActiveBackpack();
        ActiveGlasses();
        ActiveHeaddress();
    }

    ///
	public static int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            PlayerPrefs.SetInt("hp", hp);
        }
    }
    ///
	public static int maxHP
    {
        get
        {
            return maxhp;
        }
        set
        {
            maxhp = value;
            PlayerPrefs.SetInt("maxhp", maxhp);
        }
    }
    ///
	public static int FD
    {
        get
        {
            return fd;
        }
        set
        {
            fd = value;
            PlayerPrefs.SetInt("fd", fd);
        }
    }
    ///
	public static int maxFD
    {
        get
        {
            return maxfd;
        }
        set
        {
            maxfd = value;
            PlayerPrefs.SetInt("maxfd", maxfd);
        }
    }
    ///
	public static int WR
    {
        get
        {
            return wr;
        }
        set
        {
            wr = value;
            PlayerPrefs.SetInt("wr", wr);
        }
    }
    ///
	public static int maxWR
    {
        get
        {
            return maxwr;
        }
        set
        {
            maxwr = value;
            PlayerPrefs.SetInt("maxwr", maxwr);
        }
    }
    ///
	public static int EG
    {
        get
        {
            return eg;
        }
        set
        {
            eg = value;
            PlayerPrefs.SetInt("eg", eg);
        }
    }
    ///
    public static int maxEG
    {
        get
        {
            return maxeg;
        }
        set
        {
            maxeg = value;
            PlayerPrefs.SetInt("maxeg", maxeg);
        }
    }
    ///
	public static int RD
    {
        get
        {
            return rd;
        }
        set
        {
            rd = value;
            PlayerPrefs.SetInt("rd", rd);
        }
    }
    /// ///////////////////////////////////////////////////////////////////////////////
    ///
    public static int AF
    {
        get
        {
            return af;
        }
        set
        {
            af = value;
            PlayerPrefs.SetInt("af", af);
        }
    }
    ///
	public static int AT
    {
        get
        {
            return at;
        }
        set
        {
            at = value;
            PlayerPrefs.SetInt("at", at);
        }
    }
    ///
	public static int AR
    {
        get
        {
            return ar;
        }
        set
        {
            ar = value;
            PlayerPrefs.SetInt("ar", ar);
        }
    }
    ///
	public static int DM
    {
        get
        {
            return dm;
        }
        set
        {
            dm = value;
            PlayerPrefs.SetInt("dm", dm);
        }
    }
    ///
	public static float MS
    {
        get
        {
            return ms;
        }
        set
        {
            ms = value;
            PlayerPrefs.SetFloat("ms", ms);
        }
    }
    ///
	public static float MV
    {
        get
        {
            return mv;
        }
        set
        {
            mv = value;
            PlayerPrefs.SetFloat("mv", mv);
        }
    }
    ///
	public static float FV
    {
        get
        {
            return fv;
        }
        set
        {
            fv = value;
            PlayerPrefs.SetFloat("fv", fv);
        }
    }
    ///
	public static int CL
    {
        get
        {
            return cl;
        }
        set
        {
            cl = value;
            PlayerPrefs.SetInt("cl", cl);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
    ///
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
}
