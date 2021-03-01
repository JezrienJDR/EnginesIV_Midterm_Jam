using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Image yDot;
    public Image pDot;
    public Image bDot;

    public Image ySelect;
    public Image pSelect;
    public Image bSelect;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);

        Initialize();
    }

    // Update is called once per frame

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        pDot.enabled = false;
        bDot.enabled = false;

        pSelect.enabled = false;
        bSelect.enabled = false;
    }



    public void AcquirePurple()
    {
        pDot.enabled = true;
    }

    public void AcquireBlue()
    {
        bDot.enabled = true;
    }

    public void SwitchYellow()
    {
        ySelect.enabled = true;

        pSelect.enabled = false;
        bSelect.enabled = false;
    }

    public void SwitchPurple()
    {
        pSelect.enabled = true;

        ySelect.enabled = false;
        bSelect.enabled = false;
    }

    public void SwitchBlue()
    {
        bSelect.enabled = true;

        pSelect.enabled = false;
        ySelect.enabled = false;
    }


}
