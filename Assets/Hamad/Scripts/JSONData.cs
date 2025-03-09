using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace GPG214.Hamad {

    public class JSONData : MonoBehaviour
    {

        [SerializeField] private string playerName;
        [SerializeField] private GameObject player;
        [SerializeField] private Damageable health;
        [SerializeField] private int healthPoints;
        private PlayerData data = new PlayerData();
        [SerializeField] private string fileName;
        private string filePath;

        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            player = GameObject.Find(playerName);
            health = player.GetComponent<Damageable>();
            healthPoints = health.CurrentHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                SaveData();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                LoadData();
            }
        }

        private void SaveData()
        {
            if (player != null)
            {
                data.SetPlayerPosition(player.transform.position);
                data.SetHealth(healthPoints);
                string savedData = JsonUtility.ToJson(data);
                File.WriteAllText(filePath, savedData);
            }
            else
            {
                Debug.Log("Error: Player not found, attempting to relocate player");
                player = GameObject.Find(playerName);
                health = player.GetComponent<Damageable>();
                healthPoints = health.CurrentHealth;
            }

        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {

                string jsonLoader = File.ReadAllText(filePath);

                data = JsonUtility.FromJson<PlayerData>(jsonLoader);
                transform.position = data.ReturnPlayerPosition();
                healthPoints = data.ReturnHealth();

            }
            else
            {
                Debug.Log("Error: Save File Not Found");

            }
        }

    }

}