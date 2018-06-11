using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class -> interface

public interface IInteractable  {

    void MouseDown(Vector3 vector3);
    void Move(Ray ray);
    void MouseUp();



}
