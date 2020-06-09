using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DueloScript : MonoBehaviour
{
    //Carta random
    public MonoBehaviour EstadoPrimerTurno;
    //(Si gano) utilizar una carta de un elemento distinto al usado
    public MonoBehaviour EstadoGanado;
    //(Si perdió) utilizar hielo si el oponente uso fuego, usar fuego si el oponente uso agua, usar agua si el oponente uso hielo
    public MonoBehaviour EstadoPerdio;

    public AudioSource efectos;
    public AudioClip[] efectin;
   
    public Sprite[] imgCartas;
    public Sprite[] iconos;
    private Carta[] cartas;
    public static Carta[] deckEnemigo;
    private static Carta[] deckJugador;

    public static LinkedList<Carta>[] cartasVictoriaJugador = new LinkedList<Carta>[3];
    public static LinkedList<Carta>[] cartasVictoriaEnemigo = new LinkedList<Carta>[3];


    //Entero que representa estado del juego, 0 para en curso, 1 para victoria, 2 para derrota
    private static int gameStatus = 0;
    private static int cartaSeleccionada = -1;
    public static int cartaSeleccionadaEnemigo = 1;
    private static float timeLeft = 10f;
    private Carta cartaUsandoJugador;
    private Carta cartaUsandoEnemigo;
    System.Random rnd;

    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject carta5;

    public GameObject cartaenemigo1;
    public GameObject cartaenemigo2;
    public GameObject cartaenemigo3;
    public GameObject cartaenemigo4;
    public GameObject cartaenemigo5;

    public GameObject cartaUsandoPlayer;
    public GameObject cartaUsandoEnemy;

    private float waitTime;
    public float startWaitTime;

    public GameObject iconoJugadorFuego1;
    public GameObject iconoJugadorFuego2;
    public GameObject iconoJugadorFuego3;
    public GameObject iconoJugadorFuego4;
    public GameObject iconoJugadorFuego5;

    public GameObject iconoJugadorAgua1;
    public GameObject iconoJugadorAgua2;
    public GameObject iconoJugadorAgua3;
    public GameObject iconoJugadorAgua4;
    public GameObject iconoJugadorAgua5;

    public GameObject iconoJugadorHielo1;
    public GameObject iconoJugadorHielo2;
    public GameObject iconoJugadorHielo3;
    public GameObject iconoJugadorHielo4;
    public GameObject iconoJugadorHielo5;

    public static Carta referencia;
    public static Carta referenciaJugador;



    public GameObject iconoEnemigoFuego1;
    public GameObject iconoEnemigoFuego2;
    public GameObject iconoEnemigoFuego3;
    public GameObject iconoEnemigoFuego4;
    public GameObject iconoEnemigoFuego5;

    public GameObject iconoEnemigoAgua1;
    public GameObject iconoEnemigoAgua2;
    public GameObject iconoEnemigoAgua3;
    public GameObject iconoEnemigoAgua4;
    public GameObject iconoEnemigoAgua5;

    public GameObject iconoEnemigoHielo1;
    public GameObject iconoEnemigoHielo2;
    public GameObject iconoEnemigoHielo3;
    public GameObject iconoEnemigoHielo4;
    public GameObject iconoEnemigoHielo5;

    private bool[] comprobacionIconosJugador = new bool[15];
    private bool[] comprobacionIconosEnemigo = new bool[15];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            comprobacionIconosJugador[i] = false;
            comprobacionIconosEnemigo[i] = false;
        }


        iconoJugadorFuego1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorFuego2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorFuego3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorFuego4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorFuego5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

        iconoJugadorAgua1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorAgua2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorAgua3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorAgua4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorAgua5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

        iconoJugadorHielo1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorHielo2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorHielo3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorHielo4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoJugadorHielo5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);



        iconoEnemigoFuego1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoFuego2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoFuego3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoFuego4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoFuego5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

        iconoEnemigoAgua1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoAgua2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoAgua3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoAgua4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoAgua5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

        iconoEnemigoHielo1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoHielo2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoHielo3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoHielo4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        iconoEnemigoHielo5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

        


        for (int i = 0; i < 3; i++)
        {
            cartasVictoriaJugador[i] = new LinkedList<Carta>();
            cartasVictoriaEnemigo[i] = new LinkedList<Carta>();
        }


        int[] cartasEscena = CartaScript.cartasDuelo;


        deckEnemigo = new Carta[5];
        deckJugador = new Carta[5];

        //CREACION DE CARTAS
        this.cartas = new Carta[33];
        int count = 0;
        foreach (Sprite sprite in imgCartas)
        {
            switch (count)
            {
                //EL PRIMER NUMERO REPRESENTA EL VALOR DE LA CARTA, EL SEGUNDO EL ELEMENTO, EL TERCER PARAMETRO ES EL COLOR
                //PARA EL ELEMENTO, EL 0 REPRESENTA EL FUEGO, EL 1 NIEVE, 2 AGUA
                //PARA EL COLOR, SE RECIBE UN STRING

                case 0:
                    break;
                case 1:
                    cartas[0] = new Carta(sprite, 3, 0, "azul");
                    break;
                case 2:
                    cartas[1] = new Carta(sprite, 8, 0, "verde");
                    break;
                case 3:
                    cartas[2] = new Carta(sprite, 6, 0, "morado");
                    break;
                case 4:
                    cartas[3] = new Carta(sprite, 2, 0, "amarillo");
                    break;
                case 5:
                    cartas[4] = new Carta(sprite, 5, 1, "verde");
                    break;
                case 6:
                    cartas[5] = new Carta(sprite, 3, 1, "naranja");
                    break;
                case 7:
                    cartas[6] = new Carta(sprite, 6, 1, "rojo");
                    break;
                case 8:
                    cartas[7] = new Carta(sprite, 2, 1, "rojo");
                    break;
                case 9:
                    cartas[8] = new Carta(sprite, 7, 1, "amarillo");
                    break;
                case 10:
                    cartas[9] = new Carta(sprite, 3, 2, "azul");
                    break;
                case 11:
                    cartas[10] = new Carta(sprite, 5, 2, "azul");
                    break;
                case 12:
                    cartas[11] = new Carta(sprite, 2, 2, "verde");
                    break;
                case 13:
                    cartas[12] = new Carta(sprite, 7, 2, "rojo");
                    break;
                case 14:
                    cartas[13] = new Carta(sprite, 2, 2, "amarillo");
                    break;
                case 15:
                    cartas[14] = new Carta(sprite, 4, 2, "naranja");
                    break;
                case 16:
                    cartas[15] = new Carta(sprite, 5, 2, "naranja");
                    break;
                case 17:
                    cartas[16] = new Carta(sprite, 8, 1, "verde");
                    break;
                case 18:
                    cartas[17] = new Carta(sprite, 6, 1, "verde");
                    break;
                case 19:
                    cartas[18] = new Carta(sprite, 6, 0, "rojo");
                    break;
                case 20:
                    cartas[19] = new Carta(sprite, 5, 0, "naranja");
                    break;
                case 21:
                    cartas[20] = new Carta(sprite, 7, 0, "rojo");
                    break;
                case 22:
                    cartas[21] = new Carta(sprite, 3, 1, "naranja");
                    break;
                case 23:
                    cartas[22] = new Carta(sprite, 8, 2, "azul");
                    break;
                case 24:
                    cartas[23] = new Carta(sprite, 6, 2, "azul");
                    break;
                case 25:
                    cartas[24] = new Carta(sprite, 4, 2, "amarillo");
                    break;
                case 26:
                    cartas[25] = new Carta(sprite, 3, 2, "verde");
                    break;
                case 27:
                    cartas[26] = new Carta(sprite, 3, 0, "azul");
                    break;
                case 28:
                    cartas[27] = new Carta(sprite, 5, 0, "naranja");
                    break;
                case 29:
                    cartas[28] = new Carta(sprite, 10, 0, "amarillo");
                    break;
                case 30:
                    cartas[29] = new Carta(sprite, 10, 1, "verde");
                    break;
                case 31:
                    cartas[30] = new Carta(sprite, 10, 2, "amarillo");
                    break;
                case 32:
                    cartas[31] = new Carta(sprite, 10, 2, "naranja");
                    break;
                case 33:
                    cartas[32] = new Carta(sprite, 10, 0, "amarillo");
                    break;
            }
            count++;
        }


        //CREAR DECK ENEMIGO
        rnd = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            int randomCarta = rnd.Next(0, 33);
            deckEnemigo[i] = cartas[randomCarta];
        }

        //CREAR DECK JUGADOR
        for (int i = 0; i < 5; i++)
        {
            //SE DAN CARTAS RANDOM PARA REEMPLAZAR CARTAS ESPECIALES Y ESPACIOS VACIOS
            if (cartasEscena[i] == -1)
            {
                int randomCarta = rnd.Next(0, 33);
                deckJugador[i] = cartas[randomCarta];
            }
            else
            {
                deckJugador[i] = cartas[cartasEscena[i]];
            }

        }


        waitTime = startWaitTime;

        cartaUsandoPlayer.GetComponent<Image>().color = new Color(1, 1, 1,0);
        cartaUsandoEnemy.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        //DAR IMAGENES AL OBJETO CORRESPONDIENTE
        carta1.GetComponent<Image>().sprite = deckJugador[0].imgCarta;
        carta2.GetComponent<Image>().sprite = deckJugador[1].imgCarta;
        carta3.GetComponent<Image>().sprite = deckJugador[2].imgCarta;
        carta4.GetComponent<Image>().sprite = deckJugador[3].imgCarta;
        carta5.GetComponent<Image>().sprite = deckJugador[4].imgCarta;
        //StartCoroutine(Juego());

        StateMachine.activarEstado(EstadoPrimerTurno);

    }

    // Update is called once per frame
    void Update()
    {

        if (waitTime <= 0)
        {
            waitTime = startWaitTime;

            if (cartaSeleccionada == -1)
            {
                cartaSeleccionada = rnd.Next(0, 4);
            }

            //Debug.Log(cartaSeleccionada);

            cartaUsandoJugador = deckJugador[cartaSeleccionada];
            cartaUsandoEnemigo = deckEnemigo[cartaSeleccionadaEnemigo];
            referencia = cartaUsandoEnemigo;
            referenciaJugador = cartaUsandoJugador;

            cartaUsandoPlayer.GetComponent<Image>().sprite = deckJugador[cartaSeleccionada].imgCarta;
            cartaUsandoEnemy.GetComponent<Image>().sprite = deckEnemigo[cartaSeleccionadaEnemigo].imgCarta;

            int randomCarta = rnd.Next(0, 33);
            deckEnemigo[cartaSeleccionadaEnemigo] = cartas[randomCarta];
            randomCarta = rnd.Next(0, 33);
            deckJugador[cartaSeleccionada] = cartas[randomCarta];
            carta1.GetComponent<Image>().sprite = deckJugador[0].imgCarta;
            carta2.GetComponent<Image>().sprite = deckJugador[1].imgCarta;
            carta3.GetComponent<Image>().sprite = deckJugador[2].imgCarta;
            carta4.GetComponent<Image>().sprite = deckJugador[3].imgCarta;
            carta5.GetComponent<Image>().sprite = deckJugador[4].imgCarta;

            cartaUsandoPlayer.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            cartaUsandoEnemy.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            


            int resultado = checkWin(cartaUsandoJugador, cartaUsandoEnemigo);

            if (resultado == 0)
            {

                StateMachine.activarEstado(EstadoGanado);
                
                if (cartaUsandoEnemigo.elemento == 0)
                {
                    efectos.clip = efectin[0];
                    efectos.Play();
                    if (comprobacionIconosEnemigo[0]==false)
                    {
                        comprobacionIconosEnemigo[0] = true;
                        iconoEnemigoFuego1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);


                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[5];
                        } else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("morado"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoFuego1.GetComponent<Image>().sprite = iconos[10];
                        }


                    } else if(comprobacionIconosEnemigo[0]== true && comprobacionIconosEnemigo[1] == false)
                    {
                        comprobacionIconosEnemigo[1] = true;
                        iconoEnemigoFuego2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("morado"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoFuego2.GetComponent<Image>().sprite = iconos[10];
                        }

                    }
                    else if (comprobacionIconosEnemigo[1] == true && comprobacionIconosEnemigo[2] == false)
                    {
                        comprobacionIconosEnemigo[2] = true;
                        iconoEnemigoFuego3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("morado"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoFuego3.GetComponent<Image>().sprite = iconos[10];
                        }


                    }
                    else if (comprobacionIconosEnemigo[2] == true && comprobacionIconosEnemigo[3] == false)
                    {
                        comprobacionIconosEnemigo[3] = true;
                        iconoEnemigoFuego4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("morado"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoFuego4.GetComponent<Image>().sprite = iconos[10];
                        }


                    }
                    else if (comprobacionIconosEnemigo[3] == true && comprobacionIconosEnemigo[4] == false)
                    {
                        comprobacionIconosEnemigo[4] = true;
                        iconoEnemigoFuego5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("morado"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoFuego5.GetComponent<Image>().sprite = iconos[10];
                        }

                    }

                    cartasVictoriaEnemigo[0].AddLast(cartaUsandoEnemigo);
                    int winCond = CheckWinConditionsEnemigo();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        //break;
                    }
                }
                else if (cartaUsandoEnemigo.elemento == 2)
                {
                    efectos.clip = efectin[2];
                    efectos.Play();
                    if (comprobacionIconosEnemigo[5] == false)
                    {
                        comprobacionIconosEnemigo[5] = true;
                        iconoEnemigoAgua1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoAgua1.GetComponent<Image>().sprite = iconos[0];
                        } else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua1.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoAgua1.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoAgua1.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua1.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosEnemigo[5] == true && comprobacionIconosEnemigo[6] == false)
                    {
                        comprobacionIconosEnemigo[6] = true;
                        iconoEnemigoAgua2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoAgua2.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua2.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoAgua2.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoAgua2.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua2.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosEnemigo[6] == true && comprobacionIconosEnemigo[7] == false)
                    {
                        comprobacionIconosEnemigo[7] = true;
                        iconoEnemigoAgua3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoAgua3.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua3.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoAgua3.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoAgua3.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua3.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosEnemigo[7] == true && comprobacionIconosEnemigo[8] == false)
                    {
                        comprobacionIconosEnemigo[8] = true;
                        iconoEnemigoAgua4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoAgua4.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua4.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoAgua4.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoAgua4.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua4.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosEnemigo[8] == true && comprobacionIconosEnemigo[9] == false)
                    {
                        comprobacionIconosEnemigo[9] = true;
                        iconoEnemigoAgua5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("azul"))
                        {
                            iconoEnemigoAgua5.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua5.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoAgua5.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoAgua5.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoAgua5.GetComponent<Image>().sprite = iconos[4];
                        }

                    }

                    cartasVictoriaEnemigo[1].AddLast(cartaUsandoEnemigo);
                    int winCond = CheckWinConditionsEnemigo();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        //break;
                    }
                }
                else if (cartaUsandoEnemigo.elemento == 1)
                {
                    efectos.clip = efectin[1];
                    efectos.Play();
                    if (comprobacionIconosEnemigo[10] == false)
                    {
                        comprobacionIconosEnemigo[10] = true;
                        iconoEnemigoHielo1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                        if (cartaUsandoEnemigo.color.Equals("verde")){
                            iconoEnemigoHielo1.GetComponent<Image>().sprite = iconos[11];
                        } else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoHielo1.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoHielo1.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoHielo1.GetComponent<Image>().sprite = iconos[14];
                        }
                    }
                    else if (comprobacionIconosEnemigo[10] == true && comprobacionIconosEnemigo[11] == false)
                    {
                        comprobacionIconosEnemigo[11] = true;
                        iconoEnemigoHielo2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoHielo2.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoHielo2.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoHielo2.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoHielo2.GetComponent<Image>().sprite = iconos[14];
                        }

                    }
                    else if (comprobacionIconosEnemigo[11] == true && comprobacionIconosEnemigo[12] == false)
                    {
                        comprobacionIconosEnemigo[12] = true;
                        iconoEnemigoHielo3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoHielo3.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoHielo3.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoHielo3.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoHielo3.GetComponent<Image>().sprite = iconos[14];
                        }

                    }
                    else if (comprobacionIconosEnemigo[12] == true && comprobacionIconosEnemigo[13] == false)
                    {
                        comprobacionIconosEnemigo[13] = true;
                        iconoEnemigoHielo4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoHielo4.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoHielo4.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoHielo4.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoHielo4.GetComponent<Image>().sprite = iconos[14];
                        }

                    }
                    else if (comprobacionIconosEnemigo[13] == true && comprobacionIconosEnemigo[14] == false)
                    {
                        comprobacionIconosEnemigo[14] = true;
                        iconoEnemigoHielo5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoEnemigo.color.Equals("verde"))
                        {
                            iconoEnemigoHielo5.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("naranja"))
                        {
                            iconoEnemigoHielo5.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("rojo"))
                        {
                            iconoEnemigoHielo5.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoEnemigo.color.Equals("amarillo"))
                        {
                            iconoEnemigoHielo5.GetComponent<Image>().sprite = iconos[14];
                        }

                    }

                    cartasVictoriaEnemigo[2].AddLast(cartaUsandoEnemigo);
                    int winCond = CheckWinConditionsEnemigo();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        //break;
                    }
                }


            }
            else if (resultado == 1)
            {

            }
            else if (resultado == 2)
            {
                StateMachine.activarEstado(EstadoGanado);
                if (cartaUsandoJugador.elemento == 0)
                {
                    efectos.clip = efectin[0];
                    efectos.Play();
                    if (comprobacionIconosJugador[0] == false)
                    {
                        comprobacionIconosJugador[0] = true;
                        iconoJugadorFuego1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoJugador.color.Equals("morado"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorFuego1.GetComponent<Image>().sprite = iconos[10];
                        }

                    }
                    else if (comprobacionIconosJugador[0] == true && comprobacionIconosJugador[1] == false)
                    {
                        comprobacionIconosJugador[1] = true;
                        iconoJugadorFuego2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoJugador.color.Equals("morado"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorFuego2.GetComponent<Image>().sprite = iconos[10];
                        }

                    }
                    else if (comprobacionIconosJugador[1] == true && comprobacionIconosJugador[2] == false)
                    {
                        comprobacionIconosJugador[2] = true;
                        iconoJugadorFuego3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoJugador.color.Equals("morado"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorFuego3.GetComponent<Image>().sprite = iconos[10];
                        }

                    }
                    else if (comprobacionIconosJugador[2] == true && comprobacionIconosJugador[3] == false)
                    {
                        comprobacionIconosJugador[3] = true;
                        iconoJugadorFuego4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoJugador.color.Equals("morado"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorFuego4.GetComponent<Image>().sprite = iconos[10];
                        }

                    }
                    else if (comprobacionIconosJugador[3] == true && comprobacionIconosJugador[4] == false)
                    {
                        comprobacionIconosJugador[4] = true;
                        iconoJugadorFuego5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[5];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[6];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[7];
                        }
                        else if (cartaUsandoJugador.color.Equals("morado"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[8];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[9];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorFuego5.GetComponent<Image>().sprite = iconos[10];
                        }

                    }

                    cartasVictoriaJugador[0].AddLast(cartaUsandoJugador);
                    int winCond = CheckWinConditionsJugador();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
                        //break;
                    }
                }
                else if (cartaUsandoJugador.elemento == 2)
                {
                    efectos.clip = efectin[2];
                    efectos.Play();
                    if (comprobacionIconosJugador[5] == false)
                    {
                        comprobacionIconosJugador[5] = true;
                        iconoJugadorAgua1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorAgua1.GetComponent<Image>().sprite = iconos[0];
                        } else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorAgua1.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorAgua1.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorAgua1.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorAgua1.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosJugador[5] == true && comprobacionIconosJugador[6] == false)
                    {
                        comprobacionIconosJugador[6] = true;
                        iconoJugadorAgua2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorAgua2.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorAgua2.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorAgua2.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorAgua2.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorAgua2.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosJugador[6] == true && comprobacionIconosJugador[7] == false)
                    {
                        comprobacionIconosJugador[7] = true;
                        iconoJugadorAgua3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorAgua3.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorAgua3.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorAgua3.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorAgua3.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorAgua3.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosJugador[7] == true && comprobacionIconosJugador[8] == false)
                    {
                        comprobacionIconosJugador[8] = true;
                        iconoJugadorAgua4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorAgua4.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorAgua4.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorAgua4.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorAgua4.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorAgua4.GetComponent<Image>().sprite = iconos[4];
                        }

                    }
                    else if (comprobacionIconosJugador[8] == true && comprobacionIconosJugador[9] == false)
                    {
                        comprobacionIconosJugador[9] = true;
                        iconoJugadorAgua5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("azul"))
                        {
                            iconoJugadorAgua5.GetComponent<Image>().sprite = iconos[0];
                        }
                        else if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorAgua5.GetComponent<Image>().sprite = iconos[1];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorAgua5.GetComponent<Image>().sprite = iconos[2];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorAgua5.GetComponent<Image>().sprite = iconos[3];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorAgua5.GetComponent<Image>().sprite = iconos[4];
                        }

                    }

                    cartasVictoriaJugador[1].AddLast(cartaUsandoJugador);
                    int winCond = CheckWinConditionsJugador();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
                        //break;
                    }
                }
                else if (cartaUsandoJugador.elemento == 1)
                {
                    efectos.clip = efectin[1];
                    efectos.Play();
                    if (comprobacionIconosJugador[10] == false)
                    {
                        comprobacionIconosJugador[10] = true;
                        iconoJugadorHielo1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorHielo1.GetComponent<Image>().sprite = iconos[11];
                        } else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorHielo1.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorHielo1.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorHielo1.GetComponent<Image>().sprite = iconos[14];
                        }

                    }
                    else if (comprobacionIconosJugador[10] == true && comprobacionIconosJugador[11] == false)
                    {
                        comprobacionIconosJugador[11] = true;
                        iconoJugadorHielo2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorHielo2.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorHielo2.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorHielo2.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorHielo2.GetComponent<Image>().sprite = iconos[14];
                        }
                    }
                    else if (comprobacionIconosJugador[11] == true && comprobacionIconosJugador[12] == false)
                    {
                        comprobacionIconosJugador[12] = true;
                        iconoJugadorHielo3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorHielo3.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorHielo3.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorHielo3.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorHielo3.GetComponent<Image>().sprite = iconos[14];
                        }
                    }
                    else if (comprobacionIconosJugador[12] == true && comprobacionIconosJugador[13] == false)
                    {
                        comprobacionIconosJugador[13] = true;
                        iconoJugadorHielo4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorHielo4.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorHielo4.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorHielo4.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorHielo4.GetComponent<Image>().sprite = iconos[14];
                        }
                    }
                    else if (comprobacionIconosJugador[13] == true && comprobacionIconosJugador[14] == false)
                    {
                        comprobacionIconosJugador[14] = true;
                        iconoJugadorHielo5.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                        if (cartaUsandoJugador.color.Equals("verde"))
                        {
                            iconoJugadorHielo5.GetComponent<Image>().sprite = iconos[11];
                        }
                        else if (cartaUsandoJugador.color.Equals("naranja"))
                        {
                            iconoJugadorHielo5.GetComponent<Image>().sprite = iconos[12];
                        }
                        else if (cartaUsandoJugador.color.Equals("rojo"))
                        {
                            iconoJugadorHielo5.GetComponent<Image>().sprite = iconos[13];
                        }
                        else if (cartaUsandoJugador.color.Equals("amarillo"))
                        {
                            iconoJugadorHielo5.GetComponent<Image>().sprite = iconos[14];
                        }
                    }

                    cartasVictoriaJugador[2].AddLast(cartaUsandoJugador);
                    int winCond = CheckWinConditionsJugador();
                    if (winCond == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
                        //break;
                    }
                }

                

                cartaUsandoPlayer.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                cartaUsandoEnemy.GetComponent<Image>().color = new Color(1, 1, 1, 1);


                
                
                
                
                
                
                cartaSeleccionada = -1;
            }

        }
        else
        {
            waitTime -= Time.deltaTime;
            //print(waitTime);

            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                cartaSeleccionada = 0;
                waitTime = 0;
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                cartaSeleccionada = 1;
                waitTime = 0;

            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                cartaSeleccionada = 2;
                waitTime = 0;

            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                cartaSeleccionada = 3;
                waitTime = 0;

            }
            else if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                cartaSeleccionada = 4;
                waitTime = 0;

            }
        }
    }
        static int checkWin(Carta cartajugador, Carta cartaenemigo)
        {
            //DEVUELVE VALORES DISTINTOS DEPENDIENDO DEL RESULTADO ENTRE LA CARTA DEL JUGADOR Y LA CARTA DEL ENEMIGO
            //0 para derrota
            //1 para empate
            //2 para victoria
            if (cartajugador.elemento == 0)
            {
                if (cartaenemigo.elemento == 0)
                {
                    if (cartajugador.valor < cartaenemigo.valor)
                    {
                        return 0;
                    }
                    else if (cartajugador.valor == cartaenemigo.valor)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else if (cartaenemigo.elemento == 1)
                {
                    return 2;
                }
                else if (cartaenemigo.elemento == 2)
                {
                    return 0;
                }
            }
            else if (cartajugador.elemento == 1)
            {
                if (cartaenemigo.elemento == 0)
                {
                    return 0;
                }
                else if (cartaenemigo.elemento == 1)
                {
                    if (cartajugador.valor < cartaenemigo.valor)
                    {
                        return 0;
                    }
                    else if (cartajugador.valor == cartaenemigo.valor)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else if (cartaenemigo.elemento == 2)
                {
                    return 2;
                }
            }
            else if (cartajugador.elemento == 2)
            {
                if (cartaenemigo.elemento == 0)
                {
                    return 2;
                }
                else if (cartaenemigo.elemento == 1)
                {
                    return 0;
                }
                else if (cartaenemigo.elemento == 2)
                {
                    if (cartajugador.valor < cartaenemigo.valor)
                    {
                        return 0;
                    }
                    else if (cartajugador.valor == cartaenemigo.valor)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            else
            {
                return -1;
            }
            return -1;
        }

        static int CheckWinConditionsJugador()
        {
            if (cartasVictoriaJugador[0].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaJugador[0])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }
            if (cartasVictoriaJugador[1].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaJugador[1])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }
            if (cartasVictoriaJugador[2].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaJugador[2])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }

            if (cartasVictoriaJugador[0].Count > 0 && cartasVictoriaJugador[1].Count > 0 && cartasVictoriaJugador[2].Count > 0)
            {
                HashSet<string> coloresFuego = new HashSet<string>();
                HashSet<string> coloresAgua = new HashSet<string>();
                HashSet<string> coloresHielo = new HashSet<string>();

                foreach (Carta carta in cartasVictoriaJugador[0])
                {
                    coloresFuego.Add(carta.color);
                }
                foreach (Carta carta in cartasVictoriaJugador[1])
                {
                    coloresAgua.Add(carta.color);
                }
                foreach (Carta carta in cartasVictoriaJugador[2])
                {
                    coloresHielo.Add(carta.color);
                }

                foreach (string value in coloresFuego)
                {
                    foreach (string valueAgua in coloresAgua)
                    {
                        if (valueAgua.Equals(value))
                        {
                            continue;
                        }
                        else
                        {
                            foreach (string valueHielo in coloresHielo)
                            {
                                if (valueAgua.Equals(valueHielo))
                                {
                                    continue;
                                }
                                else
                                {
                                    return 1;
                                }
                            }
                        }
                    }
                }

            }

            return 0;
        }

        static int CheckWinConditionsEnemigo()
        {
            if (cartasVictoriaEnemigo[0].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaEnemigo[0])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }
            if (cartasVictoriaEnemigo[1].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaEnemigo[1])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }
            if (cartasVictoriaEnemigo[2].Count >= 3)
            {
                HashSet<string> colores = new HashSet<string>();
                foreach (Carta carta in cartasVictoriaEnemigo[2])
                {
                    colores.Add(carta.color);
                }
                if (colores.Count >= 3)
                {
                    return 1;
                }
            }

            if (cartasVictoriaEnemigo[0].Count > 0 && cartasVictoriaEnemigo[1].Count > 0 && cartasVictoriaEnemigo[2].Count > 0)
            {
                HashSet<string> coloresFuego = new HashSet<string>();
                HashSet<string> coloresAgua = new HashSet<string>();
                HashSet<string> coloresHielo = new HashSet<string>();

                foreach (Carta carta in cartasVictoriaEnemigo[0])
                {
                    coloresFuego.Add(carta.color);
                }
                foreach (Carta carta in cartasVictoriaEnemigo[1])
                {
                    coloresAgua.Add(carta.color);
                }
                foreach (Carta carta in cartasVictoriaEnemigo[2])
                {
                    coloresHielo.Add(carta.color);
                }

                foreach (string value in coloresFuego)
                {
                    foreach (string valueAgua in coloresAgua)
                    {
                        if (valueAgua.Equals(value))
                        {
                            continue;
                        }
                        else
                        {
                            foreach (string valueHielo in coloresHielo)
                            {
                                if (valueAgua.Equals(valueHielo))
                                {
                                    continue;
                                }
                                else
                                {
                                    return 1;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
