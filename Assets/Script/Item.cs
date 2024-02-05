using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            Destroy(gameObject);
        }
    }*/
}
