using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CambioEscena : MonoBehaviour
{
    public GameObject velocidad;
    public GameObject angulo;
    public GameObject campo;
    public GameObject tiempo;
    public Dropdown particula;

    public void SimulacionScene()
    {
        string v = velocidad.GetComponent<Text>().text.ToString();
        string a = angulo.GetComponent<Text>().text.ToString();
        string ef = campo.GetComponent<Text>().text.ToString();
        string t = tiempo.GetComponent<Text>().text.ToString();
        string tipo = particula.options[particula.value].text;

        PlayerPrefs.SetString("velocidad", v);
        PlayerPrefs.SetString("angulo", a);
        PlayerPrefs.SetString("campo", ef);
        PlayerPrefs.SetString("tiempo", t);
        PlayerPrefs.SetString("tipo", tipo);

        SceneManager.LoadScene(1);
    }

    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
