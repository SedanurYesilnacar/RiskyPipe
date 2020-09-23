using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    float zOffset;
    private void Awake()
    {
        zOffset = transform.position.z;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + zOffset);
    }
}
