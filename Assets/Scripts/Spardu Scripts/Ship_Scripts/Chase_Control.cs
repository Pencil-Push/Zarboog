using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_Control : MonoBehaviour
{
    public Ship_Behavior[] enemyArray;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (Ship_Behavior enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (Ship_Behavior enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }
}
