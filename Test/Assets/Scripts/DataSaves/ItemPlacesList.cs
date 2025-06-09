using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacesList : MonoBehaviour
{
    public static ItemPlacesList instance{ get; private set; }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CreatePlacesDictionary();
        }

    }

    [SerializeField] Transform allCategoriesPlaces;

    private Dictionary<string, List<Transform>> placesForCategories;

    private void CreatePlacesDictionary()
    {
        placesForCategories = new Dictionary<string, List<Transform>>();

        if (allCategoriesPlaces == null)
        {
            return;
        }

        foreach (Transform categoryPlaces in allCategoriesPlaces)
        {
            Transform[] childs = categoryPlaces.GetComponentsInChildren<Transform>();

            if (childs.Length > 1)
            {
                List<Transform> places = new List<Transform>();
                for (int i = 1; i < childs.Length; i++)
                {
                    places.Add(childs[i]);
                }
                placesForCategories.Add(categoryPlaces.name, places);
            }
            

        }
    }


    public Transform GetPlaceForItem(string categoryName)
    {
        List<Transform> places = placesForCategories[categoryName];

        if (places != null && places.Count != 0  )
        {
            int index = Random.Range(0, places.Count);
            Transform place = places[index];
            places.Remove(place);
            placesForCategories[categoryName] = places;
            return place;
        }
        return null;
    }

}
