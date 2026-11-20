using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int puntosTotales;
    public int PuntosTotales { get { return puntosTotales; } }

    void Awake()
    {
        Instance = this;
    }
    public void AñadePuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }

}