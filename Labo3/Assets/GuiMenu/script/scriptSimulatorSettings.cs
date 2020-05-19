using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptSimulatorSettings : MonoBehaviour
{
    private int cubeSize = 0;
    private int[,] cubeSizeTab = new int[256, 256];

    public int minCubeSize = 3;
    public int maxCubeSize = 255;
    public int cubeSizeX = 3;
    public int cubeSizeY = 3;

    

    // Start is called before the first frame update
    void Start()
    {
        initTabTo0();
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

        this.cubeSize = cSize;
        this.cubeSizeX = cSize;
        this.cubeSizeY = cSize;

        Debug.Log("cubeSize:"+ cubeSize.ToString() + ",cubeSizeX:" + cubeSizeX.ToString() + ",cubeSizeY" + cubeSizeY.ToString());
    }

    public int getCubeSize()
    {
        return this.cubeSize;
    }
    public int getCubeSizeX()
    {
        return this.cubeSizeX;
    }
    public int getCubeSizeY()
    {
        return this.cubeSizeY;
    }

    public int[,] getCubeSizeTab()
    {
        return this.cubeSizeTab;
    }

    private void initTabTo0()
    {
        for (int i = 0; i < 256; i++)
        {
            for (int j = 0; j < 256; j++)
            {
                this.cubeSizeTab[i,j] = 0;
            }
        }
    }

    
}
