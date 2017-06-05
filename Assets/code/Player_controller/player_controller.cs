using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

    public int tamp = 1, x, y;
    public static int dem = 0;
    public static int vacham = 0;
    private Rigidbody2D mybody;
    private Animator anim;
    private int score = 0;
    [SerializeField]
    private GameObject briddie;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip dead, by, cham;
	// Use this for initialization
	void Start () {
       
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (GameController.instance != null)
        {
            GameController.instance.resetColor();
        }
     }
	
    void MoveKey()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(tamp == 1) // duy chuyen qua phai 
            {
                audio.PlayOneShot(by);
                mybody.velocity = new Vector2(0, 0);
                mybody.AddForce(new Vector2(x, y));
                anim.SetBool("Move", true);
            }else
            {
                if(tamp == 0) // duy chuyen qua trai 
                {
                    audio.PlayOneShot(by);
                    mybody.velocity = new Vector2(0, 0);

                    mybody.AddForce(new Vector2(-x, y));
                    anim.SetBool("Move", true);
                }
               
            }

        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    void MoveTouch()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // cham li vao mang hinh 
            {
                if (tamp == 1) // duy chuyen qua phai 
                {
                    audio.PlayOneShot(by);
                    mybody.velocity = new Vector2(0, 0);
                    mybody.AddForce(new Vector2(x, y));
                    anim.SetBool("Move", true);
                }
                else
                {
                    if (tamp == 0) // duy chuyen qua trai 
                    {
                        audio.PlayOneShot(by);
                        mybody.velocity = new Vector2(0, 0);

                        mybody.AddForce(new Vector2(-x, y));
                        anim.SetBool("Move", true);
                    }

                }
            }
            else
            {
                anim.SetBool("Move", false);
            }

        }
    }

    void Update () {
        MoveKey();
        MoveTouch();

    }

    IEnumerator brid_die()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(briddie, transform.position, Quaternion.Euler(0, 0, -90));      
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag =="thanhdoctrai")
        {

            audio.PlayOneShot(cham);
            dem++;
            score++;
            if(GameController.instance != null)
            {
                GameController.instance.CountScore(score);
            }
            vacham = 2;
            tamp =1;
            Vector3 temp = transform.localScale;
            temp.x = 0.15f;
            transform.localScale = temp;
            mybody.velocity = new Vector2(0, 0);
            mybody.AddForce(new Vector2(100, 200));
           

        }
        if(hit.gameObject.tag =="thanhdocphai")
        {
            audio.PlayOneShot(cham);
            dem++;
            score++;
            if (GameController.instance != null)
            {
                GameController.instance.CountScore(score);
            }
            vacham = 1;
            tamp = 0;
            Vector3 temp = transform.localScale;
            temp.x = -0.15f;
            transform.localScale = temp;
            mybody.velocity = new Vector2(0, 0);
            mybody.AddForce(new Vector2(-100, 200));

           
        }
        if(score != 0 && score %5==0 )
        if(score != 0 && score %5== 0 )
        {
            GameController.instance.getColor();
                if(Spawneritem_controller.soluong < 7)
                {
                    Spawneritem_controller.soluong++;
                }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "itemchery")
        {
            Destroy(target.gameObject);
        }
        if(target.tag == "triangle1" || target.tag == "triangle2" || target.tag == "thanhngan")
        {
            audio.PlayOneShot(dead);
            StartCoroutine(brid_die());
            Destroy(gameObject, 0.25f);
            Spawneritem_controller.soluong = 2;

            if (GameController.instance != null)
            {
                GameController.instance.PenalGameOver(true);
                GameController.instance.PenalScoreGameOver(score);
               // GameController.instance.resetColor();
            }
        }else
        {
            GameController.instance.PenalGameOver(false);
        }
    }
}
