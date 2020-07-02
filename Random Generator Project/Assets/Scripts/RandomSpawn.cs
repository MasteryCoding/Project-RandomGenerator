using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] int amountToSpawn;

    [SerializeField] Material[] materials;

    void Start() {
        for (int i = 0; i < amountToSpawn; i++) {
            Spawn();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Spawn();
        }
    }
    
    void Spawn() {
        GameObject obj = Instantiate(objectToSpawn);

        // Randomly set materials
        MeshRenderer mr = obj.GetComponentInChildren<MeshRenderer>();
        mr.material = materials[Random.Range(0, materials.Length)];

        // Randomly set Rotate values
        Rotate rotate = obj.GetComponent<Rotate>();
        rotate.rotateSpeed = Random.Range(10f, 60f);

        Rotate childRotate = obj.transform.GetChild(0).GetComponent<Rotate>();
        childRotate.rotateSpeed = Random.Range(90f, 180f);

        // Randomly set GrowShrink values
        GrowShrink growShrink = obj.GetComponent<GrowShrink>();
        growShrink.scaleSpeed = Random.Range(1f, 2f);
        growShrink.maxSize = Random.Range(1f, 3f);
        growShrink.minSize = Random.Range(0.1f, 0.5f);

        // Randomly set BackForth values
        BackForth backForth = obj.GetComponent<BackForth>();
        backForth.maxDistance = Random.Range(5f, 10f);
        backForth.moveSpeed = Random.Range(1f, 3f);

        // Spawn in random y axis. 
        obj.transform.position = Vector3.up * Random.Range(-5f, 5f);
    }
}
