using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Counter : MonoBehaviour
{
    //[SerializeField] private Health_Death playerLives;
    public Text lifeCount;
    public int maxLives;
    public int livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCount.text = "x " + livesCounter;

        if (livesCounter < 1)
        {

        }
    }

    public void TakeLife()
    {
        livesCounter--;
    }

    public void AddLife()
    {
        livesCounter++;
    }
}
