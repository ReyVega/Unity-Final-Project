using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta
{
    public Sprite imgCarta;
    public int valor;
    public int elemento;
    public string color;


    public Carta(Sprite sprite, int valor, int elemento, string color)
    {
        this.imgCarta = sprite;
        this.valor = valor;
        this.elemento = elemento;
        this.color = color;
    }
}
