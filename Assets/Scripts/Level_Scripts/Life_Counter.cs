using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Counter : MonoBehaviour
{
    //[SerializeField] private Health_Death playerLives;
    //private GameManager theGM;
    public Text lifeCount;
    public int maxLives;
    public int livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = maxLives;

        //theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeCount.text = "x " + livesCounter;

        if (livesCounter < 1)
        {
            //theGM.GameOver();
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
