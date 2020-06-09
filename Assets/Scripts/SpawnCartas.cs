using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCartas : MonoBehaviour
{
    public GameObject carta;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CrearProyectiles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearProyectiles()
    {
        while (true)
        {
            float x = Random.Range(-2784f, -211f);
            float z = Random.Range(-1302, 1302f);
            Vector3 asteroidePos = new Vector3(x, 19.7f, z);
            Quaternion asteroideRot = new Quaternion(0, 0, 0, 0);
            Instantiate(carta, asteroidePos, asteroideRot);
            yield return new WaitForSeconds(1f);
        }
    }
}
