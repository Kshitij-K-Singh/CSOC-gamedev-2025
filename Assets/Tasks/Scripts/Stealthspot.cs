using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealthspot : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerScript>() != null)
            {
                collision.GetComponent<PlayerScript>().EnterStealthMode();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerScript>() != null)
            {
                collision.GetComponent<PlayerScript>().ExitStealthMode();
            }
        }
    }

}
