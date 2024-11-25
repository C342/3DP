using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCollect : MonoBehaviour
{
    static int coins = 0;

    bool dead = false;

    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] AudioSource collectionSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            collectionSound.Play();
        }
    }

    public void Start()
    {
        coinsText.text = "Coins: " + coins;
    }

    private void Update()
    {
        if (transform.position.y < -10f && !dead)
        {
            ClearScore();
        }
    }

    void ClearScore()
    {
        coins = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            ClearScore();
        }
    }
}
