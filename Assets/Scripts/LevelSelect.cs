using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int level = 1;
    public GameObject[] closedLevel;
	public GameObject[] noCompleteLevel;

    void Start()
    {
		level = PlayerPrefs.GetInt("level", level);
		for (int i = 0; i < level; i++)
		{
			closedLevel[i].SetActive(false);
			noCompleteLevel[i].SetActive(false);
			if (level - i == 1)
            {
				noCompleteLevel[i].SetActive(true);
            }
		}
    }

	public void LoadTo(int level)
    {
		SceneManager.LoadScene(level);
    }

	public void ExitScene(int x)
    {
		if (level < x)
		{
			level = x;
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