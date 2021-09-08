using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseCube : MonoBehaviour
{

    public GameObject cube;
    public GameObject mine;
    public TextMeshProUGUI tmp;
    public bool hasMine = false;

    public int neighbourMines = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hasMine)
        {
            return;
        }
        else
        {
            cube.SetActive(false);
        }
    }




}
