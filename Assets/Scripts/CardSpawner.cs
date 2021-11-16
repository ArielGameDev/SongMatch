using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> _clips;

    [SerializeField]
    AudioSource _source;

    [SerializeField]
    Transform _target;

    [SerializeField]
    GameObject _cardPrefab;

    [SerializeField]
    float _rows, _colums, _rowSpacing, _columnSpacing;


    public GameObject _lastPick;


    void Start()
    {
        _clips.Shuffle();

        IEnumerator clipEnum = _clips.GetEnumerator();

        float totalCards = _rows * _colums;

        Vector3 currSpawnPos = new Vector3(-_columnSpacing * _colums / 2f - _columnSpacing, _rowSpacing * _rows / 2f, 0);

        Vector3 offset = _target.position + new Vector3(_columnSpacing / 2f, -_rowSpacing / 2f, 0);

        for (int index = 0; index < totalCards; index++)
        {
            currSpawnPos.x += _columnSpacing;

            if (currSpawnPos.x >= _columnSpacing * _colums / 2f)
            {
                currSpawnPos.x = -_columnSpacing * _colums / 2f;
                currSpawnPos.y -= _rowSpacing;
            }

            GameObject newGo = Instantiate(_cardPrefab, currSpawnPos + offset, _cardPrefab.transform.rotation);

            clipEnum.MoveNext();
            newGo.GetComponent<CardAction>()._clip = (AudioClip)clipEnum.Current;
            newGo.GetComponent<CardAction>()._source = _source;
            newGo.GetComponent<CardAction>()._spawner = this;

        }
    }


}

public static class ListExtension{
    
    private static System.Random rng = new System.Random();  

    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}