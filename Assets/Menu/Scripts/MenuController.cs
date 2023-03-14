using Navigation.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Scripts
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnPlayClicked()
        {
            Navigator.Instance.Navigate(SceneEnum.MainGame);
        }
    }
}