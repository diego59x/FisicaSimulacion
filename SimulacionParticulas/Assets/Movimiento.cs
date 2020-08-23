using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    private float velocidad = 5;
    private float angulo = 30;
    private float campoE = 1000;
    private float tiempo = 10;
    private double carga;
    private double masa;
    private string particula = "electron";
    private Vector3 posicion;
    private double x;
    private double y;
    private double a;
    private float rad;
    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position;
        rad = angulo * Mathf.Deg2Rad;
        if (particula == "electron")
        {
            carga = -1.6 * 10 * Mathf.Exp(-19);
            masa = 9.1 * 10 * Mathf.Exp(-31);
        }

        x = velocidad * Mathf.Cos(rad);
        y = velocidad * Mathf.Sin(rad);
        a = ((carga * campoE) / masa) * (1 / 10 * Mathf.Exp(11));
        StartCoroutine(simulado());
        
        
    }
    IEnumerator simulado()
    {
        for (int i = 0; i < tiempo; i++)
        {
            
            posicion.x += (float)x * i;
            posicion.y += (float)y * i - (float)(0.5 * a * (i * Mathf.Exp(2)));
            posicion.z = 0;

            print(posicion);
            transform.position = posicion;
            print("j" + transform.position);

            yield return new WaitForSeconds(2);
            
            
        }
    }
    
}
