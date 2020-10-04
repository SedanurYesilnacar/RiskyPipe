using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RiskyPipe3D.UIs
{
    public class ConfettiSplash:MonoBehaviour
    {

        private void Awake()
        {
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
            gameObject.SetActive(false);
        }

 

        private void OnGameStateChanged(GameState state)
        {
            if (state.Equals(GameState.Win))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

       
    }
}
