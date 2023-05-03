using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Text error;
    [SerializeField] private Text InputTextX, InputTextY, InputTextZ;
    [SerializeField] private InputField inputFieldX, inputFieldY, InputFieldZ;
    [SerializeField] private string MyX, MyY, MyZ;
    public GameObject endpoint, inter1, inter2, inter3;
    public GameObject stick;

    float Y = 0f;
    float X = 150f;
    float Z = 25f;
    public static void Sleep(int millisecondsTimeout)
    {
        Thread.Sleep(millisecondsTimeout);
    }

    public void CheckParse()
    {
        //endpoint.transform.position = new Vector3(150f, 25f, 0f);
        MyX = InputTextX.text;
        MyY = InputTextY.text;
        MyZ = InputTextZ.text;
        if ((float.TryParse(MyX, out X)) && (float.TryParse(MyY, out Y)) && (float.TryParse(MyZ, out Z)))
        {
            //transform.position = new Vector3(150f, 25f, 0f);
            X = float.Parse(MyX) * 10f;
            Y = float.Parse(MyY) * 10f;
            Z = float.Parse(MyZ);
            
            if ((Mathf.Pow(X, 2) + Mathf.Pow(Y, 2) > Mathf.Pow(151, 2)) || (Z > 35 || Z < 10) || (X <= -10 && Y > -5 && Y < 5) || (Mathf.Pow(X, 2) + Mathf.Pow(Y, 2) < Mathf.Pow(38, 2)) || (X >= -6 && X <= -3 && Y <= 2.9 && Y >= -2.9))
            {
                error.text = ("Точка вне зоны");
                //endpoint.transform.position = new Vector3(150f, 25f, 0f);
                
            }
            else
            {
                //if (X < 35 && (Y < -20 && Y > -150))
                //{
                //    endpoint.transform.position = Vector3.MoveTowards(endpoint.transform.position, inter3.transform.position, 1f);
                //    //Sleep(5000);
                //}
                //Sleep(5000);
                error.text = (" ");
                endpoint.transform.position = new Vector3(X, Z, Y);
                

                stick.transform.position = new Vector3(stick.transform.position.x, Z, stick.transform.position.z);
            }
            
        }

    }

}
