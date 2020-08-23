using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string URL = "https://globalcatch-3da1b.firebaseio.com/";
    [SerializeField] private TMP_InputField JoinGameCode;
    [SerializeField] private IncomingObject incomingObject;
    [SerializeField] private GameObject Alert;

    DatabaseReference databaseReference;

    private string id;
    private Player player;
    private string gameKey;
    private string playerNum;

    [Serializable]
    class Game
    {
        public string key;
        public Player player1;
        public Player player2;
    }

    [Serializable]
    class Player
    {
        public string id;
        public string outgoing;
    }

    public void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(URL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        id = SystemInfo.deviceUniqueIdentifier;
        player = new Player
        {
            id = id,
            outgoing = ""
        };

        Alert.SetActive(false);
    }
    public async void CreateGame()
    {
        playerNum = "player1";
        gameKey = databaseReference.Child("Games").Push().Key;
        Game newGame = new Game
        {
            key = gameKey,
            player1 = player,
            player2 = new Player { }
        };
        string json = JsonUtility.ToJson(newGame);
        await databaseReference.Child("Games").Child(gameKey).SetRawJsonValueAsync(json);
        databaseReference.Child("Games").Child(gameKey).Child("player2").Child("outgoing").ValueChanged += HandleValueChanged;
        JoinGameCode.text = gameKey;
    }
    async void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        string InComingProjectile = args.Snapshot.GetValue(true).ToString();
        if (String.IsNullOrEmpty(InComingProjectile))
            return;
        Debug.Log(InComingProjectile);
        incomingObject.SpawnObject(InComingProjectile);

        Alert.SetActive(true);
        await Task.Delay(3000);
        Alert.SetActive(false);
        // Do something with the data in args.Snapshot
    }

    public async void JoinGame()
    {
        playerNum = "player2";
        gameKey = JoinGameCode.text;
        string json = JsonUtility.ToJson(player);
        await databaseReference.Child("Games").Child(gameKey).Child(playerNum).SetRawJsonValueAsync(json);
        databaseReference.Child("Games").Child(gameKey).Child("player1").Child("outgoing").ValueChanged += HandleValueChanged;
    }

    public void SendProjectile(string projectileName)
    {
        databaseReference.Child("Games").Child(gameKey).Child(playerNum).Child("outgoing").SetValueAsync(projectileName);
    }
}
