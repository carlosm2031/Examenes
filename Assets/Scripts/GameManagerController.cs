using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManagerController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;

    public TMP_Text bronzeText;
    public TMP_Text silverText;
    public TMP_Text goldText;

    private int score;
    private int lives;
    //Coins
    private int bronzeCoin;
    private int silverCoin;
    private int goldCoin;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        lives = 3;
        bronzeCoin = 0;
        silverCoin = 0;
        goldCoin = 0;
        PrintScoreInScreen();
        PrintLivesInScreen();
        LoadGame();
    }

    //Metodo para Data del juego
    public void SaveGame()
    {
        var filePath = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);
        }

        GameData data = new GameData();
        data.Score = score;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadGame()
    {
        var filePath = Application.persistentDataPath + "/save.dat";
        FileStream file;
        if (File.Exists(filePath))
        {
            file = File.OpenRead(filePath);
        }
        else
        {
            Debug.LogError("No se encontro archivo");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();
        score = data.Score;
        PrintScoreInScreen();
    }
    //hasta aqui el codigo
    public int Score()
    {
        return score;
    }
    public int Lives()
    {
        return lives;
    }

    public void GanarPuntos(int puntos)
    {
        score+=puntos;
        PrintScoreInScreen();
    }

    public void PerderVidas()
    {
        lives -=1;
        PrintScoreInScreen();
    }

    private void PrintScoreInScreen()
    {
        scoreText.text = "Puntaje: " + score;
    }

    private void PrintLivesInScreen()
    {
        livesText.text = "Vidas: " + lives;
    }

    //bronze coin
    public int bronzeC()
    {
        return bronzeCoin;
    }

    public void GanarBronze(int puntos)
    {
        bronzeCoin += puntos;
        PrintBronzeInScreen();
    }

    private void PrintBronzeInScreen()
    {
        bronzeText.text = "Bronze " + bronzeCoin;
    }
    //silver
    public int silverC()
    {
        return silverCoin;
    }

    public void GanarSilver(int puntos)
    {
        silverCoin += puntos;
        PrintSilverInScreen();
    }

    private void PrintSilverInScreen()
    {
        silverText.text = "Silver: " + silverCoin;
    }
    //gold
    public int goldC()
    {
        return goldCoin;
    }

    public void GanarGold(int puntos)
    {
        goldCoin += puntos;
        PrintGoldInScreen();
    }

    private void PrintGoldInScreen()
    {
        goldText.text = "Gold: " + goldCoin;
    }
}
