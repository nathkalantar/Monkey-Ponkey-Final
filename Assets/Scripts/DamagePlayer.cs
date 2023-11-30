using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(other.gameObject.GetComponent<Movement>().desactivarteclas)
            {
                Debug.Log("desactivadas las teclas");
            }
            else
            {
                Debug.Log("Hit");
                PlayerHealthController.instance.AnimDamage();
                AudioManager.instance.PlayHurt();

            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}
