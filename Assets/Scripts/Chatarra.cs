using UnityEngine;

// Usamos esta clase para que el jugador pueda recoger chatarra y sumar puntos.
public class Chatarra : MonoBehaviour
{
    private Animator animator;
    private Collider2D col;
    private bool recogido;
    public int value = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

    }

    // Cuando un personaje toque la chatarra.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Solo se recogerá cuando un objeto con el tag de player pase x encima.
        if (recogido || !other.CompareTag("Player")) return;

        recogido = true;
        col.enabled = false;
        animator.SetTrigger("Recoger");
    }

    // Sumar puntos y borrar chatarra.
    public void TerminarRecogida()
    {
        GameManager.Instance.AñadePuntos(value);
        Destroy(gameObject);
    }
}


