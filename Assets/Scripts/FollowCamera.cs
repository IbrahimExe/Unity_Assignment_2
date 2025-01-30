using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float smoothStep = 10.0f;

    void Start()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }

    void Update()
    {
        Vector3 targetPositon = target.position + offset;
        targetPositon.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPositon, smoothStep * Time.deltaTime);
    }
}
