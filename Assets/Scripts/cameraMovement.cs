using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;         
    public float smoothSpeed = 0.125f;
    public float yOffset = 0f;       

    private float fixedX;           

    void Start()
    {
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(
                fixedX, 
                target.position.y + yOffset, 
                transform.position.z
            );

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


