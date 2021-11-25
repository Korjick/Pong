using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New Fighter SO", menuName = "Scriptable Objects/Fighter SO", order = 0)]
    public class FighterSO : ScriptableObject
    {
        public Sprite icon;
        public Sprite preview;
        public string name;
        public CharacterController battlePrefab;
        public AnimatorOverrideController animator;
    }
}