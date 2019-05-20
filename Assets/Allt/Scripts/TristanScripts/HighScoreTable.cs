using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreEntryContainer : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    public List timeScore;
    private int score;
    private string HSname;

    private void Awake() {

       
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;
        score = timeScore.timeScore;
        HSname = timeScore.name;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + ":"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;


        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        entryTransform.Find("NameText").GetComponent<Text>().text = HSname;

        transformList.Add(entryTransform);
    }

    /*
     Representerar bara en highscore Entry
     */
     private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
