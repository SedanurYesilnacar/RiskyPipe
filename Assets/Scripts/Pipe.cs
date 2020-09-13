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
    public class Pipe : MonoBehaviour
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

        public void SetObject(Pipe before = null)
        {
            if(before == null)
            {

            }
            else
            {
                transform.position = before.EndPosition.position;
            }
        }

        private void Start()
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
}

