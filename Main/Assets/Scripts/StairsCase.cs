using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCase : MonoBehaviour
{
    public Transform startPoint, endPoint;

    public Vector3 onAxis;
    public Transform[] walkWay;

    List<MovablePlatform> platforms = new List<MovablePlatform>();

    private void Awake()
    {
        if (startPoint == null || endPoint == null) enabled = false;
    }
    private void Start()
    {
        float singlePercent = 1f / walkWay.Length;
        float offset = singlePercent * 0.5f;

        for (int i = 0; i < walkWay.Length; i++)
        {
           MovablePlatform platform = walkWay[i].gameObject.AddComponent<MovablePlatform>();
           platforms.Add(platform);
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
              
        // }
    }

    private void OnTriggerEnter(Collider other) 
    {    
        if (other.tag == "player")
        {
            DoTransition();  
        }
    }
    public void DoTransition()
    {
        StartCoroutine(MovePlatforms());
    }

    private IEnumerator MovePlatforms()
    {
        float singlePercent = 1f / walkWay.Length;
        float offset = singlePercent * 0.5f;
        int i = 0;

        foreach (MovablePlatform platform in platforms)
        {
            Vector3 newPosition = (offset + (singlePercent * i)) * (endPoint.position - startPoint.position) + startPoint.position;
            Vector3 newRotation = Vector3.Angle(startPoint.position, endPoint.position) * Vector3.Reflect(onAxis, onAxis);

            platform.SetTargets(newPosition, Quaternion.Euler(newRotation));
            yield return new WaitForSeconds(0.25f);
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPoint.position, 1f);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(endPoint.position, 1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
