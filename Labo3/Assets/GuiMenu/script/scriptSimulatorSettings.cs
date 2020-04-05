using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptSimulatorSettings : MonoBehaviour
{
    private int cubeSize = 0;
    public int minCubeSize = 3;
    public int maxCubeSize = 255;
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setCubeSize(int cSize)
    {
        if (cSize < 3 && cSize > 255)
            cSize = 10;

        GameObject go = GameObject.Find("SliderSize");
        Slider sliderSize = go.GetComponent<Slider>();

        cubeSize = (int)sliderSize.value;

        

        Debug.Log(cubeSize.ToString());

        this.cubeSize = cSize;
    }

    public int getCubeSize()
    {
        return this.cubeSize;
    }
}
