using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text accumulatedScoreText;

    private void Start ()
    {
        volumeSlider.value = Options.Volume;

        var score = UserData.Current.AccumulatedScore;
        accumulatedScoreText.text = score.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void UpdateVolume ()
    {
        Options.SetVolume(volumeSlider.value);
    }
}
