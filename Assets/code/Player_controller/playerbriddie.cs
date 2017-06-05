using UnityEngine;
using System.Collections;

public class playerbriddie : MonoBehaviour {

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "thanhngan")
        {
            Destroy(gameObject, 2);
        }
    }
}
