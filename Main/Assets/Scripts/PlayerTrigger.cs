using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if(other.tag == "Gate")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
