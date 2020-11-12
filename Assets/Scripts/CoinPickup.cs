using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickUpSFX;
    // FIX IT, Coin value is x2 at runtime
    [SerializeField] int pointsForCoinPickUp = 50;

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickUp);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }

}
