using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Src.Code.Rope
{
    public class Knot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private GameObject _shadow;
        [SerializeField] private Rope _rope;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _shadow.gameObject.SetActive(true);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _shadow.gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
            _rope.StretchRope();
        }
    }
}