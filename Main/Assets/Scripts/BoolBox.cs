using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolBox : MonoBehaviour
{
    public bool value = false;
    public LineRenderer line;
    public bool switched;
    public bool lineNeeded;

    public InteractiveObject[] objects;

    void Start()
    {
        
    }
    void Update() 
    {
        if(lineNeeded)
        {
            Debug.Log(switched);
            if (switched)
            {
                line.material = line.materials[1];
            }
            else if(!switched)
            {
                line.material = line.materials[0];
            }
        }
       
    }
    public void Trigger()
    {
        foreach (InteractiveObject obj in objects)
        {
            obj.Affect(value);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        switched = true;
    }
}
