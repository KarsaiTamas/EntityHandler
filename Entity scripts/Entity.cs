using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Goes onto any gameobject which has a presence on the map
/// </summary>

//Remove comment from the required component
//For 3d entities
//[RequireComponent(typeof(Rigidbody))]
//For 2d entities
//[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    public delegate void StateScript();
    public StateScript StateUpdateAction;
    public StateScript StateFixedUpdateAction;
    //Anything goes here which we want to save from an entity so we can load it back
    public EntitySaveData entitySaveData;
    // This goes to save data if we want to save and load animations and wait timings
    //other than that no reason to save it 
    public abstract List<float> Stats {get;set;}
    
    public float waitTimer;
    [SerializeField] private bool saveThisEntity;
    protected virtual void Awake()
    {
        StateUpdateAction = ()=>{ print("Update Action"); };
        StateFixedUpdateAction = ()=> { print("Fixed Update Action"); };
    }

    protected virtual void OnEnable()
    {
        if (!saveThisEntity) return;
            GetSaveData();
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Add(entitySaveData);
        
    }
    protected virtual void OnDisable()
    {
        if (!saveThisEntity) return;
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Remove(entitySaveData);
        
    }
    protected virtual void OnDestroy()
    {
        if (!saveThisEntity) return;
        
        if (SaveDataCollection.saveDatas.dataToSave.saveEntities.Contains(entitySaveData))
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Remove(entitySaveData);
        


    }


    protected virtual void DefaultInteraction()
    {
        print("Did a default interaction");
    }

    public void GetSaveData()
    { 
        entitySaveData.position = transform.position;
        entitySaveData.rotation = transform.eulerAngles;
    }
}
