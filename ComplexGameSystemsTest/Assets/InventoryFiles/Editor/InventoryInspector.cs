using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventoryObject))]
public class InventoryInspector : Editor
{
    enum displayFieldType { DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields }
    displayFieldType DisplayFieldType;

    InventoryObject inventoryObj;
    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int ListSize;
    public override void OnInspectorGUI()
    {
        //todo get working
        base.OnInspectorGUI();

       
    }
}
