using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GPG214.Hamad {
    public class AssetBundleLoader : MonoBehaviour
    {

        [SerializeField] private string folderPath; //the folder the Asset Bundle file is located in
        [SerializeField] private string fileName; //the name of the Asset Bundle
        [SerializeField] private string assetName; //the name of the asset inside the Asset Bundle
        private string filePath; //stores the file path to the fileName

        private AssetBundle dlc; //reference to the asset bundle

        void Start()
        {
            filePath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (dlc == null)
                {
                    if (File.Exists(filePath))
                    {
                        dlc = AssetBundle.LoadFromFile(filePath);
                    }
                    else Debug.Log("Error: File path Not Found");
                }
                else Debug.Log("Asset Bundle already extracted");
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                LoadPrefab();
            }


        }

        private void LoadPrefab() //loads the prefab from the asset bundle
        {

            if (dlc == null) return;

            GameObject soundPrefab = dlc.LoadAsset<GameObject>(assetName);

            if (soundPrefab != null)
            {
                Instantiate(soundPrefab);
            }
            else
            {
                Debug.Log("Error: asset not found in Asset Bundle");
            }

        }


    }

}
