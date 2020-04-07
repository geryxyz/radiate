using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpanner : MonoBehaviour
{
    public Vector2Int GridSize;
    public GameObject Tile;
    public float Gap;

    void Start()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y <GridSize.y; y++)
            {
                var instance = Instantiate(Tile);
                instance.transform.position = new Vector3(
                    (instance.GetComponent<Renderer>( ).bounds.size.x + Gap) * x,
                    0,
                    (instance.GetComponent<Renderer>( ).bounds.size.z + Gap) * y);
            }
        }
    }
}
