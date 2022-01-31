using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataCollection : MonoBehaviour
{
    /// <summary>
    /// Call this instead of requesting the gameobject for it
    /// </summary>
    public static SaveDataCollection saveDatas;
    
    /// <summary>
    /// This should contain every data which you wish to save and load
    /// </summary>
    public SaveData dataToSave;

    private void Start()
    {
        saveDatas = this;
    }


    //To use SLHandler you can get my save load handler
    //from my github: https://github.com/KarsaiTamas/SaveLoadHandler
    private void SaveData(string saveSlotName)
    {
        //SLHandler.Save(dataToSave,saveSlotName);
    }
    private void LoadEntities(string saveSlotName)
    {
        //dataToSave= SLHandler.Load(dataToSave,saveSlotName);

    }

}
