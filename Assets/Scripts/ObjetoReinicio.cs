using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetoReinicio : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el jugador colisiona con este objeto
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reinicia el nivel
            ReiniciarNivel();
        }
    }

    private void ReiniciarNivel()
    {
        // Vuelve a cargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

