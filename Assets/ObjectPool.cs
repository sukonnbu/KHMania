using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteInfo
{
    public GameObject notePrefab;
    public int count;
    public Transform noteParent;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private NoteInfo[] noteInfos;
    public Queue<GameObject> Pool = new Queue<GameObject>();
    public static ObjectPool Instance;

    void Start()
    {
        Instance = this;
        Pool = InsertQueue(noteInfos[0]);
    }

    Queue<GameObject> InsertQueue(NoteInfo noteInfo)
    {
        Queue<GameObject> tQueue = new Queue<GameObject>();
        for (int i = 0; i < noteInfo.count; i++)
        {
            GameObject tClone = Instantiate(noteInfo.notePrefab, transform.position, Quaternion.identity);
            tClone.SetActive(false);
            if (noteInfo.noteParent != null) tClone.transform.SetParent(noteInfo.noteParent);
            else tClone.transform.SetParent(this.transform);

            tQueue.Enqueue(tClone);
        }

        return tQueue;
    }
}
