using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] private GameObject wordButtonPrefab;
    [SerializeField] private Transform container;

    public List<string> SelectedWords { get; private set; } = new List<string>();

    public void DisplayWords(string[] words)
    {

        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }


        foreach (string word in words)
        {
            GameObject button = Instantiate(wordButtonPrefab, container);
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = word; 
            }
            else
            {
                Debug.LogError("Word Button Prefab is missing a TMP_Text component!");
            }

            Button buttonComponent = button.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => OnWordClicked(word));
            }
        }
    }

    private void OnWordClicked(string word)
    {
        if (!SelectedWords.Contains(word))
        {
            SelectedWords.Add(word); 
            Debug.Log($"Word Selected: {word}");
        }
    }

    public void ResetSelection()
    {
        SelectedWords.Clear(); 
    }
}
