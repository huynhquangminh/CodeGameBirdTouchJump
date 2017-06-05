using UnityEngine;
using System.Collections;

public class PepiHolder_controller : MonoBehaviour {

    public float speed;
    private Rigidbody2D mybody;
    public static int spanwerTrue = 0;
    public static int tempshowpepei = 0;
	
	void Start () {
        mybody = GetComponent<Rigidbody2D>();
       

    }
	
	
	void FixedUpdate () {

        MovePepiHolder();

    }
    void MovePepiHolder()
    {
        mybody.velocity = new Vector2(0, -speed);

    }
    void MoveWithTouch ()
    {
        Touch touch = Input.GetTouch(0);
      
    }
   
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
        if (target.tag == "centerPepi")
        {
            spanwerTrue = 1;
            tempshowpepei = tempshowpepei + 1; ;
           
        }
    }
}
