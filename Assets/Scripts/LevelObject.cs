using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    virtual public void SetObject(LevelObject levelObject = null)  {   }

    private void Awake()
    {
        Deactive();
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
