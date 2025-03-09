//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.Universal;

//using TMPro; // using text mesh for the clock display

//using UnityEngine.Rendering; // used to access the volume component

public class DayNightScript : MonoBehaviour
{
    private static int mins;
    private static int hours = 8;
    private static int days = 1;

    public Text timeDisplay; // Display Time
    public Text dayDisplay; // Display Day
    //public Volume ppv; // this is the post processing volume

    //public Light2D lights;    

    public float tick; // Increasing the tick, increases second rate
    public float seconds;
    public int minS;
    public int hourS;
    public int dayS;

    public GameObject iDay;
    public GameObject iNight;

    public bool activateLights; // checks if lights are on
    //public GameObject[] lights; // all the lights we want on when its dark
    public SpriteRenderer[] stars; // star sprites 
    // Start is called before the first frame update
    void Start()
    {
        //lights = gameObject.GetComponent<Light2D>();

        if (PlayerPrefs.HasKey("mins"))
        {
            mins = PlayerPrefs.GetInt("mins");
        }
        ///
		if (PlayerPrefs.HasKey("hours"))
        {
            hours = PlayerPrefs.GetInt("hours");
        }
        ///
        if (PlayerPrefs.HasKey("days"))
        {
            days = PlayerPrefs.GetInt("days");
        }

        minS = Mins;
        hourS = Hours;
        dayS = Days;

        dayActive();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
        DisplayTime();
        Mins = minS;
        Hours = hourS;
        Days = dayS;
        dayActive();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            minS += 1;
        }

        if (minS >= 60) //60 min = 1 hr
        {
            minS = 0;
            hourS += 1;
        }

        if (hourS >= 24) //24 hr = 1 day
        {
            hourS = 0;
            dayS += 1;
        }
        //ControlPPV(); // changes post processing volume after calculation
    } 
    
    public void dayActive()
    {
        if (hourS <= 6)
        {
            iDay.SetActive(false);
            iNight.SetActive(true);
        }
        else if (hourS >= 6 && hourS <= 21)
        {
            iDay.SetActive(true);
            iNight.SetActive(false);
        }
        else if (hourS >= 21)
        {
            iDay.SetActive(false);
            iNight.SetActive(true);
        }
    }

    public void DisplayTime() // Shows time and day in ui
    {

        timeDisplay.text = string.Format("{0:00}:{1:00}", hourS, minS); // The formatting ensures that there will always be 0's in empty spaces


        if (Language.SelectLanguage == 1)
            dayDisplay.text = "демэ " + dayS;
        else if(Language.SelectLanguage == 2)
            dayDisplay.text = "DAY " + dayS; // display day counter
    }

    ///
	public static int Mins
    {
        get
        {
            return mins;
        }
        set
        {
            mins = value;
            PlayerPrefs.SetInt("mins", mins);
        }
    }
    ///
    public static int Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = value;
            PlayerPrefs.SetInt("hours", hours);
        }
    }
    ///
    public static int Days
    {
        get
        {
            return days;
        }
        set
        {
            days = value;
            PlayerPrefs.SetInt("days", days);
        }
    }


    //public void ControlPPV() // used to adjust the post processing slider.
    //{
    //    //ppv.weight = 0;
    //    if (hours >= 21 && hours < 22 && lights.intensity >= 0.2f) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
    //    {
    //        lights.intensity = 1 - (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 
    //        for (int i = 0; i < stars.Length; i++)
    //        {
    //            stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, 1 - (float)mins / 60); // change the alpha value of the stars so they become visible
    //        }
    //    }


    //    if (hours >= 6 && hours < 7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
    //    {
    //        lights.intensity = 0.2f + (float)mins / 60; // we minus 1 because we want it to go from 1 - 0
    //        for (int i = 0; i < stars.Length; i++)
    //        {
    //            stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, (float)mins / 60); // make stars invisible
    //        }
    //    }

    //    if (hours == 21 && mins >= 20)
    //    {
    //        //OnLights();
    //    }
    //    if (hours == 6 && mins >= 20)
    //    {
    //        //OffLights();
    //    }
    //}    
}