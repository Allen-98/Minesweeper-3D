using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public GameObject[] Part1;
    public GameObject[] Part2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MainMenuBack()
    {
        SceneManager.LoadScene(0);
    }

    public void Task1_1()
    {
        Part1[0].SetActive(false);
        Part1[1].SetActive(true);
    }

    public void Task1_2()
    {
        Part1[1].SetActive(false);
        Part1[2].SetActive(true);
    }

    public void Task1_3()
    {
        Part1[2].SetActive(false);
        Part1[3].SetActive(true);
    }

    public void StartPart2()
    {
        Part1[4].SetActive(false);
        Part2[4].SetActive(true);
        Part2[0].SetActive(true);
        Part2[5].SetActive(true);
        Part2[6].SetActive(true);
    }

    public void Task2_1()
    {
        Part2[0].SetActive(false);
        Part2[1].SetActive(true);
    }
    public void Task2_2()
    {
        Part2[1].SetActive(false);
        Part2[2].SetActive(true);
    }

    public void Task2_3()
    {
        Part2[2].SetActive(false);
        Part2[3].SetActive(true);
    }




}
