using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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


    public AudioMixer audioMixer;
    public void UpdateVolume (float volume)
    {
        Options.SetVolume(volumeSlider.value);
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
}
