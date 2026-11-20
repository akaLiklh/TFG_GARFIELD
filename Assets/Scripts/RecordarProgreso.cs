using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Usamos esta clase para guardar que personajes ya has "salvado" y a quién estás rescatando.
public class RecordarProgreso : MonoBehaviour
{
    public static RecordarProgreso Instance;
    public DatosPersonajes[] personajes;


    private DatosPersonajes rescateActual;
    private DatosPersonajes itemPendiente;

    private List<DatosPersonajes> salvados = new List<DatosPersonajes>();
    private List<DatosPersonajes> itemsColocados = new List<DatosPersonajes>();
    

    public string escenaSeleccion = "SeleccionRescate";
    public string escenaSalaItems = "SalaItems";
    public string escenaFinal = "BossFinal";


    // Awake() se ejecuta cuando el objeto aparece al cargar la escena.
    void Awake()
    {
        // Si ya existe uno, este nuevo se borra (para no perder el progreso).
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Es el primero = se guarda.
            Instance = this;
            // No se borra al cambiar de escena.
            DontDestroyOnLoad(gameObject);
        }
    }

    // Métodos comprobar items.
    public DatosPersonajes ItemPendiente()
    {
        return itemPendiente;
    }

    public bool ItemColocado(DatosPersonajes personaje)
    {
        return itemsColocados.Contains(personaje);
    }

    public void ColocarItem()
    {
        if (itemPendiente == null) return;
        itemsColocados.Add(itemPendiente);
        itemPendiente = null;
    }

    // Métodos comprobar personaje.
    public bool EstaSalvado(DatosPersonajes personaje)
    {
        return salvados.Contains(personaje);
    }

    public int CantidadSalvados()
    {
        return salvados.Count;
    }

    public void EmpezarRescate(DatosPersonajes personaje)
    {
        rescateActual = personaje;
        SceneManager.LoadScene(personaje.salaRescate);
    }

    public void NivelCompletado()
    {
        // Es null cuando se completa la sala de Niis y te sale el menú de elegir pj por primera vez.
        if (rescateActual == null)
        {
            SceneManager.LoadScene(escenaSeleccion);   
            return;
        }

        // Al terminar todas las demás sala, menos la del boss.
        salvados.Add(rescateActual);             
        itemPendiente = rescateActual;
        rescateActual = null;
        SceneManager.LoadScene(escenaSalaItems);
    }

    // Si todos han colocado su item -> boss. Si no -> elegir otro pj.
    public void SalirDeSala()
    {   
        if (itemsColocados.Count == personajes.Length)
            SceneManager.LoadScene(escenaFinal);
        else
            SceneManager.LoadScene(escenaSeleccion);
    }
}