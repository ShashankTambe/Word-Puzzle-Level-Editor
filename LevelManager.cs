using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public LevelData currentLevel;
    public WordDisplay wordDisplay;
    public Animator sceneAnimator;

    private void Start()
    {
        if (currentLevel != null)
        {
            wordDisplay.DisplayWords(currentLevel.words);
        }
    }

    public void OnWordSelected(string word)
    {
        if (currentLevel.correctWords.Contains(word))
        {
            Debug.Log($"Correct: {word}");

            // Check if all correct words are selected
            if (currentLevel.correctWords.All(w => wordDisplay.SelectedWords.Contains(w)))
            {
                TriggerAction();
            }
        }
        else
        {
            Debug.Log($"Incorrect: {word}");
        }
    }

    private void TriggerAction()
    {
        Debug.Log("Action Triggered!");
        if (sceneAnimator != null && currentLevel.actionAnimation != null)
        {
            sceneAnimator.Play(currentLevel.actionAnimation.name);
        }
    }
}
