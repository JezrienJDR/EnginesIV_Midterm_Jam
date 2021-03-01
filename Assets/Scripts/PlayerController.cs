using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public int skill;

    private int colour; // 0 is yellow, 1 is purple, 2 is blue; 

    public float walkSpeed;
    public float lookSpeed;

    [ColorUsage(true, true)]
    public Color Yellow;
    [ColorUsage(true, true)]
    public Color Purple;
    [ColorUsage(true, true)]
    public Color Blue;


    public GameObject yShot;
    public GameObject pShot;
    public GameObject bShot;

    public Transform muzzle;

    private GameObject chamber;

    private Material mat;

    private float rotation;

    private bool a;
    private bool s;
    private bool w;
    private bool d;


    private bool PurpleUnlocked;
    private bool BlueUnlocked;

    public Canvas pauseMenu;

    private Animator animr;

    public GameObject interactable;

    bool firing = false;

    private HudManager HUD;

    private void Awake()
    {
        animr = GetComponent<Animator>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().materials[1];

        mat.SetColor("_col", Yellow);

        chamber = yShot;

        BlueUnlocked = false;
        PurpleUnlocked = false;

        HUD = FindObjectOfType<HudManager>();

        pauseMenu.gameObject.SetActive(false);
    }

    public void GetBlue()
    {
        BlueUnlocked = true;
        HUD.AcquireBlue();
    }

    public void GetPurple()
    {
        PurpleUnlocked = true;
        HUD.AcquirePurple();
    }

    private void Update()
    {
        Vector3 move = Vector3.zero;

        if(w && !s)
        {
            move = transform.forward * walkSpeed * Time.deltaTime;
        }
        else if(s && !w)
        {
            move = -transform.forward * walkSpeed * Time.deltaTime;
        }
        if (a && !d)
        {
            rotation = -lookSpeed * Time.deltaTime;
        }
        else if (d && !a)
        {
            rotation = lookSpeed * Time.deltaTime;
        }
        else if (!a && !d) rotation = 0;


        transform.position += move;
        transform.Rotate(0, rotation, 0);
    }

    public void OnW(InputValue val)
    {

        if (val.isPressed)
        {
            w = true;
        }
        else
        {
            w = false;
        }
    }

    public void OnA(InputValue val)
    {

        if (val.isPressed)
        {
            a = true;
        }
        else
        {
            a = false;
        }
    }

    public void OnS(InputValue val)
    {

        if (val.isPressed)
        {
            s = true;
        }
        else
        {
            s = false;
        }
    }

    public void OnD(InputValue val)
    {
 
        if (val.isPressed)
        {
            d = true;
        }
        else
        {
            d = false;
        }
    }

    public void OnYellow(InputValue val)
    {
        animr.SetInteger("Beam", 0);
        mat.SetColor("_col", Yellow);

        chamber = yShot;

        HUD.SwitchYellow();
    }

    public void OnPurple(InputValue val)
    {

        if (PurpleUnlocked)
        {

            animr.SetInteger("Beam", 1);
            mat.SetColor("_col", Purple);

            chamber = pShot;

            HUD.SwitchPurple();
        }
    }

    public void OnBlue(InputValue val)
    {
        if (BlueUnlocked)
        {

            animr.SetInteger("Beam", 2);
            mat.SetColor("_col", Blue);

            chamber = bShot;

            HUD.SwitchBlue();
        }
    }

    public void OnFire(InputValue val)
    {
        if (val.isPressed)
        {
            if (!firing)
            {
                var b = Instantiate(chamber, muzzle.position, muzzle.rotation);
                b.transform.Rotate(90, 0, 0);
                animr.SetBool("Firing", true);
                firing = true;
            }
        }

    }

    public void OnDoorTest(InputValue val)
    {
        //FindObjectOfType<Door>().Toggle();
        FindObjectOfType<Door>().OpenSequence();
    }

    public void OnPause(InputValue val)
    {
        Debug.Log("pausing");
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DoneFiring()
    {
        animr.SetBool("Firing", false);
        firing = false;
    }
}
