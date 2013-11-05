// Samuel P. Tobey
// LvlSelect.cs

using UnityEngine;
using System.Collections;

public class LvlSelect : MonoBehaviour 
{
	public bool isQuit = false;
	public int LevelJump = 0;
	
	void OnMouseUp()
	{
		if (isQuit)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(LevelJump);
		}
	}
}
