using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Goes onto any gameobject which has a presence on the map <br></br>
/// Make sure to pick a rigidbody for the entity when needed
/// </summary>

//Remove comment from the required component
//For 3d entities
//[RequireComponent(typeof(Rigidbody))]
//For 2d entities
//[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    public delegate void StateScript();
    /// <summary>
    /// Use this to Execute functions in Update
    /// </summary>
    public StateScript StateUpdateAction;
    /// <summary>
    /// Use this to Execute functions in FixedUpdate
    /// </summary>
    public StateScript StateFixedUpdateAction;
    //Anything goes here which we want to save from an entity so we can load it back
    // This goes to save data if we want to save and load animations and wait timings
    //other than that no reason to save it
    public EntitySaveData entitySaveData;
    //for 2d
    //[HideInInspector]
    //public Rigidbody2D rb;
    //for 3d
    //[HideInInspector]
    //public Rigidbody rb;
    /// <summary>
    /// Used for waiting for a player stoping action to finish
    /// </summary>
    public float waitTimer;
    /// <summary>
    /// True: Save this entity to a file<br></br>
    /// False: Don't save this entity to a file
    /// </summary>
    [SerializeField] private bool saveThisEntity;
    public float moveSpeed;
    public float health;
    public float curHealth;
    /// <summary>
    /// Used for timing without stopping the player
    /// </summary>
    protected float timer;
    protected virtual void Start()
    {
        StateUpdateAction = EntityUpdate;
        StateFixedUpdateAction = EntityFixedUpdate;
        //2d
        //rb = GetComponent<Rigidbody2D>();
        //3d
        //rb=GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Override this to change default Update behavior<br></br>
    /// note: Entity doesn't have a FixedUpdate so you should make 1 when needed
    /// </summary>
    protected virtual void EntityFixedUpdate(){  }

    /// <summary>
    /// Override this to change default Update behavior<br></br>
    /// note: Entity doesn't have an Update so you should make 1 when needed
    /// </summary>
    protected virtual void EntityUpdate(){ }
    protected virtual void OnEnable()
    {
        if (saveThisEntity)
        {        
            GetSaveData();
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Add(entitySaveData);
        }
    }
    protected virtual void OnDisable()
    {
        if (saveThisEntity)
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Remove(entitySaveData);
        
    }
    protected virtual void OnDestroy()
    {
        if (saveThisEntity)
        {
            if (SaveDataCollection.saveDatas.dataToSave.saveEntities.Contains(entitySaveData))
            SaveDataCollection.saveDatas.dataToSave.saveEntities.Remove(entitySaveData);
        }


    }
    public void GetSaveData()
    { 
        entitySaveData.position = transform.position;
        entitySaveData.rotation = transform.eulerAngles;
    }
}
