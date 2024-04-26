using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Behavior : MonoBehaviour
{
    [Header ("Ship Parameters")]
    [SerializeField] private float shipSpeed;
    public bool chase = false;

    [Header ("Ship Components")]
    private GameObject player;
    public Transform startingPoint;

    [Header ("Ranged Attack")]
    [SerializeField] private Transform emitter;
    [SerializeField] private GameObject sProjectile;
    [SerializeField] private AudioClip shootAClip;

    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    //private float attackTimer;
    private float cooldownTimer = Mathf.Infinity;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (player == null)
        {
            return;
        }

        if(chase == true)
        {
            Chase();
        }
        else
        {
            // go to starting position
            ReturnStartPoint();
        }
        
        Flip();
    }

    // using Vector2.MoveTowards, making the enemy move to the players position
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, shipSpeed * Time.deltaTime);
        
        if(cooldownTimer >= attackCooldown)
            {
                RangedAttack();
                AltAudioM.instance.PlaySFXClip(shootAClip, transform, 0.5f);
            }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, shipSpeed * Time.deltaTime);
    }

    // Flip Sprite
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        Instantiate(sProjectile, emitter.position, Quaternion.identity);
    }
}
