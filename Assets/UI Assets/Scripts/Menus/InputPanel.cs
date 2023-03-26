using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class InputPanel : MonoBehaviour
    {
        public InputField[] names;
        
        public void StartGame()
        {
            SetPlayerNames();
            if (IsValidInput())
            {
                SceneManager.LoadScene("Main Board game");
            }
        }
        
        private void SetPlayerNames()
        {
            
        }
        private bool IsValidInput()
        {
            return true;
        }
    }
}