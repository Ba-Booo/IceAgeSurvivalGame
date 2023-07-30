using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    public float cameraMoveSpeed;

    void Start()
    {

    }

    void Update()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, cameraMoveSpeed * Time.deltaTime);       //부드러운 이동
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}
