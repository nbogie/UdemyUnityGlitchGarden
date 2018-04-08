using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] attackerPrefabs;
    private Transform attackersParent;
    public Dictionary<string, int> spawnCount = new Dictionary<string, int>();

    void Start()
    {
        attackersParent = GameObject.Find("Attackers").transform;
    }
    bool SameGridValue(float a, float b){
        return Mathf.RoundToInt(a) == Mathf.RoundToInt(b);
    }

    public bool AreThereEnemiesEastOfLane(Vector2 pos){
        foreach(Transform k in attackersParent.transform){
            if ((k.position.x >= pos.x) && (SameGridValue(k.position.y, pos.y))){
                return true;
            }
        }
        return false;
    }

    void SpawnAttacker(GameObject prefab)
    {
        GameObject attacker = Instantiate(prefab, RandomSpawnPoint(), Quaternion.identity, attackersParent);
        CountSpawning(prefab.name);
        //ReportSpawnCounts();
    }

    void ReportSpawnCounts()
    {
        float t = Time.timeSinceLevelLoad;
        foreach (KeyValuePair<string, int> entry in spawnCount)
        {
            Debug.Log(entry.Key + " at " + Mathf.Round(t) + " count: " + entry.Value + " or " + Mathf.Round(t / entry.Value) + " between appearances");
        }
    }

    void CountSpawning(string key){
        int count;
        if (spawnCount.TryGetValue(key, out count))
        {
            spawnCount.Remove(key);
            spawnCount.Add(key, count + 1);
        }
        else
        {
            spawnCount.Add(key, 1);
        }
    }

    Vector3 RandomSpawnPoint(){
        return new Vector3(9, Random.Range(1, 5 + 1));
    }

    GameObject RandomAttackerPrefab()
    {
        return attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
    }

    bool IsTimeToSpawn(GameObject attacker){
        // E.g. To spawn Fox every ten seconds on average,
        //at 10 frames per second, that means 
        // ideally once every 100 frames, 
        // or a probability of 1% on any frame (assuming 10FPS)
        // calculation: prob: 1 / (spawnPeriod * FPS)
        AttackerScript script = attacker.GetComponent<AttackerScript>();
        float fps = 1 / Time.smoothDeltaTime;
        float probability = 1 / (script.seenEverySeconds * fps);
        return Random.value < probability;

    }

    bool FrameRateIsOk(){
        return Time.smoothDeltaTime < 0.1f;
    }


    void Update()
    {
        foreach(GameObject a in attackerPrefabs){
            if (IsTimeToSpawn(a) && FrameRateIsOk()){
                SpawnAttacker(a);
            }    
        }

    }
}
