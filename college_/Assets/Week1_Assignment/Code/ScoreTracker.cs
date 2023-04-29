using System;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreValue;
    
    private int score;
    
    private void Start()
    {
        _scoreValue.text = String.Format("{0}", score);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            score++;
            _scoreValue.text = String.Format("{0}", score);
        }
    }
}
