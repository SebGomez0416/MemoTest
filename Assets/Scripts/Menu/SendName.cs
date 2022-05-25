using UnityEngine;
using UnityEngine.UI;

public class SendName : MonoBehaviour
{
   [SerializeField] private Text name;


   private void OnDestroy()
   {
      DataBetweenScenes.instance._name = name.text;
   }
}
