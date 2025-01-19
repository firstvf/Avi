using System;
using UnityEngine;

namespace Assets.Src.Code.Controllers
{
    public class RopeController : MonoBehaviour
    {
        public static RopeController Instance { get; private set; }
        public Action OnRopeEndDragHandler { get; set; }

        [field: SerializeField] public Sprite RedRope { get; private set; }
        [field: SerializeField] public Sprite GreenRope { get; private set; }        

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            FakeStart();
            Invoke(nameof(FakeStart), 0.05f);
        }

        private void FakeStart()
        => OnRopeEndDragHandler?.Invoke();
    }
}