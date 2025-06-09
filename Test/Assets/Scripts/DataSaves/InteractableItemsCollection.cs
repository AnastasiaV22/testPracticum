using System.Collections.Generic;
using UnityEngine;
using static JsonConventer;


public class InteractableItemsCollection : MonoBehaviour
{
    GameManager gameManager;

    public static InteractableItemsCollection instance { get; private set; }
    public InteractableItemsCollection() { }
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        gameManager = GameManager.instance;
              
        itemsInfo = new List<ItemInfo>();
        items = new List<Item>();

        LoadItemsInfo();
    }


    List<Item> items;
    List<ItemInfo> itemsInfo;
    ItemPlacesList itemPlacesList;


    //Info about items, load once
    private class ItemInfo 
    {
        internal int id { get; private set; }

        internal string name { get; private set; }
        internal string category { get; private set; } //Book, Pictures, 

        internal string reactionPhrase { get; private set; }
        internal string notePhrase { get; private set; }

        public ItemInfo(int _id, string _name, string _category, string _reactionPhrase, string _notePhrase) 
        {
            id = _id;
            name = _name;
            category = _category;
            reactionPhrase = _reactionPhrase;
            notePhrase = _notePhrase;
        }

    }


    //Items game settings, reset before new game  
    private class Item
    {
        private int id;
        internal bool active { get; private set; }
        private GameObject pref;
        private Transform currentPlace;

        private GameObject thisItem;

        public Item(int _id, GameObject _pref, Transform _currentPlace)
        {

            id = _id;
            pref = _pref;
            currentPlace = _currentPlace;
            active = true;


            thisItem = SpawnNewObject(_currentPlace.transform.position, pref);
            thisItem.AddComponent<PointerDoorController>();
            thisItem.AddComponent<Rigidbody>();
            thisItem.GetComponent<Rigidbody>().isKinematic = true;
            thisItem.AddComponent<BoxCollider>();

        }

        public void SetUsed()
        {
            active = false;
            Destroy(thisItem.GetComponent<PointerDoorController>());
        }

        public int GetIdIfItemThis(GameObject item)
        {
            if (item == thisItem)
                return id;
            else
                return -1;
        }
        public GameObject SpawnNewObject(Vector3 pos, GameObject pref)
        {
            return Instantiate(pref, pos, Quaternion.identity);
        }

    }
    // load info about interactable objects from json file
    public void LoadItemsInfo()
    {

        JsonDataWrapper jsonDataWrapper = JsonConventer.GetItemsFromJson();

        foreach (JsonConventer.AboutItemsInfo aboutItemInfo in jsonDataWrapper.aboutItemsInfo) 
        {   
            ItemInfo info = new ItemInfo(aboutItemInfo.id, aboutItemInfo.name, aboutItemInfo.category, aboutItemInfo.reactionPhrase, aboutItemInfo.notePhrase);
            itemsInfo.Add(info);
        }
    }

    // Generate Items for new game
    public void GenerateItems()
    {
        if (items != null)
            items.Clear();

        PrefabsList prefabsList = PrefabsList.instance;
        itemPlacesList = ItemPlacesList.instance;

        foreach (ItemInfo itemInfo in itemsInfo) {

            GameObject pref = prefabsList.GetRandomPrefabByCategory(itemInfo.category);
            Transform place = itemPlacesList.GetPlaceForItem(itemInfo.category);
            if (pref != null && place != null)
            {
                Item item = new Item(itemInfo.id, pref, place);
                items.Add(item);
            }
        }

    }



    public void SetItemUsed(GameObject item)
    {

        int id = -1;
        foreach (Item _item in items)
        {
            id = _item.GetIdIfItemThis(item);
            if (id >= 0)
                break;
        }
        if (id == -1)
            return;
        else
        {
            items[id].SetUsed();
         //   gameManager.AddNote(itemsInfo[id].name, itemsInfo[id].notePhrase); //Add note to collection
            gameManager.DisplayMessage(itemsInfo[id].reactionPhrase);


        }

    }

   // public string[] GetOpenNotes(){}

}
