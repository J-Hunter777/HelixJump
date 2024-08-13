using Assets.Scripts.Extentions;
using Assets.Scripts.Phyzics.Ejection;
using UnityEngine;

namespace Assets.Scripts.Platforms.Parts
{
    public abstract class PlatformPart : MonoBehaviour
    {
        public void UnhoolBy(EjectionSo ejection, Vector3 crnterOfPlatform)
        {
           Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();

            transform.ClearParent();
            rigidbody.detectCollisions = false;
            ejection.PushOut(rigidbody, crnterOfPlatform);
        }
    }
}
