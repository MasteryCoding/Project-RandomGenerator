using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 1f;

    void Update()
    {
        // Multiply vector (0,1,0) by the speed and deltaTime every frame
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
