using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    GameObject _cardPrefab;

    [SerializeField]
    float _rows, _colums, _rowSpacing, _columnSpacing;

    void Start()
    {
        float totalCards = _rows * _colums;

        Vector3 currSpawnPos = new Vector3(-_columnSpacing * _colums / 2f - _columnSpacing, _rowSpacing * _rows / 2f, 0);

        Vector3 offset = _target.position + new Vector3(_columnSpacing/2f, -_rowSpacing/2f, 0);

        for (int index = 0; index < totalCards; index++)
        {
            currSpawnPos.x += _columnSpacing;

            if (currSpawnPos.x >= _columnSpacing * _colums / 2f)
            {
                currSpawnPos.x = -_columnSpacing * _colums / 2f;
                currSpawnPos.y -= _rowSpacing;
            }

            Instantiate(_cardPrefab, currSpawnPos + offset, _cardPrefab.transform.rotation);
        }
    }

}