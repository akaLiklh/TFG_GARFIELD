using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Usamos esta clase para rellenar la lista de logros del menú.
public class MenuLogros : MonoBehaviour
{
    public GameObject menuPrincipal;
    public VisualTreeAsset plantillaLogro;
    public List<LogroItem> logros;

    private Button bVolver;

    // Rellena la lista y conecta el botón cada vez que se abre el menú.
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var lista = root.Q<ScrollView>("ListaLogros");

        // Por cada logro, crea una fila con la plantilla y la rellena.
        foreach (LogroItem logro in logros)
        {
            var fila = plantillaLogro.Instantiate();
            fila.Q<Label>("Nombre").text = logro.nombre;
            fila.Q<Label>("Descripcion").text = logro.descripcion;
            fila.Q("Icono").style.backgroundImage = new StyleBackground(Background.FromSprite(logro.icono));

            // Si no tiene icono, lo oculta para que no deje un hueco vacío.
            if (logro.icono == null) fila.Q("Icono").style.display = DisplayStyle.None;

            // Si el logro está desbloqueado, se ve resaltado en dorado. Si no, se ve más apagado.
            if (logro.desbloqueado) fila.Q("Fila").AddToClassList("desbloqueado");
            else fila.Q("Fila").AddToClassList("bloqueado");

            // Añade la fila a la lista.
            lista.Add(fila);
        }

        // Busca el botón "Volver" y lo conecta a su función.
        bVolver = root.Q<Button>("bVolver");
        bVolver.clicked += Volver;
    }

    // Apaga el menú de logros y enciende el menú principal.
    private void Volver()
    {
        menuPrincipal.SetActive(true);
        gameObject.SetActive(false);
    }

    // Desconecta el botón de su función.
    private void OnDisable()
    {
        bVolver.clicked -= Volver;
    }
}