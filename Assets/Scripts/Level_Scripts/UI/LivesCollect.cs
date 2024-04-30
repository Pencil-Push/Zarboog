using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCollect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float lifeValue;
    [SerializeField] private AudioClip lifeAClip;

   private void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "Player")
        {
            col.GetComponent<Health_Death>().AddLife();
            AltAudioM.instance.PlaySFXClip(lifeAClip, transform, 1f);
            gameObject.SetActive(false);
        }
   }
}
