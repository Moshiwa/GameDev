using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    internal static UnityEngine.Color red;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController character = collider.GetComponent<PlayerController>();
        if (character)
        {
            character.color += 100;
            Destroy(gameObject);
        }
    }
}
