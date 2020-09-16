using RiskyPipe3D.GameDynamics;
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
    public class BasePipe : MonoBehaviour
    {
        [SerializeField]
        private Transform _endPosition;
        public Transform EndPosition { get => _endPosition;}

        public void SetObject(BasePipe before = null)
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
            //Deactive();
        }

        public void Active()
        {
            gameObject.SetActive(true);
        }

        public void Deactive()
        {
            gameObject.SetActive(false);
        }
        private void OnTriggerExit(Collider other)
        {
            if(this as MidLeftPipe || this as MidRightPipe)
            {
                if (other.CompareTag("Player"))
                {
                    PlayerController pController = other.GetComponent<PlayerController>();
                    pController.SetPosition(EndPosition.position);
                    pController.SpeedUp();
                    GetComponent<Collider>().enabled = false;
                }
            }
        }
    }
}

