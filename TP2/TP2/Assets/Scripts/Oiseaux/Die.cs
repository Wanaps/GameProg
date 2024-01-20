using UnityEngine;

namespace Oiseaux
{
    public class Die : Oiseau
    {
        private void Update()
        {
            if (transform.position.y < -10)
            {
                Destroy(this);
            }
        }
    }
}