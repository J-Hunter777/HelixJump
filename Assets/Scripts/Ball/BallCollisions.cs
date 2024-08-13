using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Phyzics;
using Assets.Scripts.Ball;
using Assets.Scripts.Platforms;
using Assets.Scripts.Platforms.Parts;

namespace Assets.Scripts.Ball
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallBounce _bounce;
        [SerializeField] private BallPaticles _particles;
        [SerializeField] private Transform _ball;
        [SerializeField] private BallDistroyer _destroyer;
        

        private bool _collided;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PlatformObstacle _))
            {
                _destroyer.Destroy();
                return;
            }

            if (_collided)
                return;
            _collided = true;
            _bounce.BounceOff(Vector3.up);
            _particles.EmitSpotParticles(other);
            _particles.EmitCollisionParticles(other);
        }

        private void OnCollisionExit(Collision other) => 
            _collided = false;

        
    }
}
