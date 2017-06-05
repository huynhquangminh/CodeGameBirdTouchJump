using UnityEngine;
using System.Collections;

public class itemcontrol: MonoBehaviour {


    public static int tempitem = 1, solanxuatvacham = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 2, 0);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
            tempitem = 1;
            solanxuatvacham++;

        }
    }
}
