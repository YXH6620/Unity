using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> monsters;

    public float minTime = 0.5f;
    public float maxTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while(true)
        {
            //wait for a mintue
            float t = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(t);

            //create monster
            int i = Random.Range(0, monsters.Count);
            //Random position
            Vector3 pos = new Vector3(Random.Range(-2.1f, 2.1f), transform.position.y, 0);
            Transform m = Instantiate(monsters[i], pos, Quaternion.identity);
                     

        }
    }
}
