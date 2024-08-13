using UnityEngine;

namespace Assets.Scripts.Platforms
{
    [CreateAssetMenu(fileName = "PlatformSettings", menuName = "ScriptableObjects/Platforms/platformsSettings")]
    public class PlatformSettings : ScriptableObject
    {
        [SerializeField] [Min(0.0f)]private float _destroyDelatAfterUnhooking;

        public float DestroyDelayAfterUnhooking =>
            _destroyDelatAfterUnhooking;
    }
}
