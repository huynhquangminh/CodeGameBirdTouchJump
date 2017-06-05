using UnityEngine;
using System.Collections;

public class Spawner_controller : MonoBehaviour {


    public static  int demsoluong = 0;
    [SerializeField]
    private GameObject pepiholderbig, pepiholdertim, pepiholderpink, item1, item2, item3;
    
	
	void Start () {
        // StartCoroutine(Spawner());
        StartCoroutine(Spawner());
    }
	
	
	void Update () {

        //if(PepiHolder_controller.spanwerTrue == 1)
        //{
        //    StartCoroutine(Spawner());
        //    PepiHolder_controller.spanwerTrue = 0;
        //}
      
    }


    
    IEnumerator Spawner()
    {
       
        
      

        Vector3 temp = pepiholderbig.transform.position;
        temp.x = Random.Range(-0.5f, 1.4f);
        Instantiate(pepiholderbig, temp, Quaternion.identity);



        //Vector3 tamp1 = temp;
        //tamp1.x = Random.Range(-1f, 1.3f);
        //tamp1.y += Random.Range(0.8f, 2f);
       
       
       

        //Vector3 tamp2 = pepiholderbig.transform.position;
        //tamp2.x = Random.Range(-1.4f, 1.4f);
        //tamp2.y += Random.Range(-2f, -0.7f);

        //demsoluong++;

        //if (PepiHolder_controller.tempshowpepei - 3 < 15 )
        //{
        //    Instantiate(pepiholderbig, temp, Quaternion.identity);
        //    Instantiate(item1, tamp1, Quaternion.identity);
        //    Instantiate(item1, tamp2, Quaternion.identity);
        //}
        //if (PepiHolder_controller.tempshowpepei - 3 >15 && PepiHolder_controller.tempshowpepei - 3 <  30)
        //{
        //    Instantiate(pepiholdertim, temp, Quaternion.identity);
        //    Instantiate(item2, tamp1, Quaternion.identity);
        //    Instantiate(item2, tamp2, Quaternion.identity);
        //}
        //if (PepiHolder_controller.tempshowpepei - 3 > 30 )
        //{
        //    Instantiate(pepiholderpink, temp, Quaternion.identity);
        //    Instantiate(item3, tamp1, Quaternion.identity);
        //    Instantiate(item3, tamp2, Quaternion.identity);
        //}
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Spawner());
    }



}
