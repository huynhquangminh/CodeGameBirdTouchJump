using UnityEngine;
using System.Collections;

public class spawnerdiamond : MonoBehaviour {


    [SerializeField]
    private GameObject item;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
       if(itemcontrol.solanxuatvacham % 2 == 0 && itemcontrol.tempitem == 1)
       {
            StartCoroutine(spawneritem(-1));
            itemcontrol.tempitem = 0;

       }
        if (itemcontrol.solanxuatvacham % 2 != 0 && itemcontrol.tempitem == 1)
        {
            StartCoroutine(spawneritem(1));
            itemcontrol.tempitem = 0;

        }

    }
    IEnumerator spawneritem (int huong)
    {
        yield return new WaitForSeconds(0.8f);
        Vector3 temp = transform.position;
        temp.x = huong * transform.position.x;
        Instantiate(item, temp, Quaternion.identity);
        
    }
}
