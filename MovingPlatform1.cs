using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour {

    private Vector3 posA; //first position

    private Vector3 posB; //second postition

    private Vector3 nexPos; //A or B depending on last position.

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Use this for initialization
    void Start () {
        posA = childTransform.localPosition;  //position of the platform
        posB = transformB.localPosition;
        nexPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
		
	}

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.captureFramerate);
        if(Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDes();
        }
    }

    private void ChangeDes()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
