using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb.velocity = new Vector3(0, 0, 10);
    }
}
