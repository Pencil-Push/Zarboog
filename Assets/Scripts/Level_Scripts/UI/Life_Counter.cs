using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Life_Counter : MonoBehaviour
{
    [SerializeField] private Health_Death playerLives;
    [SerializeField] private TMP_Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = GetComponent<Health_Death>();
        lifeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = $"x: {playerLives.currLives}";


    }
}
