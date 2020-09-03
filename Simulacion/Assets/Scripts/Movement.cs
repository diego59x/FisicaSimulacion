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
        
        velocidad = Convert.ToDouble(PlayerPrefs.GetString("velocidad"));// problema
        angulo = Convert.ToDouble(PlayerPrefs.GetString("angulo"));
        campoE = Convert.ToDouble(PlayerPrefs.GetString("campo"));// problema
        tiempo = Convert.ToDouble(PlayerPrefs.GetString("tiempo"));//problema
        particula = PlayerPrefs.GetString("tipo");//problemon

        posicion = transform.position;
        rad = angulo * Mathf.Deg2Rad;
        print("tiempo " + tiempo);

        print("angulo " + angulo);
        if (particula == "Electron")
        {
            carga = -1.6 * Mathf.Pow(10,-19);
            masa = 9.1095 * Mathf.Pow(10, -31);
        } else if (particula == "Proton")
        {
            carga = -1.6 * Mathf.Pow(10,-19);
            masa = 1.6725 * Mathf.Pow(10,-27);
        } else if (particula == "Neutron")
        {
            carga = 0;
            masa = 1.6748 * Mathf.Pow(10,-27);
        }
        else if (particula == "Positron")
        {
            carga = 1.602176487 * Mathf.Pow(10,-19);
            masa = 9.109 * Mathf.Pow(10,-31);
        }
        else if (particula == "Partícula Alfa")
        {
            carga = 3.2 * Mathf.Pow(10,-19);
            masa = 6.64 * Mathf.Pow(10,-27);
        }
        else if (particula == "Muón")
        {
            carga = 1.6 * Mathf.Pow(10,-19);
            masa = 1.9 * Mathf.Pow(10,-28);
        }
        else if (particula == "Quark Cima")
        {
            masa = 307.5 * Mathf.Pow(10,-27); 
            carga = 2 / 3 * (1.6 * Mathf.Pow(10,-19));
        }
        else if (particula == "Quark Extraño")
        {
            masa = 142.61 * Mathf.Pow(10,-30);
            carga = -1 / 3 * (1.6 * Mathf.Pow(10,-19));
        }
        else if (particula == "Quark Abajo")
        {
            masa = 7.13 * Mathf.Pow(10,-30);
            carga = -1 / 3 * (1.6 * Mathf.Pow(10,-19));
        }
        else if (particula == "Quark Fondo")
        {
            masa = 7.13 * Mathf.Pow(10,-27); 
            carga = -1 / 3 * (1.6 * Mathf.Pow(10,-19));
        }


        Vx = velocidad * Mathf.Cos((float)rad);
        Vy = velocidad * Mathf.Sin((float)rad);
        a = (carga * campoE) / masa;
        print("carga " + carga);
        print("campoE " + campoE);
        print("masa " + masa);

        print("velocidad x "+Vx);
        print("velocidad y " + Vy);
        print("aceleracion " + a);
        StartCoroutine(simulado());


    }
    IEnumerator simulado()
    {
        for (int i = 0; i < tiempo; i++)
        {
            float retardo = i * (Mathf.Pow(10,-6));
            

            float x_normal = (float)Vx * i; // al ponerle el retardo se ve muy mal, se queda en el mismo punto en x 
            float y_normal = ((float)Vy * retardo) - (float)(0.5 * a * Mathf.Pow(retardo,2));

            //print("retardo" + Mathf.Pow(retardo,2) );
            //print("y normal"+ y_normal);
            //print(" 2 parte " + (float)(0.5 * a * (Mathf.Pow(retardo,2))));


            posicion.x += x_normal/10; //Para que se pueda ver completo
            posicion.y += y_normal/10; //Para que se pueda ver completo
            posicion.z = 0;
            transform.position = posicion;

            //print("x"+posicion.x);
            //print("y" + posicion.y);

            print("Posicion actual (" + x_normal*10 + " , " + y_normal*10 + ")");


            yield return new WaitForSeconds(2);


        }
    }
}
