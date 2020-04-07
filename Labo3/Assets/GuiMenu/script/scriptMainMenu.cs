using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMainMenu : MonoBehaviour
{
    public void StartSimulator()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitSimulator()
    {
        Application.Quit();
    }

}
