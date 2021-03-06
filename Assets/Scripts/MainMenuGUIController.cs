﻿namespace Assets.Scripts
{
	using UnityEngine;

	public class MainMenuGUIController : MonoBehaviour {

		public void StartSinglePlayer()
		{
			NetworkController.Instance.StartSinglePlayer();
		}

		public void HostGame()
		{
			NetworkController.Instance.HostGame();
		}

		public void JoinGame()
		{
			NetworkController.Instance.JoinGame();
		}

		public void StartGame()
		{
			NetworkController.Instance.StartGame();
		}

		public void ExitGame()
		{
			Application.Quit();
		}
	}
}
