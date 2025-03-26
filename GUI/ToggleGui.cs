using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using UnityEngine.InputSystem;
namespace SpectralWave.Modules.Utill
{
    internal class ToggleGui : TogglesLoad
    {
        public static bool Open = true;

        public override void Update()
        {
            if (Keyboard.current.insertKey.wasPressedThisFrame)
            {
                Open = !Open;
            }
        }
    }
}
