using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void ChangeScene(string Main)
	{
		SceneManager.LoadScene(Main);
	}
	public void Exit()
	{
		var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
		activity.Call("finish");
		Application.Quit();
	}
}