using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameData : MonoBehaviour
{
    public TMP_InputField lengthInput;
    public TMP_InputField widthInput;
    public TMP_InputField heightInput;
    public TMP_InputField mineInput;

    public int length=3;
    public int width=3;
    public int height=3;
    public int mines=1;


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LengthInputChange()
    {
        length = int.Parse(lengthInput.text);
    }

    public void WidthInputChange()
    {
        width = int.Parse(widthInput.text);
    }
    public void HeightInputChange()
    {
        height = int.Parse(heightInput.text);
    }
    public void MinesInputChange()
    {
        mines = int.Parse(mineInput.text);
    }




}
