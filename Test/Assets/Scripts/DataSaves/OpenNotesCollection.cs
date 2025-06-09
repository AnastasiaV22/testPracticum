using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNotesCollection : MonoBehaviour
{
    GameManager gameManager;

    public static OpenNotesCollection instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<Note> openNotes {get; private set;}

    private void Start()
    {
        openNotes = new List<Note>();
        gameManager = GameManager.instance;
    }

    public class Note
    {
        private int id;
        private string name;
        private string notePhrase;

        public Note(int _id, string _name, string _notePhrase)
        {
            id = _id;
            name = _name;
            notePhrase = _notePhrase;
        }

    }

    public void AddNewNote(string name, string notePhrase)
    {
        Note newNote = new Note(openNotes.Count, name, notePhrase);
        openNotes.Add(newNote);
    }

}
