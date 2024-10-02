using System.Collections.Generic;
using Assets.Scripts.Platforms;
using Structur;
using UnityEngine;

namespace Tower
    
{

    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] public TowerGenerationSettings _generetionSettings;

        [Header("Tower")]
        [SerializeField] private Transform _tower;

        private FloatRange RotationRange => _generetionSettings.RotationRange;

        private void Start()
        {
            Generate(_generetionSettings, _tower);
        }
        private void Generate(TowerGenerationSettings generetionSettings, Transform tower)
        {
            List<Platform> spawnedPlatforms = SpawnPlatforms(generetionSettings, out float offsetFromTop);

            FitTowerHeight(tower, offsetFromTop);
            spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
        }

        private List<Platform> SpawnPlatforms(TowerGenerationSettings generetionSettings, out float offsetFromTop)
        {
            offsetFromTop = generetionSettings.OffsetBetweenPlatforms;
            const int startAndLastPlatforms = 2;
            var spawnedPlatforms = new List<Platform>(generetionSettings.PlatformVariationCount + startAndLastPlatforms);

            Platform startPlatform = Create(generetionSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(startPlatform);

            for (int i = 0; i < generetionSettings.PlatformVariationCount; i++)
            {
                Platform platform = Create(generetionSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
                spawnedPlatforms.Add(platform);
            }

            Platform finishPlatform = Create(generetionSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(finishPlatform);

            return spawnedPlatforms;
        }

            private Vector3 GetRAndomYRotation(FloatRange rotationRange) =>
                Vector3.up * _generetionSettings.RotationRange.Random;

            private Platform Create(Platform platformPrefab, FloatRange rotationRange, ref float offsetFromTop)
            {
                Platform createdPlatform = Instantiate(platformPrefab);
                Transform platformTransform = createdPlatform.transform;
                platformTransform.position = Vector3.down * offsetFromTop;
                platformTransform.eulerAngles = GetRAndomYRotation(rotationRange);

                offsetFromTop += platformTransform.localScale.y + _generetionSettings.OffsetBetweenPlatforms;
                return createdPlatform;
            }
            
           private void FitTowerHeight(Transform tower, float height)
            {
                Vector3 originalSize = tower.localScale;
                float towerHeight = height / 2.0f;
                tower.localScale = new Vector3(originalSize.x, y: towerHeight, originalSize.z);
                tower.localPosition -= Vector3.up * towerHeight;
            }
        }
    } 



