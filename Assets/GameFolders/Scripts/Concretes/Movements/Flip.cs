using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipCharacter(float horizontal)
        {
            if (horizontal != 0) //En son elimizi çektiðimiz tuþ A ise Player yönünün solda kalmasý için
            {
                float mathfValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathfValue) return;

                transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f); //A'ya bastýðýmýzda yönünün deðiþmesi için
            }
            
        }
    }
}

