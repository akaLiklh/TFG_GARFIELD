using UnityEngine;
using UnityEngine.UIElements;

// Usamos esta clase para aniamr el fondo del menú principal.
public class FondoMenuPrincipalAnimado : MonoBehaviour
{
    public Sprite[] frames;

    private VisualElement fondo;
    private int frameActual = 0;

    void Start()
    {
        // Busca el elemento "Fondo" del UI Builder.
        fondo = GetComponent<UIDocument>().rootVisualElement.Q("Fondo");

        // Llama a SiguienteFrame cada 0.1 segundos.
        InvokeRepeating("SiguienteFrame", 0f, 0.1f);
    }

    void SiguienteFrame()
    {
        // Pone la imagen actual de fondo.
        fondo.style.backgroundImage = new StyleBackground(Background.FromSprite(frames[frameActual]));

        // Pasa a la siguiente. Al llegar al final, vuelve a la primera.
        frameActual++;
        if (frameActual == frames.Length)
            frameActual = 0;
    }
}
