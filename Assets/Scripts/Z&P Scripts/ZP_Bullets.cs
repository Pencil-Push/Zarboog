using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZP_Bullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    [SerializeField] private Rigidbody2D rb;
    private Animator shAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        shAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            //shAnim.SetTrigger("Explode");
            Destroy(gameObject);
        }

        if(collision.tag == "Ship")
        {
            collision.GetComponent<Ship_Health>().TakeDamage(damage);
            //shAnim.SetTrigger("Explode");
            Destroy(gameObject);
        }

        if(collision.tag == "Boss")
        {
            collision.GetComponent<Boss_Health>().TakeDamage(damage);
            //shAnim.SetTrigger("Explode");
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
