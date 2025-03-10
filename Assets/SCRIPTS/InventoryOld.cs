using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOld: MonoBehaviour
{
    public GameObject pnlInvent;
    public GameObject pnlInventEcip;
    //public Text nameEcip;
    ////public Text descriptionEcip;
    //public Text afTx;
    //public Text atTx;
    //public Text arTx;
    //public Text dmTx;
    //public Text msTx;
    //public Text mvTx;
    //public Text fvTx;
    //public Text clTx;

    public string ecipName;

    public static string socks = "s1";
    public static string boots = "b1";
    public static string pants = "p1";
    public static string gloves = "false";
    public static string lightClothing = "l1";
    public static string faceMask = "false";
    public static string warmClothes = "false";
    public static string armor = "false";
    public static string unloadingVest = "false";
    public static string outerwear = "false";
    public static string backpack = "false";
    public static string glasses = "false";
    public static string headdress = "false";
    public static string transport = "false";

    public string soc;
    public string boo;
    public string pan;
    public string glov;
    public string lightClot;
    public string faceM;
    public string warmClot;
    public string arm;
    public string unloadingV;
    public string outerw;
    public string backp;
    public string glass;
    public string headdr;
    public string transp;

    //public GameObject dAF, dAT, dAR, dMS, dMV, dFV, dDM, dCL;

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

    private static string s;
    private static string b;
    private static string p;
    private static string g;
    private static string l;
    private static string f;
    private static string w;
    private static string a;
    private static string u;
    private static string o;
    private static string bp;
    private static string gla;
    private static string h;
    private static string t;

    void Start()
    {
        ClotheThing();
        ActiveITA();
    }

    void Update()
    {
        soc = socks;
        boo = boots;
        pan = pants;
        glov = gloves;
        lightClot = lightClothing;
        faceM = faceMask;
        warmClot = warmClothes;
        arm = armor;
        unloadingV = unloadingVest;
        outerw = outerwear;
        backp = backpack;
        glass = glasses;
        headdr = headdress;
    }

    public void InventrThingActive(string ITA)
    {
        switch (ITA)
        {
            case "s1":
                socks1i.SetActive(true);
                break;
            case "b1":
                boots1i.SetActive(true);
                break;
            case "p1":
                pants1i.SetActive(true);
                break;
            case "g1":
                gloves1i.SetActive(true);
                break;
            case "l1":
                lightClothing1i.SetActive(true);
                break;
            case "f1":
                faceMask1i.SetActive(true);
                break;
            case "w1":
                warmClothes1i.SetActive(true);
                break;
            case "a1":
                armor1i.SetActive(true);
                break;
            case "u1":
                unloadingVest1i.SetActive(true);
                break;
            case "o1":
                outerwear1i.SetActive(true);
                break;
            case "bp1":
                backpack1i.SetActive(true);
                break;
            case "gla1":
                glasses1i.SetActive(true);
                break;
            case "h1":
                headdress1i.SetActive(true);
                break;
        }
    }

    public void InventrThingDrop(string ITD)
    {
        switch (ITD)
        {
            case "s1":
                socks1i.SetActive(false);
                break;
            case "b1":
                boots1i.SetActive(false);
                break;
            case "p1":
                pants1i.SetActive(false);
                break;
            case "g1":
                gloves1i.SetActive(false);
                break;
            case "l1":
                lightClothing1i.SetActive(false);
                break;
            case "f1":
                faceMask1i.SetActive(false);
                break;
            case "w1":
                warmClothes1i.SetActive(false);
                break;
            case "a1":
                armor1i.SetActive(false);
                break;
            case "u1":
                unloadingVest1i.SetActive(false);
                break;
            case "o1":
                outerwear1i.SetActive(false);
                break;
            case "bp1":
                backpack1i.SetActive(false);
                break;
            case "gla1":
                glasses1i.SetActive(false);
                break;
            case "h1":
                headdress1i.SetActive(false);
                break;
        }
    }

    public void ActiveITA()
    {
        switch (SockS)
        {
            case "false":
                socks1i.SetActive(false);
                break;
            case "s1":
                socks1i.SetActive(true);
                break;
        }
        switch (BootS)
        {
            case "false":
                boots1i.SetActive(false);
                break;
            case "b1":
                boots1i.SetActive(true);
                break;
        }
        switch (PantS)
        {
            case "false":
                pants1i.SetActive(false);
                break;
            case "p1":
                pants1i.SetActive(true);
                break;
        }
        switch (GloveS)
        {
            case "false":
                gloves1i.SetActive(false);
                break;
            case "g1":
                gloves1i.SetActive(true);
                break;
        }
        switch (LightClothinG)
        {
            case "false":
                lightClothing1i.SetActive(false);
                break;
            case "l1":
                lightClothing1i.SetActive(true);
                break;
        }
        switch (FaceMasK)
        {
            case "false":
                faceMask1i.SetActive(false);
                break;
            case "f1":
                faceMask1i.SetActive(true);
                break;
        }
        switch (WarmClotheS)
        {
            case "false":
                warmClothes1i.SetActive(false);
                break;
            case "w1":
                warmClothes1i.SetActive(true);
                break;
        }
        switch (ArmoR)
        {
            case "false":
                armor1i.SetActive(false);
                break;
            case "a1":
                armor1i.SetActive(true);
                break;
        }
        switch (UnloadingVesT)
        {
            case "false":
                unloadingVest1i.SetActive(false);
                break;
            case "u1":
                unloadingVest1i.SetActive(true);
                break;
        }
        switch (OuterweaR)
        {
            case "false":
                outerwear1i.SetActive(false);
                break;
            case "o1":
                outerwear1i.SetActive(true);
                break;
        }
        switch (BackpacK)
        {
            case "false":
                backpack1i.SetActive(false);
                break;
            case "bp1":
                backpack1i.SetActive(true);
                break;
        }
        switch (GlasseS)
        {
            case "false":
                glasses1i.SetActive(false);
                break;
            case "gla1":
                glasses1i.SetActive(true);
                break;
        }
        switch (HeaddresS)
        {
            case "false":
                headdress1i.SetActive(false);
                break;
            case "h1":
                headdress1i.SetActive(true);
                break;
        }
    }

    public void DeactiveITA()
    {
        switch (SockS)
        {
            case "false":
                socks1i.SetActive(false);
                break;
        }
        switch (BootS)
        {
            case "false":
                boots1i.SetActive(false);
                break;
        }
        switch (PantS)
        {
            case "false":
                pants1i.SetActive(false);
                break;
        }
        switch (GloveS)
        {
            case "false":
                gloves1i.SetActive(false);
                break;
        }
        switch (LightClothinG)
        {
            case "false":
                lightClothing1i.SetActive(false);
                break;
        }
        switch (FaceMasK)
        {
            case "false":
                faceMask1i.SetActive(false);
                break;
        }
        switch (WarmClotheS)
        {
            case "false":
                warmClothes1i.SetActive(false);
                break;
        }
        switch (ArmoR)
        {
            case "false":
                armor1i.SetActive(false);
                break;
        }
        switch (UnloadingVesT)
        {
            case "false":
                unloadingVest1i.SetActive(false);
                break;
        }
        switch (OuterweaR)
        {
            case "false":
                outerwear1i.SetActive(false);
                break;
        }
        switch (BackpacK)
        {
            case "false":
                backpack1i.SetActive(false);
                break;
        }
        switch (GlasseS)
        {
            case "false":
                glasses1i.SetActive(false);
                break;
        }
        switch (HeaddresS)
        {
            case "false":
                headdress1i.SetActive(false);
                break;
        }
    }

    public void ClosePnlInventEcip()
    {
        pnlInvent.SetActive(false);
        pnlInventEcip.SetActive(false);
    }

    public void ÑhoiceThing(string btnEcipName)
    {
        pnlInvent.SetActive(true);
        ecipName = btnEcipName;
    }

    public void ÑhoiceThingEcip(string btnEcipName)
    {
        pnlInventEcip.SetActive(true);
        ecipName = btnEcipName;
    }

    public void DropThing()
    {
        switch (ecipName)
        {
            case "s1":
                socks1.SetActive(false);
                socks1i.SetActive(false);
                SockS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "b1":
                boots1.SetActive(false);
                boots1i.SetActive(false);
                BootS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "p1":
                pants1.SetActive(false);
                pants1i.SetActive(false);
                PantS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "g1":
                gloves1.SetActive(false);
                gloves1i.SetActive(false);
                GloveS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "l1":
                lightClothing1.SetActive(false);
                lightClothing1i.SetActive(false);
                LightClothinG = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "f1":
                faceMask1.SetActive(false);
                faceMask1i.SetActive(false);
                FaceMasK = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "w1":
                warmClothes1.SetActive(false);
                warmClothes1i.SetActive(false);
                WarmClotheS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "a1":
                armor1.SetActive(false);
                armor1i.SetActive(false);
                ArmoR = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "u1":
                unloadingVest1.SetActive(false);
                unloadingVest1i.SetActive(false);
                UnloadingVesT = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "o1":
                outerwear1.SetActive(false);
                outerwear1i.SetActive(false);
                OuterweaR = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "bp1":
                backpack1.SetActive(false);
                backpack1i.SetActive(false);
                BackpacK = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "gla1":
                glasses1.SetActive(false);
                glasses1i.SetActive(false);
                GlasseS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "h1":
                headdress1.SetActive(false);
                headdress1i.SetActive(false);
                HeaddresS = "false";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
        }            
    }

    public void ClotheThing()
    {
        switch (ecipName)
        {
            case "s1":
                socks1.SetActive(true);
                socks1i.SetActive(false);
                CharPlayer.Socks = 1;
                S = "1";
                pnlInvent.SetActive(false);
                break;
            case "b1":
                boots1.SetActive(true);
                boots1i.SetActive(false);
                CharPlayer.Boots = 1;
                B = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "p1":
                pants1.SetActive(true);
                pants1i.SetActive(false);
                CharPlayer.Pants = 1;
                P = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "g1":
                gloves1.SetActive(true);
                gloves1i.SetActive(false);
                CharPlayer.Gloves = 1;
                G = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "l1":
                lightClothing1.SetActive(true);
                lightClothing1i.SetActive(false);
                CharPlayer.LightClothing = 1;
                L = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "f1":
                faceMask1.SetActive(true);
                faceMask1i.SetActive(false);
                CharPlayer.FaceMask = 1;
                F = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "w1":
                warmClothes1.SetActive(true);
                warmClothes1i.SetActive(false);
                CharPlayer.WarmClothes = 1;
                W = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "a1":
                armor1.SetActive(true);
                armor1i.SetActive(false);
                CharPlayer.Armor = 1;
                A = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "u1":
                unloadingVest1.SetActive(true);
                unloadingVest1i.SetActive(false);
                CharPlayer.UnloadingVest = 1;
                U = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "o1":
                outerwear1.SetActive(true);
                outerwear1i.SetActive(false);
                CharPlayer.Outerwear = 1;
                O = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "bp1":
                backpack1.SetActive(true);
                backpack1i.SetActive(false);
                CharPlayer.Backpack = 1;
                BP = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "gla1":
                glasses1.SetActive(true);
                glasses1i.SetActive(false);
                CharPlayer.Glasses = 1;
                GLA = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "h1":
                headdress1.SetActive(true);
                headdress1i.SetActive(false);
                CharPlayer.Headdress = 1;
                H = "1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
        }
        switch (S)
        {
            case "1":
                socks1.SetActive(true);
                socks1i.SetActive(false);
                CharPlayer.Socks = 1;
                S = "1";
                break;
        }
        switch (B)
        {
            case "1":
                boots1.SetActive(true);
                boots1i.SetActive(false);
                CharPlayer.Boots = 1;
                B = "1";
                break;
        }
        switch (P)
        {
            case "1":
                pants1.SetActive(true);
                pants1i.SetActive(false);
                CharPlayer.Pants = 1;
                P = "1";
                break;
        }
        switch (G)
        {
            case "1":
                gloves1.SetActive(true);
                gloves1i.SetActive(false);
                CharPlayer.Gloves = 1;
                G = "1";
                break;
        }
        switch (L)
        {
            case "1":
                lightClothing1.SetActive(true);
                lightClothing1i.SetActive(false);
                CharPlayer.LightClothing = 1;
                L = "1";
                break;
        }
        switch (F)
        {
            case "1":
                faceMask1.SetActive(true);
                faceMask1i.SetActive(false);
                CharPlayer.FaceMask = 1;
                F = "1";
                break;
        }
        switch (W)
        {
            case "1":
                warmClothes1.SetActive(true);
                warmClothes1i.SetActive(false);
                CharPlayer.WarmClothes = 1;
                W = "1";
                break;
        }
        switch (A)
        {
            case "1":
                armor1.SetActive(true);
                armor1i.SetActive(false);
                CharPlayer.Armor = 1;
                A = "1";
                break;
        }
        switch (U)
        {
            case "1":
                unloadingVest1.SetActive(true);
                unloadingVest1i.SetActive(false);
                CharPlayer.UnloadingVest = 1;
                U = "1";
                break;
        }
        switch (O)
        {
            case "1":
                outerwear1.SetActive(true);
                outerwear1i.SetActive(false);
                CharPlayer.Outerwear = 1;
                O = "1";
                break;
        }
        switch (BP)
        {
            case "1":
                backpack1.SetActive(true);
                backpack1i.SetActive(false);
                CharPlayer.Backpack = 1;
                BP = "1";
                break;
        }
        switch (GLA)
        {
            case "1":
                glasses1.SetActive(true);
                glasses1i.SetActive(false);
                CharPlayer.Glasses = 1;
                GLA = "1";
                break;
        }
        switch (H)
        {
            case "1":
                headdress1.SetActive(true);
                headdress1i.SetActive(false);
                CharPlayer.Headdress = 1;
                H = "1";
                break;
        }
    }

    public void TakeOff()
    {
        switch (ecipName)
        {
            case "s1":
                socks1.SetActive(false);
                socks1i.SetActive(true);
                CharPlayer.Socks = 0;
                S = "0";
                socks = "s1";
                pnlInventEcip.SetActive(false);
                break;
            case "b1":
                boots1.SetActive(false);
                boots1i.SetActive(true);
                CharPlayer.Boots = 0;
                B = "0";
                BootS = "b1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "p1":
                pants1.SetActive(false);
                pants1i.SetActive(true);
                CharPlayer.Pants = 0;
                P = "0";
                PantS = "p1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "g1":
                gloves1.SetActive(false);
                gloves1i.SetActive(true);
                CharPlayer.Gloves = 0;
                G = "0";
                GloveS = "g1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "l1":
                lightClothing1.SetActive(false);
                lightClothing1i.SetActive(true);
                CharPlayer.LightClothing = 0;
                L = "0";
                LightClothinG = "l1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "f1":
                faceMask1.SetActive(false);
                faceMask1i.SetActive(true);
                CharPlayer.FaceMask = 0;
                F = "0";
                FaceMasK = "f1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "w1":
                warmClothes1.SetActive(false);
                warmClothes1i.SetActive(true);
                CharPlayer.WarmClothes = 0;
                W = "0";
                WarmClotheS = "w1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "a1":
                armor1.SetActive(false);
                armor1i.SetActive(true);
                CharPlayer.Armor = 0;
                A = "0";
                ArmoR = "a1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "u1":
                unloadingVest1.SetActive(false);
                unloadingVest1i.SetActive(true);
                CharPlayer.UnloadingVest = 0;
                U = "0";
                UnloadingVesT = "u1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "o1":
                outerwear1.SetActive(false);
                outerwear1i.SetActive(true);
                CharPlayer.Outerwear = 0;
                O = "0";
                OuterweaR = "o1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "bp1":
                backpack1.SetActive(false);
                backpack1i.SetActive(true);
                CharPlayer.Backpack = 0;
                BP = "0";
                BackpacK = "bp1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "gla1":
                glasses1.SetActive(false);
                glasses1i.SetActive(true);
                CharPlayer.Glasses = 0;
                GLA = "0";
                GlasseS = "gla1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
            case "h1":
                headdress1.SetActive(false);
                headdress1i.SetActive(true);
                CharPlayer.Headdress = 0;
                H = "0";
                HeaddresS = "h1";
                pnlInvent.SetActive(false);
                pnlInventEcip.SetActive(false);
                break;
        }
    }



    void Awake()
    {
        if (PlayerPrefs.HasKey("s"))
        {
            s = PlayerPrefs.GetString("s");
        }
        if (PlayerPrefs.HasKey("b"))
        {
            b = PlayerPrefs.GetString("b");
        }
        if (PlayerPrefs.HasKey("p"))
        {
            p = PlayerPrefs.GetString("p");
        }
        if (PlayerPrefs.HasKey("g"))
        {
            g = PlayerPrefs.GetString("g");
        }
        if (PlayerPrefs.HasKey("l"))
        {
            l = PlayerPrefs.GetString("l");
        }
        if (PlayerPrefs.HasKey("f"))
        {
            f = PlayerPrefs.GetString("f");
        }
        if (PlayerPrefs.HasKey("w"))
        {
            w = PlayerPrefs.GetString("w");
        }
        if (PlayerPrefs.HasKey("a"))
        {
            a = PlayerPrefs.GetString("a");
        }
        if (PlayerPrefs.HasKey("u"))
        {
            u = PlayerPrefs.GetString("u");
        }
        if (PlayerPrefs.HasKey("o"))
        {
            o = PlayerPrefs.GetString("o");
        }
        if (PlayerPrefs.HasKey("bp"))
        {
            bp = PlayerPrefs.GetString("bp");
        }
        if (PlayerPrefs.HasKey("gla"))
        {
            gla = PlayerPrefs.GetString("gla");
        }
        if (PlayerPrefs.HasKey("h"))
        {
            h = PlayerPrefs.GetString("h");
        }
        if (PlayerPrefs.HasKey("t"))
        {
            t = PlayerPrefs.GetString("t");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        if (PlayerPrefs.HasKey("socks"))
        {
            socks = PlayerPrefs.GetString("socks");
        }
        if (PlayerPrefs.HasKey("boots"))
        {
            boots = PlayerPrefs.GetString("boots");
        }
        if (PlayerPrefs.HasKey("pants"))
        {
            pants = PlayerPrefs.GetString("pants");
        }
        if (PlayerPrefs.HasKey("gloves"))
        {
            gloves = PlayerPrefs.GetString("gloves");
        }
        if (PlayerPrefs.HasKey("lightClothing"))
        {
            lightClothing = PlayerPrefs.GetString("lightClothing");
        }
        if (PlayerPrefs.HasKey("faceMask"))
        {
            faceMask = PlayerPrefs.GetString("faceMask");
        }
        if (PlayerPrefs.HasKey("warmClothes"))
        {
            warmClothes = PlayerPrefs.GetString("warmClothes");
        }
        if (PlayerPrefs.HasKey("armor"))
        {
            armor = PlayerPrefs.GetString("armor");
        }
        if (PlayerPrefs.HasKey("unloadingVest"))
        {
            unloadingVest = PlayerPrefs.GetString("unloadingVest");
        }
        if (PlayerPrefs.HasKey("outerwear"))
        {
            outerwear = PlayerPrefs.GetString("outerwear");
        }
        if (PlayerPrefs.HasKey("backpack"))
        {
            backpack = PlayerPrefs.GetString("backpack");
        }
        if (PlayerPrefs.HasKey("glasses"))
        {
            glasses = PlayerPrefs.GetString("glasses");
        }
        if (PlayerPrefs.HasKey("headdress"))
        {
            headdress = PlayerPrefs.GetString("headdress");
        }
        if (PlayerPrefs.HasKey("transport"))
        {
            transport = PlayerPrefs.GetString("transport");
        }

        //SockS = socks;
        //BootS = boots;
        //PantS = pants;
        //GloveS = gloves;
        //LightClothinG = lightClothing;
        //FaceMasK = faceMask;
        //WarmClotheS = warmClothes;
        //ArmoR = armor;
        //UnloadingVesT = unloadingVest;
        //OuterweaR = outerwear;
        //BackpacK = backpack;
        //GlasseS = glasses;
        //HeaddresS = headdress;
    }

    public static string S
    {
        get
        {
            return s;
        }
        set
        {
            s = value;
            PlayerPrefs.SetString("s", s);
        }
    }
    ///
    public static string B
    {
        get
        {
            return b;
        }
        set
        {
            b = value;
            PlayerPrefs.SetString("b", b);
        }
    }
    ///
    public static string P
    {
        get
        {
            return p;
        }
        set
        {
            p = value;
            PlayerPrefs.SetString("p", p);
        }
    }
    ///
    public static string G
    {
        get
        {
            return g;
        }
        set
        {
            g = value;
            PlayerPrefs.SetString("g", g);
        }
    }
    ///
    public static string L
    {
        get
        {
            return l;
        }
        set
        {
            l = value;
            PlayerPrefs.SetString("l", l);
        }
    }
    ///
    public static string F
    {
        get
        {
            return f;
        }
        set
        {
            f = value;
            PlayerPrefs.SetString("f", f);
        }
    }
    ///
    public static string W
    {
        get
        {
            return w;
        }
        set
        {
            w = value;
            PlayerPrefs.SetString("w", w);
        }
    }
    ///
    public static string A
    {
        get
        {
            return a;
        }
        set
        {
            a = value;
            PlayerPrefs.SetString("a", a);
        }
    }
    ///
    public static string U
    {
        get
        {
            return u;
        }
        set
        {
            u = value;
            PlayerPrefs.SetString("u", u);
        }
    }
    ///
    public static string O
    {
        get
        {
            return o;
        }
        set
        {
            o = value;
            PlayerPrefs.SetString("o", o);
        }
    }
    ///
    public static string BP
    {
        get
        {
            return bp;
        }
        set
        {
            bp = value;
            PlayerPrefs.SetString("bp", bp);
        }
    }
    ///
    public static string GLA
    {
        get
        {
            return gla;
        }
        set
        {
            gla = value;
            PlayerPrefs.SetString("gla", gla);
        }
    }
    ///
    public static string H
    {
        get
        {
            return h;
        }
        set
        {
            h = value;
            PlayerPrefs.SetString("h", h);
        }
    }
    ///
    public static string T
    {
        get
        {
            return t;
        }
        set
        {
            t = value;
            PlayerPrefs.SetString("t", t);
        }
    }
    /////////////////////////////////////////////////////////////////////
    public static string SockS
    {
        get
        {
            return socks;
        }
        set
        {
            socks = value;
            PlayerPrefs.SetString("socks", socks);
        }
    }
    public static string BootS
    {
        get
        {
            return boots;
        }
        set
        {
            boots = value;
            PlayerPrefs.SetString("boots", boots);
        }
    }
    public static string PantS
    {
        get
        {
            return pants;
        }
        set
        {
            pants = value;
            PlayerPrefs.SetString("pants", pants);
        }
    }
    public static string GloveS
    {
        get
        {
            return gloves;
        }
        set
        {
            gloves = value;
            PlayerPrefs.SetString("gloves", gloves);
        }
    }
    public static string LightClothinG
    {
        get
        {
            return lightClothing;
        }
        set
        {
            lightClothing = value;
            PlayerPrefs.SetString("lightClothing", lightClothing);
        }
    }
    public static string FaceMasK
    {
        get
        {
            return faceMask;
        }
        set
        {
            faceMask = value;
            PlayerPrefs.SetString("faceMask", faceMask);
        }
    }
    public static string WarmClotheS
    {
        get
        {
            return warmClothes;
        }
        set
        {
            warmClothes = value;
            PlayerPrefs.SetString("warmClothes", warmClothes);
        }
    }
    public static string ArmoR
    {
        get
        {
            return armor;
        }
        set
        {
            armor = value;
            PlayerPrefs.SetString("armor", armor);
        }
    }
    public static string UnloadingVesT
    {
        get
        {
            return unloadingVest;
        }
        set
        {
            unloadingVest = value;
            PlayerPrefs.SetString("unloadingVest", unloadingVest);
        }
    }
    public static string OuterweaR
    {
        get
        {
            return outerwear;
        }
        set
        {
            outerwear = value;
            PlayerPrefs.SetString("outerwear", outerwear);
        }
    }
    public static string BackpacK
    {
        get
        {
            return backpack;
        }
        set
        {
            backpack = value;
            PlayerPrefs.SetString("backpack", backpack);
        }
    }
    public static string GlasseS
    {
        get
        {
            return glasses;
        }
        set
        {
            glasses = value;
            PlayerPrefs.SetString("glasses", glasses);
        }
    }
    public static string HeaddresS
    {
        get
        {
            return headdress;
        }
        set
        {
            headdress = value;
            PlayerPrefs.SetString("headdress", headdress);
        }
    }
    public static string TransporT
    {
        get
        {
            return transport;
        }
        set
        {
            transport = value;
            PlayerPrefs.SetString("transport", transport);
        }
    }
}
