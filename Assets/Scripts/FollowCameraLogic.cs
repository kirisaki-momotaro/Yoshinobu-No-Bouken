using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraLogic : MonoBehaviour
{

    public Transform camera_trans;
    public Transform target_trans;

    public float scroll_speed = 10;
    public float move_speed = 20;

    public Camera main_camera;

    Vector3 camera_position;
    Vector3 camera_angle;

    public bool follow_player;

    // Start is called before the first frame update
    void Start()
    {
        follow_player = true;


    }

    // Update is called once per frame
    void Update()
    {
        camera_angle = new Vector3(45, -45, 0);

        Vector3 cameraUpdatedPos = camera_trans.position;
        if (Input.GetKey("w"))
        {
            cameraUpdatedPos.z += move_speed * Time.deltaTime;
            cameraUpdatedPos.x -= move_speed * Time.deltaTime;
            follow_player = false;
        }
        if (Input.GetKey("s"))
        {
            cameraUpdatedPos.z -= move_speed * Time.deltaTime;
            cameraUpdatedPos.x += move_speed * Time.deltaTime;
            follow_player = false;
        }
        if (Input.GetKey("d"))
        {
            cameraUpdatedPos.x += move_speed * Time.deltaTime;
            cameraUpdatedPos.z += move_speed * Time.deltaTime;
            follow_player = false;
        }
        if (Input.GetKey("a"))
        {
            cameraUpdatedPos.z -= move_speed * Time.deltaTime;
            cameraUpdatedPos.x -= move_speed * Time.deltaTime;
            follow_player = false;
        }

        if (Input.GetKey("y"))
        {
            follow_player = true;
        }
        if (follow_player == true)
        {
            cameraUpdatedPos = new Vector3(target_trans.position.x + 10, target_trans.position.y + 15, target_trans.position.z - 10);

        }


        cameraUpdatedPos.x = Mathf.Clamp(cameraUpdatedPos.x, target_trans.position.x - 50, target_trans.position.x + 50);
        cameraUpdatedPos.z = Mathf.Clamp(cameraUpdatedPos.z, target_trans.position.z - 50, target_trans.position.z + 50);

        camera_trans.position = cameraUpdatedPos;
        camera_trans.eulerAngles = camera_angle;

        main_camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scroll_speed;
    }
}
