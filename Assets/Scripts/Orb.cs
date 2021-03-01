using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float rotationSpeed;

    public int colour;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(colour == 1)
            {
                collision.gameObject.GetComponent<PlayerController>().GetPurple();
                Destroy(gameObject);
            }
            else if(colour == 2)
            {
                collision.gameObject.GetComponent<PlayerController>().GetBlue();
                Destroy(gameObject);
            }
        }
    }
}
