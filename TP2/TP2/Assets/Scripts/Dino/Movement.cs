using Coin;
using UnityEngine;

namespace Dino
{
    public class Movement : Dino
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && (Rb.velocity.y == 0 || doubleJump) )
            {
                doubleJump = !doubleJump;
                Jump();
            }
            
        }

        private void Jump()
        {
            Rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }
    }
}