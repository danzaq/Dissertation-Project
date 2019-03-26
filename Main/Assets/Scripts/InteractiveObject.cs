using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [System.Flags]
    public enum PropertyType
    {
        None = 0, Visibility = 1 << 0, Position = 1 << 1, Rotation = 1 << 2, AllProperties = ~0
    }

    public bool defaultValue = false;

    [EnumFlag]
    public PropertyType type;

    public Transform positionFalse;

    public Transform positionTrue;

    public float maxDistanceDelta = 10f;

    private Vector3 currentPosition;

    private void Start()
    {
        Affect(defaultValue);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, maxDistanceDelta * Time.deltaTime);
    }

    public void Affect(bool value)
    {
        if ((type & PropertyType.Visibility) == PropertyType.Visibility)
        {
            gameObject.SetActive(value);
        }

        if ((type & PropertyType.Position) == PropertyType.Position)
        {
            currentPosition = value ? positionTrue.position : positionFalse.position;
        }

        if ((type & PropertyType.Rotation) == PropertyType.Rotation)
        {
            transform.rotation = value ? positionTrue.rotation : positionFalse.rotation;
        }
    }
}
