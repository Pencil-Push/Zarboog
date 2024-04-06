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
    private bool zHit;
    private bool m_FacingRight;

    [Header ("Emitter Components")]
    private Rigidbody2D rb;
    private Animator zAnimator;
    private BoxCollider2D zCollider;
    
    // Update is called once per frame
     void Start()
    {
        // Grab references for rigidbody from object at start
        m_FacingRight = true;

        rb = GetComponent<Rigidbody2D>();
        zAnimator = spriteObj.GetComponent<Animator>();
        zCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        //Positioning();

        if(zHit) return;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        zHit = true;
        zCollider.enabled = false;

        if(collision.tag == "Enemy")
            collision.GetComponent<Health_Death>().TakeDamage(2);
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
