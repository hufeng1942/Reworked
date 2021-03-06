﻿namespace ElGalio.Components.Spells
{
    using System;
    using System.Linq;

    using ElGalio.Enumerations;
    using ElGalio.Utils;

    using LeagueSharp;
    using LeagueSharp.Common;

    using SharpDX;

    /// <summary>
    ///     The spell R.
    /// </summary>
    internal class SpellR : ISpell
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the damage type.
        /// </summary>
        internal override TargetSelector.DamageType DamageType => TargetSelector.DamageType.Magical;

        /// <summary>
        ///     Gets Aoe.
        /// </summary>
        internal override bool Aoe => true;

        /// <summary>
        ///     Gets the delay.
        /// </summary>
        internal override float Delay => 250f;

        /// <summary>
        ///     Gets the range.
        /// </summary>
        internal override float Range => 600f;

        /// <summary>
        ///     Gets the speed.
        /// </summary>
        internal override float Speed => 1000f;

        /// <summary>
        ///     Gets the spell slot.
        /// </summary>
        internal override SpellSlot SpellSlot => SpellSlot.R;

        /// <summary>
        ///     Gets the width.
        /// </summary>
        internal override float Width => 550f;

        #endregion

        #region Methods

        /// <summary>
        ///     The on combo callback.
        /// </summary>
        internal override void OnCombo()
        {
            try
            {
                if (this.SpellObject == null)
                {
                    return;
                }

                var target = Misc.GetTarget(this.Range, this.DamageType);
                if (target != null)
                {
                    var enemiesCount =
                        HeroManager.Enemies.Count(
                            x => x.IsValidTarget(this.Range + this.Width) && !x.IsDead && !x.IsZombie);

                    if (enemiesCount < MyMenu.RootMenu.Item("countrenemies").GetValue<Slider>().Value)
                    {
                        return;
                    }

                    // do other stuff..
                }
            }
            catch (Exception e)
            {
                Logging.AddEntry(LoggingEntryTrype.Error, "@SpellR.cs: Can not run OnCombo - {0}", e);
                throw;
            }
        }

        /// <summary>
        ///     The on mixed callback.
        /// </summary>
        internal override void OnMixed()
        {
            this.OnCombo();
        }


        /// <summary>
        ///     The on last hit callback.
        /// </summary>
        internal override void OnLastHit()
        {
        }

        /// <summary>
        ///     The on lane clear callback.
        /// </summary>
        internal override void OnLaneClear()
        {
        }

        /// <summary>
        ///     The on jungle clear callback.
        /// </summary>
        internal override void OnJungleClear()
        {
        }

        #endregion
    }
}