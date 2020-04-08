using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Radiate : MonoBehaviour
{
    public GameObject Prototype;
    public int MaxCount = 8;
    public int MinCount = 2;
    public float MaxForce = 5f;
    public float MinForce = 0f;
    public Material Touched;
    public float ShrinkTime = 10;

    private void OnMouseDown()
    {
        Destroy(gameObject);

        var count = Random.Range(MinCount, MaxCount);
        Vector3 direction = new Vector3(count / (2 * Mathf.PI) + .1f, 0, 0);
        var rotaryOffset = Quaternion.Euler(0, 360.0f / count + Random.Range(0f, 360f), 0);
        for(int i = 0; i < count; i++)
        {
            direction = rotaryOffset * direction;
            var instance = Instantiate(Prototype);
            instance.transform.position = transform.position + direction;
            instance.GetComponent<Rigidbody>().AddForce(direction * Random.Range(MinForce, MaxForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            collision.gameObject.GetComponent<MeshRenderer>( ).material = Touched;
        }
    }
}
