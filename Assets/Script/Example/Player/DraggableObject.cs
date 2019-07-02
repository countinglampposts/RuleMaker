using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rulemaker.Example
{
    public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Vector3 pointerStartPosition;
        Vector3 objectStartPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            pointerStartPosition = ScreenToPlanePosition(eventData.position);
            objectStartPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var deltaPosition = ScreenToPlanePosition(eventData.position) - pointerStartPosition;
            transform.position = objectStartPosition + deltaPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        private Vector3 ScreenToPlanePosition(Vector2 screenPosition)
        {
            var plane = new Plane(Vector3.up, Vector3.zero);
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            float outFloat;
            plane.Raycast(ray, out outFloat);

            return ray.GetPoint(outFloat);
        }
    }
}