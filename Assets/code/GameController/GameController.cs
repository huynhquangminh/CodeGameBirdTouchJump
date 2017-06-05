using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public static GameController instance;
    public Text Score;
    public Text ScorePenal;
    public Text bestscore;
    

    [SerializeField]
    private GameObject bg, thanhdoctrai, thanhdocphai ,tamgiac1, tamgiac2;
    [SerializeField]
    private GameObject penalGameOver;
    private Animator anim;

    [SerializeField]
    private AudioSource click;
    [SerializeField]
    private AudioClip soundclick;


    public  string[] dsmaubg = new string[10];
    public string[] dsmauthanh = new string[10];
    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
     public  void CountScore(int n)
    {
        Score.text = n.ToString();
    }
    public void PenalScoreGameOver(int score)
    {
        ScorePenal.text = score.ToString();
        if (score > Controller_Menu.instance.getBestCore())
        {
            Controller_Menu.instance.setBestCore(score);
        }
        bestscore.text = Controller_Menu.instance.getBestCore().ToString();

    }
    public void PenalGameOver(bool action)
    {
       penalGameOver.GetComponent<Animator>().SetBool("AnimationGameOver", action);
    }
    public void ClickReplay()
    {
        click.PlayOneShot(soundclick);
        Application.LoadLevel("GameMenu");
        resetColor();
    }
    public void ClickQuit()
    {
        click.PlayOneShot(soundclick);
        Application.Quit();
        resetColor();
    }

    public void getColor(  )
    {
        int i = (int)Random.Range(0, 10);
       
        string [] temp = new string[dsmaubg.Length];
        string[] temp2 = new string[dsmauthanh.Length];
        
        temp = setColor();
        temp2 = setcolor2();



        string maubg = temp[i];
        string mauthanh = temp2[i];

        UnityEngine.Color clbg = new UnityEngine.Color();
        UnityEngine.Color clthanh = new UnityEngine.Color();
        ColorUtility.TryParseHtmlString("#" + maubg, out clbg);
        ColorUtility.TryParseHtmlString("#" + mauthanh, out clthanh);
     
        bg.GetComponent<SpriteRenderer>().color = clbg;
       
        GameObject[] arryob = GameObject.FindGameObjectsWithTag("thanhngan");
        foreach (GameObject ob in arryob)
        {
            ColorUtility.TryParseHtmlString("#" + mauthanh, out clthanh);
            ob.GetComponent<SpriteRenderer>().color = clthanh;

        }


        thanhdoctrai.GetComponent<SpriteRenderer>().color = clthanh;
        thanhdocphai.GetComponent<SpriteRenderer>().color = clthanh;
        tamgiac1.GetComponent<SpriteRenderer>().color = clthanh;
        tamgiac2.GetComponent<SpriteRenderer>().color = clthanh;
    }

    public void resetColor()
    {
        UnityEngine.Color clthanh = new UnityEngine.Color();
        ColorUtility.TryParseHtmlString("#BABBBCFF", out clthanh);
        tamgiac1.GetComponent<SpriteRenderer>().color = clthanh;
        tamgiac2.GetComponent<SpriteRenderer>().color = clthanh;

    }
    public string[] setColor()
    {
        dsmaubg[0] = "FCDAD5";
        dsmaubg[1] = "FACE9C";
        dsmaubg[2] = "FCE0A6";
        dsmaubg[3] = "F5A89A";
        dsmaubg[4] = "C8E2B1";
        dsmaubg[5] = "98D0B9";
        dsmaubg[6] = "99D1D3";
        dsmaubg[7] = "98D0B9";
        dsmaubg[8] = "94AAD6";
        dsmaubg[9] = "A095C4";
       // dsmaubg[10] = "";

        return dsmaubg;
    }
    public string[] setcolor2()
    {
        dsmauthanh[0] = "EE7C6B";
        dsmauthanh[1] = "F09C42";
        dsmauthanh[2] = "F3C246";
        dsmauthanh[3] = "E54646";
        dsmauthanh[4] = "83C75D";
        dsmauthanh[5] = "00AE72";
        dsmauthanh[6] = "00B2BF";
        dsmauthanh[7] = "00AE72";
        dsmauthanh[8] = "426EB4";
        dsmauthanh[9] = "635BA2";
       // dsmauthanh[10] = "E54646";
        return dsmauthanh;
    }

}
