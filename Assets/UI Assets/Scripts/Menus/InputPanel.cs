using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class InputPanel : MonoBehaviour
    {
        public InputField[] nameInputs;
        public Player3DController[] playerShips;

        public void StartGame()
        {
            if (InvalidInput())
                return;

            SetPlayerNames();
            SceneManager.LoadScene("Main Board game");
        }


        private bool InvalidInput()
        {
            return IsAnyInputEmpty() || HasSameNames();
        }

        private bool IsAnyInputEmpty()
        {
            return nameInputs.Any(inputField => string.IsNullOrEmpty(inputField.text));
        }

        private bool HasSameNames()
        {
            var nameSet = new HashSet<string>();
            foreach (var nameInput in nameInputs)
                nameSet.Add(nameInput.text.ToLower());

            var numOfPlayers = nameInputs.Length;
            return nameSet.Count < numOfPlayers; // if there are duplicate names will return true
        }

        private void SetPlayerNames()
        {
            for (int i = 0; i < BoardStateHolder.Instance.playerBoardStates.Length; i++)
                BoardStateHolder.Instance.playerBoardStates[i].playerName =
                    nameInputs[i].text;
        }
        
        
        
        private void OnEnable()
        {
            foreach (var ship in playerShips)
                ship.ShowSpaceShip();
        }
        private void OnDisable()
        {
            foreach (var ship in playerShips)
                ship.DisableSpaceShip();
        }
    }
}