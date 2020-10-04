using RiskyPipe3D.Enums;
using RiskyPipe3D.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.UIs
{
    public class EnergySystem : MonoBehaviour
    {

        [SerializeField] private RectTransform _energyFrontImage=null;
        [SerializeField] private float _energySpeed=0;
        private bool _isPlaying = false;
        private Vector3 _defaultVector=Vector3.zero;


        private void Awake()
        {
            EventManager.Instance.GameStateChanged += GameStateChanged;
            EventManager.Instance.EnergyIncreased += OnEnergyIncreased;
            EventManager.Instance.MechanicChanged += OnMechanicChanged;
            gameObject.SetActive(false);
            ResetObject();
        }

        private void OnMechanicChanged(ScaleMechanic scaleMechanic)
        {
            if(!scaleMechanic.Equals(ScaleMechanic.Joystick))
            {
                gameObject.SetActive(false);
            }
            
        }

        private void OnEnergyIncreased()
        {
            IncreaseEnergy();
        }

        private void GameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Playing))
            {
                _isPlaying = true;
                gameObject.SetActive(true);
            }
            else
            {
                ResetObject();
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (!_isPlaying) return;

            _defaultVector = Vector3.up;
            EnergyDown();
            CheckIfGameOver(_energyFrontImage.localScale.y);
        }

        private void EnergyDown()
        {
            _energyFrontImage.localScale -= _defaultVector * _energySpeed * Time.deltaTime;
        }

        

        public void IncreaseEnergy()
        {
            _energyFrontImage.localScale += _defaultVector * _energySpeed * Time.deltaTime * 5;
            CheckIfObjectOverMax(_energyFrontImage.localScale.y);
        }

        private void CheckIfObjectOverMax(float yValue)
        {
            if (yValue>1)
            {
                _energyFrontImage.localScale = new Vector3(_energyFrontImage.localScale.x, 1f, _energyFrontImage.localScale.z);
            }
        }

        private void CheckIfGameOver(float yValue)
        {
            if (yValue<=0)
            {
                _isPlaying = false;
                EventManager.Instance.MechanicChange(ScaleMechanic.None);
                EventManager.Instance.GameStateChange(GameState.Lose);
                //IncreaseEnergy(0.3f);
            }
        }

       public void ResetObject()
        {
            _isPlaying = false;
            _energyFrontImage.localScale = new Vector3(1, 1, 1);
        }

        
    }
}