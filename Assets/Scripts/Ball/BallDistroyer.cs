using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using Cinemachine;

namespace Assets.Scripts.Ball
{
    public class BallDistroyer : MonoBehaviour
    {
        [SerializeField] private BallPaticles _particles;
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
