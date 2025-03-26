using SpectralWave.TogglesLoadManager;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager; 

namespace SpectralWave.Modules.Visual
{
    internal class DisableGrainEffect : TogglesLoad
    {
        public override void Update()
        {
          GameObject.Find("Post Processing Main").SetActive(!BDisableGrain);
        }
    }
}
