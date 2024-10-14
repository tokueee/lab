using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll: MonoBehaviour
{
    //追従して欲しいオブジェクト
    public Transform target;
    public Vector3 offset;
    public Transform camera;

    private float RotateSpeed = 1.5f;

    private Vector3 Rot_Camera = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //カメラリセット
        if (Input.GetKey(KeyCode.R))
        {
            Rot_Camera = Vector2.zero;
        }

        transform.position = target.position + offset;

        Rot_Camera.x -= Input.GetAxis("Mouse Y") * RotateSpeed;
        Rot_Camera.x = Mathf.Clamp(Rot_Camera.x, -90, 90);
        Rot_Camera.y += Input.GetAxis("Mouse X") * RotateSpeed;

        transform.rotation = Quaternion.Euler(0, Rot_Camera.y, 0);
        camera.rotation = Quaternion.Euler(Rot_Camera.x, Rot_Camera.y, 0);
    }
}
