﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace Lovatto.OrbitCamera
{
    public class bl_OrbitUIBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bl_CameraOrbit CameraOrbit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (CameraOrbit == null)
            {
                Debug.LogWarning("Please assign a camera orbit target");
                return;
            }
            CameraOrbit.Interact = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (CameraOrbit == null)
            {
                Debug.LogWarning("Please assign a camera orbit target");
                return;
            }
            CameraOrbit.Interact = true;
        }
    }
}