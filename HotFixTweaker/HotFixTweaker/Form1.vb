Imports System.IO
Imports System.Net
Imports DevComponents.DotNetBar

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabItem2.Visible = False
        allpublichotfixes(1)
    End Sub

    Dim selectedtext, selectedfolder, savefilepath As String

    Function Readtextfromgithub(githubby As String) As String
        Dim address As String = githubby
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        Return reader.ReadToEnd
    End Function

    Function publichotfixes(selected As String, gity As String, loadordoubleclick As Boolean)
        If loadordoubleclick = True Then
            If Not ListBox3.Items.Contains(selected) Then
                ListBox3.Items.Add(selected)
            End If
        Else
            If ListBox3.SelectedItem = selected Then
                RichTextBoxEx2.Clear()
                RichTextBoxEx2.Text = Readtextfromgithub("https://raw.githubusercontent.com/BLCM/bl3mods/master/" + gity.Replace(" ", "%20").Replace("bl3mods/", "") + selected.Replace(" ", "%20"))
                TabControl4.SelectedTabIndex = 1
            End If
        End If
    End Function

    Function allpublichotfixes(loadordoubleclick As Boolean)
        publichotfixes("Amara True Melee.bl3hotfix", "CZ47/Amara/", loadordoubleclick)
        publichotfixes("Amara2.0.bl3hotfix", "CZ47/Amara/", loadordoubleclick)
        publichotfixes("Stronger Enemies Arms Race.bl3hotfix", "CZ47/Arms Race/", loadordoubleclick)
        publichotfixes("Barbaric Yawp Loaders.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick)
        publichotfixes("Barbaric Yawp Loaders.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick)
        publichotfixes("Custom Loader Names.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick)
        publichotfixes("Purple Tree Fl4k Overhaul.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick)
        publichotfixes("Really Lucky 7.bl3hotfix", "CZ47/Gear/", loadordoubleclick)
        publichotfixes("Spiritual Driver V1.bl3hotfix", "CZ47/Gear/", loadordoubleclick)
        publichotfixes("Increased Spawns.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("Increased spawns x10.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("Increased spawns x15.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("Increased spawns x20.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("Increased spawns x4.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("Increased spawns x40.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick)
        publichotfixes("4P Enemy Health in Solo Mode.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick)
        publichotfixes("Enhanced Enemies Mayhem10.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick)
        publichotfixes("Increased Mayhem8+ Enemy Health.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick)
        publichotfixes("MayhemScaled StatuseffectDamage.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick)
        publichotfixes("Reduced SpawnDelay MTD.bl3hotfix", "CZ47/Takedown/", loadordoubleclick)
        publichotfixes("No Elemental Penalties or Bonuses.bl3hotfix", "bl3mods/CZ47/Utility/", loadordoubleclick)
        publichotfixes("Unrestricted Skilltrees.bl3hotfix", "bl3mods/CZ47/Utility/", loadordoubleclick)
        publichotfixes("BetterSanctuary3Floors.bl3hotfix", "bl3mods/DexManly/BetterSanctuary3Floors/", loadordoubleclick)
        publichotfixes("Floor_Under_Kritchy.bl3hotfix", "bl3mods/DexManly/FloorUnderKritchy/", loadordoubleclick)
        publichotfixes("LessPunishingGuardianTakedownPlatforming.bl3hotfix", "bl3mods/DexManly/LessPunishingGuardianTakedownPlatforming/", loadordoubleclick)
        publichotfixes("Patch_Slaughterstar3000_BossLootDrop.bl3hotfix", "bl3mods/DexManly/PatchSlaughterstar3000BossDrop/", loadordoubleclick)
        publichotfixes("TrialNames_DisplayOnly.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick)
        publichotfixes("TrialNames_Full.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick)
        publichotfixes("TrialNames_SubHeader.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick)
        publichotfixes("NoXPBar.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick)
        publichotfixes("Small_Hud.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick)
        publichotfixes("Small_Hud_NoXPBar.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick)
        publichotfixes("Small_Hud_NoXPBar_NoCrosshair.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick)
        publichotfixes("Borderlands_3_Redux.bl3hotfix", "bl3mods/EpicNNG/", loadordoubleclick)
        publichotfixes("Melee Amara Adjustments.bl3hotfix", "bl3mods/Freezer/Amara/", loadordoubleclick)
        publichotfixes("White Elephant Rework.bl3hotfix", "bl3mods/Freezer/Artifacts/", loadordoubleclick)
        publichotfixes("Rough Rider Reborn.bl3hotfix", "bl3mods/Freezer/", loadordoubleclick)
        publichotfixes("Ward Reborn.bl3hotfix", "bl3mods/Freezer/", loadordoubleclick)
        publichotfixes("Nuclear Moze.bl3hotfix", "bl3mods/Freezer/Moze/", loadordoubleclick)
        publichotfixes("Elements_Dots_Overhaul.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick)
        publichotfixes("Weighted_Ammo.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick)
        publichotfixes("World_Drop_Scales_With_Your_Level.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick)
        publichotfixes("B3&2_NoMayhem.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick)
        publichotfixes("B3&2_RescaledMayhem.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick)
        publichotfixes("B3&2_RescaledMayhem_LessWorldDrop.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick)
        publichotfixes("B3&2_VanillaMayhem_NoModifiers.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick)
        publichotfixes("B3&2_VanillaMayhem_WithModifiers.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick)
        publichotfixes("Fl4k.bl3hotfix", "bl3mods/Grimm/FL4K/", loadordoubleclick)
        publichotfixes("Garcia_Full_Auto.bl3hotfix", "bl3mods/Grimm/Gear/Garcia/", loadordoubleclick)
        publichotfixes("unlocked_parts.bl3hotfix", "bl3mods/Jalokin333/Unlock Part Restrictions/", loadordoubleclick)
        publichotfixes("less_guaranteed_gun_accessoires.bl3hotfix", "bl3mods/Jalokin333/", loadordoubleclick)
        publichotfixes("Loot_the_Universe_Artifacts_to_Slaughterstar_3000.bl3hotfix", "bl3mods/Litch/", loadordoubleclick)
        publichotfixes("Loot_the_Universe_COMs_to_Slaughter_Shaft.bl3hotfix", "bl3mods/Litch/", loadordoubleclick)
        publichotfixes("Remove Health Gates.bl3hotfix", "bl3mods/Lonemasterino/", loadordoubleclick)
        publichotfixes("map_defogger.bl3hotfix", "bl3mods/Novenic/Map Defogger/", loadordoubleclick)
        publichotfixes("no_sparkles.bl3hotfix", "bl3mods/Novenic/No More Sparkles/", loadordoubleclick)
        publichotfixes("Infinite_Fade_Away_Duration.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick)
        publichotfixes("Infinite_Gamma_Burst_Duration.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick)
        publichotfixes("Leave_No_Trace_Old_Version.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick)
        publichotfixes("No_Action_Skills_Cooldown_Beastmaster.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick)
        publichotfixes("Instant_Pet_Respawn.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick)
        publichotfixes("PetZilla.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick)
        publichotfixes("PokePet.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick)
        publichotfixes("TrialNames_Full_FR.bl3hotfix", "bl3mods/Phenom/French Translations/", loadordoubleclick)
        publichotfixes("Better_Vending_Machines.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("Legendary_Price_Scaling.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("Moxxis_Tipping_Jar_Rewards.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("TVHM_Scale_From_Level1.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("Unlimited_Bank_Backpack.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("Unlimited_Vehicles_Boost.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick)
        publichotfixes("Infinite_SNTNL_Drone_Duration.bl3hotfix", "bl3mods/Phenom/Operative/", loadordoubleclick)
        publichotfixes("No_Action_Skills_Cooldown_Operative.bl3hotfix", "bl3mods/Phenom/Operative/", loadordoubleclick)
        publichotfixes("Faster Slide.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("Legendary Arms Race.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("No Barrier AmpShot VFX.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("No DOT Screams.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("Silent ActionSkill Cooldowns.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("Slide Jumper.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick)
        publichotfixes("non_slippery_crit.bl3hotfix", "bl3mods/Rumo/WeaponChanges/", loadordoubleclick)
        publichotfixes("green_monster_clickclick_fix.bl3hotfix", "bl3mods/SSpyR/bugfix/", loadordoubleclick)
        publichotfixes("god_bear.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick)
        publichotfixes("god_clone.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick)
        publichotfixes("god_skag.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick)
        publichotfixes("enemy_gear_drops.bl3hotfix", "bl3mods/SSpyR/enemy/", loadordoubleclick)
        publichotfixes("guardiantd_health_changes.bl3hotfix", "bl3mods/SSpyR/enemy/", loadordoubleclick)
        publichotfixes("clear_skies.bl3hotfix", "bl3mods/SSpyR/event/", loadordoubleclick)
        publichotfixes("supercharged_crystals.bl3hotfix", "bl3mods/SSpyR/event/", loadordoubleclick)
        publichotfixes("dna_buff.bl3hotfix", "bl3mods/SSpyR/gear-general/", loadordoubleclick)
        publichotfixes("webslinger_buff.bl3hotfix", "bl3mods/SSpyR/gear-general/", loadordoubleclick)
        publichotfixes("no_anoint_balance.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick)
        publichotfixes("no_world_drops.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick)
        publichotfixes("trials_loot_changes.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick)
        publichotfixes("mayhem2_mods_no_weights.bl3hotfix", "bl3mods/SSpyR/mayhem/", loadordoubleclick)
        publichotfixes("gear_randomizer_nade.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick)
        publichotfixes("gear_randomizer_relic.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick)
        publichotfixes("gear_randomizer_shield.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick)
        publichotfixes("commit_phalanx_stack.bl3hotfix", "bl3mods/SSpyR/skill-changes/", loadordoubleclick)
        publichotfixes("zane_anarchy.bl3hotfix", "bl3mods/SSpyR/skill-changes/", loadordoubleclick)
        publichotfixes("StygianEmperor_COV_FasterEquipSpeed.bl3hotfix", "bl3mods/Stygian Emperor/COV/FasterEquipSpeed/", loadordoubleclick)
        publichotfixes("StygianEmperor_Consistent_Mitigated_Element_Influence.bl3hotfix", "bl3mods/Stygian Emperor/Consistent Mitigated Element Influence/", loadordoubleclick)
        publichotfixes("StygianEmperor_HeavyWeapons_NoSpeedPenalty.bl3hotfix", "bl3mods/Stygian Emperor/HeavyWeapons/NoSpeedPenalty/", loadordoubleclick)
        publichotfixes("StygianEmperor_IronBearNoSelfDamage.bl3hotfix", "bl3mods/Stygian Emperor/Moze/Iron Bear No Self Damage/", loadordoubleclick)
        publichotfixes("StygianEmperor_IronBearUnlimitedFuel.bl3hotfix", "bl3mods/Stygian Emperor/Moze/IronBearUnlimitedFuel/", loadordoubleclick)
        publichotfixes("StygianEmperor_IronBearUnlimitedFuel_FullRefund.bl3hotfix", "bl3mods/Stygian Emperor/Moze/IronBearUnlimitedFuel/", loadordoubleclick)
        publichotfixes("StygianEmperor_Moze_ReactiveArmor.bl3hotfix", "bl3mods/Stygian Emperor/Moze/Reactive Armor/", loadordoubleclick)
        publichotfixes("StygianEmperor_RelaxedSkillRequirements.bl3hotfix", "bl3mods/Stygian Emperor/Relaxed Skill Requirements/", loadordoubleclick)
        publichotfixes("StygianEmperor_SilenceMessyBreakup.bl3hotfix", "bl3mods/Stygian Emperor/Shields/SilenceMessyBreakup/", loadordoubleclick)
        publichotfixes("Guardian Angel Nerf 250%.bl3hotfix", "bl3mods/TheGigaMaster/Guardian Angel Nerf/", loadordoubleclick)
        publichotfixes("Guardian Angel Nerf 400%.bl3hotfix", "bl3mods/TheGigaMaster/Guardian Angel Nerf/", loadordoubleclick)
        publichotfixes("Weapon_Balance_Overhaul.bl3hotfix", "bl3mods/TheGigaMaster/Major Weapon Overhaul/", loadordoubleclick)
        publichotfixes("ReVolter 150% Reduction.bl3hotfix", "bl3mods/TheGigaMaster/ReVolter Nerf/", loadordoubleclick)
        publichotfixes("ReVolter 175% Reduction.bl3hotfix", "bl3mods/TheGigaMaster/ReVolter Nerf/", loadordoubleclick)
        publichotfixes("TheNotSoFakobs.bl3hotfix", "bl3mods/TheGigaMaster/The Fakobs Buff/", loadordoubleclick)
        publichotfixes("TheNotSoFakobs_Redux_Compatible.bl3hotfix", "bl3mods/TheGigaMaster/The Fakobs Buff/", loadordoubleclick)
        publichotfixes("varkid_always_evolve.bl3hotfix", "bl3mods/TheGigaMaster/Varkid Evolution Increase/", loadordoubleclick)
        publichotfixes("varkid_evolution_increase.bl3hotfix", "bl3mods/TheGigaMaster/Varkid Evolution Increase/", loadordoubleclick)
        publichotfixes("buffed_projected_shields.bl3hotfix", "bl3mods/TheNiTrex/BuffedProjectedShields/", loadordoubleclick)
        publichotfixes("ShowMeThePurplex2.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick)
        publichotfixes("ShowMeThePurplex20.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick)
        publichotfixes("ShowMeThePurplex5.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick)
        publichotfixes("BetterBrainstormer.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("FITSK Nuclear fallout.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("FullAutoAnarchy.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("MaggieTrickshotBalancing.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("OneOrphan.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("SolekiOrion.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("StackingR&R.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("bekahBuff.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("moreMaxAmmo.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("unBurstPlasma.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick)
        publichotfixes("3000_hyperion_slaughter.bl3hotfix", "bl3mods/altef-4/", loadordoubleclick)
        publichotfixes("3000_mob_spawn_mod.bl3hotfix", "bl3mods/altef-4/", loadordoubleclick)
        publichotfixes("Fixed Weapon Cards.bl3hotfix", "bl3mods/lollixlii/Fixed Weapon Cards/", loadordoubleclick)
        publichotfixes("Oldschool Mayhem.bl3hotfix", "bl3mods/lollixlii/Oldschool Mayhem/", loadordoubleclick)
        publichotfixes("RecursionBuff.bl3hotfix", "bl3mods/niol/Recursion Buff/", loadordoubleclick)
        publichotfixes("SuperballBuff.bl3hotfix", "bl3mods/niol/Superball Buff/", loadordoubleclick)
        publichotfixes("UndoMayhemLootHotfix.bl3hotfix", "bl3mods/notrixatenza/", loadordoubleclick)
        publichotfixes("Standalone Third Person.bl3hotfix", "bl3mods/screen names/", loadordoubleclick)
        publichotfixes("No Scaling.bl3hotfix", "bl3mods/shadowevil/", loadordoubleclick)
        publichotfixes("armsracestarter-blue.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick)
        publichotfixes("armsracestarter-green.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick)
        publichotfixes("armsracestarter-orange.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick)
        publichotfixes("armsracestarter-purple.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick)
        publichotfixes("billy-and-the-cloneasaurus.bl3hotfix", "bl3mods/skruntskrunt/boss-rush-slaughter/", loadordoubleclick)
        publichotfixes("boss_rush_3000.bl3hotfix", "bl3mods/skruntskrunt/boss-rush-slaughter/", loadordoubleclick)
        publichotfixes("bossrace.bl3hotfix", "bl3mods/skruntskrunt/bossrace/", loadordoubleclick)
        publichotfixes("chubby.bl3hotfix", "bl3mods/skruntskrunt/chubby/", loadordoubleclick)
        publichotfixes("mitosis.bl3hotfix", "bl3mods/skruntskrunt/mitosisharker/", loadordoubleclick)
        publichotfixes("omegamantakoreraid.bl3hotfix", "bl3mods/skruntskrunt/omegamantakoreraid/", loadordoubleclick)
        publichotfixes("raid.bl3hotfix", "bl3mods/skruntskrunt/raid/", loadordoubleclick)
        publichotfixes("truetrials.bl3hotfix", "bl3mods/skruntskrunt/truetrials/", loadordoubleclick)

    End Function

    Function Listboxrefresh(listybox As ListBox)
        listybox.Items.Clear()
        Dim files() As String = IO.Directory.GetFiles(selectedfolder)
        For Each item In files
            If item.Contains(".bl3hotfix") Then
                listybox.Items.Add(item)
            End If
        Next
    End Function

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If Not ListBox1.SelectedItem = Nothing Then
            selectedtext = ListBox1.SelectedItem
            TabControl1.SelectedTabIndex = 1
            If selectedtext.Contains(".bl3hotfix") Then
                RichTextBoxEx1.Clear()
                RichTextBoxEx1.Text = File.ReadAllText(selectedtext)
                TabItem2.Visible = True
            Else
                MessageBox.Show("Please Only Load bl3hotfix Files.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileToolStripMenuItem.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.Filter = "bl3hotfix Files (*.bl3hotfix*)|*.bl3hotfix"
        SaveFileDialog1.Title = "Save HotFix File."
        SaveFileDialog1.FileName = "Tweaked_" + Path.GetFileName(selectedtext)
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            savefilepath = SaveFileDialog1.FileName
            File.WriteAllText(SaveFileDialog1.FileName, RichTextBoxEx1.Text)
            ListBox1.Items.Add(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub AddItemToLisboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemToLisboxToolStripMenuItem.Click
        ListBox1.Items.Add(ToolStripTextBox1.Text)
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        If WordWrapToolStripMenuItem.Checked = True Then
            RichTextBoxEx1.WordWrap = True
        Else
            RichTextBoxEx1.WordWrap = False
        End If
    End Sub

    Private Sub LoadHotFixsDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadHotFixsDirectoryToolStripMenuItem.Click
        ListBox1.Items.Clear()
        Dim folderbroswer As New FolderBrowserDialog
        If folderbroswer.ShowDialog() = DialogResult.OK Then
            selectedfolder = folderbroswer.SelectedPath
            Dim files() As String = IO.Directory.GetFiles(selectedfolder)
            For Each item In files
                If item.Contains(".bl3hotfix") Then
                    ListBox1.Items.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub RefreshCurrentSelectedDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshCurrentSelectedDirectoryToolStripMenuItem.Click
        Listboxrefresh(ListBox1)
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        MessageBox.Show(ListBox2.SelectedItem, "Heads Up !", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
    End Sub

    Private Sub ListBox3_DoubleClick(sender As Object, e As EventArgs) Handles ListBox3.DoubleClick
        allpublichotfixes(0)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.Filter = "bl3hotfix Files (*.bl3hotfix*)|*.bl3hotfix"
        SaveFileDialog1.Title = "Save HotFix File."
        SaveFileDialog1.FileName = "HotFix.bl3hotfix"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            savefilepath = SaveFileDialog1.FileName
            File.WriteAllText(SaveFileDialog1.FileName, RichTextBoxEx2.Text)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ToolStripMenuItem2.Checked = True Then
            RichTextBoxEx2.WordWrap = True
        Else
            RichTextBoxEx2.WordWrap = False
        End If
    End Sub

    Private Sub RemoveItemFromListboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveItemFromListboxToolStripMenuItem.Click
        If Not ListBox1.SelectedItem = Nothing Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub DeleteSelectedFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedFileToolStripMenuItem.Click
        If MessageBox.Show("Are You Sure You Want To Delete " + ListBox1.SelectedItem + "", "Heads Up !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            If File.Exists(ListBox1.SelectedItem) Then
                File.Delete(ListBox1.SelectedItem)
                ListBox1.Items.Remove(ListBox1.SelectedItem)
            End If
        End If
    End Sub
End Class
