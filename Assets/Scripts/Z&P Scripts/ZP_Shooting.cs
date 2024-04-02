using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZP_Shooting : MonoBehaviour
{
    [Header ("Emitter Parameters")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spriteObj;
    [SerializeField] private float bulletSpeed = 20f;
    private bool m_FacingRight;

    [Header ("Emitter Components")]
    private Rigidbody2D rb;
    private Animator zAnimator;
    
    // Update is called once per frame
     void Start()
    {
        // Grab references for rigidbody from object at start
        m_FacingRight = true;

        rb = GetComponent<Rigidbody2D>();
        zAnimator = spriteObj.GetComponent<Animator>();
    }
    
    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        //Positioning();

        if (Input.GetButtonDown("Fire1"))
        {
            if (m_FacingRight)
            {
                Shoot(0f);
            }
            if (!m_FacingRight)
            {
                Shoot(180f);
            }
        }
         
        if (!m_FacingRight && horizontalInput > 0)
        {
            Flip();
        }
        else if (m_FacingRight && horizontalInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
       
       m_FacingRight = !m_FacingRight;
       transform.Rotate(0f, 180f, 0f);
    }

    void Shoot(float ang)
    {
        // shooting logic firePoint.rotation,
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        float bulletAngle = ang;
        Vector2 bulletDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * bulletAngle), Mathf.Sin(Mathf.Deg2Rad * bulletAngle));

        Rigidbody2D projectilerb = projectile.GetComponent<Rigidbody2D>();
        projectilerb.AddForce(bulletDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
