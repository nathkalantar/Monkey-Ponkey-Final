using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    //si banana choca con enemigo, destruir banana, hacer animacion de enemigo con banana 
    public Transform disparo;
    public SpriteRenderer playerSR;
    public int speedbanana;
    Vector3 targetRotation;
    Vector3 fuerza;
    Rigidbody2D proyectil;
    public GameObject banana;
    public bool isActive = false;
    public Movement movimiento;

    // Start is called before the first frame update
    private void Start()
    {
        movimiento = GetComponent<Movement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            CambiarModo();

        }
        ActualizaAngulo();
    }

    private void ActualizaAngulo()
        {
        if (isActive == true)
            {
            if (disparo != null)
            { 
            fuerza = (Input.mousePosition - Camera.main.WorldToScreenPoint(disparo.position)).normalized *speedbanana;
            targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(disparo.position);
            float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;

        if (angle > 180 || angle < 0)
            {

            }
            else
            {
                    disparo.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            Shoot();
            }
            }
            }
    }


    /*  if (angle > 90 || angle <-90)
        {
        disparoSR.flipY = true;
        }
    else
        {
        disparoSR.flipY = false; */


    public void Recargar ()
    {
        disparo = Instantiate(banana, this.transform) .transform;
        proyectil = disparo.GetComponent<Rigidbody2D>(); 
    }

    public void CambiarModo()

    {
        isActive = !isActive;
        if (isActive == true)
        {
            Debug.Log("Modo Activo");
            movimiento.ModoTieso(true);
            Recargar();
        }
        else
        {
            Debug.Log("Modo Desactivo");
            movimiento.ModoTieso(false);
            Descargar();
        }
    }

    public void Descargar()
    {
        if (proyectil !=null)
            {
            Destroy(proyectil.gameObject);
            }
    }

    void Shoot()
    {

        if(LevelManager.instance.bananaCollected >0)
        {
        proyectil.AddForce(fuerza, ForceMode2D.Impulse);
        Debug.Log("He disparado con angulo: " + disparo.rotation.z);
        Debug.Log("Posicion origen: " + disparo.position);
        Debug.Log("Posicion mouse: " + Input.mousePosition);
        LevelManager.instance.bananaCollected--;
        UIController.instance.UpdateBananaCount();
            proyectil = null;

            //debe ir cuando choca con algo, no ahorita
            if (LevelManager.instance.bananaCollected > 0)
            {
                Recargar();
            }
            else
            {
                CambiarModo();
            }
        }
    }
}
