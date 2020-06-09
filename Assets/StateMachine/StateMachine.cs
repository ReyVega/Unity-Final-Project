using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static MonoBehaviour estadoActual;

    public static void activarEstado(MonoBehaviour nuevoEstado)
    {
        if (estadoActual != null)
        {
            estadoActual.enabled = false;
        }
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }
}
