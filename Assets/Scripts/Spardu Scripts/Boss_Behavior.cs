using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Behavior : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    
    // Start is called before the first frame update
    // How to flip Boss
    public void LookAtPlayer()
    {
       Vector3 flipped = transform.localScale;
       flipped.z *= -1f;

       if(transform.position.x > player.position.x && isFlipped)
       {
           transform.localScale = flipped;
           transform.Rotate(0f, 180f, 0f);
           isFlipped = false;
       } 
       else if (transform.position.x < player.position.x && !isFlipped)
       {
           transform.localScale = flipped;
           transform.Rotate(0f, 180f, 0f);
           isFlipped = true;
       }
    }
    /*
    public IEnumerator bossInactive()
    {
        yield return new WaitForSecondsRealtime(120f);
    }
    */
}
