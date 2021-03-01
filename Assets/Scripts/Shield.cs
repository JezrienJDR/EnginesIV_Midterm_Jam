using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponentInParent<Door>();

        if(door == null)
        {
            Debug.Log("DOOR IS NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
