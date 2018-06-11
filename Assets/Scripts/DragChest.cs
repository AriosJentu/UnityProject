using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

using System;

public class DragChest : MonoBehaviour, IInteractable {
    
    private Vector3 point;
    private Vector3 startCoord;
    public bool lock_;
    public Vector3 direction;
    
    // Use this for initialization
    void Start ()
    {

        //direction = new Vector3(0, transform.localPosition.y, 0);;
        startCoord = transform.localPosition;
        
        
      

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseDown(Vector3 vector3) {
        point = vector3;
        
    }

    public void Move(Ray ray) {
        if (lock_ == false)
        {
            float distance_;

            Vector3 start;
            Vector3 finish;
            if (transform.parent != null)
            {
                start = transform.parent.TransformPoint(startCoord);
                finish = start + transform.TransformDirection(direction);
            }
            else
            {
                start = startCoord;
                finish = startCoord + direction;
            }


            Vector3 projectPoint = HandleUtility.ProjectPointLine(ray.origin, start, finish);
           
           Vector3 normal = projectPoint - ray.origin;

            var plane = new Plane(normal, point);

            plane.Raycast(ray, out distance_);



           var intersectionPoint = ray.origin + ray.direction * distance_;

            transform.position = HandleUtility.ProjectPointLine(intersectionPoint, start, finish);
        }
    }

    public void MouseUp() { }

    public bool UnLock()
    {   lock_ = false;
        Debug.Log("Unlock");
        return lock_;
    }

    public static implicit operator DragChest(GameObject v)
    {
        throw new NotImplementedException();
    }
}
