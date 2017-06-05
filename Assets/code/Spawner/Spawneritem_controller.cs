using UnityEngine;
using System.Collections;


public class Spawneritem_controller : MonoBehaviour {


    [SerializeField]
    private GameObject triangle1, triangle2;
    public float rotaition = 0;
   
    
    public static int soluong = 2;
    public Vector3[] lsvitri = new Vector3[6];
    void Start () {
     
	}
	
	
	void Update () {
        kiemtravacham();
        
    }  

    void kiemtravacham()
    {
        if(player_controller.vacham == 1)
        {
            StartCoroutine(spawnertriangle(soluong, 1, triangle1));
            rotaition = -90;
            Triangle_controller.rong = 1;
          
            if(player_controller.dem > 1)
            {
                GameObject[] arryob = GameObject.FindGameObjectsWithTag("triangle2");
                foreach(GameObject n in arryob)
                {
                    Destroy(n, 0.2f);
                }
              
            }
        }
        else
            if(player_controller.vacham==2)
        {
            StartCoroutine(spawnertriangle(soluong, -1, triangle2));
            rotaition = 90;
            Triangle_controller.rong = -1;
            //Debug.Log("vitri dau 2: " + triangle2.transform.position);
            if (player_controller.dem > 1)
            {
                GameObject[] arryob = GameObject.FindGameObjectsWithTag("triangle1");
                foreach (GameObject n in arryob)
                {
                    Destroy(n, 0.2f);
                }
            }
        }
        player_controller.vacham = 0;
    }
    void clearArray()
    {
        for(int i = 0; i < lsvitri.Length;i++)
        {
            lsvitri[i].x = 0;
            lsvitri[i].y = 0;
            lsvitri[i].z = 0;

        }
    }
   int kiemtrakhoangcach(Vector3 diem, int soluong)
    {
        float kc;
        for(int i = 0;i < soluong; i++ )
        {
            kc = Mathf.Sqrt(Mathf.Pow(lsvitri[i].x - diem.x, 2) + Mathf.Pow(lsvitri[i].y - diem.y, 2));
           // Debug.Log("kc = " + kc);
            if(kc <= 0.75f)
            {
                return -1;
            }
        }
        return 0;
    } 
    void xuatmang ()
    {
        foreach(Vector3 a in lsvitri)
        {
            Debug.Log(a);
        }
    }
    IEnumerator spawnertriangle(int soluong, int n, GameObject name)
    {
       // xuatmang();
        yield return new  WaitForSeconds(0.5f);
        Vector3 temp =transform.position;
        temp.x = temp.x * n;
        clearArray();
        for (int i = 1; i <= soluong; i++ )
        {
           if(i != 1)
           {
                int kq;
                do
                {
                    temp.y = Random.Range(-3.4f, 3.3f)+ 0.2f ;
                    kq = kiemtrakhoangcach(temp, i-1);
                 // Debug.Log("kq = " + kq);
                    
                } while (kq == -1);
                //Debug.Log(temp);

                lsvitri[i - 1] = temp;
            }
           else
            {
                temp.y = Random.Range(-3.4f, 3.3f) + 0.2f;
                lsvitri[0] = temp;
               
            }

           
            Instantiate(name, temp, Quaternion.Euler(0, 0, rotaition));
           
        }
      

    } 
   
}
