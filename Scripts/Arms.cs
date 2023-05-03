using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public Arms child;

    public Arms GetChild()
    {
        return child;
    }
    
    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.up * angle);
    }
}
