using System;
using UnityEngine;


namespace Board_Game_Assets.Scripts.Board_Game.Field
{
    public class FieldMaterials : MonoBehaviour
    {
        private FieldColor _selectedColor;
        
        public Material redMaterial;
        public Material emptyMaterial;
        public Material yellowMaterial;
        public Material cyanMaterial;
        public Material purpleMaterial;

        public void SetFieldColor(GameObject fieldHaloObj)
        {
            switch (_selectedColor) //TODO Split getting material and setting it to field
            {
                case FieldColor.Red:
                    SetFieldMaterial(fieldHaloObj, redMaterial);
                    break;
                case FieldColor.Empty:
                    SetFieldMaterial(fieldHaloObj, emptyMaterial);
                    break;
                case FieldColor.Yellow:
                    SetFieldMaterial(fieldHaloObj, yellowMaterial);
                    break;
                case FieldColor.Cyan:
                    SetFieldMaterial(fieldHaloObj, cyanMaterial);
                    break;
                case FieldColor.Purple:
                    SetFieldMaterial(fieldHaloObj, purpleMaterial);
                    break;
            }
        }

        public void SetSelectedColor(FieldColor color) => _selectedColor = color;

        private void SetFieldMaterial(GameObject fieldHaloObj, Material materialToSet)
        {
            Debug.Log("Set color of field to: " + _selectedColor);
            fieldHaloObj.GetComponent<MeshRenderer>().material = materialToSet;
        }
    }
    
    public enum FieldColor
    {
        Red,
        Empty,
        Yellow,
        Cyan,
        Purple
    }
}