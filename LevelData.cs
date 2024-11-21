using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "PuzzleGame/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string[] words;
    public string[] correctWords;
    public AnimationClip actionAnimation;
}
