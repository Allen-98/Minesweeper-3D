using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseCube : MonoBehaviour
{
    public GameObject baseCube;
    public GameObject cube;
    public GameObject mine;
    public TextMeshProUGUI tmp;
    public bool hasMine = false;
    public bool isOpened = false;
    public MapGeneration3D_2 mg;
    public bool isMarked = false;

    public int neighbourMines = 0;

    public Vector3Int cubeCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        mg = FindObjectOfType<MapGeneration3D_2>().GetComponent<MapGeneration3D_2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OpenCube();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MarkMine();
        }
    }

    public void OpenCube()
    {
        if (hasMine)
        {
            mg.GameOver();
        }
        else
        {
            if (neighbourMines > 0)
            {
                cube.SetActive(false);
                
            }
            else
            {
                baseCube.SetActive(false);
                //mg.checkNeighbourCubes(cubeCoordinates);
            }
        }
    }


    public void MarkMine()
    {
        if (hasMine)
        {
            hasMine = false;
            isMarked = true;

            mine.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }


}
