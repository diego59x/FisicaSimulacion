using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text nombreparticula;
    public Text nposicion;
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
            carga = -1.6 * Mathf.Pow(10, -19);
            masa = 9.1095 * Mathf.Pow(10, -31);
        }
        else if (particula == "Proton")
        {
            carga = 1.6 * Mathf.Pow(10, -19);
            masa = 1.6725 * Mathf.Pow(10, -27);
        }
        else if (particula == "Neutron")
        {
            carga = 0;
            masa = 1.6748 * Mathf.Pow(10, -27);
        }
        else if (particula == "Positron")
        {
            carga = 1.602176487 * Mathf.Pow(10, -19);
            masa = 9.109 * Mathf.Pow(10, -31);
        }
        else if (particula == "Particula Alfa")
        {
            carga = 3.2 * Mathf.Pow(10, -19);
            masa = 6.64 * Mathf.Pow(10, -27);
        }
        else if (particula == "Muon")
        {
            carga = 1.6 * Mathf.Pow(10, -19);
            masa = 1.9 * Mathf.Pow(10, -28);
        }
        else if (particula == "Quark Cima")
        {
            carga = (2/3)*(1.6 * Mathf.Pow(10, -19));
            masa = 307.5 * Mathf.Pow(10, -27);
        }
        else if (particula == "Quark Extrano")
        {
            masa = 142.61 * Mathf.Pow(10, -30);
            carga = -(1/3) * (1.6 * Mathf.Pow(10, -19));
        }
        else if (particula == "Quark Abajo")
        {
            masa = 7.13 * Mathf.Pow(10, -30);
            carga = -(1/3) * (1.6 * Mathf.Pow(10, -19));
        }
        else if (particula == "Quark Fondo")
        {
            masa = 7.13 * Mathf.Pow(10, -27);
            carga = -(1/3) * (1.6 * Mathf.Pow(10, -19));
        }

        Vx = velocidad * Mathf.Cos((float)rad);
        Vy = velocidad * Mathf.Sin((float)rad);
        a = (carga * campoE) / masa;

        //Se coloca la particula en el inicio del campo contrario
        if ((carga > 0 && campoE > 0) || (carga < 0 && campoE < 0)) {
            if(velocidad>0)
                transform.position = new Vector3(-170, 90, 0);
            else
            {
                transform.position = new Vector3(170, 90, 0);
            }
        } else if (carga < 0 && campoE > 0 || (carga > 0 && campoE < 0)) {
            if (velocidad>0)
                transform.position = new Vector3(-170, -90, 0);
            else
                transform.position = new Vector3(170, -90, 0);
        }
        //Dependiendo de la carga se coloca el color de la particula
        if (carga > 0)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        } else if (carga < 0)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        //Dependiendo del campo se voltea la simulacion
        if (campoE < 0)
        {
            for(int i = 0; i < 3; i++)
                GameObject.FindGameObjectsWithTag("Arrow")[i].transform.Rotate(0, 0, 180);
            GameObject.FindGameObjectWithTag("Up").GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            GameObject.FindGameObjectWithTag("Down").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        StartCoroutine(simulado());


    }
    IEnumerator simulado()
    {
        yield return new WaitForSeconds(2);
        Vector3 pos = transform.position;

        for (int i = 1; i < tiempo; i++)
        {
            float retardo = i * Mathf.Pow(10, -3);
            float x_normal = (float)(Vx*i)/10;

            float y_normal = ((float)Vy * retardo) - (float)(0.5 * a * (Mathf.Pow(retardo, 2)));

            
            //Para que se pueda ver completo
            if (Math.Abs(y_normal) >= Math.Pow(10, 5))
            {
                y_normal = (y_normal / (Mathf.Pow(10, 6))) / i;
            } else if (Math.Abs(y_normal) > Math.Pow(10, 2))
            {
                y_normal = (y_normal / (Mathf.Pow(10, 3))) / i;
            }
            

            pos.x += x_normal;
            pos.y += y_normal;
            transform.position = pos;

            nombreparticula.text = "Particula: " + particula;
            nposicion.text = "Posicion actual: " + (int)x_normal + ", " + (int)y_normal;


            yield return new WaitForSeconds(2);


        }
    }
}
