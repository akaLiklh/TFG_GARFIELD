using UnityEngine;

// Usanis esta clase para definir el mnoviemietno del jugador.
public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private DatosPersonajes datos;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }


    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;
    }


    private void FixedUpdate()
    {
        rb.velocity = movimiento * datos.velocidad;
    }
}
