using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Platform : MonoBehaviour
{
    public GameObject PathPartical;
    public GameObject Heart, star;

    // Start is called before the first frame update
    void Start()
    {
        int randNumber = Random.Range(1, 26);
        Vector3 TempPos = transform.position;
        TempPos.y += 1f;
         
        if(randNumber < 6)
        {
            Instantiate(star,TempPos,star.transform.rotation);
        }
        if(randNumber == 9) 
        {
            Instantiate(Heart, TempPos,Heart.transform.rotation);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            //Destroy(gameObject, 0.5f);
            Invoke("FallDown", 0.55f);
        }
    }  

    void FallDown()
    {
        Instantiate(PathPartical,transform.position,Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject,0.6f);
    }
}
