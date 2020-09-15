using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RiskyPipe3D
{
    public enum PipeType
    {
        NormalPipe,
        NormalRightPipe,
        NormalLeftPipe,
        MidRightPipe,
        MidLeftPipe,
        MidNormalPipe,
    }
    public class Pipe : LevelObject
    {
        [SerializeField]
        private PipeType _type;
        [SerializeField]
        private Transform _endPosition;
        [SerializeField]
        bool _isMid;

        
        
        public bool IsMid { get => _isMid;}
        public PipeType Type { get => _type;}
        public Transform EndPosition { get => _endPosition;}

        private Pipe(PipeType pipeType, Transform endPosition)
        {
            _type = pipeType;
            _endPosition = endPosition;
        }

        override
        public void SetObject(LevelObject before = null)
        {
            if(before != null)
            {
                Pipe beforePipe = before as Pipe;
                transform.position = beforePipe.EndPosition.position;
                if (beforePipe.Type == PipeType.MidRightPipe || beforePipe.Type == PipeType.MidLeftPipe)
                    transform.localEulerAngles = new Vector3(90, beforePipe.transform.localScale.x * 90 + beforePipe.transform.localEulerAngles.y, 0);
                else
                    transform.localEulerAngles = beforePipe.transform.localEulerAngles;

                Debug.Log( "This Pipe Has "+transform.childCount + " Child");
            }
          
        }

  
    }
}

