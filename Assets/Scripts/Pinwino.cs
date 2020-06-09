using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Pinwino : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip musica;

    public int walkSpeed;
    public int runSpeed;
    public float jumpForce;
    private int speed;

    //private bool enSuelo = true;
    private Rigidbody rb;
    private Vector3 jump;

    public GameObject original;
    public Transform referencia;
    //public Camara cameraxd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
        jump = new Vector3(0.0f, 0.1f, 0.0f) * jumpForce;
    }

   // void OnCollisionStay()
   // {
   //     enSuelo = true;
   // }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            Camara.cameraMoveSpeed = 160f;
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            Camara.cameraMoveSpeed = 120f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump, ForceMode.Impulse);
           // enSuelo = false;
        }

        float h = Input.GetAxis("Vertical");
        transform.Translate(0, 0, h * -1 * speed * Time.deltaTime);

        float a = Input.GetAxis("Horizontal");
        transform.Translate(a * -1 * speed * Time.deltaTime, 0, 0);

        transform.Rotate(0, Input.GetAxis("Mouse X") * 150 * Time.deltaTime, 0);

        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(original, referencia.position, referencia.rotation);
        }

        Rigidbody rbdy = gameObject.GetComponent<Rigidbody>();

        //Stop Moving/Translating
        rbdy.velocity = Vector3.zero;

        //Stop rotating
        rbdy.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Carta(Clone)") {
            audio.clip = musica;
            audio.time = 0.5f;
            audio.Play();
        }
    }
}
