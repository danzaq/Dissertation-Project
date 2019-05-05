using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stairPieces;
    public float offSet;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    public bool move;
    
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "player")
        {
            RaiseStaircase();
            move = false;
        }        
    }

    void RaiseStaircase()
    {
        if (move)
        {
            for (int i = 0; i < stairPieces.Length; i++)
            {
                currentPosition = stairPieces[i].transform.position;
                newPosition = new Vector3(currentPosition.x,(currentPosition.y + (i + offSet)),currentPosition.z);
                stairPieces[i].transform.position = newPosition;
            }  
        }
        
    }
}
