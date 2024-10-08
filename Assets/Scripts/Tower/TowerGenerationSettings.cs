﻿using System;
using Assets.Scripts.Platforms;
using Structur;
using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]

    public class TowerGenerationSettings : ScriptableObject
    {
        [SerializeField][Min(0)] private int _platformVariationCount;
        [SerializeField][Min(0.0f)] private float _offsetBetweenPlatforms;

        [SerializeField] private FloatRange _rotationRange;

        [Header("Platform Prefab")]
        [SerializeField] private Platform _startPlatformPrefab;
        [SerializeField] private Platform _finishPlatformPrefab;
        [SerializeField] private Platform[] _platformVariantsPrefabs = Array.Empty<Platform>();

        public int PlatformVariationCount => _platformVariationCount;
        public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;

        internal Platform StartPlatformPrefab => _startPlatformPrefab;

        internal Platform FinishPlatformPrefab => _finishPlatformPrefab;

        internal Platform[] PlatformVariationsPrefab => _platformVariantsPrefabs;

        public FloatRange RotationRange => _rotationRange;
    }
}
