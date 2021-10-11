using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboKamifiedTestPlugin.Combos
{
    internal static class BLM
    {
        public const byte ClassID = 7;
        public const byte JobID = 25;

        public const uint
            Fire = 141,
            Blizzard = 142,
            Thunder = 144,
            Blizzard2 = 146,
            Transpose = 149,
            Fire3 = 152,
            Thunder3 = 153,
            Blizzard3 = 154,
            Scathe = 156,
            Freeze = 159,
            Flare = 162,
            LeyLines = 3573,
            Enochian = 3575,
            Blizzard4 = 3576,
            Fire4 = 3577,
            BetweenTheLines = 7419,
            Despair = 16505,
            UmbralSoul = 16506,
            Xenoglossy = 16507;

        public static class Buffs
        {
            public const short
                Thundercloud = 164,
                LeyLines = 737,
                Firestarter = 165;
        }

        public static class Debuffs
        {
            public const short
                Thunder = 161,
                Thunder3 = 163;
        }

        public static class Levels
        {
            public const byte
                Fire3 = 34,
                Freeze = 35,
                Blizzard3 = 40,
                Thunder3 = 45,
                Flare = 50,
                Enochian = 56,
                Blizzard4 = 58,
                Fire4 = 60,
                BetweenTheLines = 62,
                Despair = 72,
                UmbralSoul = 76,
                Xenoglossy = 80;
        }
    }

    internal class BlackEnochianFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackEnochianFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<BLMGauge>();
            if (gauge.IsEnochianActive)
            {
                if (gauge.InUmbralIce && level >= BLM.Levels.Blizzard4)
                    return BLM.Blizzard4;
                if (level >= BLM.Levels.Fire4)
                    return BLM.Fire4;
            }

            if (level < BLM.Levels.Fire3)
                return BLM.Fire;

            if (gauge.InAstralFire && (level < BLM.Levels.Enochian || gauge.IsEnochianActive))
            {
                if (HasEffect(BLM.Buffs.Firestarter))
                    return BLM.Fire3;
                return BLM.Fire;
            }

            return actionID;
        }
    }

    internal class BlackManaFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackManaFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<BLMGauge>();
            if (gauge.InUmbralIce && gauge.IsEnochianActive && level >= BLM.Levels.UmbralSoul)
                return BLM.UmbralSoul;

            return actionID;
        }
    }

    internal class BlackLeyLinesFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackLeyLinesFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (HasEffect(BLM.Buffs.LeyLines) && level >= BLM.Levels.BetweenTheLines)
                return BLM.BetweenTheLines;

            return actionID;
        }
    }

    internal class BlackBlizzardFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackBlizzardFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == BLM.Blizzard)
            {
                var gauge = GetJobGauge<BLMGauge>();
                if (level >= BLM.Levels.Blizzard3 && !gauge.InUmbralIce)
                    return BLM.Blizzard3;
            }

            if (actionID == BLM.Freeze)
            {
                if (level < BLM.Levels.Freeze)
                    return BLM.Blizzard2;
            }

            return actionID;
        }
    }

    internal class BlackFireFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackFireFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<BLMGauge>();
            if (level >= BLM.Levels.Fire3 && (!gauge.InAstralFire || HasEffect(BLM.Buffs.Firestarter)))
                return BLM.Fire3;

            return actionID;
        }
    }

    internal class BlackScatheFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.BlackScatheFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<BLMGauge>();
            if (level >= BLM.Levels.Xenoglossy && gauge.PolyglotStacks > 0)
                return BLM.Xenoglossy;

            return actionID;
        }
    }
}
