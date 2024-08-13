using Assets.Scripts.Phyzics.Ejection;
using Assets.Scripts.Platforms.Parts;
using UnityEngine;

namespace Assets.Scripts.Platforms
{ public class Platform : MonoBehaviour
    {
        [SerializeField] private EjectionSo _ejection;
        [SerializeField] private PlatformSettings _settings;

        private PlatformPart[] _parts;
        private void Start() => _parts = GetComponentsInParent<PlatformPart>();
        
        public void UnhookAllParts()
        {
            foreach (PlatformPart platformPart in _parts)
            {
                platformPart.UnhoolBy(_ejection, transform.position);
                Destroy(platformPart.gameObject, _settings.DestroyDelayAfterUnhooking);
            }
            Destroy(gameObject, _settings.DestroyDelayAfterUnhooking);
        }

    }
}
