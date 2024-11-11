using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    private void OnCollisionEnter(Collision collision)
    {
        void Update()
        {
            if (transform.position.y < -1f && !dead)
            {
                Die();
            }
        }

        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die(); 
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled =  false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}