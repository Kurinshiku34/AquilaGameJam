using UnityEngine;

public class Rewind : MonoBehaviour
{
    public Vector3 startingPosition = new Vector3();
    public Transform spawnPoint;
    public Rigidbody Prefab;
    public GameObject powerCount1;
    public GameObject powerCount2;
    public GameObject powerCount3;
    public int sayac = 3;

    void Start()
    {
        transform.localPosition = (Vector3)startingPosition;       //baslangic konumu
        sayac = 3;
    }
    void Update()
    {
        rewind();
        //Rewind kalan haklarin oyuncuya ui uzerinde gosterilmesi
        if (sayac == 2)
        {
            powerCount3.SetActive(false);
        }
        if (sayac == 1)
        {
            powerCount2.SetActive(false);
        }
        if (sayac == 0)
        {
            powerCount1.SetActive(false);
        }
    }
    void rewind()
    {
        if (Input.GetKeyDown(KeyCode.R) && sayac > 0)   //"R" tusuna basarsam ve sayac 0'dan buyukse (yani ozel gucum varsa) REWIND calistir.
        {
            Rigidbody rigidPrefab;
            rigidPrefab = Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
            transform.localPosition = (Vector3)startingPosition;
            sayac--;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("FallGround"))
        {
            transform.localPosition = (Vector3)startingPosition;
        }
    }
}