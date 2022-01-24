using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public void quit()
	{
        
        UnityEditor.EditorApplication.isPlaying = false;
		Debug.Log("has quit game");
		Application.Quit();
	}
}