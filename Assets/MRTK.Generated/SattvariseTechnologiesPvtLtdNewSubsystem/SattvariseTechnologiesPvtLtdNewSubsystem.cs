// TODO: [Optional] Add copyright and license statement(s).

using MixedReality.Toolkit;
using MixedReality.Toolkit.Subsystems;
using UnityEngine;
using UnityEngine.Scripting;

namespace SattvariseTechnologiesPvtLtd.MRTK3.Subsystems
{
    [Preserve]
    [MRTKSubsystem(
        Name = "sattvarisetechnologiespvtltd.mrtk3.subsystems",
        DisplayName = "SattvariseTechnologiesPvtLtd NewSubsystem",
        Author = "SattvariseTechnologiesPvtLtd",
        ProviderType = typeof(SattvariseTechnologiesPvtLtdNewSubsystemProvider),
        SubsystemTypeOverride = typeof(SattvariseTechnologiesPvtLtdNewSubsystem),
        ConfigType = typeof(BaseSubsystemConfig))]
    public class SattvariseTechnologiesPvtLtdNewSubsystem : NewSubsystem
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Register()
        {
            // Fetch subsystem metadata from the attribute.
            var cinfo = XRSubsystemHelpers.ConstructCinfo<SattvariseTechnologiesPvtLtdNewSubsystem, NewSubsystemCinfo>();

            if (!SattvariseTechnologiesPvtLtdNewSubsystem.Register(cinfo))
            {
                Debug.LogError($"Failed to register the {cinfo.Name} subsystem.");
            }
        }

        [Preserve]
        class SattvariseTechnologiesPvtLtdNewSubsystemProvider : Provider
        {

            #region INewSubsystem implementation

            // TODO: Add the provider implementation.

            #endregion NewSubsystem implementation
        }
    }
}
