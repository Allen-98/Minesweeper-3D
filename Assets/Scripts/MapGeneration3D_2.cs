using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapGeneration3D_2 : MonoBehaviour
{

    public GameObject map;
    public GameObject baseCube;
    public GameObject[,,] cubeList;
    GameData gd;
    public Slider slider;

    [Header("Map Setting")]
    public int length = 5;
    public int width = 5;
    public int height = 5;

    [Header("Mine Setting")]
    //public GameObject mine;
    public int mineNumber = 5;
    private int totalMines;
    public TextMeshProUGUI minesCount;

    [Header("Game Setting")]
    public GameObject gameOver;
    public GameObject gameWin;


    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.Find("GameData") != null)
        {
            gd = GameObject.Find("GameData").GetComponent<GameData>();
            length = gd.length;
            width = gd.width;
            height = gd.height;
            mineNumber = gd.mines;
        }

        map.transform.position = new Vector3(width / 2, height / 2, length / 2);

        totalMines = mineNumber;
        cubeList = new GameObject[width, height, length];
        //GenerateMap();
        GenerateMines();
        minesCount.SetText(mineNumber.ToString() + " / " + totalMines.ToString());
    }

    private void FixedUpdate()
    {
        if (mineNumber == 0)
        {
            GameWin();
        }
    }


    public void GenerateMap()
    {
        if(gameWin.activeSelf || gameOver.activeSelf)
        {
            gameWin.SetActive(false);
            gameOver.SetActive(false);
        }

        if (map.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            Debug.Log("No children");
        }
        else
        {
            int childCount = map.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(map.transform.GetChild(i).gameObject);
            }
        }

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    CheckCube(w, h, l);
                }
            }
        }

    }

    public void CheckCube(int x, int y, int z)
    {
        Vector3 posC1 = new Vector3(x, y, z);
        GameObject cubeC1 = Instantiate(baseCube, posC1, Quaternion.identity);
        cubeC1.transform.parent = map.transform;
        cubeC1.name = x + "," + y + "," + z;
        cubeC1.GetComponent<BaseCube>().cubeCoordinates = new Vector3Int(x, y, z);
        cubeList[x, y, z] = cubeC1;
    }

    public void checkNeighbourCubes(Vector3Int cubeCoord)
    {
        int w = cubeCoord.x;
        int h = cubeCoord.y;
        int l = cubeCoord.z;

        for (int x = w - 1; x <= w + 1; x++)
        {
            if (x >= 0 && x < width)
            {
                for (int y = h - 1; y <= h + 1; y++)
                {
                    if (y >= 0 && y < height)
                    {
                        for (int z = l - 1; z <= l + 1; z++)
                        {
                            if (z >= 0 && z < length)
                            {
                                GameObject otherCube = cubeList[x, y, z];
                                BaseCube bc = otherCube.GetComponent<BaseCube>();
                                if(!bc.hasMine && !bc.isOpened)
                                {
                                    bc.OpenCube();
                                }
                            }
                        }
                    }
                }
            }
        }


    }

    public void GenerateMines()
    {
        GenerateMap();

        for (int i = 0; i < mineNumber; i++)
        {
            RandomChoose();

        }

        MinesCount();

    }

    public void RandomChoose()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        int z = Random.Range(0, length);

        GameObject o = cubeList[x, y, z];
        BaseCube bc = o.GetComponent<BaseCube>();

        if (bc.hasMine == false)
        {
            bc.hasMine = true;
            bc.cube.SetActive(true);
            bc.mine.SetActive(true);
        }
        else
        {
            RandomChoose();
        }
    }

    public void MinesCount()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    GameObject cubeC2 = cubeList[w, h, l];
                    
                    for (int x = w - 1; x <= w + 1; x++)
                    {
                        if (x >= 0 && x < width)
                        {
                            for (int y = h - 1; y <= h + 1; y++)
                            {
                                if (y >= 0 && y < height)
                                {
                                    for (int z = l - 1; z <= l + 1; z++)
                                    {
                                        if (z >= 0 && z < length)
                                        {
                                            if (cubeList[x, y, z] != null)
                                            {
                                                if (cubeList[x, y, z].GetComponent<BaseCube>().hasMine)
                                                {
                                                    cubeC2.GetComponent<BaseCube>().neighbourMines += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    cubeC2.GetComponent<BaseCube>().tmp.SetText(cubeC2.GetComponent<BaseCube>().neighbourMines.ToString());
                }
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);

    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWin.SetActive(true);
    }

    public void MinesCountMinus()
    {
        mineNumber -= 1;
        minesCount.SetText(mineNumber.ToString() + " / " + totalMines.ToString());

    }

    public void MarkMineNumberChange(Vector3Int cubeCoord)
    {
        int w = cubeCoord.x;
        int h = cubeCoord.y;
        int l = cubeCoord.z;

        for (int x = w - 1; x <= w + 1; x++)
        {
            if (x >= 0 && x < width)
            {
                for (int y = h - 1; y <= h + 1; y++)
                {
                    if (y >= 0 && y < height)
                    {
                        for (int z = l - 1; z <= l + 1; z++)
                        {
                            if (z >= 0 && z < length)
                            {
                                GameObject otherCube = cubeList[x, y, z];
                                BaseCube bc = otherCube.GetComponent<BaseCube>();

                                if(bc.neighbourMines > 0)
                                {
                                    bc.neighbourMines -= 1;
                                    bc.GetComponent<BaseCube>().tmp.SetText(bc.GetComponent<BaseCube>().neighbourMines.ToString());

                                    if(bc.neighbourMines == 0)
                                    {
                                        bc.gameObject.SetActive(false);
                                    }

                                }

                            }
                        }
                    }
                }
            }
        }


    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        mineNumber = 1;
        GenerateMap();
        GenerateMines();
    }

    public void AddSpace(float distance)
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    GameObject cube = cubeList[w, h, l];
                    if (w > 0 || h > 0 || l > 0)
                    {
                        cube.transform.Translate(w*distance, h*distance, l*distance);
                    }
                }
            }
        }
    }

    public void ResetPos()
    {
        if(slider.value != 0)
        {
            slider.value = 0;
        }

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    GameObject cube = cubeList[w, h, l];
                    cube.transform.position = new Vector3(w, h, l);
                }
            }
        }
    }


}
