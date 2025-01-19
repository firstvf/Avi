using UnityEngine;

namespace Assets.Src.Code.Controllers
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Instance { get; private set; }
        public int Score { get; private set; }
        //public List<Rope.Rope> _ropeList

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }


    }
}