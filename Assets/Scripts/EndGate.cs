using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        // If a collision with the Player is detected, end the level
        if (collision.gameObject.CompareTag("Player"))
            LevelManager._EndLevel();
    }

}
