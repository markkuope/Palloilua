using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // tehd‰‰n taulukko johon s‰ilˆt‰‰n kaikki esteet
    public GameObject[] esteet;
    // Maximi Y -sijainnin arvo esteille
    public float maxYpos;
    //Paikka, josta aloitetaan esteiden spawnaus
    Vector3 spawnPos;
    // Spawnauksen taajuus
    public float spawnBreak;
    // Boolean muuttuja spawnEsteet, spawnataanko vai ei.
    public bool spawnEsteet;

    // tehd‰‰n instance, jotta t‰m‰ scripti "n‰kyy" muihin scripteihin

    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position; // spawnPos saa spawnerin paikka-arvon
        StartSpawning();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        spawnEsteet = true;
        StartCoroutine("SpawnEste");
    }

    IEnumerator SpawnEste()
    {
        yield return new WaitForSeconds(0.5f); //odotetaan 0.5 sekuntia
        while (spawnEsteet)
        {
            int randomEste = Random.Range(0, esteet.Length); // valitaan satunnaisesti yksi esteist‰
            spawnPos.y = Random.Range(-maxYpos, maxYpos); // spawnataan este satunnaiseen paikkaan -maxYpos ja maxYpos v‰lill‰
            Instantiate(esteet[randomEste], spawnPos, Quaternion.identity);// spawnaus

            yield return new WaitForSeconds(spawnBreak);// odotetaan spawnBreak verran
        }
    }


}
