using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsManager : MonoBehaviour
{
    public Arms root;
    public Arms end;
    public GameObject endPoint, inter1, inter2;
    public float minDistance = 0.05f;
    //public float speed;

    float GetDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }

    float CalculateSlope(Arms arms)
    {
        float Delta = 0.01f;

        float distance1 = GetDistance(end.transform.position, endPoint.transform.position);

        arms.Rotate(Delta);

        float distance2 = GetDistance(end.transform.position, endPoint.transform.position);

        arms.Rotate(-Delta);

        return (distance2 - distance1) / Delta;
    }

    // Update is called once per frame
    void Update()
    {   
        if (GetDistance(end.transform.position, endPoint.transform.position) > minDistance)
        {
            Arms current = root;
            float degree = 0;
            while (current != null)
            {
                float slope = CalculateSlope(current);
                
                degree = degree - slope;
                //Debug.Log(degree);

                current.Rotate(-slope);
                current = current.GetChild();

                
            }
        }   
    }

}
