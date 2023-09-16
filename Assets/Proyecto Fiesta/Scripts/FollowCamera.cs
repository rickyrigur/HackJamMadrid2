using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed;
    public float cameraDistance;
    public float yOffset;
    public float xOffset;
    //float smooth = 0.95f;
    public Transform personaje;

    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(personaje.position.x + xOffset, personaje.position.y + yOffset, cameraDistance);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
