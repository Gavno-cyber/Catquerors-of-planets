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

    public void OpenScene_1()
    {
	SceneManager.LoadScene("Level_1");
    }


    public void OpenScene_2()
    {
	SceneManager.LoadScene("Level_2");
    }


    public void OpenScene_3()
    {
	SceneManager.LoadScene("Level_3");
    }


    public void OpenScene_4()
    {
	SceneManager.LoadScene("Level_4");
    }

    public void ExitScene_1()
    {
	if (level < 2)
	{
	    level = 2;
	    PlayerPrefs.SetInt("level", level);
	}
	SceneManager.LoadScene("Menu");
    }

    public void ExitScene_2()
    {
	if (level < 3)
	{
	    level = 3;
	    PlayerPrefs.SetInt("level", level);
	}
	SceneManager.LoadScene("Menu");
    }

    public void ExitScene_3()
    {
	if (level < 4)
	{
	    level = 4;
	    PlayerPrefs.SetInt("level", level);
	}
	SceneManager.LoadScene("Menu");
    }

    public void ExitScene_4()
    {
	if (level < 5)
	{
	    level = 5;
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
