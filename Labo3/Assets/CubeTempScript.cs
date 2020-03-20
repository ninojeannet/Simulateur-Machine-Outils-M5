using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTempScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goTarget;
    public GuiManagerScript GM;
    


    void ChangeColor()
    {
        Renderer render = goTarget.GetComponent<Renderer>();
        render.material.color = Color.red;
    }

    void Start()
    {
        GM = GameObject.FindObjectOfType<GuiManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter(Collider other)
    {
        goTarget.transform.position = goTarget.transform.position + new Vector3(-1, 0, 0);
    }
}
