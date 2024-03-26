using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;

    [Header ("Enemy")]
    //[SerializeField] private Rigidbody2D sb;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;

    void start()
    {
        //sb = GetComponent<Rigidbody2D>();
    }

    void update()
    {
        MoveInDirection(1);
    }

    private void MoveInDirection(int _direction)
    {
        // Make enemy face direction

        // Move in that direction
        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y);
    }
}
