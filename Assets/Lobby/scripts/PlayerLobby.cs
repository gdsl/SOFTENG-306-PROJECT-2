﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.EventSystems;

public class PlayerLobby : NetworkLobbyPlayer
{
	public Canvas playerCanvasPrefab;

	public Canvas playerCanvas;

	// cached components
	ColorControl cc;
	NetworkLobbyPlayer lobbyPlayer;

	void Awake()
	{
		cc = GetComponent<ColorControl>();
		lobbyPlayer = GetComponent<NetworkLobbyPlayer>();
	}

	public override void OnClientEnterLobby()
	{
		if (playerCanvas == null)
		{
			playerCanvas = (Canvas)Instantiate(playerCanvasPrefab, Vector3.zero, Quaternion.identity);
			playerCanvas.sortingOrder = 1;
		}

		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks>();
		int height = 100;

		if (slot > 3) {
			height = -120;
		}

		hooks.panelPos.localPosition = new Vector3(GetPlayerPos(lobbyPlayer.slot), height, 0);
		hooks.SetColor(cc.myColor);
		hooks.SetReady(lobbyPlayer.readyToBegin);

		//EventSystem.current.SetSelectedGameObject(hooks.colorButton.gameObject);
	}

	public override void OnClientExitLobby()
	{
		if (playerCanvas != null)
		{
			Destroy(playerCanvas.gameObject);
		}
	}

	public override void OnClientReady(bool readyState)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks>();
		hooks.SetReady(readyState);
	}

	float GetPlayerPos(int slot)
	{
		var lobby = NetworkManager.singleton as GuiLobbyManager;
		if (lobby == null)
		{
			// no lobby?
			return slot * 200;
		}

		// this spreads the player canvas panels out across the screen
		var screenWidth = playerCanvas.pixelRect.width;
		screenWidth -= 200; // border padding
	//	var playerWidth = screenWidth / (lobby.maxPlayers-1);
		var playerWidth = 150;
	//	Debug.LogError ("slot" + slot);
		return -(screenWidth / 4) + 150 + (slot%4) * playerWidth;
	}

	public override void OnStartLocalPlayer()
	{
		if (playerCanvas == null)
		{
			playerCanvas = (Canvas)Instantiate(playerCanvasPrefab, Vector3.zero, Quaternion.identity);
			playerCanvas.sortingOrder = 1;
		}

		// setup button hooks
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks>();
		int height = 100;

		if (slot > 3) {
			height = -120;
		}

		hooks.panelPos.localPosition = new Vector3(GetPlayerPos(lobbyPlayer.slot), height, 0);
		hooks.SetColor(cc.myColor);

		hooks.OnColorChangeHook = OnGUIColorChange;
		hooks.OnReadyHook = OnGUIReady;
		hooks.OnRemoveHook = OnGUIRemove;
		hooks.SetLocalPlayer();
	}

	void OnDestroy()
	{
		if (playerCanvas != null)
		{
			Destroy(playerCanvas.gameObject);
		}
	}

	public void SetColor(Color color)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks>();
		hooks.SetColor(color);
	}

	public void SetReady(bool ready)
	{
		var hooks = playerCanvas.GetComponent<PlayerCanvasHooks>();
		hooks.SetReady(ready);
	}

	[Command]
	public void CmdExitToLobby()
	{
		var lobby = NetworkManager.singleton as GuiLobbyManager;
		if (lobby != null)
		{
			lobby.ServerReturnToLobby();
		}
	}

	// events from UI system

	void OnGUIColorChange()
	{
		if (isLocalPlayer)
			cc.ClientChangeColor();
	}

	void OnGUIReady()
	{
		if (isLocalPlayer)
			lobbyPlayer.SendReadyToBeginMessage();
	}

	void OnGUIRemove()
	{
		if (isLocalPlayer)
		{
			ClientScene.RemovePlayer(lobbyPlayer.playerControllerId);

			var lobby = NetworkManager.singleton as GuiLobbyManager;
			if (lobby != null)
			{
				lobby.SetFocusToAddPlayerButton();
			}
		}
	}
}

