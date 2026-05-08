using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject TutorialPanel;
    public GameObject NextPatch;
    public Transform tutorial1, tutorial2, botonNext, botonPrev;
    public void GoMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void GoChoseLevelScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoVictoryScene()
    {
        SceneManager.LoadScene(3);
        PlayerPrefs.GetFloat("Score");
    }

    public void GoLoseScene()
    {
        SceneManager.LoadScene(4);
    }

    public void GoLevel1()
    {
        ScoreController.ResetScore();
        SceneManager.LoadScene(5);
    }

    public void ShowTutorial()
    {
        TutorialPanel.SetActive(!TutorialPanel.activeSelf);
    }
    public void ShowTutorialBtn2()
    {
        tutorial1.gameObject.SetActive(false);
        tutorial2.gameObject.SetActive(true);
        botonNext.gameObject.SetActive(false);
        botonPrev.gameObject.SetActive(true);
    }
    public void ShowTutorialBtn1()
    {
        tutorial1.gameObject.SetActive(true);
        tutorial2.gameObject.SetActive(false);
        botonNext.gameObject.SetActive(true);
        botonPrev.gameObject.SetActive(false);
    }

    public void ShowNextPatch()
    {
        NextPatch.SetActive(!NextPatch.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
