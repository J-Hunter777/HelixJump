using Cinemachine;
using UnityEngine;

namespace Ball
{
    public class BallDistroyer : MonoBehaviour
    {
        [SerializeField] private BallParticles _particles;
        [SerializeField] private Transform _ball;
        [SerializeField] private CinemachineImpulseSource _impulseSours;
        public void Destroy()
        {
            _particles.EmitDestroyParticles(_ball.position);
            _impulseSours.GenerateImpulse();
            Destroy(_ball.gameObject);
        }
    }
}
