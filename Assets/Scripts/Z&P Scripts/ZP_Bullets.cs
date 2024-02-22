using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZP_Bullets : MonoBehaviour
{
    public float bulletSpeed = 20f;

    public int damage = 10;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
      rb.velocity = transform.right * bulletSpeed;  
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow))
        {
            // rb.velocity = transform.up * bulletSpeed;
            Debug.Log("Is firing at up.");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Angled");
        }  
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy_Behavior enemy = hitInfo.GetComponent<Enemy_Behavior>();
        if (enemy != null)
        {
            //enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
