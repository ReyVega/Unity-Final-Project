using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPrimerTurno : MonoBehaviour
{
    System.Random rnd = new System.Random();

    private void OnEnable()
    {
        int max = 0, index = 0;
        for (int i = 0; i < 5; i++) {
            if (max < DueloScript.deckEnemigo[i].valor) {
                max = DueloScript.deckEnemigo[i].valor;
                index = i;
            }
        }

        DueloScript.cartaSeleccionadaEnemigo = index;
    }
}
