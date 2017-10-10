using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject parent;
    private RubyDisplay rubyDisplay;

    private void Start()
    {
        myCamera = GameObject.FindObjectOfType<Camera>();
        rubyDisplay = GameObject.FindObjectOfType<RubyDisplay>();
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        //Set Click as rounded World Units
        Vector2 worldDecimals = CalcWorldPointOfMouseClick();
        Vector2 worldWhole = SnapToGrid(worldDecimals);
        GameObject defender = Button.selectedDefender;
        int defCost = defender.GetComponent<Defender>().rubyCost;
        //Spawn Defender if there is enough currency to cover cost
        if(rubyDisplay.UseRubyAmount(defCost) == RubyDisplay.Status.SUCCESS)
        {
            SpawnDefender(worldWhole, defender);
        }
        else
        {
            Debug.Log("Insufficent funds");
        }
    }

    private void SpawnDefender(Vector2 worldWhole, GameObject defender)
    {
        GameObject newDef = Instantiate(defender, worldWhole, Quaternion.identity) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    //Take in world units of mouse click
    Vector2 CalcWorldPointOfMouseClick()
    {
        float xPixels = Input.mousePosition.x;
        float yPixels = Input.mousePosition.y;
        float cameraDistance = 10;

        Vector3 pixels = new Vector3(xPixels, yPixels, cameraDistance);
        Vector2 world = myCamera.ScreenToWorldPoint(pixels);
        return world;
    }

    //Round Mouse Click to nearest World Units
    Vector2 SnapToGrid(Vector2 rawWorld)
    {
        float roundedX = Mathf.Round(rawWorld.x);
        float roundedY = Mathf.Round(rawWorld.y);
        Vector2 rounded = new Vector2(roundedX, roundedY);
        return rounded;
    }
}
