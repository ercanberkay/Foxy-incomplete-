using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Inputs
{
    public class PcInput : MonoBehaviour
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical { get; set; }
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}
