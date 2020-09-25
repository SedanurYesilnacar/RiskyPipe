using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiskyPipe3D.Managers
{
    public class PlayerManager : BaseObject
    {
        private int _score;
        private int _scoreMultiplier;
        [SerializeField] private GameObject _ringPrefab;
        private GameObject _ringObj;

        public override void PreInit()
        {
            _score = 0;
            _scoreMultiplier = 1;
            // set prefab from some class idk 
        }
        public override void Init()
        {

            _ringObj = Instantiate(_ringPrefab, Vector3.zero, Quaternion.identity);
            GameManager.Instance.SetCameraFollowTransform(_ringObj.transform);
        }

        public GameObject GetRingObject()
        {
            return _ringObj;
        }
        public void IncreaseScoreMultiplier()
        {
            _scoreMultiplier++;
        }
    }
}
