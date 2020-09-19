using RiskyPipe3D.LevelDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        public BasePipe _leftHorizontal;
        public BasePipe _rightHorizontal;
        public BasePipe _leftVertical;
        public BasePipe _rightVertical;

        public BasePipe _vertical;
        public BasePipe _verticalLeft;
        public BasePipe _verticalRight;
        private void Awake()
        {
            List<BasePipe> _pipes = new List<BasePipe>();
            for(int i = 0; i < 5; i++)
            {
                _pipes.Add(_vertical);
            }
            _pipes.Add(_verticalRight);
            for(int i = 0; i < 5; i++)
            {
                _pipes.Add(_rightHorizontal);
            }
            _pipes.Add(_rightVertical);

            for(int i = 0; i < _pipes.Count; i++)
            {
                GameObject obj = Instantiate(_pipes[i].gameObject);
                _pipes[i] = obj.GetComponent<BasePipe>();
            }
            _pipes[0].transform.position = Vector3.zero;
            Debug.LogError(_pipes.Count);
            for(int i = 1; i < _pipes.Count; i++)
            {
                _pipes[i].SetObject(_pipes[i - 1]);
            }
        }

    }
}
