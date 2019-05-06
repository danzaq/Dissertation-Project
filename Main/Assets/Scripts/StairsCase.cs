using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stairPieces;
    public float openSpeed;
    public float offSet;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    public bool triggered;
    [Header("The angle added has to always be 12.84")]
    public float xAng;
    public float yAng;
    public float zAng;

    Coroutine MoveIE;
    
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "player" && !triggered)
        {
            StartCoroutine(moveObject());
            triggered = true;
        }        
    }

    IEnumerator moveObject()
    {
        for (int i = 0; i < stairPieces.Length; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            newPosition = new Vector3(stairPieces[i].transform.position.x,(stairPieces[i].transform.position.y + (i + offSet)),stairPieces[i].transform.position.z);
            Debug.Log(newPosition);
            yield return MoveIE;
        }
    }

    IEnumerator Moving(int initialPosition)
    {
        while (stairPieces[initialPosition].transform.position != newPosition)
        {
            Debug.Log("hello");
            Debug.Log(stairPieces[initialPosition].transform.position);
            stairPieces[initialPosition].transform.position = Vector3.MoveTowards(stairPieces[initialPosition].transform.position, newPosition , openSpeed * Time.deltaTime);
            stairPieces[initialPosition].transform.eulerAngles = new Vector3(xAng,yAng,zAng);
            yield return null;
        }        
    }
    
}
