using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private string _modalOpenTrigger = "Open";
        [SerializeField] private string _modalCloseTrigger = "Close";

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void CloseGame()
        {
            Application.Quit();
        }

        public void OpenModalWindow(Animator modalWindowAnimator)
        {
            modalWindowAnimator.SetTrigger(_modalOpenTrigger);
        }

        public void CloseModalWindow(Animator modalWindowAnimator)
        {
            modalWindowAnimator.SetTrigger(_modalCloseTrigger);
        }
    }
}
