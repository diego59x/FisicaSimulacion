using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscena : MonoBehaviour
{

    public void FirstScene()
    {
        SceneManager.LoadScene("Principal");
    }
    public void SecondScene()
    {
        SceneManager.LoadScene("Simulacion");
    }
}
