using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
   [SerializeField] private float healthValue;
   [SerializeField] private AudioClip healthAClip;

   private void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "Player")
        {
            col.GetComponent<Health_Death>().AddHealth(healthValue);
            AltAudioM.instance.PlaySFXClip(healthAClip, transform, 1f);
            gameObject.SetActive(false);
        }
   }
}
