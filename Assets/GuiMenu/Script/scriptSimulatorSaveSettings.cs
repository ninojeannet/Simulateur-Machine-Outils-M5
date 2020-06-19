using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scriptSimulatorSaveSettings : MonoBehaviour
{
    int cubeSize = 128;
    int chunkSize = 16;
    int maxCubeSize = 256; 
    int minCubeSize = 128;
    int maxChunkSize = 32;
    int minChunkSize = 16;
    GameObject goTextCubeSize = null;
    TextMeshProUGUI goTextCubeSizeTxt = null;
    GameObject goTextChunkSize = null;
    TextMeshProUGUI goTextChunkSizeTxt = null;

    private void Awake()
    {
        goTextCubeSize = GameObject.Find("TextCubeSizeField");
        goTextCubeSizeTxt = goTextCubeSize.GetComponent<TextMeshProUGUI>();
        goTextCubeSizeTxt.text = cubeSize.ToString();
        PlayerPrefs.SetInt("cubeSize", cubeSize);

        goTextChunkSize = GameObject.Find("TextChunkSizeField");
        goTextChunkSizeTxt = goTextChunkSize.GetComponent<TextMeshProUGUI>();
        goTextChunkSizeTxt.text = chunkSize.ToString();
        PlayerPrefs.SetInt("chunkSize", chunkSize);
    }
    void Start() {}

    void Update() {}



    /// <summary>
    /// feed the drop down list here
    /// </summary>
    public void handleDropDownList(int val)
    {
        if(val == 0)
        {
            PlayerPrefs.SetString("typeDrill", "DrillDefault");
        }
        if (val == 1)
        {
            PlayerPrefs.SetString("typeDrill", "DrillConvex");
        }
        if (val == 2)
        {
            PlayerPrefs.SetString("typeDrill", "DrillTform");
        }
        if (val == 3)
        {
            PlayerPrefs.SetString("typeDrill", "DrillDefaultV2");
        }
    }

    public void incCubeSize()
    {
        if (cubeSize < maxCubeSize)
        {
            cubeSize *= 2;
        }
        PlayerPrefs.SetInt("cubeSize", cubeSize);
        goTextCubeSizeTxt.text = cubeSize.ToString();
    }

    public void decCubeSize()
    {
        if (cubeSize > minCubeSize)
        {
            cubeSize /= 2;
        }
        PlayerPrefs.SetInt("cubeSize", cubeSize);
        goTextCubeSizeTxt.text = cubeSize.ToString();
    }

    public void incChunkSize()
    {
        if (chunkSize < maxChunkSize)
        {
            chunkSize *= 2;
        }
        PlayerPrefs.SetInt("chunkSize", chunkSize);
        goTextChunkSizeTxt.text = chunkSize.ToString();
    }

    public void decChunkSize()
    {
        if (chunkSize > minChunkSize)
        {
            chunkSize /= 2;
        }
        PlayerPrefs.SetInt("chunkSize", chunkSize);
        goTextChunkSizeTxt.text = chunkSize.ToString();
    }
}
