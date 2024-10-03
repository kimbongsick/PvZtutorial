using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float speed;

    public int health;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage)
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
