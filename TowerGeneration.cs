using Assets.Scripts.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tower
{
    internal class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private Platform _startPlatform;
        [SerializeField] private Platform _finishPlatform;
        [SerializeField] private Platform[] _platformVariants = Array.Empty<Platform>();



    }
}
