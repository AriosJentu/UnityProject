using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour, IInteractable {
    public float Speed;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(activated)
        {
            transform.position += new Vector3(0, 0, 1) * Speed * Time.deltaTime;
            
        }      	
	}

    public void MouseDown(Vector3 vector3) {

        activated = true;
    }


    public void Move(Ray ray) { }
    public void MouseUp() { }
    bool activated = false;


}
