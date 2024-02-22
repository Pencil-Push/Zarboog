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
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
/*
     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy_Behavior enemy = hitInfo.GetComponent<Enemy_Behavior>();
        if (enemy != null)
        {
            //enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
*/
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
