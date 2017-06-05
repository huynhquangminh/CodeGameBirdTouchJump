using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller_Menu : MonoBehaviour {

    public static Controller_Menu instance;
    public const string High_score = "High_score";
    public Text bestscore;
  
    private void Awake()
    {
        _MakeSingleIntstance();
        IsGameStartedForTheFirstTime();
       bestscore.text = PlayerPrefs.GetInt(High_score).ToString();
    }
    void _MakeSingleIntstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
       
    }

    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(High_score, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    public int getBestCore()
    {
        //bestscore.text = PlayerPrefs.GetInt(High_score).ToString();
        return PlayerPrefs.GetInt(High_score);
    }
    public void setBestCore(int score)
    {
        PlayerPrefs.SetInt(High_score, score);
    }

    
	
}
