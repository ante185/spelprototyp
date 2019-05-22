using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    public List timeScore;
    private int score;
    private string HSname;
    private List<HighscoreEntry> highScoreEntryList;
    private List<HighscoreEntry> highScoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighscoreEntry>()
        {
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score},
            //new HighscoreEntry {name = HSname , score = score}

            new HighscoreEntry {name = "Tristan" , score = 100},
            new HighscoreEntry {name = "fgrgaer" , score = 123},
            new HighscoreEntry {name = "srzssef" , score = 148},
            new HighscoreEntry {name = "<segzsreg" , score = 457},
            new HighscoreEntry {name = "szefzsef" , score = 424},
            new HighscoreEntry {name = "szefsef" , score = 999},
            new HighscoreEntry {name = "zsefzsefs" , score = 773},
            new HighscoreEntry {name = "zsfszefsze" , score = 486},
            new HighscoreEntry {name = "zsefss" , score = 157},
            new HighscoreEntry {name = "szefsss" , score = 111},
        };

        //highScoreEntryTransformList = new List<Transform>();
        //highScoreEntryTransformList = new List<Transform>();
        //foreach (HighscoreEntry highscoreEntry in highScoreEntryList)
        //{
        //    CreateHighScoreEntryTransform(HighscoreEntry, entryContainer, highScoreEntryTransformList);
        //}

    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + ":"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        score = timeScore.timeScore;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        HSname = timeScore.name;
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
