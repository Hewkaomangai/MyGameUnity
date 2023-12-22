using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitity = 3.0f;

    private float rotationX;
    private float rotationY;

    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3.0f;

    private Vector3 currentRotaion;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector3 rotationXminMax = new Vector2 (-20, 40);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitity;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, rotationXminMax.x, rotationXminMax.y);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        currentRotaion = Vector3.SmoothDamp(currentRotaion, nextRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotaion;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
