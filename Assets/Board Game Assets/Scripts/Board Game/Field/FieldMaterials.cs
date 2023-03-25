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
            switch (_selectedColor)
            {
                case FieldColor.Red:
                    SetFieldMaterial(redMaterial);
                    break;
                case FieldColor.Empty:
                    SetFieldMaterial(emptyMaterial);
                    break;
                case FieldColor.Yellow:
                    SetFieldMaterial(yellowMaterial);
                    break;
                case FieldColor.Cyan:
                    SetFieldMaterial(cyanMaterial);
                    break;
                case FieldColor.Purple:
                    SetFieldMaterial(purpleMaterial);
                    break;
            }
        }

        public void SetSelectedColor(FieldColor color) => _selectedColor = color;

        public void SetFieldMaterial(Material materialToSet)
        {
            Debug.Log("Set color of field to: " + _selectedColor);
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