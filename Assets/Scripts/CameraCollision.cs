using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    public float minDistance = 1.0f,
                 maxDistance = 4.0f,
                 smooth = 10.0f,
                 distance;

    Vector3 dollyDir;

    public Vector3 dollyDirAdjusted;

    // Start is called before the first frame update
    void Awake()
    {
        this.dollyDir = transform.localPosition.normalized;
        this.distance = transform.localPosition.magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DesiredCameraPos = transform.parent.TransformPoint(this.dollyDir * this.maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, DesiredCameraPos, out hit))
        {
            this.distance = Mathf.Clamp((hit.distance * 0.9f), this.minDistance, this.maxDistance);
        }
        else {
            this.distance = this.maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition,this.dollyDir * this.distance,Time.deltaTime * this.smooth);
    }
}
