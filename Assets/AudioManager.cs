using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audio;
    private Dictionary<float, string> _sheet;
    private List<float> _timing;
    private List<string> _notes;
    private int _currentNote;
    public float timer;
    [SerializeField] public List<Transform> lanes;
    [SerializeField] public List<Material> materials;

    void Start()
    {
        // lane 1~5
        _sheet = new Dictionary<float, string>
        {
            {1, "1"}
        };
        _timing = _sheet.Keys.ToList();
        _notes = _sheet.Values.ToList();
        _currentNote = 0;

        _audio = GetComponent<AudioSource>();
        timer = 0f;
    }

    void Update()
    {
        if (timer > 1.5f && !_audio.isPlaying) _audio.Play();

        if (_timing.Count > _currentNote && timer > _timing[_currentNote])
        {
            _currentNote++;

            // call note
            foreach (var lane in _notes[_currentNote])
            {
                GameObject tNote = ObjectPool.Instance.Pool.Dequeue();
                tNote.transform.parent = lanes[(int)lane - 1];
                tNote.SetActive(true);
            }
        }
        timer += Time.deltaTime;
    }
}
