using RiskyPipe3D.LevelDynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public class GameManager : MonoBehaviour
    {
        public Pipe _midRightForward;
        public Pipe _midLeftForward;
        public Pipe _midLeftHorizontal;
        public Pipe _midRightHorizontal;

        public Pipe _horizontalRightPipe;
        public Pipe _horizontalLeftPipe;
        public Pipe _verticalPipe;
        private void Awake()
        {
            List<Pipe> _pipes = new List<Pipe>();
            for(int i = 0; i < 5; i++)
            {
                _pipes.Add(_verticalPipe);
            }
            _pipes.Add(_midRightForward);
            for(int i = 0; i < 5; i++)
            {
                _pipes.Add(_horizontalRightPipe);
            }
            _pipes.Add(_midRightHorizontal);

            for(int i = 0; i < _pipes.Count; i++)
            {
                GameObject obj = Instantiate(_pipes[i].gameObject);
                _pipes[i] = obj.GetComponent<Pipe>();
            }

            for(int i = 1; i < _pipes.Count; i++)
            {
                _pipes[i].SetObject(_pipes[i - 1]);
            }
        }

    }
}
