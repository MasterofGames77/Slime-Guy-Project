using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerSpawn>();
        if (player != null)
        {
            //PlayerSpawn.lastCheckPointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
