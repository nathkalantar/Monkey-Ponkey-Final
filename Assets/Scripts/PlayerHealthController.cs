using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    public Animator anim;

    public GameManager gameManager;
    public bool isDead;

    private void Awake()
    {
        instance = this;
    }


    public void DealDamage()
    {
        currentHealth += Time.deltaTime;

        if (currentHealth >= 10)
        {
            currentHealth = 10;
            AnimMuerte();
        }
        LevelManager.instance.valordedeteccion = currentHealth;
        UIController.instance.UpdateBarraDeteccion();
    }

    public void AnimDamage()
    {
        anim.SetTrigger("Hit");

    }

    public void AnimMuerte()
    {
        anim.SetTrigger("Dead");
        GetComponent<Movement>().desactivarteclas = true;
        isDead = true;
        UIController.instance.Slidercito=false;
    }

    public void KillGameOver ()
    {
        if (isDead)
        {
            Debug.Log("voyamorir");
            gameManager.gameOver();
            
        }
    }

    /* 
     public void Anima()
     {
         if (currentHealth >= 10)
         {
             currentHealth = 10;
             anim.SetTrigger("Dead");
         }
     }

     public void DestroyMe()
     {
         if (currentHealth >= 10)
         {
             currentHealth = 10;
             gameObject.SetActive(false);
         }
     }
    */

}
