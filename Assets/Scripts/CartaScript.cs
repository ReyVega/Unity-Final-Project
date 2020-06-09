using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaScript : MonoBehaviour
{
    public static int[] cartasDuelo = new int[5];
    public AudioSource audio;
    public AudioClip[] musica;
    private Vector3 scaleChange;
    public Sprite[] cartas;
    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject carta5;
    public GameObject cartaIntercambio;
    public Text textitoIntercambio;
    public GameObject pinwino;
    public GameObject pared;
    public Transform refer;
    List<Renderer> rendererList = new List<Renderer>();
    public GameObject camera;
    public static bool[] activoCartas = new bool[5];
    public Image[] imagenesCartas = new Image[5];
    public static int[] cartasEspeciales = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(1, 1, 1);
        GetRenderers();
        GetImages();
        for (int i = 0; i < 5; i++)
        {
            activoCartas[i] = true;
        }


        //int que identifica que cartas tiene el jugador
        cartasDuelo[0] = -1;
        cartasDuelo[1] = -1;
        cartasDuelo[2] = -1;
        cartasDuelo[3] = 0;
        cartasDuelo[4] = 13;



        // CARTAS ESPECIALES (1 pared, 2 TP, 3 invisibilidad, 0 nada)
        cartasEspeciales[0] = 1;
        cartasEspeciales[1] = 2;
        cartasEspeciales[2] = 3;
        cartasEspeciales[3] = 0;
        cartasEspeciales[4] = 0;
        cartaIntercambio.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //NUMERO 1
        if (Input.GetKey(KeyCode.Alpha1) && (activoCartas[0]==true))
        {
            carta1.transform.localPosition = new Vector3(carta1.transform.localPosition.x, -120f);
            carta1.transform.localScale = scaleChange;
            carta1.transform.SetAsLastSibling();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if(cartasEspeciales[0] == 1)
                {
                    generarPared(0);
                } else if(cartasEspeciales[0] == 2)
                {
                    Teletransportar(0);
                } else if(cartasEspeciales[0] == 3)
                {
                    Invisibilidad(0);
                }
                else
                {
                    audio.clip = musica[3];
                    audio.Play();
                    imagenesCartas[0].color = new Color(1f, 1f, 1f, 0f);
                    activoCartas[0] = false;
                }
            }

        }
        else if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            carta1.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            carta1.transform.localPosition = new Vector3(carta1.transform.localPosition.x, -189.91f);
        }


        //NUMERO 2
        else if (Input.GetKey(KeyCode.Alpha2) && (activoCartas[1] == true))
        {
            carta2.transform.localPosition = new Vector3(carta2.transform.localPosition.x, -120f);
            carta2.transform.localScale = scaleChange;
            carta2.transform.SetAsLastSibling();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cartasEspeciales[1] == 1)
                {
                    generarPared(1);
                }
                else if (cartasEspeciales[1] == 2)
                {
                    Teletransportar(1);
                }
                else if (cartasEspeciales[1] == 3)
                {
                    Invisibilidad(1);
                }
                else
                {
                    audio.clip = musica[3];
                    audio.Play();
                    imagenesCartas[1].color = new Color(1f, 1f, 1f, 0f);
                    activoCartas[1] = false;
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            carta2.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            carta2.transform.localPosition = new Vector3(carta2.transform.localPosition.x, -189.91f);
        }


        //NUMERO 3
        else if (Input.GetKey(KeyCode.Alpha3) && (activoCartas[2] == true))
        {
            carta3.transform.localPosition = new Vector3(carta3.transform.localPosition.x, -120f);
            carta3.transform.localScale = scaleChange;
            carta3.transform.SetAsLastSibling();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cartasEspeciales[2] == 1)
                {
                    generarPared(2);
                }
                else if (cartasEspeciales[2] == 2)
                {
                    Teletransportar(2);
                }
                else if (cartasEspeciales[2] == 3)
                {
                    Invisibilidad(2);
                }
                else
                {
                    audio.clip = musica[3];
                    audio.Play();
                    imagenesCartas[2].color = new Color(1f, 1f, 1f, 0f);
                    activoCartas[2] = false;
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            carta3.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            carta3.transform.localPosition = new Vector3(carta3.transform.localPosition.x, -189.91f);
        }


        //NUMERO 4
        else if (Input.GetKey(KeyCode.Alpha4) && (activoCartas[3] == true))
        {
            carta4.transform.localPosition = new Vector3(carta4.transform.localPosition.x, -120f);
            carta4.transform.localScale = scaleChange;
            carta4.transform.SetAsLastSibling();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cartasEspeciales[3] == 1)
                {
                    generarPared(3);
                }
                else if (cartasEspeciales[3] == 2)
                {
                    Teletransportar(3);
                }
                else if (cartasEspeciales[3] == 3)
                {
                    Invisibilidad(3);
                }
                else
                {
                    audio.clip = musica[3];
                    audio.Play();
                    imagenesCartas[3].color = new Color(1f, 1f, 1f, 0f);
                    activoCartas[3] = false;
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            carta4.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            carta4.transform.localPosition = new Vector3(carta4.transform.localPosition.x, -189.91f);
        }


        //NUMERO 5
        else if (Input.GetKey(KeyCode.Alpha5) && (activoCartas[4] == true))
        {
            carta5.transform.localPosition = new Vector3(carta5.transform.localPosition.x, -120f);
            carta5.transform.localScale = scaleChange;
            carta5.transform.SetAsLastSibling();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cartasEspeciales[4] == 1)
                {
                    generarPared(4);
                }
                else if (cartasEspeciales[4] == 2)
                {
                    Teletransportar(4);
                }
                else if (cartasEspeciales[4] == 3)
                {
                    Invisibilidad(4);
                }
                else
                {
                    audio.clip = musica[3];
                    audio.Play();
                    imagenesCartas[4].color = new Color(1f, 1f, 1f, 0f);
                    activoCartas[4] = false;
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            carta5.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            carta5.transform.localPosition = new Vector3(carta5.transform.localPosition.x, -189.91f);
        }
    }
    void Esperar()
    {
        foreach (Renderer objectRenderer in rendererList)
        {
            objectRenderer.enabled = true;
        }
        CPU.keyInvisible = true;
    }

    public void GetRenderers()
    {
        foreach (Renderer objectRenderer in pinwino.GetComponentsInChildren<Renderer>())
        {
            rendererList.Add(objectRenderer);
        }
    }

    public void GetImages()
    {
        imagenesCartas[0] = carta1.GetComponent<Image>();
        imagenesCartas[1] = carta2.GetComponent<Image>();
        imagenesCartas[2] = carta3.GetComponent<Image>();
        imagenesCartas[3] = carta4.GetComponent<Image>();
        imagenesCartas[4] = carta5.GetComponent<Image>();
    }

    void generarPared(int xd)
    {
        Vector3 paredPosition = new Vector3(pinwino.transform.position.x, pinwino.transform.position.y, pinwino.transform.position.z);
        audio.clip = musica[0];
        audio.Play();
        Instantiate(pared, refer.position, pinwino.transform.rotation);
        imagenesCartas[xd].color = new Color(1f, 1f, 1f, 0f);
        activoCartas[xd] = false;
    }

    void Teletransportar(int xd)
    {
        float x = Random.Range(-2784f, -211f);
        float z = Random.Range(-1302, 1302f);
        audio.clip = musica[1];
        audio.Play();
        pinwino.transform.position = new Vector3(x, 24.4f, z);
        camera.transform.position = new Vector3(x, 24.4f, z);
        imagenesCartas[xd].color = new Color(1f, 1f, 1f, 0f);
        activoCartas[xd] = false;
    }

    void Invisibilidad(int xd)
    {
        audio.clip = musica[2];
        audio.Play();
        CPU.keyInvisible = false;
        foreach (Renderer objectRenderer in rendererList)
        {
            objectRenderer.enabled = false;
        }
        imagenesCartas[xd].color = new Color(1f, 1f, 1f, 0f);
        activoCartas[xd] = false;
        Invoke("Esperar", 3f);

    }

    void ReseteoGUI()
    {
        cartaIntercambio.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        textitoIntercambio.text = "";
    }

    public void intercambiarCarta()
    {
        int random = Random.Range(1, 36);
        bool espacio = false;
        int lugar = 0;
        for(int i = 0; i < 5; i++)
        {
            if (!activoCartas[i])
            {
                espacio = true;
                lugar = i;
            }
        }

        if (espacio)
        {
            activoCartas[lugar] = true;
            if (random == 33)
            {
                cartasDuelo[lugar] = -1;
                cartasEspeciales[lugar] = 2;
            }
            else if (random == 34)
            {
                cartasDuelo[lugar] = -1;
                cartasEspeciales[lugar] = 3;
            }
            else if (random == 35)
            {
                cartasDuelo[lugar] = -1;
                cartasEspeciales[lugar] = 1;
            }
            else
            {
                cartasDuelo[lugar] = random - 1;
                cartasEspeciales[lugar] = 0;
            }
            if (lugar == 0)
            {
                imagenesCartas[0].sprite = cartas[random];
                imagenesCartas[0].color = new Color(1f, 1f, 1f, 1f);
            } else if (lugar == 1)
            {
                imagenesCartas[1].sprite = cartas[random];
                imagenesCartas[1].color = new Color(1f, 1f, 1f, 1f);
            }
            else if (lugar == 2)
            {
                imagenesCartas[2].sprite = cartas[random];
                imagenesCartas[2].color = new Color(1f, 1f, 1f, 1f);
            }
            else if (lugar == 3)
            {
                imagenesCartas[3].sprite = cartas[random];
                imagenesCartas[3].color = new Color(1f, 1f, 1f, 1f);
            }
            else if (lugar == 4)
            {
                imagenesCartas[4].sprite = cartas[random];
                imagenesCartas[4].color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else
        {
            
            cartaIntercambio.GetComponent<Image>().sprite = cartas[random];
            cartaIntercambio.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            textitoIntercambio.text = "Intercambiar Carta \n 1 - 2 - 3 - 4 - 5 \n \n 0 - Desechar Carta";
            StartCoroutine(Intercambio(random));

        }
    }

    IEnumerator Intercambio(int random)
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                ReseteoGUI();
                StopAllCoroutines();
            }
            else if (Input.GetKey(KeyCode.Alpha1))
            {
                imagenesCartas[0].sprite = cartaIntercambio.GetComponent<Image>().sprite;
                if (random == 33)
                {
                    cartasDuelo[0] = -1;
                    cartasEspeciales[0] = 2;
                }
                else if (random == 34)
                {
                    cartasDuelo[0] = -1;
                    cartasEspeciales[0] = 3;
                }
                else if (random == 35)
                {
                    cartasDuelo[0] = -1;
                    cartasEspeciales[0] = 1;
                }
                else
                {
                    cartasDuelo[0] = random - 1;
                    cartasEspeciales[0] = 0;
                }
                ReseteoGUI();
                StopAllCoroutines();
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                imagenesCartas[1].sprite = cartaIntercambio.GetComponent<Image>().sprite;
                if (random == 33)
                {
                    cartasDuelo[1] = -1;
                    cartasEspeciales[1] = 2;
                }
                else if (random == 34)
                {
                    cartasDuelo[1] = -1;
                    cartasEspeciales[1] = 3;
                }
                else if (random == 35)
                {
                    cartasDuelo[1] = -1;
                    cartasEspeciales[1] = 1;
                }
                else
                {
                    cartasDuelo[1] = random - 1;
                    cartasEspeciales[1] = 0;
                }
                ReseteoGUI();
                StopAllCoroutines();
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                imagenesCartas[2].sprite = cartaIntercambio.GetComponent<Image>().sprite;
                if (random == 33)
                {
                    cartasDuelo[2] = -1;
                    cartasEspeciales[2] = 2;
                }
                else if (random == 34)
                {
                    cartasDuelo[2] = -1;
                    cartasEspeciales[2] = 3;
                }
                else if (random == 35)
                {
                    cartasDuelo[2] = -1;
                    cartasEspeciales[2] = 1;
                }
                else
                {
                    cartasDuelo[2] = random - 1;
                    cartasEspeciales[2] = 0;
                }
                ReseteoGUI();
                StopAllCoroutines();
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                imagenesCartas[3].sprite = cartaIntercambio.GetComponent<Image>().sprite;
                if (random == 33)
                {
                    cartasDuelo[3] = -1;
                    cartasEspeciales[3] = 2;
                }
                else if (random == 34)
                {
                    cartasDuelo[3] = -1;
                    cartasEspeciales[3] = 3;
                }
                else if (random == 35)
                {
                    cartasDuelo[3] = -1;
                    cartasEspeciales[3] = 1;
                }
                else
                {
                    cartasDuelo[3] = random - 1;
                    cartasEspeciales[3] = 0;
                }
                ReseteoGUI();
                StopAllCoroutines();
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                imagenesCartas[4].sprite = cartaIntercambio.GetComponent<Image>().sprite;
                if (random == 33)
                {
                    cartasDuelo[4] = -1;
                    cartasEspeciales[4] = 2;
                }
                else if (random == 34)
                {
                    cartasDuelo[4] = -1;
                    cartasEspeciales[4] = 3;
                }
                else if (random == 35)
                {
                    cartasDuelo[4] = -1;
                    cartasEspeciales[4] = 1;
                }
                else
                {
                    cartasDuelo[4] = random - 1;
                    cartasEspeciales[4] = 0;
                }
                ReseteoGUI();
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
