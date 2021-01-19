using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    public Transform porta;

    private Transform _selection;
    private float offset;
    [SerializeField] private GameObject player;
    public Animator animator;

    private void Update()
    {
        //Debug.Log(porta.transform.transform.eulerAngles.y);

        if (porta.transform.transform.eulerAngles.y > 275f)
        {
            //animator.SetTrigger("Open");
        }
       /* if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }*/

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var SelectionRenderer = selection.GetComponent<Renderer>();
                if (SelectionRenderer != null)
                {
                    SelectionRenderer.material = highlightMaterial;
                }
                if (Input.GetMouseButton(0))
                {
                    offset = Input.mousePosition.x;
                    //Debug.Log("cliccato");
                    porta.Rotate(0f, 0f - Time.deltaTime * offset * 0.1f, 0f );
                  
                }
            }

            _selection = selection;

        }
    }
}


