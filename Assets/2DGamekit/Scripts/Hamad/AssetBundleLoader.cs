using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetBundleLoader : MonoBehaviour
{

    [SerializeField] private string folderPath;
    [SerializeField] private string fileName;
    private string filePath;

    private AssetBundle dlc;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (dlc == null)
            {
                if (File.Exists(filePath))
                    dlc = AssetBundle.LoadFromFile(filePath);
                else Debug.Log("File Not Found");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadPrefab();
        }
        
    }

    private void LoadPrefab()
    {

        //need to check if the thing is null to prefent that

        GameObject soundPrefab = dlc.LoadAsset<GameObject>("SoundLoader2");

        if (soundPrefab != null)
        {
            Instantiate(soundPrefab);
        }
        
    }

    

}
