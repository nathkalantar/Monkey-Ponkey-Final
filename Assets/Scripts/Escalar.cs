using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalar : MonoBehaviour
{
    public float velocidadescalar;
    public CapsuleCollider2D capsulecolli;
    public float gravedadInicial;
    public bool escalando;
    public bool puedoescalar;
    public Rigidbody2D theRb;
    public float verti;
    //public vector2 input

    // Start is called before the first frame update
    void Start()
    {
        theRb = GetComponent<Rigidbody2D>();
        gravedadInicial = theRb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        verti = Input.GetAxis("Vertical");
        Escalanding();
    }
    private void Escalanding()
    {
        if (puedoescalar)
            if ((verti != 0 || escalando) && (capsulecolli.IsTouchingLayers(LayerMask.GetMask("Soga"))))
            {
                Vector2 velocidadSubida = new Vector2(theRb.velocity.x, verti * velocidadescalar);
                theRb.velocity = velocidadSubida;
                theRb.gravityScale = 0;
                escalando = true;


            }

            else
            {
                // if (!GetComponent<Movement>().desactivarteclas)
                if (PlayerHealthController.instance.isDead==false)
                theRb.gravityScale = gravedadInicial;
                escalando = false;
        }


    }
    public void DesactivarEscalix ()
      {
        puedoescalar = false;
        theRb.gravityScale = gravedadInicial;
        escalando = false;
    }

    public void ActivarEscalix ()
    {
        puedoescalar = true;
    }
}
