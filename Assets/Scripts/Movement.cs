using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movimiento iz y de
    public float moveSpeed;
    public bool isMoving = false;
    public bool desactivarteclas;

    //Salto
    public float jumpForce;
    public string tagSuelo = "Suelo";
    public bool chequearSuelo = true;
    private bool puedeSaltar = true;

    //Escalar
    public Escalar escalo;

    //Componentes
    public Rigidbody2D theRb;
    public Animator anim;
    public CapsuleCollider2D capsulecolli;
    public float gravedadInicial;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        //agregado recién
        theRb = GetComponent<Rigidbody2D>();
        gravedadInicial = theRb.gravityScale;
        escalo = GetComponent<Escalar>();

        //no agregado recién
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (desactivarteclas == false)
        { 
        float hori = Input.GetAxis("Horizontal");

        if (hori != 0f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        theRb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRb.velocity.y);


            if (puedeSaltar && Input.GetButtonDown("Jump"))
         {
            escalo.DesactivarEscalix();
            theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
            puedeSaltar = !chequearSuelo;
            anim.SetTrigger("Jump");
            AudioManager.instance.PlayJump();
        }

        if (escalo.escalando)
            {
                AnimEscalar();
            }
            else
            {
                StopEscalar();
            } 
        

        if (theRb.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRb.velocity.x > 0)
        {
            theSR.flipX = false;
        }
    }
}

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (chequearSuelo) 
        {
            if(collisionData.gameObject.CompareTag(tagSuelo) || (escalo.escalando))
            {
                escalo.ActivarEscalix();
                puedeSaltar = true;
            }
        }

    }

    public void Desactivate()
    {
        desactivarteclas = true;
        capsulecolli.isTrigger = true;
        theRb.gravityScale=0f;
        theRb.velocity = Vector2.zero;
    }

    public void ModoTieso(bool value)
        {
            desactivarteclas = value;
        }


        public void AnimEscalar ()
    {
        anim.SetBool("Escalando", true);
        anim.SetBool("EscalandoIdle", escalo.verti == 0);
        
    }

    public void StopEscalar ()
    {
        anim.SetBool("Escalando", false);
        anim.SetBool("EscalandoIdle", false);
    }    

}

