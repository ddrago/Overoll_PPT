using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public PlayableDirector current;

    int index;

    private void Start()
    {
        index = -1;
        current = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Forward();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (current == null)
            {
                return;
            }
            else
            {
                Previous();
            }
        }
    }

    public void Forward()
    {
        current.gameObject.SetActive(false);
        index++;
        current = playableDirectors[index];
        current.Play();
    }

    public void Previous()
    {
        current.gameObject.SetActive(false);
        index--;
        current = playableDirectors[index];
        current.Play();
    }
}
