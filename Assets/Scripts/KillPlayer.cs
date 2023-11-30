using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillPlayer : MonoBehaviour
{
    public string tagEnemigo = "Enemigo";
    GameObject player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Te toqué " + collision.gameObject.name);

        if (collision.gameObject.tag == "Player" && gameObject.CompareTag("Enemigo"))
        {
            player = collision.gameObject;

            PlayerHealthController.instance.AnimMuerte();
            player.GetComponent<Movement>().Desactivate();
            Debug.Log("Te quito vida");
        

        }
    }


}


