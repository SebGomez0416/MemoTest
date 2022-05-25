using UnityEngine;
using UnityEngine.UI;

public class SendName : MonoBehaviour
{
   [SerializeField] private Text _name;


   private void OnDestroy()
   {
      DataBetweenScenes.instance._name = _name.text;
   }
}
