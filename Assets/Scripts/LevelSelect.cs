using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int level = 1;
    public GameObject[] closedLevel;

    void Start()
    {
		level = PlayerPrefs.GetInt("level", level);
		for (int i = 0; i < level; i++)
		{
			closedLevel[i].SetActive(false);
		}
    }

	public void OpenScene(string SceneName)
    {
		SceneManager.LoadScene(SceneName);
    }

	public void ExitScene()
    {
		if (level < level++)
		{
			level = level++;
			PlayerPrefs.SetInt("level", level);
		}
		SceneManager.LoadScene("Menu");
	}

    public void DeleteSave()
    {
		level = 1;
		PlayerPrefs.SetInt("level", level);
    }
}