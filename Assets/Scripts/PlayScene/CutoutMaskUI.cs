using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace NeonImpact.PlayScene
{
   public class CutoutMaskUI : Image
   {
      public override Material materialForRendering
      {
         get
         {
            Material material = new Material(base.materialForRendering);
            material.SetInt("_StencilComp",(int)CompareFunction.NotEqual); // Equal yerine not equal yaparak mask'in ters alani kaplamasini sagladim
            return material;
         }
      }
   }
}
