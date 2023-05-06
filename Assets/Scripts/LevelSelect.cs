using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] closedLevel;
	public GameObject[] noCompleteLevel;
	public GameObject[] closedStars;

    void Start()
    {
		int level = PlayerPrefs.GetInt("level");
		for (int i = 0; i < level; i++)
		{
			closedLevel[i].SetActive(false);
			noCompleteLevel[i].SetActive(false);
			closedStars[i].SetActive(false);
			PlayerPrefs.SetInt("Stars", i * 3);
			if (level - i == 1)
            {
				noCompleteLevel[i].SetActive(true);
				closedStars[i].SetActive(true);
			}
		}
	}

	public void LoadTo(int indx)
    {
		SceneManager.LoadScene(indx);
    }

	public void ExitScene(int x)
    {
		int level = PlayerPrefs.GetInt("level", x);
		if (level < x)
		{
			PlayerPrefs.SetInt("level", x);
		}
		SceneManager.LoadScene("Menu");
	}

    public void DeleteSave()
    {
		PlayerPrefs.SetInt("level", 1);
		PlayerPrefs.SetInt("Stars", 0);
	}
}