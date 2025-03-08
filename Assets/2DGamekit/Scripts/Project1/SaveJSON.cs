using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveJSON : MonoBehaviour
{

    [SerializeField] private PlayerData data = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JsonUtility.ToJson(this);
    }
}
