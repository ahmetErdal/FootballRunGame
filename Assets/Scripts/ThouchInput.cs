using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ThouchInput : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float leftForwardSpeed;
    [SerializeField] private TeamFriendType type;
    [SerializeField] Vector3 moveVector;
    [SerializeField] private Camera cam;
    private Quaternion defaultRotate;
    private float defaultRotation;
    private float rotationPositiveZAxis = 22f;
    private float rotationNegativeZAxis = -22f;

    private void Awake()
    {
        defaultRotation = transform.rotation.z;
        defaultRotate = Quaternion.Euler(transform.rotation.x, transform.rotation.y, defaultRotation);
    }
    private void Start()
    {
        forwardSpeed = type.playerSpeed;
        leftForwardSpeed = type.playerLeftSpeed;
        moveVector = type.leftRightMove;
       
    }
    private void Update()
    { 
        ForwardMoveController();
        ThouchController();
        
    }
    #region MouseInput Controller
    public void ForwardMoveController()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward *( leftForwardSpeed * Time.deltaTime));
            cam.DOFieldOfView(80, 1);
            transform.DOMoveX(-1, 1);
           
        }
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    PlayerRotation(rotationNegativeZAxis);
        //}
        //else if (Input.GetMouseButtonDown(0))
        //{
        //    PlayerRotation(rotationPositiveZAxis);
        //}
        else
        {
            transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
            cam.DOFieldOfView(60, 1);
            transform.DOMoveX(1, 1);
            
        }
    }
    #endregion
    
    #region Touch Input
    public void ThouchController()
    {
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                transform.Translate(Vector3.forward * (leftForwardSpeed * Time.deltaTime));
                cam.DOFieldOfView(80, 1);
                transform.DOMoveX(-1, 1);
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("up");
                transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
                cam.DOFieldOfView(60, 1);
                transform.DOMoveX(1, 1);

            }
        }

       
    }
    #endregion
    private void PlayerRotation(float rotationAxis)
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationAxis);
        transform.DORotateQuaternion(rotation, .3f).OnComplete(() =>
        {
            transform.DORotateQuaternion(defaultRotate, .3f);
        });
    }
}
