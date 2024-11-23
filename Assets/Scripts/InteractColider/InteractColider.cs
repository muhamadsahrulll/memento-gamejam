using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractColider : MonoBehaviour
{
    public GameObject buttuonOrImage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttuonOrImage.SetActive(true);
            //Debug.Log("Muncul");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            buttuonOrImage.SetActive(false);
        }
    }

    
}
