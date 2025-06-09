using UnityEngine;

public class PrefabsList : MonoBehaviour
{
    [SerializeField] GameObject defaultPrefab;
    [SerializeField] GameObject[] booksPrefs = new GameObject[0];
    [SerializeField] GameObject[] flowersPrefs = new GameObject[0];
    [SerializeField] GameObject[] magazinePrefs = new GameObject[0];
    [SerializeField] GameObject[] picturesPrefs = new GameObject[0];

    public static PrefabsList instance { get; private set; }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
   
    }


    public GameObject GetRandomPrefabByCategory(string category)
    {
        switch (category){
            
            case "book":
                if (booksPrefs.Length>0)
                    return booksPrefs[Random.Range(0, booksPrefs.Length)];
                break;

            case "flowers":
                if (flowersPrefs.Length > 0)
                    return flowersPrefs[Random.Range(0, flowersPrefs.Length)];
                break;

            case "magazine":
                if (magazinePrefs.Length > 0)
                    return magazinePrefs[Random.Range(0, magazinePrefs.Length)];
                break;
            case "pictures":
                if (picturesPrefs.Length > 0)
                    return picturesPrefs[Random.Range(0, picturesPrefs.Length)];
                break;

            default:
                return defaultPrefab;
        }
        return defaultPrefab;
    }
}
