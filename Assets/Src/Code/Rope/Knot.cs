using Assets.Src.Code.Controllers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Src.Code.Rope
{
    public class Knot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _shadow;
        private readonly List<Rope> _ropeList = new();

        public void AddRopeToList(Rope rope)
        => _ropeList.Add(rope);

        public void OnBeginDrag(PointerEventData eventData)
        => SoundController.Instance.StretchSound();

        public void OnEndDrag(PointerEventData eventData)
        => RopeController.Instance.OnRopeEndDragHandler?.Invoke();

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.pointerCurrentRaycast.worldPosition;

            foreach (var rope in _ropeList)
                rope.StretchRope();
        }

        public void OnPointerDown(PointerEventData eventData)
        => SoundController.Instance.ClickSound();

        public void OnPointerEnter(PointerEventData eventData)
        => _shadow.SetActive(true);

        public void OnPointerExit(PointerEventData eventData)
        => _shadow.SetActive(false);
    }
}