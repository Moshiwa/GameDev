using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lava : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(collision.gameObject.name == "heroCube")
        {
            collision.GetComponent<PlayerController>().CreateDeath();
        }
        else
        {
            collision.GetComponent<Enemy>().CreateDeath();
        }
    }

}
