using UnityEngine;
using System.Collections;
//using System.Threading;

public class GameController : MonoBehaviour
{

   
    public GameObject coin;
    public float Xmin, Xmax;
    public float Height;
   
    private float spawnCoinTime;

    
    private float timeCoin;


    
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        //Counts up
       
        timeCoin += Time.deltaTime;

        //Check if its the right time to spawn the object
        
        if (timeCoin >= spawnCoinTime)
        {
            CoinSpawnObject();
            SetCoinRandomTime();
        }

    }

    
    void SetCoinRandomTime()
    {
        spawnCoinTime = Random.Range(1, 6);
    }

   
    void CoinSpawnObject()
    {
        timeCoin = 0;
        Vector3 pos = new Vector3(Random.Range(Xmin, Xmax), Height, 0.00f);
        Instantiate(coin, pos, Quaternion.identity);
    }


}
