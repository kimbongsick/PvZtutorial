using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    private float dropToYPos;

    private float speed = .15f;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-4f, 8.35f), 6, 0);
        dropToYPos = Random.Range(2f, -3f);
        Destroy(gameObject, Random.Range(6, 12));
    }

    private void Update()
    {
        if (transform.position.y >= dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
