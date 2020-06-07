using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptUpdateData : MonoBehaviour
{
    // Start is called before the first frame update

    private float deformSpeed;
    private float deformRange;
    private Text txt;

    private void Awake()
    {
        txt = GameObject.Find("TextInfo").GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        deformSpeed = PlayerPrefs.GetFloat("deformSpeed");
        deformRange = PlayerPrefs.GetFloat("deformRange");

        System.Math.Round(deformSpeed, 1);
        System.Math.Round(deformRange, 1);

        txt.text = "Deforme Speed : " + deformSpeed + "\nDeforme Range : " + deformRange;

    }
}
