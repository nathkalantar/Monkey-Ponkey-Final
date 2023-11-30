using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isBanana;

    private bool isCollected;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isBanana)
            {
                LevelManager.instance.bananaCollected++;
                UIController.instance.UpdateBananaCount();
                isCollected = true;
                AudioManager.instance.PlayCollectable();
                anim.SetBool("isCollected",true);

            }
        }

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
