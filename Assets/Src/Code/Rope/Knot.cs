using Assets.Src.Code.Controllers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Src.Code.Rope
{
    public class Knot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private GameObject _shadow;
        private readonly List<Rope> _ropeList = new();

        public void AddRopeToList(Rope rope)
        {
            _ropeList.Add(rope);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _shadow.gameObject.SetActive(true);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _shadow.gameObject.SetActive(false);
            RopeController.Instance.OnRopeEndDragHandler?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.pointerCurrentRaycast.worldPosition;

            foreach (var rope in _ropeList)
                rope.StretchRope();
        }
    }
}