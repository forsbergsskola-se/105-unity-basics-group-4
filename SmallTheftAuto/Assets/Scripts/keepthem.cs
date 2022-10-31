using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepthem : MonoBehaviour
{
    public List<GameObject> keepthose;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        var newInstance = Instantiate(prefab);
        keepthose.Add(newInstance);
        DontDestroyOnLoad(newInstance);
    }
}

public class nextSceneScript : MonoBehaviour
{
    void Start()
    {
        var keepThem = FindObjectOfType<keepthem>();
        for (var index = 0; index < keepThem.keepthose.Count; index++)
        {
            var item = keepThem.keepthose[index];
            // work with it
        }
        Destroy(keepThem.gameObject);
    }
}