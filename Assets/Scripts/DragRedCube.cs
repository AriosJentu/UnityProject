using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRedCube : MonoBehaviour, IInteractable {
    public Vector3 inNormalVector;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseDown(Vector3 vector3)
    {
        

    }

    public void Move(Ray ray) {

        float distance_;

        var plane = new Plane(inNormalVector, Vector3.zero);

        plane.Raycast(ray, out distance_);

        var intersectionPoint = ray.origin + ray.direction * distance_;

        transform.position = intersectionPoint + new Vector3(0, 0.5f, 0);//0.5 * высоту куба


    }

    public void MouseUp() {

    }

    public bool Check(GameObject gameObject)
    {   
        
        bool isRotatable = false;

        if (Mathf.Round(gameObject.transform.position.x) == Mathf.Round(this.transform.position.x))
        {
            Debug.Log("All");
            return true;
            
        }

        return false;
    }
}
