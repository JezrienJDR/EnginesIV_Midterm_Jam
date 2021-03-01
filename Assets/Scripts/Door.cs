using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator animr;

    private bool open;

    public GameObject Shield;
    public GameObject Shield2;

    private Material shieldMat;
    private Material shieldMat2;

    public int color;

    public float recloseDelay;

    private bool Animating;

    // Start is called before the first frame update
    void Start()
    {
        animr = GetComponent<Animator>();
        open = false;

        shieldMat = Shield.GetComponent<MeshRenderer>().material;
        shieldMat2 = Shield2.GetComponent<MeshRenderer>().material;


        shieldMat.SetVector("_Center", transform.position);
        shieldMat.SetFloat("_Radius", 0);

        shieldMat2.SetVector("_Center", transform.position);
        shieldMat2.SetFloat("_Radius", 0);

        Animating = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        animr.SetBool("Open", true);
        open = true;
    }

    public void Close()
    {
        animr.SetBool("Open", false);
        open = false;
    }

    public void Toggle()
    {
        Debug.Log("Toggling Door");
        open = !open;

        if(open)
        {
            animr.SetBool("Open", true);
        }
        else
        {
            animr.SetBool("Open", false);
        }
    }

    public void HitOpen(Vector3 hitPoint)
    {
        if (!Animating)
        {
            shieldMat.SetVector("_Center", hitPoint);
            shieldMat2.SetVector("_Center", hitPoint);
            OpenSequence();
        }
    }

    public void OpenSequence()
    {
        StopCoroutine("Closing");
        StartCoroutine("Opening");
    }

    public void CloseSequence()
    {
        StopCoroutine("Opening");
        StartCoroutine("Closing");
    }

    IEnumerator Opening()
    {
        Animating = true;

        Open();

        Shield.GetComponent<MeshCollider>().enabled = false;
        Shield2.GetComponent<MeshCollider>().enabled = false;

        float radius = 0.4f;
        shieldMat.SetFloat("_Radius", 0.4f);
        shieldMat2.SetFloat("_Radius", 0.4f);
        for (int i = 0; i <150; i++)
        {
            radius += 0.02f;
            shieldMat.SetFloat("_Radius", radius);
            shieldMat2.SetFloat("_Radius", radius);

            yield return new WaitForSeconds(0.01f);
        }

        Shield.SetActive(false);
        Shield2.SetActive(false);

        Animating = false;

        yield return new WaitForSeconds(recloseDelay);

        CloseSequence();
    }
    IEnumerator Closing()
    {

        Animating = true;

        shieldMat.SetVector("_Center", transform.position);
        shieldMat2.SetVector("_Center", transform.position);

        Shield.SetActive(true);
        Shield2.SetActive(true);

        Shield.GetComponent<MeshCollider>().enabled = true;
        Shield2.GetComponent<MeshCollider>().enabled = true;

        Close();

        float rad = 2.1f;
        shieldMat.SetFloat("_Radius", rad);
        shieldMat2.SetFloat("_Radius", rad);
        while (rad > 0.0f)
        {
            rad -= 0.01f;
            shieldMat.SetFloat("_Radius", rad);
            shieldMat2.SetFloat("_Radius", rad);

            yield return new WaitForSeconds(0.01f);
        }

        Animating = false;

    }



}
