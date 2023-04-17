using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DetectOffensive : MonoBehaviour
{
    // Dictionary of offensive words and their scores
    private readonly Dictionary<string, float> _offensiveWords = new Dictionary<string, float>()
    {
    { "fuck", 0.9f },
    { "shit", 0.8f },
    { "cunt", 0.95f },
    { "asshole", 0.7f },
    { "bitch", 0.6f },
    { "dick", 0.8f },
    { "pussy", 0.9f },
    { "fag", 0.7f },
    { "slut", 0.85f },
    { "whore", 0.9f },
    { "bastard", 0.5f },
    { "retard", 0.7f },
    { "nigger", 0.95f },
    { "chink", 0.8f },
    { "spic", 0.8f },
    { "kike", 0.9f }
        // add more offensive words and scores as needed
    };
    
    // The regular expression used to remove non-alphanumeric characters from the input text
    private const string NonAlphanumericRegex = @"[^a-zA-Z0-9\s]";
    
    public bool DetectOffensiveLanguage(string message)
    {
        // Preprocess the input text by removing non-alphanumeric characters
        string processedMessage = Regex.Replace(message, NonAlphanumericRegex, "");
        
        // Split the processed message into individual words
        string[] words = processedMessage.Split(' ');
        
        float totalScore = 0f;
        
        // Iterate through each word in the message and calculate its offensive score
        foreach (string word in words)
        {
            if (_offensiveWords.TryGetValue(word.ToLower(), out float score))
            {
                totalScore += score;
            }
        }
        
        // Determine if the message is offensive based on the total score
        bool isOffensive = totalScore >= 0.5f;
        
        return isOffensive;
    }
}
