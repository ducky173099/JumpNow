using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player") //neu khi vao cham moi tam van truot, thi player se di chuyen theo tam van 
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    */


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //neu khi vao cham moi tam van truot, thi player se di chuyen theo tam van 
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
