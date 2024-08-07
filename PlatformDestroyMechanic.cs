namespace Assets.Scripts.Platforms.Parts
{
    public class PlatformSaveZone : PlatformPart { }
}

using UnityEngine;

namespace Assets.Scripts.Platforms.Parts
{
    public class PlatformObstacle : PlatformPart { }
}

using UnityEngine;

namespace Assets.Scripts.Platforms.Parts
{
    public abstract class PlatformPart : MonoBehaviour
    {

    }
}
using Assets.Scripts.Ball;
using Assets.Scripts.Platforms;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    [RequireComponent(typeof(Collider))]
    public class PlatformPassTrigger : MonoBehaviour
    {
        private Platform _parentPlatform;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallCollisions _) == false)
                return;
            _parentPlatform.UnhookAllParts();
            Destroy(gameObject);
        }
        private void OnValidate()
        {
            GetComponent<Collider>().isTrigger = true;
        }
        private void Start()
        {
            _parentPlatform = GetComponentInParent<Platform>();
        }

      
}
