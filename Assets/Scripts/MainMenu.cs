using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameData gd;

    private void Start()
    {
        //gd = GameObject.Find("GameData").GetComponent<GameData>();
    
    }


    public void StartGame()
    {
        if (gd.length != 0 && gd.width != 0 && gd.height != 0 && gd.mines != 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            gd.length = 5;
            gd.width = 5;
            gd.height = 5;
            gd.mines = 5;
            SceneManager.LoadScene(1);
        }

    }

    public void Tutorial()
    {
        gd.length = 3;
        gd.width = 3;
        gd.height = 3;
        gd.mines = 1;
        SceneManager.LoadScene(2);
    }




    public void QuitGame()
    {
        Application.Quit();
    }

}
