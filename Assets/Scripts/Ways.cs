using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class Ways : MonoBehaviour
{
    public GameObject leftWay;
    public GameObject middleWay;
    public GameObject rightWay;

    public GameObject manager;

    public Material mat;
    public Material matCube;

    public float vitesse = 0.5f;

    public Transform target;
    public float offset = 20.0f;

    public GameObject cubeObject;
    public GameObject artefact;

    public GameObject bob;

    public static bool isFinish;
    public int maxBobZ;

    // Infinity mode
    public int optionLevel;

    // Use this for initialization
    void Start()
    {     
        optionLevel = PlayerPrefs.GetInt("SelectedOptionLevel") +1;
        CreateWays();
        GenerateArtefacts();
        GenerateObstacles();
        isFinish = false;
    }
    private void CreateWays()
    {
        Dictionary<int, string> dict = new()
        {
            { -3, "leftWay" },
            { 0, "middleWay" },
            { 3, "rightWay" }
        };

        foreach (KeyValuePair<int, string> entry in dict)
        {
            int wayXPosition = entry.Key;
            string wayName = entry.Value;
            GameObject way = GameObject.CreatePrimitive(PrimitiveType.Cube);
            way.name = wayName;
            way.tag = "Ground";
            way.transform.position = new Vector3(wayXPosition, 0, 0);
            MeshRenderer meshRendererWay = way.GetComponent<MeshRenderer>();
            meshRendererWay.material = mat;
            way.transform.localScale = new Vector3(3, 1, 230 * optionLevel);
            way.transform.parent = manager.transform;
            BoxCollider boxCollider = way.GetComponent<BoxCollider>();
            boxCollider.isTrigger= false;
            Rigidbody rb = way.AddComponent<Rigidbody>();
            rb.useGravity= false;
        }

        int bobZ = (230 * optionLevel) /2;
        maxBobZ = bobZ;
        Debug.Log(bobZ);
        bob.transform.position = new Vector3(Mathf.Clamp(bob.transform.position.y, - 4, 4), bob.transform.position.y, -(bobZ));

    }
    private void GenerateObstacles()
    {
        int nbObstacles = 10 * optionLevel;
        Debug.Log("Nb obstacles " + nbObstacles);

        for (int i = 0; i < nbObstacles; i++)
        {
            cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeObject.name = "Obstacle " + i.ToString();
            float[] lanePositions = { -2, -1.5f, 0, 1.5f, 2 };
            int laneWidth = Random.Range(-3, 3);
            int randomLane = Random.Range(0, lanePositions.Length - laneWidth);
            float xPosition = 0;
            for (int x = 0; x < laneWidth; x++)
            {
                xPosition += lanePositions[randomLane + x];
            }
            xPosition /= laneWidth;
            cubeObject.transform.position = new Vector3(xPosition, 2, Random.Range(-100 * optionLevel, 115 * optionLevel));
            cubeObject.transform.localScale = new Vector3(laneWidth +4, 2, 1);
            cubeObject.transform.parent = manager.transform;
            BoxCollider getBoxCollider = cubeObject.GetComponent<BoxCollider>();
            getBoxCollider.isTrigger = true;
            Rigidbody rigidbody = cubeObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            MeshRenderer meshRendererCube = cubeObject.GetComponent<MeshRenderer>();
            cubeObject.tag = "Obstacle";
        }
    }
    private void GenerateArtefacts()
    {
        int nbArtefacts = 15 * optionLevel;
        Debug.Log("Nb artefacts " + nbArtefacts);

        for (int i = 0; i < nbArtefacts; i++)
        {
            int randomValue = Random.Range(0, 100);

            artefact = GameObject.CreatePrimitive(PrimitiveType.Cube);
            MeshRenderer meshRendererObject = artefact.GetComponent<MeshRenderer>();
            // Sélection de l'objet en fonction de la probabilité
            if (randomValue < 80)
            {
                meshRendererObject.material.color = Color.yellow;
                artefact.name = "Pièce d'or";
                artefact.tag = artefact.name;
            }
            if (randomValue < 14)
            {
                meshRendererObject.material.color = Color.green;
                artefact.name = "Emeraude";
                artefact.tag = artefact.name;
            }
            if (randomValue < 5)
            {
                meshRendererObject.material.color = Color.red;
                artefact.name = "Rubis";
                artefact.tag = artefact.name;
            }
            if (randomValue < 2)
            {
                meshRendererObject.material.color = Color.blue;
                artefact.name = "Diamant";
                artefact.tag = artefact.name;
            }
            if (randomValue < 2)
            {
                meshRendererObject.material.color = Color.black;
                artefact.name = "Diamant sombre";
                artefact.tag = artefact.name;
            }

            //Instantiation de l'objet
            Vector3 randomPosition;
            randomPosition = new Vector3(Random.Range(-3, 3), 1, Random.Range(-100 * optionLevel, 115 * optionLevel));
            artefact.transform.position = randomPosition;
            artefact.transform.parent = manager.transform;
            BoxCollider getBoxCollider = artefact.GetComponent<BoxCollider>();
            getBoxCollider.isTrigger = true;
            Rigidbody rigidbody = artefact.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       float currentZ = bob.transform.position.z;
       if (maxBobZ == currentZ)
        {
            isFinish= true;
        }
    }

 

}

