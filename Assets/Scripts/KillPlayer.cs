using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillPlayer : MonoBehaviour
{
    public string tagEnemigo = "Enemigo";
    GameObject player;
    public Collider2D capsulecolliderenemy;
    public GameObject cono;
    public EnemyPatrol patrolcito;

    //public Animator animenemy;

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

    public void OnBanana()

    {
        capsulecolliderenemy.isTrigger = true;
        if (cono != null)
        cono.SetActive(false);
        if (patrolcito != null)
        patrolcito.patrullando = false;
        // animenemy.SetTrigger("ANIMACION DE ENEMIGO");

    }


}


