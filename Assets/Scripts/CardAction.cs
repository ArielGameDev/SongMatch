using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{

    public AudioClip _clip;

    public AudioSource _source;

    public CardSpawner _spawner;

    private void OnMouseDown()
    {
        if(_source.clip != null && _source.clip.name.Split('_')[0] == _clip.name.Split('_')[0] && _source.clip.name!= _clip.name){
            Destroy(transform.gameObject);
            Destroy(_spawner._lastPick);
        }

        _source.Stop();
        _source.clip = _clip;
        _source.Play();

        _spawner._lastPick = transform.gameObject;
    }


}
