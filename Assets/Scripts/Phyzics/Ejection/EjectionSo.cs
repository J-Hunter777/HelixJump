using UnityEngine;

namespace Assets.Scripts.Phyzics.Ejection
{
    [CreateAssetMenu(fileName = "Ejection", menuName = "ScriptableObjects/Phyzics/Ejection")]
    public class EjectionSo : ScriptableObject
    {
        [SerializeField] [Min(0.0f)] private float _horizontalPanelForce;
        [SerializeField] private float _upwardsModifier;
        public void PushOut(Rigidbody rigidbody, Vector3 position) 
        {
            Vector3 forceDirection = (rigidbody.worldCenterOfMass - position).normalized;
            Vector3 force = ScaleForce(forceDirection);
            rigidbody.AddForce(force, ForceMode.VelocityChange);
        }

        private Vector3 ScaleForce(Vector3 forceDirection)
        {
            return Vector3.Scale(forceDirection.normalized ,new Vector3
            {
                x = _horizontalPanelForce,
                y = 1,
                z = _horizontalPanelForce
            })
                + Vector3.up * _upwardsModifier;
        }
    }
}
