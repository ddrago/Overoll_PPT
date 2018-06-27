using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public PlayableDirector current;

    public GameObject charc;
    public GameObject worker;

    public int index;

    private void Start()
    {
        index = -1;

        charc.SetActive(true);
        worker.SetActive(false);

        foreach (PlayableDirector p in playableDirectors)
        {
            p.gameObject.SetActive(false);
        }
  
        current = null;
    }

    private void Update()
    {
        if (index == 5)
        {
            worker.SetActive(true);
            Debug.Log("hello");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (current == null)
            {
                index++;
                current = playableDirectors[index];
                current.gameObject.SetActive(true);
                current.Play();
            }
            else
            {
                charc.gameObject.SetActive(false);
                Forward();
            }
        }
    }

    public void Forward()
    {
        current.gameObject.SetActive(false);
        index++;
        current = playableDirectors[index];
        current.gameObject.SetActive(true);
        current.Play();
    }

    public void Previous()
    {
        current.gameObject.SetActive(false);
        index--;
        current = playableDirectors[index];
        current.gameObject.SetActive(true);
        current.Play();
    }
}
