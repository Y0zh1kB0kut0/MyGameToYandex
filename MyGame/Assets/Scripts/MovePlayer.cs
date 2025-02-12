using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraPosition;

    public float speed = 5f;

    private Transform transformCamera;

    private void Start()
    {
        transformCamera = cameraPosition.GetComponent<Transform>();
    }

    private void Update()
    {
        float vert = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(1, 0 , 0) * speed * Time.deltaTime * vert);

        float hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime * hor);

        transformCamera.position = transform.position;
    }
}
