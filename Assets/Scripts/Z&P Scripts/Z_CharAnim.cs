using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_CharAnim : MonoBehaviour
{
    public GameObject spriteObj;

    public Rigidbody2D rb;
    private Animator zAnimator;
    PlayerMovement pMove;

    // Start is called before the first frame update
     void Start()
    {
        // Grab references for rigidbody from object at start
        rb = GetComponent<Rigidbody2D>();
        zAnimator = spriteObj.GetComponent<Animator>();
        pMove = spriteObj.GetComponent<PlayerMovement>();
    }
    
    void Update()
    { 
        

        /*
        if (Input.GetButtonDown("Fire1") && )
        {
            zAnimator.SetBool("jumpShoot", true);
        }
        else
        {
            zAnimator.SetBool("jumpShoot", false);
        }
        */
        
        if (Input.GetButtonDown("Fire1"))
        {
            zAnimator.SetBool("isShooting", true);
        }
        else
        {
            zAnimator.SetBool("isShooting", false);
        }
    }
}
