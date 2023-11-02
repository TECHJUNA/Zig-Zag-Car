using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject star_partical, Heart_partical;
    //public GameObject Heart_partical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 100f)*Time.deltaTime );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if(gameObject.tag == "Heart")
            {
                GameManager.instance.GetHeart();
                Instantiate(Heart_partical, transform.position, Quaternion.identity);
            }
            if(gameObject.tag == "Star")
            {
                GameManager.instance.GetStar();
                Instantiate(star_partical, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        
        }
    }
}
