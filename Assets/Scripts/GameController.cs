using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField, Header("Canvas Elements")]
    GameObject mainMenu;

    [SerializeField]
    InputField nameField;

    [SerializeField, Header("Objects References")]
    CentipedeManager _centipedeManager;

    [SerializeField]
    MushroomField field;

    [SerializeField]
    GameObject player;

    private string _playerName;

    public string PlayerName
    {
        get => _playerName;
        set => _playerName = value;
    }

    public int Score
    {
        get => score;
    }
    

    int score;

    void OnEnable()
    {
        GameEvents.GameOverEvent += PlayerTouched;
        GameEvents.IncreaseScore += SetScore;
        GameEvents.NextLevel += NextLevel;
    }

    void OnDestroy()
    {
        GameEvents.GameOverEvent -= PlayerTouched;
        GameEvents.IncreaseScore -= SetScore;
        GameEvents.NextLevel -= NextLevel;
    }

    public void Play()
    {
        player.SetActive(true);
        _centipedeManager.SpawnCentipedes();
        mainMenu.SetActive(false);
    }

    public void NextLevel()
    {
        _centipedeManager.UpdateDifficulty();
        field.UpdateDifficulty();

        _centipedeManager.SpawnCentipedes();
    }

    void PlayerTouched()
    {
        GameOver(score);
        
    }

    public void GameOver(int s)
    {
        player.SetActive(false);
    }

    public void SetScore(int i)
    {
        score += i;
    }

    public void OnRetryPressed()
    {
        // Don't bother resetting everything carefully, just reload!
        SceneManager.LoadScene(0);
    }
}