// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class WordDisplay : MonoBehaviour
// {
//     public Button wordButtonPrefab;
//     public Transform wordContainer;

//     public List<string> SelectedWords { get; private set; } = new List<string>();

//     public void DisplayWords(string[] words)
//     {
//         foreach (Transform child in wordContainer)
//         {
//             Destroy(child.gameObject);
//         }

//         foreach (string word in words)
//         {
//             Button btn = Instantiate(wordButtonPrefab, wordContainer);
//             btn.GetComponentInChildren<Text>().text = word;
//             btn.onClick.AddListener(() => OnWordClicked(word));
//         }
//     }

//     private void OnWordClicked(string word)
//     {
//         SelectedWords.Add(word);
//         Debug.Log($"Word Selected: {word}");
//     }
// }
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class WordDisplay : MonoBehaviour
// {
//     [SerializeField] private GameObject wordButtonPrefab;
//     [SerializeField] private Transform container;

//     public void DisplayWords(string[] words)
//     {
//         // Clear existing buttons
//         foreach (Transform child in container)
//         {
//             Destroy(child.gameObject);
//         }

//         // Create a button for each word
//         foreach (string word in words)
//         {
//             GameObject button = Instantiate(wordButtonPrefab, container);
//             TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
//             if (buttonText != null)
//             {
//                 buttonText.text = word; // Set the button text
//             }
//             else
//             {
//                 Debug.LogError("Word Button Prefab is missing a TMP_Text component!");
//             }

//             // Add functionality to button click
//             Button buttonComponent = button.GetComponent<Button>();
//             if (buttonComponent != null)
//             {
//                 buttonComponent.onClick.AddListener(() => OnWordSelected(word));
//             }
//         }
//     }

//     private void OnWordSelected(string selectedWord)
//     {
//         Debug.Log($"Word selected: {selectedWord}");
//         // Handle word selection logic here
//     }
// }
using System.Collections.Generic;
using TMPro; // Ensure you're using TextMeshPro namespace
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] private GameObject wordButtonPrefab;
    [SerializeField] private Transform container;

    public List<string> SelectedWords { get; private set; } = new List<string>();

    public void DisplayWords(string[] words)
    {
        // Clear existing buttons
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // Create a button for each word
        foreach (string word in words)
        {
            GameObject button = Instantiate(wordButtonPrefab, container);
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = word; // Set the button text
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
            SelectedWords.Add(word); // Track selected words
            Debug.Log($"Word Selected: {word}");
        }
    }

    public void ResetSelection()
    {
        SelectedWords.Clear(); // Clear selection when needed
    }
}
