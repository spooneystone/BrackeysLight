using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour {

    Door door;

    GameObject player;

    public GameObject enemiesPrefab,torchPrefab;
    public Transform[] eneySpawnAreas;
    public Transform torchSpawn,playerSpawn;

    List<GameObject> torchesInLevel = new List <GameObject>();
    bool[] torchesBeenLit;

    bool allTorchesLit;

    public bool hasTorch { get; private set;}
    public bool hasSword { get; private set;}

    private void OnEnable()
    {
        EventManager.LevelEnded += LevelProgress;
        EventManager.PlayerDead += PlayerRespawn;
    }
    private void OnDisable()
    {
        EventManager.LevelEnded -= LevelProgress;
        EventManager.PlayerDead -= PlayerRespawn;
    }
    void LevelProgress()
    {

        
        if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No more levels");
        }
    }
    private void Awake()
    {
        allTorchesLit = false;
        door = FindObjectOfType<Door>();
    }
    void PlayerRespawn()
    {
        player.transform.position = playerSpawn.position;
        StartCoroutine(SpawnPlayer());

    }
    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(2f);
        if(!player.activeInHierarchy)
        {
            player.SetActive(true);
        }
    }
    // Use this for initialization
    void Start () {

        torchesInLevel.AddRange(GameObject.FindGameObjectsWithTag("Torch"));
        torchesBeenLit = new bool[torchesInLevel.Count];
        for (int i = 0; i < torchesInLevel.Count; i++)
        {
            
            
            torchesBeenLit[i] = false;
        }

        player = GameObject.FindGameObjectWithTag("Player");
      
    }
    public void HasTorch(bool _value)
    {
        hasTorch = _value;
    }
    public void HasSword(bool _value)
    {
        hasSword = _value;
    }
    public bool AllTorchesLit()
    {
        return allTorchesLit;
    }
	public void SetTorch()
    {
        for (int i = 0; i < torchesBeenLit.Length; i++)
        {
            if(torchesBeenLit[i] == false)
            {
                torchesBeenLit[i] = true;
                if(torchesBeenLit[torchesBeenLit.Length-1])
                {
                    Debug.Log("all torches lit");
                    allTorchesLit = true;
                    if (GameObject.Find("Canvas"))
                    {
                        GameObject.Find("Canvas").transform.Find("LightTheseText").gameObject.SetActive(false);
                    }
                    
                    door.OpenDoor();
                }
                break;
               
            }

            
        }
        
    }
    public void EnterEnemies(int _amount)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(enemiesPrefab, eneySpawnAreas[Random.Range(0,eneySpawnAreas.Length)].position, Quaternion.identity);
        }
    }
    public void SpawnTorch()
    {
        Instantiate(torchPrefab, torchSpawn.position, Quaternion.identity);
    }
	
}
