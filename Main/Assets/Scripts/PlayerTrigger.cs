using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public Vector3 respawnPosition;
    private void Start()
    {
        respawnPosition = gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(1 << i);
        }
    }

    void Update()
    {
         
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);          
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
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
            }
            
        }
        
        if(other.tag == "ExitGame")
        {
            Application.Quit();
        }

        if (other.tag == "respawnWall")
        {
            gameObject.transform.position = respawnPosition;
        }
    }

    
}
