using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    public float maxSize = 3f;

    public float minSize = 0.5f;
    public float scaleSpeed = 1f;

    Transform childTransform;

    bool growing = true;

    void Awake()
    {
        // Get a reference to the child transform.
        childTransform = transform.GetChild(0).transform;
    }

    void Start()
    {
        childTransform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the child has passed the maximum distance, if so, change the direction.
        if (childTransform.localScale.x >= maxSize) {
            growing = false;
        } else if (childTransform.localScale.x <= minSize) {
            growing = true;
        }

        // Check which direction the child is moving, then move its position in that direction.
        if (growing) {
            childTransform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        } else {
            childTransform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }
}
