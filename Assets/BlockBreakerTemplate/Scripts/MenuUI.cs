using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour 
{
	//Called when the play button is pressed
	public void PlayButton ()
	{
        SceneManager.LoadScene(1);  //Loads the 'Game' scene to begin the game
    }

	//Called when the quit button is pressed
	public void QuitButton ()
	{
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
    }
}
