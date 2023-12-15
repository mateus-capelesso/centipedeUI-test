using UnityEngine;

namespace View
{
    public class ScoreParticle : MonoBehaviour
    {
        public void DestroyParticle()
        {
            Destroy(gameObject);
        }
    }
}