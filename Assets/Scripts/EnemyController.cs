using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed =15f;

    void Start()
    {
        transform.Rotate(0, 180, 0);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
