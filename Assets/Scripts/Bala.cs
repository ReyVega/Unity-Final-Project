using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bala : MonoBehaviour
{
    private Rigidbody rb;

    public AudioSource audio;
    public AudioClip[] musica;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audio.clip = musica[0];
        audio.Play();

        rb.AddForce(transform.forward * 200,ForceMode.Impulse);
        rb.AddForce(-5,0,0,ForceMode.Impulse);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pinwino") {
            
            audio.time = 0f;
            audio.clip = musica[1];
            audio.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
}
