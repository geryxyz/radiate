using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpanner : MonoBehaviour
{
    public Vector2Int GridSize;
    public GameObject Tile;
    public float Gap;

    List<GameObject> tiles = new List<GameObject>( );

    void Start()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y <GridSize.y; y++)
            {
                var instance = Instantiate(Tile);
                Vector2 size = new Vector2(
                    instance.GetComponent<Renderer>( ).bounds.size.x,
                    instance.GetComponent<Renderer>( ).bounds.size.z);
                Vector2 maxSize = new Vector2(
                    (size.x + Gap) * (GridSize.x - 1),
                    (size.y + Gap) * (GridSize.y - 1));
                instance.transform.position = new Vector3(
                    (size.x + Gap) * x - maxSize.x * .5f,
                    0,
                    (size.y + Gap) * y- maxSize.y * .5f);
                tiles.Add(instance);
            }
        }
    }

    public GameObject GetRandomTile()
    {
        return tiles[Random.Range(0, tiles.Count)];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit( );
        }
    }
}
