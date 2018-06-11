using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour {
    public GameObject Key;
    public Button keyButton;
    private bool pressed = false;
    // Use this for initialization
    void Start () {
       

        Button btn = keyButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

	
	// Update is called once per frame
	void Update () {
       
    }
    void TaskOnClick()
    {
        if (Key.GetComponent<ChestWithBaseObj>().GetPressed() == true)
        {

            
            pressed = true;
            Destroy(Key.GetComponent<ChestWithBaseObj>());
        }
    }

    public bool GetPressed()
    {
        return pressed;
    }
}
