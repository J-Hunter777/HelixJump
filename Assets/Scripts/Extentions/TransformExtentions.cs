using UnityEngine;

namespace Extentions
{
    public static class TransformExtentions
    {
        public static void ClearParent(this Transform transform ) =>
            transform.SetParent( null );
    }
}
