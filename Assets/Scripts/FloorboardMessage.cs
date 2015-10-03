﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface FloorboardMessage : IEventSystemHandler
{
	//function to be called on game objects that receive this message
	void receiveFloorboardMessage();
}
