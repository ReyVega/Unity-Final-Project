using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    public float speed;
    public Transform[] spots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    public Transform Jugador;
    public GameObject original;
    public Transform referencia;

    private bool keyInit = true;

    public static bool keyInvisible = true;

    private IEnumerator shoot;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, spots.Length);
        shoot = disparar();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(Jugador.position, transform.position);
        if ((dist < 500f) && keyInvisible)
        {
            initiate();
            if (dist < 60f)
            {
                transform.Rotate(0, 160.725f, 0, Space.World);
                transform.LookAt(Jugador.transform);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 24.4f, transform.position.z);
                transform.Rotate(0, 160.725f, 0, Space.World);
                transform.LookAt(Jugador.transform);
                transform.position = Vector3.MoveTowards(transform.position, Jugador.position, Time.deltaTime * 60);
            }
        } else {
            StopCoroutine(shoot);
            keyInit = true;

            Vector3 lookDir = spots[randomSpot].position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            transform.position = Vector3.MoveTowards(transform.position, spots[randomSpot].position, speed *
                           Time.deltaTime);

            transform.LookAt(spots[randomSpot].position);

            if (Vector3.Distance(transform.position, spots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, spots.Length);
                    waitTime = startWaitTime;

                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    public void initiate() {
        if (keyInit) {
            StartCoroutine(shoot);
            keyInit = false;
        }
    }

    public IEnumerator disparar() {
        while (true) {
            referencia.LookAt(Jugador.transform);
            Instantiate(original, referencia.position, referencia.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
