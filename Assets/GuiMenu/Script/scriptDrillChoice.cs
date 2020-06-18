using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDrillChoice : MonoBehaviour
{
    string drillChoice = "";
    private void Awake()
    {
        drillChoice = PlayerPrefs.GetString("typeDrill");
        GameObject[] allChildren = new GameObject[transform.childCount];
        int i = 0;

        foreach (Transform child in transform)
        {
            allChildren[i++] = child.gameObject;
        }

        foreach (GameObject child in allChildren)
        {
            if (child.name != drillChoice)
                child.gameObject.SetActive(false);
        }
    }

    void Start() {}
    
    void Update() {}
}
