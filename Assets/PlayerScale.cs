using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    private void FixedUpdate()
    {

        if (Input.GetMouseButton(0))
        {
            transform.localScale += Time.fixedTime * new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (Input.GetMouseButton(1))
        {
            transform.localScale -= Time.fixedTime * new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
    
}
