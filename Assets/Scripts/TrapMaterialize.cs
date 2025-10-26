using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapMaterialize : MonoBehaviour
{
    [SerializeField] GameObject[] allTraps;
    private UnityEngine.Object currentTrap;
    private GameObject parent;
    private VisualElement root;
    public VisualTreeAsset trapButtonTemplate;

    void OnEnable()
    {
        parent = gameObject.transform.parent.gameObject;
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;


        foreach (GameObject trap in allTraps)
        {
            TemplateContainer trapButton = trapButtonTemplate.Instantiate();
            Button button = trapButton.Q<Button>("Button");
            button.text = trap.name;
            button.RegisterCallback<ClickEvent>(OnClick => CycleTrap(trap));
            Debug.Log("Creating button for " + trap.name);
            root.Q("ButtonContainer").Add(trapButton);
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && parent.GetComponent<MazeCollision>().isHighlighted)
        {
            if (currentTrap != null)
            {
                Destroy(currentTrap);
            }
            root.visible = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            root.visible = false;
        }
    }

    public void CycleTrap(GameObject trap)
    {
        if (currentTrap != null)
        {
            Destroy(currentTrap);
        }
        currentTrap = Instantiate(trap, gameObject.transform.position, gameObject.transform.rotation);
        root.visible = false;
    }
}
