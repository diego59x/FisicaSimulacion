using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscena : MonoBehaviour
{
    
    public void SimulacionScene()
    {
        SceneManager.LoadScene("Simulacion");
    }

    public void FirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
