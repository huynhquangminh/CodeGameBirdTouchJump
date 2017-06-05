using UnityEngine;
using System.Collections;

public class Controll_Player : MonoBehaviour {


    public float speed;
    public  int temp = 0;
    public int tamp = 0;
    
    private Rigidbody2D myBody;
    public static Controll_Player instance;
    public static int checkmove = 0;
    private float minX, maxX, minY, maxY;
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start() {
        MakeInstance();
        myBody = GetComponent<Rigidbody2D>();


        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)); // 4 diem tren mang hinh 
        minX = -bound.x + 0.4f;
        maxX = bound.x - 0.4f;
        minY = -bound.y + 0.4f;
        maxY = bound.y - 4.5f;
    }

  
    void MoveByKey()
    {
       
        int n = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {

            myBody.velocity = new Vector2(0.0f, 0.0f);
            myBody.velocity = new Vector2(speed, 0);
            //myBody.AddForce(new Vector2(100, 300));
            //n = 1;

        }
        else
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myBody.velocity = new Vector2(0.0f, 0.0f);
                myBody.velocity = new Vector2(-speed, 0);
                //myBody.AddForce(new Vector2(-100, 300));
                //n = 2;
            }else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    myBody.velocity = new Vector2(0.0f, 0.0f);
                    myBody.velocity = new Vector2(0, speed);
                }
                else
                {
                    myBody.velocity = new Vector2(0.0f, 0.0f);
                }
            }
                
            
        }

        //Vector3 temp = transform.position;
        //if (temp.y > maxY+0.1f)
        //{
        //    checkmove = 1;
        //    temp.y = maxY+0.09f;
        //    if(n == 1)
        //         myBody.AddForce(new Vector2(10, -50));
        //    else
        //        myBody.AddForce(new Vector2(-10, -50));


        //}
        //transform.position = temp;

    }

    void Movetouch()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // cham li vao mang hinh 
            {
                if (touch.position.x < Screen.width * 0.5f) // duy chuyen ve ben trai 
                {
                    
                }
                else
                {
                    if (touch.position.x > Screen.width * 0.5f) // duy chuyen ve ben phai 
                    {
                       
                       
                    }
                }
            }
            
        }
    }
         
    void FixedUpdate()
    {
        Movetouch();
        MoveByKey();

    }
   
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PepiHoler" )
        {
            this.temp = 1;
        }
        
    }
   
}


    
	

