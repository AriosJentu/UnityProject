using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Rotate_ : MonoBehaviour, IInteractable
{
    
   
    private int c;
    private Vector3 firstCoord;
    private float a, a1;
    private float b, b1;
    private Vector3 direction;//y public
    private Vector3 normal;
    private Vector3 normalDirection;
    private Vector3 movePoint;
    private Vector3 point;
    private Vector3 center;
    private Quaternion initRotation;
    private float sumAngle = 0;

    public Vector3 rotateAxis;
    public bool lock_;
    // Use this for initialization
    void Start ()
    {   
        //direction = new Vector3(1, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    
    }

    public void MouseDown(Vector3 vector3)
    {
        rotateAxis.Normalize();
        normal = transform.rotation * rotateAxis;

        point = vector3;

        var plane = new Plane(normal, transform.position);

        point = plane.ClosestPointOnPlane(point);
        center = transform.position;
        direction = (point - center).normalized;
        normalDirection = Vector3.Cross(direction, normal).normalized;

        initRotation = transform.rotation;
    }

    public void Move(Ray ray)
    {
        if (!lock_)
        {
            float distance_;


            var plane = new Plane(normal, center);

            plane.Raycast(ray, out distance_);

            var intersectionPoint = ray.origin + ray.direction * distance_;

            var look = (intersectionPoint - center).normalized;

            var cos = Vector3.Dot(direction, look);
            var sin = Vector3.Dot(normalDirection, look);

            //Debug.Log(sin);

            float angle = -Mathf.Acos(cos) * Mathf.Rad2Deg;
            
            if (sin < 0)
            {
                angle *= -1;
            }


            sumAngle = angle;
            // Debug.Log(direction);

            transform.rotation = Quaternion.AngleAxis(angle, normal) * initRotation;

            
           

            Debug.DrawLine(center, center + direction * 10, Color.red);
            Debug.DrawLine(center, center + normalDirection * 10, Color.green);
            Debug.DrawLine(center, center + normal * 10, Color.blue);
            Debug.DrawLine(center, center + look * 10, Color.yellow);
        }
    }

    public void MouseUp()
    {

    }

    public bool CheckAngle()
    {
        bool unlock = false;
        if(sumAngle >= 120)
        {
            unlock = true;
        }

        return unlock;
    }

    public bool UnLock()
    {
        lock_ = false;
       // Debug.Log("Unlock");
        return lock_;
    }
}
