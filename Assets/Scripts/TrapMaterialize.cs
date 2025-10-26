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
            Button newButton = trapButton.Q<Button>("Button");
            newButton.text = trap.name;
            newButton.RegisterCallback<ClickEvent>(evt => CycleTrap(trap));
            root.Q("ButtonContainer").Add(trapButton);
        }

        TemplateContainer removeButton = trapButtonTemplate.Instantiate();
        Button remButton = removeButton.Q<Button>("Button");
        remButton.text = "Remove Trap";
        remButton.RegisterCallback<ClickEvent>(evt => RemoveTrap());
        root.Q("ButtonContainer").Add(removeButton);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && parent.GetComponent<MazeCollision>().isHighlighted)
        {
            root.visible = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            root.visible = false;
        }
    }

    public void CycleTrap(GameObject trap)
    {
        Debug.Log("Placing trap: " + trap.name);
        if (currentTrap != null)
        {
            Destroy(currentTrap);
        }
        currentTrap = Instantiate(trap, gameObject.transform.position, gameObject.transform.rotation);
        root.visible = false;
    }

    public void RemoveTrap()
    {
        if (currentTrap != null)
        {
            Destroy(currentTrap);
        }
        root.visible = false;
    }
}
