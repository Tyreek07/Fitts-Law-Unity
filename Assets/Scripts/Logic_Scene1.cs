using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Logic_Scene1 : MonoBehaviour
{
    public TextMeshProUGUI TMP_zaehler;
    public TextMeshProUGUI TMP_timer;
    public TextMeshProUGUI TMP_schwierigkeit;
    public TextMeshProUGUI TMP_anweisung;
    public GameObject cubeButtonUI_1;
    public GameObject cubeButtonUI_2;
    public GameObject cubeButtonUI_3;
    public GameObject cubeButtonUI_4;
    public GameObject cubeButtonUI_5;
    public GameObject cubeButtonUI_6;
    public GameObject startButton;

    double timeStart;
    int counter = 0;
    bool beginTimer = false;

    public string filename;
    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/FittsLaw_Log/");

    }

    // Update is called once per frame
    void Update()
    {
        if (beginTimer)
        {
            if (counter < 15)
            {
                timeStart += Time.deltaTime;
                TMP_timer.text = "Timer: " + timeStart.ToString("F2");
            }
            else
            {
                cubeButtonUI_5.SetActive(false);
                cubeButtonUI_6.SetActive(false);
                TMP_anweisung.text = "Task 1 beendet, lade Task 2";
            }
        }
    }

    public void StartTimer()
    {
        beginTimer = true;
    }
    public void CountOne()
    {
        counter++;
        TMP_zaehler.text = "Zähler: " + counter.ToString();
    }
    public void RemoveComponent()
    {
        if (counter == 5)
        {
            CreateTextFile("Schwierigkeitsgrad: 1");
            TMP_schwierigkeit.text = "Schwierigkeitsgrad: 2";
            cubeButtonUI_1.SetActive(false);
            cubeButtonUI_2.SetActive(false);
            cubeButtonUI_4.SetActive(true);
        }
        else if (counter == 10)
        {
            CreateTextFile("Schwierigkeitsgrad: 2");
            TMP_schwierigkeit.text = "Schwierigkeitsgrad: 3";
            cubeButtonUI_3.SetActive(false);
            cubeButtonUI_4.SetActive(false);
            cubeButtonUI_6.SetActive(true);
        }
        else if (counter == 15)
        {
            CreateTextFile("Schwierigkeitsgrad: 3");
            cubeButtonUI_5.SetActive(false);
            cubeButtonUI_6.SetActive(false);
            beginTimer = false;

            if (SceneManager.GetSceneByBuildIndex(0) == SceneManager.GetActiveScene())
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void CreateTextFile(String schwierigkeitsgrad)
    {
        filename = GiveFileName.filename;
        string path = Application.streamingAssetsPath + "/FittsLaw_Log/" + filename + ".txt";
       
        if (SceneManager.GetSceneByBuildIndex(0) == SceneManager.GetActiveScene())
        {
            File.AppendAllText(path, "Rechte Hand\n");
        } else if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene())
        {
            File.AppendAllText(path, "Linke Hand\n");
        }
        File.AppendAllText(path, schwierigkeitsgrad + " Sekunden: " + Math.Round(timeStart, 4) + " Millisekunden: " + (Math.Round(timeStart, 2) * 1000) + "\n");
    }
}
