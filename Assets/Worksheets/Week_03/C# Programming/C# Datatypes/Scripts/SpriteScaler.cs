using UnityEngine;

namespace GADVDataTypes
{
    /// <summary>
    /// Scales the attached GameObject's transform in the X and Y axes.
    /// </summary>
    public class SpriteScaler : MonoBehaviour
    {
        [SerializeField]
        private float scale = 2.0f;

        void Start()
        {
            // Set the local scale of the transform
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}

