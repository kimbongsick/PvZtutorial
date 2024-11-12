using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    public Animator ani;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            ani.Play("deathAni");
            Debug.Log("ªÁ∏¡√Êµπ!");
            Invoke("RestartScene", 5);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
