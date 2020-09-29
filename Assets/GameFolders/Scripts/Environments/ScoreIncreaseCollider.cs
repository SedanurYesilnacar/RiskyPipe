namespace RiskyPipe3D.Environments
{
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;

    public class ScoreIncreaseCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.ScoreIncrease();
            }
        }
    }
}
