using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField, Header("Objects References")] CentipedeManager centipedeManager;
    [SerializeField] private MushroomField field;
    [SerializeField] private PlayerMovementController player;

    private string _playerName;
    int _score;

    public string PlayerName
    {
        get => _playerName;
        set => _playerName = value;
    }

    public int Score
    {
        get => _score;
    }
    
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
        player.gameObject.SetActive(true);
        player.SetPlayerPositionToCenter();
        centipedeManager.SpawnCentipedes();
        field.SpawnMushrooms();
    }

    public void NextLevel()
    {
        centipedeManager.UpdateDifficulty();
        field.UpdateDifficulty();

        centipedeManager.SpawnCentipedes();
    }

    void PlayerTouched()
    {
        GameOver(_score);
    }

    public void GameOver(int s)
    {
        player.gameObject.SetActive(false);
    }

    public void SetScore(int i)
    {
        _score += i;
    }

    public void ResetGame()
    {
        centipedeManager.DeleteCentipede();
        field.ResetMushrooms();
    }
}