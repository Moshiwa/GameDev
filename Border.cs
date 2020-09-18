using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    public Transform groundCheck;
    public Transform botBorder;

    private void FixedUpdate()
    {
        if (groundCheck)
        {
            if (groundCheck.transform.position.y < botBorder.transform.position.y)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
     
}
