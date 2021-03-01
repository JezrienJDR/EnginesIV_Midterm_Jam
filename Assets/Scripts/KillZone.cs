using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{

    private Vector3 startPoint;

    private void Awake()
    {
        startPoint = FindObjectOfType<PlayerController>().transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = startPoint;
        }
    }
}
