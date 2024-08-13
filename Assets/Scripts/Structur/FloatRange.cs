using UnityEngine;

namespace Assets.Scripts.Structur
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Structur/FloatRange", fileName = "FloatRange")]
    public class FloatRange : Range<float>
    {
        public float Random => UnityEngine.Random.Range(Min, Max);
    }
}

