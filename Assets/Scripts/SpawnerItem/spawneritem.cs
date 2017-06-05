using UnityEngine;
using System.Collections;

public class spawneritem : MonoBehaviour {


    [SerializeField]
    private GameObject item1;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawner());
	}

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator spawner()
    {
        int rand = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
      
          Vector3 tamp = item1.transform.position;
            tamp.x = Random.Range(-1.02f, 1.6f);
            tamp.y = Random.Range(0.5f, 1f);
            Instantiate(item1, tamp, Quaternion.identity);
           // Instantiate(item2, tamp, Quaternion.identity);

     
       
        //if(rand == 2)
        //{
        //    Vector3 tamp = item2.transform.position;
           
        //    Instantiate(item2, tamp, Quaternion.identity);
        //    //Instantiate(item3, tamp, Quaternion.identity);
        //}
            
        //if(rand == 3)
        //{
        //    Vector3 tamp = item3.transform.position;
        //    //Instantiate(item1, tamp, Quaternion.identity);
        //    Instantiate(item3, tamp, Quaternion.identity);
        //}
           
       

           
    }
}
