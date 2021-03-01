using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;
    // 0 is yellow, 
    // 1 is purple,
    // 2 is blue;

    public float speed;

    public GameObject burst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += -transform.up * speed * Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        //collision.GetContact(0).

        if(tag != "Player")
        {
            if(tag == "Shield")
            {
                Debug.Log("HIT SHIELD");

                var d = collision.gameObject.GetComponent<Shield>().door;
                if(d.color == type)
                {
                    d.HitOpen(transform.position);
                    StartCoroutine("pop");
                }
                else
                {
                    transform.up = collision.contacts[0].normal;
                }
            }
            else
            {
                StartCoroutine("pop");
            }
        }

    }


    IEnumerator pop()
    {
        transform.localScale = new Vector3(50, 50, 50);
        Instantiate(burst, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
