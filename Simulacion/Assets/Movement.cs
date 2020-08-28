using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    private double velocidad;
    private double angulo;
    private double campoE;
    private double tiempo;
    private double carga;
    private double masa;
    private string particula;
    private Vector3 posicion;
    private double Vx;
    private double Vy;
    private double a;
    private double rad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = Convert.ToDouble(PlayerPrefs.GetString("velocidad"));
        angulo = Convert.ToDouble(PlayerPrefs.GetString("angulo"));
        campoE = Convert.ToDouble(PlayerPrefs.GetString("campo"));
        tiempo = Convert.ToDouble(PlayerPrefs.GetString("tiempo"));
        particula = PlayerPrefs.GetString("tipo");


        posicion = transform.position;
        rad = angulo * Mathf.Deg2Rad;
        if (particula == "Electron")
        {
            carga = -1.6 * 10 * Mathf.Exp(-19);
            masa = 9.1095 * 10 * Mathf.Exp(-31);
        } else if (particula == "Proton")
        {
            carga = -1.6 * 10 * Mathf.Exp(-19);
            masa = 1.6725 * 10 * Mathf.Exp(-27);
        } else if (particula == "Neutron")
        {
            carga = 0;
            masa = 1.6748 * 10 * Mathf.Exp(-27);
        }

        Vx = velocidad * Mathf.Cos((float)rad);
        Vy = velocidad * Mathf.Sin((float)rad);
        a = (carga * campoE) / masa;
        StartCoroutine(simulado());


    }
    IEnumerator simulado()
    {
        for (int i = 0; i < tiempo; i++)
        {
            float retardo = i * (10 * Mathf.Exp(-5));
            float x_normal = (float)Vx * retardo;
            float y_normal = ((float)Vy * retardo) - (float)(0.5 * a * (retardo * Mathf.Exp(2)));


            posicion.x += x_normal/10; //Para que se pueda ver completo
            posicion.y += y_normal/10; //Para que se pueda ver completo
            posicion.z = 0;
            transform.position = posicion;

            print("Posicion actual (" + x_normal*10 + " , " + y_normal*10 + ")");


            yield return new WaitForSeconds(2);


        }
    }
}
