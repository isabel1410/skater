using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkateboards : MonoBehaviour
{
    [SerializeField] private GameObject _skateBoard;
    [SerializeField] private Vector3[] _spawns;

    private GameObject _canvas;

    private bool _spawn;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _spawn = true;
        StartCoroutine(CSpawnSkateboards());
    }

    private IEnumerator CSpawnSkateboards()
    {
        while (_spawn)
        {
            ShuffleSkateboards();
            GameObject _skateBoardA = SpawnSkateboard(_spawns[0]);
            yield return new WaitForSeconds(25f);
            Destroy(_skateBoardA);

            GameObject _skateBoardB = SpawnSkateboard(_spawns[1]);
            yield return new WaitForSeconds(25f);
            Destroy(_skateBoardB);

            GameObject _skateBoardC = SpawnSkateboard(_spawns[2]);
            yield return new WaitForSeconds(25f);
            Destroy(_skateBoardC);
        }
    }

    private void ShuffleSkateboards()
    {
        for (int positionOfArray = 0; positionOfArray < _spawns.Length; positionOfArray++)
        {
            Vector3 tra = _spawns[positionOfArray];
            int randomizeArray = Random.Range(0, positionOfArray);
            _spawns[positionOfArray] = _spawns[randomizeArray];
            _spawns[randomizeArray] = tra;
        }
    }

    private GameObject SpawnSkateboard(Vector3 position)
    {
        GameObject x = Instantiate(_skateBoard, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        x.transform.SetParent(_canvas.transform, false);
        return x;
    }
}
