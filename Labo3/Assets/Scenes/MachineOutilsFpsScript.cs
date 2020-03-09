using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*script très simple pour compter le nombre de frame / second*/
public class MachineOutilsFpsScript : MonoBehaviour
{

    private int frameCount = 0;
    private string frameCountString = "";

    void Start()
    {
        InvokeRepeating("FPShomeMade", 1, 1);
    }

    void Update()
    {
        frameCount++;
    }

    void FPShomeMade()
    {
        frameCountString = frameCount.ToString();
        frameCount = 0;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 250, 100), "From MachineOutilsFpsScript-> FPS: " + frameCountString);
    }



}
