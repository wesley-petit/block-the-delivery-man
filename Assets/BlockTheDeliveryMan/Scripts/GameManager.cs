using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Important edges")]
    [SerializeField] private EdgeGameEvent onMoveDelivery;
    [SerializeField] private EdgeGameEvent onSetupStart;
    
    [SerializeField] private Edge _start;
    [SerializeField] private Edge _end;

    [Header("Spawn Player")]
    [SerializeField] private AgentController _agentControllerPrefab;
    [SerializeField, Range(0f, 5f)] private float _spawnDelayInSeconds = 0.5f;

    private AgentController _player;
    [SerializeField] private CreateMap createMap;

    private void Start()
    {
        if( _start== null)
        {
            _start = createMap.Start.GetComponent<Edge>();
        }
        if (_end == null)
        {
            _end = createMap.End.GetComponent<Edge>();
        }
        onSetupStart.Raise(_start);
        onMoveDelivery.Raise(_end);
        
        StartCoroutine(SpawnPlayer_Coroutine());
    }


    
    private IEnumerator SpawnPlayer_Coroutine()
    {
        yield return new WaitForSeconds(_spawnDelayInSeconds);
        Debug.Log("_start.GetPosition: " + _start.GetPosition);
        _player = Instantiate(_agentControllerPrefab, _start.GetPosition, Quaternion.identity, transform);
        _player.name = "Player";
    }
}
