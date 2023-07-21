using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipCharacter(float horizontal)
        {
            if (horizontal != 0) //En son elimizi �ekti�imiz tu� A ise Player y�n�n�n solda kalmas� i�in
            {
                float mathfValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathfValue) return;

                transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f); //A'ya bast���m�zda y�n�n�n de�i�mesi i�in
            }
            
        }
    }
}

