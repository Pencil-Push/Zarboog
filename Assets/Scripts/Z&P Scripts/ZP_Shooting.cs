using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZP_Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;

    bool m_FacingRight;
    bool diagUP;
    bool diagDOWN;
    bool up;
    bool down;

    public Rigidbody2D rb;

    // Update is called once per frame
     void Start()
    {
        // Grab references for rigidbody from object at start
        m_FacingRight = true;
        diagUP = false;
        diagDOWN = false;
        up = false;
        down = false;
        rb = GetComponent<Rigidbody2D>(); 
    }
    
    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        Positioning();
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_FacingRight)
            {
                if (diagUP)
                {
                    Shoot(45f);
                }
                else if (diagDOWN)
                {
                    Shoot(-45f);
                }
                else if (up)
                {
                    Shoot(90f);
                }
                else if (down)
                {
                    Shoot(-90f);
                }
                else
                {
                    Shoot(0f);
                }
            }
            if (!m_FacingRight)
            {
               if (diagUP)
                {
                    Shoot(135f);
                }
                else if (diagDOWN)
                {
                    Shoot(-135f);
                }
                else if (up)
                {
                    Shoot(90f);
                }
                else if (down)
                {
                    Shoot(-90f);
                }
                else
                {
                    Shoot(180f);
                } 
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

    void Positioning()
    {
        if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow) ^ (Input.GetKey(KeyCode.RightArrow))))
        {
            diagUP = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) ^ (Input.GetKey(KeyCode.RightArrow))))
        {
            diagDOWN = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            down = true;
        }
        else
        {
          diagUP = false;
          diagDOWN = false;
          up = false;
          down = false;
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
