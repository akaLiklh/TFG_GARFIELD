using UnityEngine;

// Deja crear directamente un nuevo personaje con este cod desde create -> Juego -> Personaje.
[CreateAssetMenu(
    fileName = "NuevoPersonaje",
    menuName = "Juego/Personaje"
)]
public class DatosPersonajes : ScriptableObject
{
    // Para pantalla de selección personajes cuando Niis complete su nivel.
    public string nombrePersonaje;
    public Sprite retratoPersonaje;
    [TextArea(3, 6)] public string objetivo;

    // Nivel que se carga para cada pj elegido.
    public string salaRescate;
    public GameObject baseJugador;

    // Objeto que el pj coloca en la sala después de ser salvado.
    public string nombreItem;
    public Sprite iconoItem;

    // Stats comunes.
    public int vidaMaxima = 100;
    public float velocidad = 5f;

    // Devuelve los stats en texto para mostrarlos en la UI.
    public virtual string GetStatsText()
    {
        return "Vida: " + vidaMaxima + "\nVelocidad: " + velocidad;
    }
}