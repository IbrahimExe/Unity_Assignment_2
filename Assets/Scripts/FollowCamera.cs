using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player1 = null;
    [SerializeField] private Transform player2 = null;

    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float smoothStep = 15.0f;

    void Start()
    {
        // Initial camera setup
        Vector3 targetPosition = (player1.position + player2.position) / 2 + offset;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }

    void Update()
    {
        Vector3 midpoint = (player1.position + player2.position) / 2;

        Vector3 targetPosition = midpoint + offset;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothStep * Time.deltaTime);
    }
}