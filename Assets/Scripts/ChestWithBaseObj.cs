using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestWithBaseObj : MonoBehaviour, IInteractable {
    //GameObject Key;
    bool enabled_ = true;
    bool pressed = false;
    public GameObject Key;
    // Use this for initialization
    void Start ()
	{
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseDown(Vector3 vector3)
    {
        pressed = true;
        
        if (enabled_)
        {
            Key.SetActive(false);
            enabled_ = false;
            //Destroy(this);
        }
    }

    public void Move(Ray ray)
    {

    }

    public void MouseUp()
    {

    }

    public bool GetPressed()
    {
        
        return pressed;
        
    }
}
