using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolBox : MonoBehaviour
{
    public bool value = false;

    public InteractiveObject[] objects;

    public void Trigger()
    {
        foreach (InteractiveObject obj in objects)
        {
            obj.Affect(value);
        }
    }
}
