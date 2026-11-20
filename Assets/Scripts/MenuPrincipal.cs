using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

// Usamos esta clase para que funcionen los botones del menú principal.
public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuLogros;
    public GameObject menuConfirmacionSalir;

    private VisualElement botones;
    private Button bJugar;
    private Button bOpciones;
    private Button bLogros;
    private Button bSalir;

    private VisualElement pantallaPartida;
    private Button bNuevaPartida;
    private Button bCargarPartida;
    private Button bVolver;

    // Conecta los botones a su función.
    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement root = uIDocument.rootVisualElement;

        // Busca los botones por su nombre del UI Builder.
        botones = root.Q("Botones");             
        bJugar = root.Q<Button>("bJugar");
        bOpciones = root.Q<Button>("bOpciones");
        bLogros = root.Q<Button>("bLogros");
        bSalir = root.Q<Button>("bSalir");

        pantallaPartida = root.Q("PantallaPartida");
        bNuevaPartida = root.Q<Button>("bNuevaPartida");
        bCargarPartida = root.Q<Button>("bCargarPartida");
        bVolver = root.Q<Button>("bVolver");

        // Qué hace cada botón al pulsarlo.
        bJugar.clicked += Jugar;
        bOpciones.clicked += MostrarAjustes;
        bLogros.clicked += MostrarLogros;
        bSalir.clicked += Salir;

        bNuevaPartida.clicked += NuevaPartida;
        bCargarPartida.clicked += CargarPartida;
        bVolver.clicked += Volver;
    }

    private void Jugar()
    {
        Debug.Log("Has pulsado JUGAR");
        botones.style.display = DisplayStyle.None;
        pantallaPartida.style.display = DisplayStyle.Flex;
    }
    private void Volver()
    {
        pantallaPartida.style.display = DisplayStyle.None;
        botones.style.display = DisplayStyle.Flex;
    }

    private void NuevaPartida()
    {
        SceneManager.LoadScene("CinematicaComienzo");
    }


    private void CargarPartida()
    {
    
    }

    // Apaga el menú principal y enciende el de opciones.
    private void MostrarAjustes()
    {
        menuOpciones.SetActive(true);
        gameObject.SetActive(false);
    }

    // Apaga el menú principal y enciende el de logros.
    private void MostrarLogros()
    {
        menuLogros.SetActive(true);
        gameObject.SetActive(false);
    }

    // Antes de salir, pregunta si está seguro.
    private void Salir()
    {
        menuConfirmacionSalir.SetActive(true);
        gameObject.SetActive(false);
    }


    // Desconecta los botones de su función.
    private void OnDisable()
    {
        bJugar.clicked -= Jugar;
        bOpciones.clicked -= MostrarAjustes;
        bLogros.clicked -= MostrarLogros;
        bSalir.clicked -= Salir;

        bNuevaPartida.clicked -= NuevaPartida;
        bCargarPartida.clicked -= CargarPartida;
        bVolver.clicked -= Volver;
    }
}