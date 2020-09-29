namespace RiskyPipe3D.LevelDynamics
{
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    public class PointPipe : RotateablePipe
    {
        [SerializeField] private int _multipier = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.GameStateChange(Enums.GameState.Win);
                EventManager.Instance.MultipierSet(_multipier);
                Debug.Log("1");
            }
        }
    }
}

