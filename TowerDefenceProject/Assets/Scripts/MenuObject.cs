﻿using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour
{
	public bool isQuit = false;
	public int jumpToLevel = 0;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.blue;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseUp()
	{
		if(isQuit)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(jumpToLevel);
		}
	}
}
