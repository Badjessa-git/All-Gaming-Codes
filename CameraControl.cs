using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    public bool YmaxEnabled = false;

    public float Ymaxvalue = 0;

    public bool YMinEnabled = false;

    public float YminValue = 0;

    public bool XmaxEnabled = false;

    public float Xmaxvalue = 0;

    public bool XMinEnabled = false;

    public float XminValue = 0;


    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        //vertical
        if(YMinEnabled && YmaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YminValue, Ymaxvalue);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YminValue, target.position.y);
        }
        else if (YmaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, Ymaxvalue);
        }
        //horizontal
        if (XMinEnabled && XmaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XminValue, Xmaxvalue);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XminValue, target.position.x);
        }
        else if (XmaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, Ymaxvalue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
