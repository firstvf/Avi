using Assets.Src.Code.Controllers;
using UnityEngine;

namespace Assets.Src.Code.Rope
{
    public class Rope : MonoBehaviour
    {
        [SerializeField] private Knot[] _knot;
        [SerializeField] private SpriteRenderer _ropeSprite;
        public int CollideCounter { get; private set; }

        private void Start()
        {
            for (int i = 0; i < _knot.Length; i++)
                _knot[i].AddRopeToList(this);

            RopeController.Instance.OnRopeEndDragHandler += OnEndDragRopeAction;
            StretchRope();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Rope rope))
                CollideCounter++;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Rope rope))
                CollideCounter--;
        }

        private void OnEndDragRopeAction()
        {
            if (CollideCounter == 0)
                _ropeSprite.sprite = RopeController.Instance.GreenRope;
            else _ropeSprite.sprite = RopeController.Instance.RedRope;
        }

        public void StretchRope()
        {
            float distance = Vector2.Distance(_knot[0].transform.position, _knot[1].transform.position) * 1.1f;
            transform.localScale = new Vector3(distance, transform.localScale.y, transform.localScale.z);

            Vector2 direction = _knot[1].transform.position - _knot[0].transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation((_knot[0].transform.position + _knot[1].transform.position) / 2, Quaternion.Euler(0, 0, angle));
        }

        private void OnDestroy()
        {
            RopeController.Instance.OnRopeEndDragHandler -= OnEndDragRopeAction;
        }
    }
}