using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPrefab : MonoBehaviour
{
    public GameObject bananapref;
    public CapsuleCollider2D capsulecolli;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /* private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
           Object.Destroy(bananapreb);
        }
    } */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
        {
            Debug.Log("Toqué al enemigo");
            Object.Destroy(bananapref);
            //capsulecolli del enemigo
            capsulecolli.isTrigger = true;
            //desactivar cono de deteccion
            gameObject.SetActive(false);
        }
    }
}
