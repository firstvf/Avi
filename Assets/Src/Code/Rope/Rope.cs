using UnityEngine;
using UnityEngine.UI;

namespace Assets.Src.Code.Rope
{
    public class Rope : MonoBehaviour
    {
        [SerializeField] private Sprite _greenRope, _redRope;
        [SerializeField] private Knot[] _knot;
        private Image _ropeImage;

        private void Awake()
        {
            _ropeImage = GetComponent<Image>();
        }

        private void Start()
        {
            StretchRope();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision);
        }

        public void StretchRope()
        {
            Debug.Log("stretch");
            float distance = Vector2.Distance(_knot[0].transform.position, _knot[1].transform.position) / 100;

            transform.localScale = new Vector3(distance, transform.localScale.y, transform.localScale.z);

            Vector2 direction = _knot[1].transform.position - _knot[0].transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation((_knot[0].transform.position + _knot[1].transform.position) / 2, Quaternion.Euler(0, 0, angle));
        }
    }
}