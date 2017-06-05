using UnityEngine;
using System.Collections;

public class item_control : MonoBehaviour {

    public float speed;
    private Rigidbody2D mybody;
	// Use this for initialization
	void Start () {
        mybody = GetComponent<Rigidbody2D>();
        if (Spawner_controller.demsoluong == 1)
        {
            Vector3 temp = transform.position;
            temp.y -= 130 * Time.deltaTime;
            transform.position = temp;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
      
	}
    void Moveitem()
    {
       

    }
    void MoveWithTouch()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) // cham li vao mang hinh 
        {
            //Vector3 temp = transform.position;
            //temp.y -= speed * Time.deltaTime;
            //transform.position = temp;

            mybody.velocity = new Vector2(0, -30 * Time.timeScale);
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            mybody.velocity = new Vector2(0, 0);
        }
    
    }


    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy")
            Destroy(gameObject);
    }
}
