using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 cameraDistance;
    Quaternion rot;
    private void Start()
    {
        rot = transform.rotation;


    }
    //private void FixedUpdate()
    //{
    //    transform.position = player.transform.position + cameraDistance;
    //}
    // camera will follow this object
    private void LateUpdate()
    {
       // transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 100);
       // transform.Rotate(rot.eulerAngles);
    }
}
