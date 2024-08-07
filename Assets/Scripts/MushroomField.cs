using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MushroomField : MonoBehaviour
{
    [SerializeField]
    Mushroom mushroom;

    [SerializeField]
    int mushroomsToSpawn;// to start with

    Rect fieldArea;
    const float maxSpawnRetries = 1;
    const int additionalMushroomsPerLevel = 5;

    int _numMushrooms;

    private List<GameObject> _mushrooms; 
    
    void Awake()
    {
        _numMushrooms = mushroomsToSpawn;
        GameEvents.CentipedeHitEvent += OnCentipedeHit;

        // define spawn area within viewport:
        var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.25f, Camera.main.nearClipPlane));
        var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.93f, Camera.main.nearClipPlane));
        fieldArea = new Rect(bottomLeft, topRight - bottomLeft);
    }

    void OnDestroy()
    {
        GameEvents.CentipedeHitEvent -= OnCentipedeHit;
    }

    public void SpawnMushrooms()
    {
        SpawnMushrooms(_numMushrooms);
    }

    void SpawnMushrooms(int number)
    {
        _mushrooms = new List<GameObject>();
        
        for (int i = 0; i < number; i++)
        {
            var position = GetRandomPositionWithoutOverlap();
            var obj = Instantiate(mushroom, position, Quaternion.identity, transform);
            _mushrooms.Add(obj.gameObject);
        }
    }

    Vector2 GetRandomPositionWithoutOverlap()
    {
        Vector2 randomPosition;
        bool isOverlap;
        int retries = 0;
        do
        {
            randomPosition = new Vector2( Random.Range(fieldArea.xMin, fieldArea.xMax - 5), Random.Range(fieldArea.yMin, fieldArea.yMax));
            isOverlap = Physics2D.OverlapCircle(randomPosition, 0.5f, Physics2D.AllLayers) != null;
            retries++;
        } while (isOverlap && retries < maxSpawnRetries);

        if (retries == maxSpawnRetries)
        {
            // we could keep trying, but it doesn't really matter!
        }

        return randomPosition;
    }

    public void UpdateDifficulty()
    {
        _numMushrooms += additionalMushroomsPerLevel;
        SpawnMushrooms(additionalMushroomsPerLevel);
    }
    
    void OnCentipedeHit(Vector3 pos)
    {
        var obj = Instantiate(mushroom, pos, Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    public void ResetMushrooms()
    {
        foreach (var mushroomObj in _mushrooms)
        {
            Destroy(mushroomObj);
        }
        
        _mushrooms.Clear();
    }
}