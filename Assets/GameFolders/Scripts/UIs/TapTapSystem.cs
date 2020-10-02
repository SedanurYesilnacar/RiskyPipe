using RiskyPipe3D.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.UIs
{
    public class TapTapSystem : MonoBehaviour
    {

        private void Start()
        {
            EventManager.Instance.TapTapChanged += TapTapChanged;
        }

       

        private void OnDisable()
        {
            EventManager.Instance.TapTapChanged -= TapTapChanged;
        }

  

        private void TapTapChanged(bool isActive)
        {
            if (isActive)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}