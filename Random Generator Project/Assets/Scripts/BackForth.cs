using UnityEngine;

public class BackForth : MonoBehaviour
{

    public float moveSpeed = 1f;

    public float maxDistance = 3f;

    private Transform childTransform;

    void Awake()
    {
        // Get a reference to the child's transform
        childTransform = transform.GetChild(0).transform;
    }

    void Start()
    {
        // Start the child object at parent's origin. 
        childTransform.localPosition = Vector3.zero;
    }

    void Update()
    {
        // Move the child back and forth.
        childTransform.localPosition = Vector3.right * Mathf.Sin(Time.time * moveSpeed) * maxDistance;
    }
}
