using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public float RotateSpeed = 2f;
    private float Radius = 2.5f;
    private int temp = 0;
    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        Movekey();
    }

    void Movekey()
    {

       
        _angle += RotateSpeed * Time.deltaTime;
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           

            var offset = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle)) * Radius;
            transform.position = _centre + offset;
           // transform.rotation = Quaternion.Euler(0, 0, ++temp + 1);
        }
        else
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
               

                var offset = new Vector2( Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                transform.position = _centre + offset;
               // transform.rotation = Quaternion.Euler(0, 0, --temp + 1);
            }
        }
        
      
    }
}
