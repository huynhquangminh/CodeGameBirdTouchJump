using UnityEngine;
using System.Collections;

public class Triangle_controller : MonoBehaviour {

    public static float rong;
    private Rigidbody2D mybody;
	// Use this for initialization
	void Start () {

        MoveTriangle(rong);
       
       
    }


    void MoveTriangle(float huong)
    {
        //Vector3 temp = transform.position;
        //temp.x += huong;
        //transform.position = temp;
        transform.position= Vector2.MoveTowards(transform.position, new Vector2(-2.34f, transform.position.y), 1);
    }

    
    // Update is called once per frame
    void Update () {
      
       
    }
}
