using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpanner : MonoBehaviour
{
    public GameObject BluePrototype;
    public GameObject RedPrototype;

    public int MinCount = 3;

    GridSpanner gridSpanner;

    void Start()
    {
        gridSpanner = FindObjectOfType<GridSpanner>( ).GetComponent<GridSpanner>( );
    }

    void Update()
    {
        refill(BluePrototype);
        refill(RedPrototype);
    }

    private void refill(GameObject prototype)
    {
        var pieces = GameObject.FindGameObjectsWithTag(prototype.tag);
        if(pieces.Length < 3)
        {
            for(int i = 0; i < 3 - pieces.Length; i++)
            {
                var instance = Instantiate(prototype);
                instance.transform.position =
                    gridSpanner.GetRandomTile( ).transform.position + new Vector3(0, 2f, 0);
            }
        }
    }
}
