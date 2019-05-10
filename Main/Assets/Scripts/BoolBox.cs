using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolBox : MonoBehaviour
{
    public bool value = false;

    public LineRenderer line;
    
    public bool switched;
    
    public bool lineNeeded;

    public BoolBox oppositeBool;

    public InteractiveObject[] objects;

    public Gradient disabledColor, activeColor;

    void Start()
    {
        ToggleLine();
    }
    
    void Update() 
    {
        if(lineNeeded)
        {
            Debug.Log(switched);
            
        }
       
    }

    public void Trigger()
    {
        oppositeBool.TurnOff();
        foreach (InteractiveObject obj in objects)
        {
            obj.Affect(value);
        }
    }

    private void TurnOff()
    {
        switched = false;
        ToggleLine();
    }

    private void ToggleLine() => line.colorGradient = switched ? activeColor : disabledColor;

    private void OnTriggerEnter(Collider other) 
    {
        switched = true;
        ToggleLine();
    }
}
