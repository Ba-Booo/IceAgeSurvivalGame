using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform Target;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, 0, -10);
    }
}
