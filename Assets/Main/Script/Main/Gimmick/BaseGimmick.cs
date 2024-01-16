using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class BaseGimmick : MonoBehaviour, IGetGimmick
    {
        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
        public virtual void OnTriggerExit2D(Collider2D collision)
        {
            
        }
        public virtual void OnTriggerStay2D(Collider2D collision)
        {
            
        }
        public virtual void UseGimmick()
        {

        }
    }
}