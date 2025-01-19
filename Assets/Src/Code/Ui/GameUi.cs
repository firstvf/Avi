using Assets.Src.Code.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Src.Code.Ui
{
    public class GameUi : MonoBehaviour
    {
        [SerializeField] private Canvas _uiCanvas;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Image _disableInputScreen;
        [SerializeField] private Image _completeLevelScreen;
        [SerializeField] private Image _gameScreen;
        [SerializeField] private Image _endLevelScreen;
        [SerializeField] private Button _fullSkipButton;
        [SerializeField] private Button _skipButton;
        [SerializeField] private Text _winText;

        private void Awake()
        {
            _scoreText.text = 0.ToString();
            _fullSkipButton.onClick.AddListener(FullSkipLevel);
            _skipButton.onClick.AddListener(SkipLevel);
        }

        private void Start()
        {
            LevelController.Instance.OnLevelEndHandler += EndLevelAction;
        }

        private void EndLevelAction()
        {
            Dispose();
            ChangeScoreText();
            SoundController.Instance.WinSound(0.4f);
            _disableInputScreen.gameObject.SetActive(true);
            _endLevelScreen.gameObject.SetActive(true);
        }

        private void FullSkipLevel()
        {
            Dispose();
            _endLevelScreen.gameObject.SetActive(true);
            CommonSettings();
        }

        private void SkipLevel()
        {
            _completeLevelScreen.gameObject.SetActive(true);
            _winText.gameObject.SetActive(true);
            _winText.DOFade(1, 1.5f);
            CommonSettings();
        }

        private void CommonSettings()
        {
            _disableInputScreen.gameObject.SetActive(true);
            _gameScreen.gameObject.SetActive(false);
            RopeController.Instance.OnRopeEndDragHandler?.Invoke();

            Invoke(nameof(DisableCompleteLevelUi), 3f);
        }

        private void DisableCompleteLevelUi() => _completeLevelScreen.gameObject.SetActive(false);

        private void ChangeScoreText()
        => _scoreText.DOText(LevelController.Instance.Score.ToString(), 1f, scrambleMode: ScrambleMode.Numerals);

        private void Dispose()
        {
            LevelController.Instance.OnLevelEndHandler -= EndLevelAction;
            _fullSkipButton.onClick.RemoveAllListeners();
            _skipButton.onClick.RemoveAllListeners();
        }
    }
}