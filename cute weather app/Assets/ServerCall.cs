using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerCall : MonoBehaviour
{
    public GameObject CloudAtNight;
    public GameObject CloudSunny;
    public GameObject Cloudy;
    public GameObject CloudyRain;
    public GameObject Fog;
    public GameObject HeavyRain;
    public GameObject HeavySnow;
    public GameObject LightRain;
    public GameObject LightSnow;
    public GameObject MiddleRain;
    public GameObject MinSnow;
    public GameObject Moon;
    public GameObject RainSnow;
    public GameObject Sunny;
    public GameObject SunnySnow;
    public GameObject Temperature;
    public GameObject Thunder;
    public GameObject ThunderRain;
    public GameObject Tornado;
    public GameObject Wind;
    public Text VisualTemp;
    public Text VisualLocation;

    public class Weather
    {
        public string location;
        public string style;
        public string temp;
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetData();
        StartCoroutine(GetServerData());
    }

    public void StartDataUpdate()
    {
        ResetData();
        StartCoroutine(GetServerData());
    }

    void ResetData()
    {
        VisualTemp.text = "";
        VisualLocation.text = "";

        CloudAtNight.SetActive(false);
        CloudSunny.SetActive(false);
        Cloudy.SetActive(false);
        CloudyRain.SetActive(false);
        Fog.SetActive(false);
        HeavyRain.SetActive(false);
        HeavySnow.SetActive(false);
        LightRain.SetActive(false);
        LightSnow.SetActive(false);
        MiddleRain.SetActive(false);
        MinSnow.SetActive(false);
        Moon.SetActive(false);
        RainSnow.SetActive(false);
        Sunny.SetActive(false);
        SunnySnow.SetActive(false);
        Temperature.SetActive(false);
        Thunder.SetActive(false);
        ThunderRain.SetActive(false);
        Tornado.SetActive(false);
        Wind.SetActive(false);
    }

    IEnumerator GetServerData()
    {
        var random = Random.Range(0f, 9999f);
        UnityWebRequest www = UnityWebRequest.Get("https://www.lukechaffey.com.au/weather-data/?" + random);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Debug.Log("RESPONSE: " + json);
            Weather weatherItem = JsonUtility.FromJson<Weather>(json);

            VisualLocation.text = weatherItem.location;
            VisualTemp.text = "Current Temp: " + weatherItem.temp;
            UpdateWeatherModel(weatherItem.style); 
        }
    }

    void UpdateWeatherModel(string style)
    {
        switch(style)
        {
            case "CloudAtNight":
                CloudAtNight.SetActive(true);
                break;
            case "CloudSunny":
                CloudSunny.SetActive(true);
                break;
            case "Cloudy":
                Cloudy.SetActive(true);
                break;
            case "CloudyRain":
                CloudyRain.SetActive(true);
                break;
            case "Fog":
                Fog.SetActive(true);
                break;
            case "HeavyRain":
                HeavyRain.SetActive(true);
                break;
            case "HeavySnow":
                HeavySnow.SetActive(true);
                break;
            case "LightRain":
                LightRain.SetActive(true);
                break;
            case "LightSnow":
                LightSnow.SetActive(true);
                break;
            case "MiddleRain":
                MiddleRain.SetActive(true);
                break;
            case "MinSnow":
                MinSnow.SetActive(true);
                break;
            case "Moon":
                Moon.SetActive(true);
                break;
            case "RainSnow":
                RainSnow.SetActive(true);
                break;
            case "Sunny":
                Sunny.SetActive(true);
                break;
            case "SunnySnow":
                SunnySnow.SetActive(true);
                break;
            case "Thunder":
                Thunder.SetActive(true);
                break;
            case "ThunderRain":
                ThunderRain.SetActive(true);
                break;
            case "Tornado":
                Tornado.SetActive(true);
                break;
            case "Wind":
                Wind.SetActive(true);
                break;
            default:
                Temperature.SetActive(true);
                break;
        }
    }
}
