using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Tooltip("The map texture. Check Read/Write Enabled in the texture inspector.")]
    public Texture2D mapTexture;

    public GameObject prefabTile;

    public Vector3 size = Vector2.one;

    public Vector2 spacing = Vector2.zero;

    public bool clearOnGenerate = true;

    public void Generate()
    {
        // stop if no map texture.
        if (mapTexture == null)
        {
            Debug.LogWarning("No map was applied to this Map Generator.");
            return;
        }
        
        if (clearOnGenerate) Clear();

        // cache the width and height.
        int width = mapTexture.width, height = mapTexture.height;

        // loop through all pixels and generate the map.
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Color c = mapTexture.GetPixel(x, z);

                if (c.Equals(Color.black))
                {
                    GameObject floor;
                    if (prefabTile != null)
                    {
                        floor = Instantiate<GameObject>(prefabTile, transform);
                    }
                    else
                    {
                        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        floor.transform.SetParent(transform);
                    }

                    floor.transform.localScale = new Vector3(size.x, size.y, size.z);
                    floor.transform.localPosition = new Vector3(x * (size.x + spacing.x), 0, z * (size.z + spacing.y));
                    floor.name = string.Format("Tile-{0},{1}", x, z);
                }
            }
        }
    }

    public void Clear()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
