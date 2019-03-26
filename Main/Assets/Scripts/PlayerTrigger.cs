using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(1 << i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Switch")
        {
            BoolBox box = other.GetComponent<BoolBox>();
            if (box != null)
            {
                box.Trigger();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");
        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }
}
