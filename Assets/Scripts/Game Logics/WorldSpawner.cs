using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldSpawner : MonoBehaviour
{
    private enum LastObstacleEndPosition
    {
        Bot,
        Mid,
        Top
    }
    
    //[SerializeField] private Grid baseGrid;
    [SerializeField] private GameObject[] botOpeningPrefabs;
    [SerializeField] private GameObject[] midOpeningPrefabs;
    [SerializeField] private GameObject[] topOpeningPrefabs;
    
    [SerializeField] private float spawnIntervals;

    private GameObject _currentObstacle;
    private LastObstacleEndPosition _currentObstacleEndPosition;
    private float _timer;

    private void Start()
    {
        InstantiateMidOpening();
    }

    void Update() {
        
        _timer += Time.deltaTime;

        if (_timer >= spawnIntervals) {
            switch (_currentObstacleEndPosition)
            {
                case LastObstacleEndPosition.Bot:
                    InstantiateBotOpening();
                    break;
                case LastObstacleEndPosition.Mid:
                    InstantiateMidOpening();
                    break;
                case LastObstacleEndPosition.Top:
                    InstantiateTopOpening();
                    break;
            }
            _timer = 0f;
        }
    }

    void InstantiateBotOpening()
    {
        _currentObstacle = Instantiate(botOpeningPrefabs[Random.Range(0, botOpeningPrefabs.Length)], transform);
        _currentObstacleEndPosition = (LastObstacleEndPosition)_currentObstacle.GetComponent<Obstacle>().getEndPosition();
    }
    void InstantiateMidOpening()
    {
        _currentObstacle = Instantiate(midOpeningPrefabs[Random.Range(0, midOpeningPrefabs.Length)], transform);
        _currentObstacleEndPosition = (LastObstacleEndPosition)_currentObstacle.GetComponent<Obstacle>().getEndPosition();
    }
    void InstantiateTopOpening()
    {
        _currentObstacle = Instantiate(topOpeningPrefabs[Random.Range(0, topOpeningPrefabs.Length)], transform);
        _currentObstacleEndPosition = (LastObstacleEndPosition)_currentObstacle.GetComponent<Obstacle>().getEndPosition();
    }
}

