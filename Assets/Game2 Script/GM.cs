using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoretext;

    public bool isGameOver;
    public bool playerWon;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoretext.text = "Score:$ ";
        if (isGameOver == false)
        {
            
            if (score >= 360)
            {
                isGameOver = true;
                playerWon = true;
                scoretext.text = "Score: You Won";
            }
        }

        
    }
}
