using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GuiManagerScript : MonoBehaviour
{

    public int CubeSize = 30;
    private GameObject cubeTemp;


    public void UpdateCubeTempData()
    {
        cubeTemp = GameObject.Find("CubeTemp");

        Renderer cbRender = cubeTemp.gameObject.GetComponent<Renderer>();
        cbRender.material.color = Color.magenta;
        Debug.Log("salope");
    }

    void ButtonClickBande2P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setCubeSize(int cz)
    {

    }
}
