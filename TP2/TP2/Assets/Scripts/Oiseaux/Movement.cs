using System;
using UnityEngine;

namespace Oiseaux
{
    public class Movement : Oiseau
    {
        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }
    }
}