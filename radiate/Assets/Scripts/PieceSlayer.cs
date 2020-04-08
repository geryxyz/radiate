using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSlayer : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < 0f)
        {
            Destroy(gameObject);
        }
    }
}
