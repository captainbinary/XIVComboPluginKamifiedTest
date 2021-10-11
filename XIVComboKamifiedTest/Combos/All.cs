using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboKamifiedTestPlugin.Combos
{
    internal static class All
    {
        public const byte JobID = 0;

        public const uint
            Swiftcast = 7561,
            Resurrection = 173,
            Verraise = 7523,
            Raise = 125,
            Ascend = 3603;

        public static class Buffs
        {
            public const short
                Swiftcast = 167;
        }

        public static class Levels
        {
            public const byte
                Raise = 12;
        }
    }

    internal class AllSwiftcastFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.AllSwiftcastFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == All.Raise || actionID == All.Resurrection || actionID == All.Ascend || actionID == All.Verraise)
            {
                var swiftCD = GetCooldown(All.Swiftcast);
                if ((swiftCD.CooldownRemaining == 0 && !HasEffect(RDM.Buffs.Dualcast))
                    || level <= All.Levels.Raise
                    || (level <= RDM.Levels.Verraise && actionID == All.Verraise))
                    return All.Swiftcast;
            }

            return actionID;
        }
    }
}