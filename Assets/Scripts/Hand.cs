using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    IInteractable obj1;
    GameObject Chest1;
    GameObject Chest2;
    GameObject Key;
    GameObject Key2;
    GameObject Key1Button;
    GameObject Key2Button;
    GameObject Clock;
    GameObject Head;
    bool chest1lock = false;
    void Start()
    {
        Chest1 = GameObject.FindWithTag("Chest1");
        Chest2 = GameObject.FindWithTag("AboveBox");
        Key = GameObject.FindWithTag("Key");
        Key2 = GameObject.FindWithTag("Key2");
        Key1Button = GameObject.FindWithTag("Key1Button");
        Key2Button = GameObject.FindWithTag("Key2Button");
        Clock = GameObject.FindWithTag("Clock");
        Head = GameObject.FindWithTag("Head");

    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var obj_ = hit.transform.gameObject.GetComponent<IInteractable>();


                if (obj_ != null)
                {
                    obj1 = obj_;


                    obj1.MouseDown(hit.point);

                }

            }


            Vector3 _chest = Chest1.transform.position + new Vector3(2f, 2f, 2f);
            Vector3 chest_ = Chest1.transform.position - new Vector3(2f, 2f, 2f);

            if (Key1Button.GetComponent<KeyButton>().GetPressed() == true)
            {
                if (((hit.point.x <= _chest.x) && (hit.point.y <= _chest.y) && (hit.point.z <= _chest.z)) && ((hit.point.x >= chest_.x) && (hit.point.y >= chest_.y) && (hit.point.z >= chest_.z)))
                {
                    Key.transform.position = Chest1.transform.position ;
                    Key.SetActive(true);
                    //Key.transform.rotation = new Quaternion(-180, 0, 0, 0);
                    Key.transform.parent = Chest1.transform;
                }
            }

            Vector3 _above = Chest2.transform.position + new Vector3(2f, 2f, 2f);
            Vector3 above_ = Chest2.transform.position - new Vector3(2f, 2f, 2f);

            if (Key2Button.GetComponent<KeyButton>().GetPressed() == true)
            {
                if (((hit.point.x <= _above.x) && (hit.point.y <= _above.y) && (hit.point.z <= _above.z)) && ((hit.point.x >= above_.x) && (hit.point.y >= above_.y) && (hit.point.z >= above_.z)))
                {
                    Key2.transform.position = Chest2.transform.position;
                    Key2.SetActive(true);
                    
                    Key2.transform.parent = Chest2.transform;
                    Key2.transform.rotation = new Quaternion(-90, 0, 0, 0);
                }
            }

        }

        if (Input.GetButton("Fire1"))
        {
            if (obj1 != null)
            {


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                obj1.Move(ray);

                if (Key.GetComponent<Rotate_>().CheckAngle() == true)
                {
                    Chest1.GetComponent<DragChest>().UnLock();
                }

                if (Key2.GetComponent<Rotate_>().CheckAngle() == true)
                {
                    Clock.GetComponent<Rotate_>().UnLock();
                    Debug.Log("aaaaaaaaaa");
                }

                if (Clock.GetComponent<Rotate_>().CheckAngle() == true)
                {
                    Head.GetComponent<DragChest>().UnLock();
                }



            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (obj1 != null)
            {
                obj1.MouseUp();
            }

            obj1 = null;
        }

    }



}
