using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPerdio : MonoBehaviour
{
    private void OnEnable()
    {
        System.Random rnd = new System.Random();

        if (DueloScript.referenciaJugador.elemento == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (DueloScript.deckEnemigo[i].elemento == 1)
                {
                    DueloScript.cartaSeleccionadaEnemigo = i;
                }
                else
                {
                    DueloScript.cartaSeleccionadaEnemigo = rnd.Next(0, 4);
                }

            }
        }
        else if (DueloScript.referenciaJugador.elemento == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (DueloScript.deckEnemigo[i].elemento == 2)
                {
                    DueloScript.cartaSeleccionadaEnemigo = i;
                }
                else
                {
                    DueloScript.cartaSeleccionadaEnemigo = rnd.Next(0, 4);
                }
            }
        }
        else if (DueloScript.referenciaJugador.elemento == 2)
        {
            for (int i = 0; i < 5; i++)
            {
                if (DueloScript.deckEnemigo[i].elemento == 0)
                {
                    DueloScript.cartaSeleccionadaEnemigo = i;
                }
                else
                {
                    DueloScript.cartaSeleccionadaEnemigo = rnd.Next(0, 4);
                }
            }
        }
    }
}
