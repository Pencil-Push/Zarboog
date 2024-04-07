using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZP_Bullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
