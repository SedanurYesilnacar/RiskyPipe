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

        [SerializeField] private RectTransform _energyFrontImage;
        [SerializeField] private float _energySpeed;
        private bool _isPlaying = false;
        private Vector3 _defaultVector;

        private void Start()
        {
            EventManager.Instance.EnergyChanged += OnEnergyChanged;
            EventManager.Instance.GameStateChanged += GameStateChanged;
            ResetObject();
        }

        private void GameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.NextStage))
            {
                ResetObject();
            }
        }

        private void Update()
        {
            if (!_isPlaying) return;

            _defaultVector = new Vector3(0, 1, 0);
            _energyFrontImage.localScale -= _defaultVector * _energySpeed/10000;
            CheckIfGameOver(_energyFrontImage.localScale.y);
        }

        private void OnDisable()
        {
            EventManager.Instance.EnergyChanged -= OnEnergyChanged;
            
        }

        public void IncreaseEnergy(float amount)
        {
            _energyFrontImage.localScale = new Vector3(_energyFrontImage.localScale.x,_energyFrontImage.localScale.y+ amount, _energyFrontImage.localScale.z);
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
                EventManager.Instance.GameStateChange(GameState.Restart);

                GameManager.Instance.GameOverPanel(true);
                //IncreaseEnergy(0.3f);
            }
        }

       public void ResetObject()
        {
            _isPlaying = false;
            _energyFrontImage.localScale = new Vector3(1, 1, 1);
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

        private void OnEnergyChanged(bool isActive)
        {
            if (isActive)
            {
                _isPlaying = isActive;
                gameObject.transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                ResetObject();
            }
        }
    }
}