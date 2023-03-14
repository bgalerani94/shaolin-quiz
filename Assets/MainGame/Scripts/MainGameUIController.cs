using Navigation.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame.Scripts
{
    public class MainGameUIController : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        private void Awake()
        {
            backButton.onClick.AddListener(GoToMainMenu);
        }

        private void GoToMainMenu()
        {
            Navigator.Instance.Navigate(SceneEnum.Menu);
        }
    }
}