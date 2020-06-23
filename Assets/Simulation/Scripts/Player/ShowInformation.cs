using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInformation : MonoBehaviour
{
    private bool isHide = false;
    private Text[] txt = null;

    private void Awake()
    {
        //txt = GameObject.Find("TextInfo").GetComponent<Text>();
        txt = GetComponentsInChildren<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (Text t in txt)
                t.gameObject.SetActive(isHide);

            isHide = !isHide;
        }
    }
}
