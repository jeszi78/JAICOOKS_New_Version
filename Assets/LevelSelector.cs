using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{

    public void Game1()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);


    }

    public void Game2()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);


    }


}
