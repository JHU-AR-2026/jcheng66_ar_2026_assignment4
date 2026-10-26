
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    void Start()
    {
        // Save the initial distance between camera and player
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Keep the same offset while following the player
        transform.position = player.position + offset;
    }
}
