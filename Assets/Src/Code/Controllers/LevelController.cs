using Assets.Src.Code.Ropes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Src.Code.Controllers
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Instance { get; private set; }
        public Action OnLevelEndHandler { get; set; }
        public int Score { get; private set; }

        private readonly List<Rope> _ropeList = new();
        private bool _isLevelComplete;

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
            RopeController.Instance.OnRopeEndDragHandler += EndLevel;
        }

        public void AddRopeToList(Rope rope) => _ropeList.Add(rope);

        private bool CheckIsAnyRopeCollide()
        {
            for (int i = 0; i < _ropeList.Count; i++)
                if (_ropeList[i].CollideCounter > 0)
                    return false;

            return true;
        }

        private void EndLevel()
        {
            Invoke(nameof(DelayEndLevelLogic), 0.1f);
        }

        private void DelayEndLevelLogic()
        {
            if (!_isLevelComplete && CheckIsAnyRopeCollide())
            {
                _isLevelComplete = true;
                Score += 350;
                OnLevelEndHandler?.Invoke();
            }
        }

        private void OnDestroy()
        {
            RopeController.Instance.OnRopeEndDragHandler -= EndLevel;
        }
    }
}