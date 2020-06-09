using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaMapa : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 1, 0), 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        //GRAFICA?
        if (other.gameObject.name == "Pinwino") {
            other.gameObject.GetComponent<CartaScript>().intercambiarCarta();
            Destroy(gameObject);
        }
       
    }
}
