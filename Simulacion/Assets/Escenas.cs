using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Escenas : MonoBehaviour
{
    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void SecondScene()
    {
        SceneManager.LoadScene(1);
    }
}
