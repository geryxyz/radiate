using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreCounter : MonoBehaviour
{
    public GameObject Tile;
    public Material OwnMaterial;
    public string Unit;

    void Update()
    {
        var tiles = new List<GameObject>(GameObject.FindGameObjectsWithTag(Tile.tag));
        var score = tiles.Count(e => e.GetComponent<MeshRenderer>( ).sharedMaterial == OwnMaterial);
        GetComponent<Text>( ).text = string.Format($"{score} {Unit}");
    }
}
