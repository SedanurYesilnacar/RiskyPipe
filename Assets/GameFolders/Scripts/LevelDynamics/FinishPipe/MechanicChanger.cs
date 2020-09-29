namespace RiskyPipe3D.Mechanics.LevelDynamics.FinishPipe
{
    using UnityEngine;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;

    public class MechanicChanger : MonoBehaviour
    {
        [SerializeField] private ScaleMechanic _mechanic;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                EventManager.Instance.MechanicChange(_mechanic);
        }
    }
}
