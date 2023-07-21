using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class LadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 0f, true);
        }

        private void OnTriggerExit2D(UnityEngine.Collider2D collision)
        {
            EnterExitOnTrigger(collision, 1f, false);
        }

        private void EnterExitOnTrigger(Collider2D collison, float gravityForce, bool isClimbing)
        {
            Climbing playerClimbing = collison.GetComponent<Climbing>();
            if (playerClimbing != null)
            {
                playerClimbing.Rigidbody.gravityScale = gravityForce;
                playerClimbing.IsClimbing = isClimbing;
            }
        }
    }

}
