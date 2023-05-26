using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentItem : MonoBehaviour
{
    public Quest questDependency;
    [Tooltip("This is the mesh of the item before it is unavailable. IE, an empty coffeepot. If n/a, leave null")]
    public GameObject unavailableGraphic;
    [Tooltip("Mesh of the object when it is available. IE, donuts appear. If n/a, leave null")]
    public GameObject availableGraphic;

    public GameObject camera;
    Camera cam;

    private void Awake()
    {
        cam = camera.GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (questDependency != null)
            SetItemAvailable(questDependency.IsComplete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHover()
    {

    }

    void OnSelect()
    {

    }

    public void SetItemAvailable(bool available)
    {
        if (unavailableGraphic != null)
            unavailableGraphic.SetActive(!available);
        if (availableGraphic != null)
            availableGraphic.SetActive(available);
    }
}
