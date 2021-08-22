Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Form1
    Dim selectedtext, selectedfolder, savefilepath As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEx1.SelectedIndex = 0

        RichTextBoxEx8.Text = Readtextfromgithub("https://raw.githubusercontent.com/JamesCreations/Borderlands-3-HotFix-Tweaker/main/README.md")
        RichTextBoxEx6.Text = Readtextfromgithub("https://raw.githubusercontent.com/gibbed/Borderlands3Dumps/master/Inventory%20Serial%20Number%20Database.json").Replace(",", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(Chr(34), "")

        TabItem14.Text = "Inventory Dump ( Lines " + RichTextBoxEx6.Lines.Count.ToString + ")"

        RichTextBoxEx5.Text = Readtextfromgithub("https://raw.githubusercontent.com/BLCM/bl3hotfixes/master/hotfixes_current.json")

        TabItem24.Text = "Raw"

        For Each lines As String In RichTextBoxEx5.Lines
            If lines.Contains(Chr(34) + "key" + Chr(34) + ": ") Then
                ListBox15.Items.Add(lines.Replace(Chr(34) + "key" + Chr(34) + ": ", "").Replace(Chr(34), "").Replace(" ", "").Replace(",", ""))
            End If
        Next

        ListBox6.Visible = False
        ListBox7.Visible = False
        ListBox8.Visible = False
        ListBox9.Visible = False
        ListBox10.Visible = False
        ListBox11.Visible = False
        ListBox12.Visible = False
        ListBox14.Visible = False
        ListBox16.Visible = False


        TabItem2.Visible = False

        ListboxPopulationFunc(1)
        ListUserCodeItems(1)
        TabItem8.Text = "List (" + ListBox3.Items.Count.ToString + ")"

        ColorPickerButton1.SelectedColor = Color.Black
        ColorPickerButton2.SelectedColor = Color.Green
        ColorPickerButton3.SelectedColor = Color.Green
        ColorPickerButton4.SelectedColor = Color.Black

        If File.Exists(My.Application.Info.DirectoryPath + "\HotFixTweakerFavorites.hfts") Then
            For Each item In File.ReadAllLines(My.Application.Info.DirectoryPath + "\HotFixTweakerFavorites.hfts")
                ListBox4.Items.Add(item)
            Next
            TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
        End If

        If File.Exists(My.Application.Info.DirectoryPath + "\HotFixTweakerSettings.hfts") Then

            CheckBoxX1.Checked = Semiparseloadingvalues(2, "Use Initial HotFixes Directory On Load : ")
            TextBoxX1.Text = Semiparseloadingvalues(3, "Initial HotFixes Directory : ")
            ColorPickerButton1.SelectedColor = Color.FromArgb(Semiparseloadingvalues(4, "Session Editor Background Color R : "), Semiparseloadingvalues(5, "Session Editor Background Color G : "), Semiparseloadingvalues(6, "Session Editor Background Color B : "))
            ColorPickerButton2.SelectedColor = Color.FromArgb(Semiparseloadingvalues(7, "Session Editor Text Color R : "), Semiparseloadingvalues(8, "Session Editor Text Color G : "), Semiparseloadingvalues(9, "Session Editor Text Color B : "))
            ColorPickerButton4.SelectedColor = Color.FromArgb(Semiparseloadingvalues(10, "HotFix Code Background Color R : "), Semiparseloadingvalues(11, "HotFix Code Background Color G : "), Semiparseloadingvalues(12, "HotFix Code Background Color B : "))
            ColorPickerButton3.SelectedColor = Color.FromArgb(Semiparseloadingvalues(13, "HotFix Code Text Color R : "), Semiparseloadingvalues(14, "HotFix Code Text Color G : "), Semiparseloadingvalues(15, "HotFix Code Text Color B : "))
            CheckBoxX2.Checked = Semiparseloadingvalues(16, "Create Backups : ")


        End If

        If CheckBoxX1.Checked = True Then
            selectedfolder = TextBoxX1.Text
            Listboxrefresh(ListBox1)
            TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
        End If

        RichTextBoxEx1.BackColorRichTextBox = ColorPickerButton1.SelectedColor
        RichTextBoxEx1.ForeColor = ColorPickerButton2.SelectedColor
        RichTextBoxEx2.BackColorRichTextBox = ColorPickerButton4.SelectedColor
        RichTextBoxEx2.ForeColor = ColorPickerButton3.SelectedColor

    End Sub

    Function Semiparseloadingvalues(linenow As Integer, stringfromsettings As String) As String
        Dim Result As String

        Result = File.ReadLines(My.Application.Info.DirectoryPath + "\HotFixTweakerSettings.hfts")(linenow).Replace(stringfromsettings, "").Replace("(", "").Replace(")", "")
        Return Result
    End Function

    Function Readtextfromgithub(githubby As String) As String
        Dim address As String = githubby
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        Return reader.ReadToEnd
    End Function

#Region "User Codes"
    Dim countofcodes As Integer
    Function ListUserBL3CodesAndPopulate(selected As String, gity As String, loadordoubleclick As Boolean)
        If loadordoubleclick = True Then
            If Not ListBox5.Items.Contains(selected) Then
                ListBox5.Items.Add(selected)
            End If
        Else
            If ListBox5.SelectedItem = selected Then
                countofcodes = 0
                RichTextBoxEx7.Clear()
                RichTextBoxEx7.Text = Readtextfromgithub(gity)
                TabControl7.SelectedTabIndex = 1

                For Each line In RichTextBoxEx7.Lines
                    If line.Contains("bl3(") Or line.Contains("Bl3(") Or line.Contains("BL3(") Or line.Contains("bL3(") Then
                        countofcodes += 1
                    End If
                Next
                TabItem17.Text = "User : " + ListBox5.SelectedItem + " | Codes ( Amount Of Codes " + countofcodes.ToString + " | Lines " + RichTextBoxEx7.Lines.Count.ToString + ")"

            End If
        End If
        Return 0
    End Function
    Function ListUserCodeItems(loadordoubleclick As Boolean)
        ListUserBL3CodesAndPopulate("Aplixion", "https://raw.githubusercontent.com/Aplixion/Aplixions-Custom-Item-Codes/main/Aplixion's%20Custom%20Item%20Codes.txt", loadordoubleclick)
        Return 0
    End Function


#End Region

#Region "Public HotFixes List"
    Function publichotfixes(selected As String, gity As String, loadordoubleclick As Boolean, SwitchoffBLCM As Boolean)
        If loadordoubleclick = True Then
            If Not ListBox3.Items.Contains(selected) Then
                ListBox3.Items.Add(selected)
            End If
        Else
            If ListBox3.SelectedItem = selected Then
                RichTextBoxEx2.Clear()

                If SwitchoffBLCM = False Then
                    RichTextBoxEx2.Text = Readtextfromgithub("https://raw.githubusercontent.com/BLCM/bl3mods/master/" + gity.Replace(" ", "%20").Replace("bl3mods/", "") + selected.Replace(" ", "%20"))
                    ToolTip1.SetToolTip(ListBox3, "https://raw.githubusercontent.com/BLCM/bl3mods/master/" + gity.Replace(" ", "%20").Replace("bl3mods/", "") + selected.Replace(" ", "%20") + "
HotFix Lines : " + RichTextBoxEx2.Lines.Count.ToString)
                    TabItem9.Text = "HotFix Code ( Lines " + RichTextBoxEx2.Lines.Count.ToString + ")"

                Else

                    RichTextBoxEx2.Text = Readtextfromgithub(gity)
                    ToolTip1.SetToolTip(ListBox3, gity + "
HotFix Lines : " + RichTextBoxEx2.Lines.Count.ToString)
                    TabItem9.Text = "HotFix Code ( Lines " + RichTextBoxEx2.Lines.Count.ToString + ")"

                End If

                TabControl4.SelectedTabIndex = 1
            End If
        End If
        Return 0
    End Function

    Function ListboxPopulationFunc(loadordoubleclick As Boolean)
        publichotfixes("4P Enemy Health in Solo Mode.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick, 0)
        publichotfixes("3000_hyperion_slaughter.bl3hotfix", "bl3mods/altef-4/", loadordoubleclick, 0)
        publichotfixes("3000_mob_spawn_mod.bl3hotfix", "bl3mods/altef-4/", loadordoubleclick, 0)
        publichotfixes("all_weapons_can_anoint.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/all_weapons_can_anoint/", loadordoubleclick, 0)
        publichotfixes("alternate_scaling_bl1.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/alternate_scaling/", loadordoubleclick, 0)
        publichotfixes("alternate_scaling_bl2.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/alternate_scaling/", loadordoubleclick, 0)
        publichotfixes("alternate_scaling_tps.bl3hotfix", "Abl3mods/pocalyptech/gameplay_changes/alternate_scaling/", loadordoubleclick, 0)
        publichotfixes("Amara2.0.bl3hotfix", "CZ47/Amara/", loadordoubleclick, 0)
        publichotfixes("Amara True Melee.bl3hotfix", "CZ47/Amara/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_1.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_10.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_25.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_50.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_100.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_150.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_200.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("anointment_reroll_cost_free.bl3hotfix", "bl3mods/Apocalyptech/economy/anointment_reroll_cost/", loadordoubleclick, 0)
        publichotfixes("armsracestarter-blue.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick, 0)
        publichotfixes("armsracestarter-green.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick, 0)
        publichotfixes("armsracestarter-orange.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick, 0)
        publichotfixes("armsracestarter-purple.bl3hotfix", "bl3mods/skruntskrunt/armsracestarterchest/", loadordoubleclick, 0)
        publichotfixes("B3&2_NoMayhem.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick, 0)
        publichotfixes("B3&2_RescaledMayhem.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick, 0)
        publichotfixes("B3&2_RescaledMayhem_LessWorldDrop.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick, 0)
        publichotfixes("B3&2_VanillaMayhem_NoModifiers.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick, 0)
        publichotfixes("B3&2_VanillaMayhem_WithModifiers.bl3hotfix", "bl3mods/Grimm/Borderlands 3&2/", loadordoubleclick, 0)
        publichotfixes("Barbaric Yawp Loaders.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick, 0)
        publichotfixes("bekahBuff.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("BetterBrainstormer.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("BetterSanctuary3Floors.bl3hotfix", "bl3mods/DexManly/BetterSanctuary3Floors/", loadordoubleclick, 0)
        publichotfixes("better_maliwan_charge_time.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/better_maliwan_charge_time/", loadordoubleclick, 0)
        publichotfixes("better_mayhem_rewards.bl3hotfix", "bl3mods/Apocalyptech/mayhem/better_mayhem_rewards/", loadordoubleclick, 0)
        publichotfixes("better_slots.bl3hotfix", "bl3mods/Apocalyptech/economy/better_slots/", loadordoubleclick, 0)
        publichotfixes("Better_Vending_Machines.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("billy-and-the-cloneasaurus.bl3hotfix", "bl3mods/skruntskrunt/boss-rush-slaughter/", loadordoubleclick, 0)
        publichotfixes("black_market_world_drops.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/black_market_world_drops/", loadordoubleclick, 0)
        publichotfixes("Borderlands_3_Redux.bl3hotfix", "bl3mods/EpicNNG/", loadordoubleclick, 0)
        publichotfixes("bossrace.bl3hotfix", "bl3mods/skruntskrunt/bossrace/", loadordoubleclick, 0)
        publichotfixes("boss_drop_randomizer.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/boss_drop_randomizer/", loadordoubleclick, 0)
        publichotfixes("boss_rush_3000.bl3hotfix", "bl3mods/skruntskrunt/boss-rush-slaughter/", loadordoubleclick, 0)
        publichotfixes("buffed_projected_shields.bl3hotfix", "bl3mods/TheNiTrex/BuffedProjectedShields/", loadordoubleclick, 0)
        publichotfixes("cheaper_eridium_economy.bl3hotfix", "bl3mods/Apocalyptech/economy/cheaper_eridium_economy/", loadordoubleclick, 0)
        publichotfixes("cheaper_sdus.bl3hotfix", "bl3mods/Apocalyptech/economy/cheaper_sdus/", loadordoubleclick, 0)
        publichotfixes("cheaper_slots.bl3hotfix", "bl3mods/Apocalyptech/economy/cheaper_slots/", loadordoubleclick, 0)
        publichotfixes("chubby.bl3hotfix", "bl3mods/skruntskrunt/chubby/", loadordoubleclick, 0)
        publichotfixes("clear_skies.bl3hotfix", "bl3mods/SSpyR/event/", loadordoubleclick, 0)
        publichotfixes("commit_phalanx_stack.bl3hotfix", "bl3mods/SSpyR/skill-changes/", loadordoubleclick, 0)
        publichotfixes("customizations_only_heads_and_skins.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/customizations_only_heads_and_skins/", loadordoubleclick, 0)
        publichotfixes("customization_drop_rate_constant.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/customization_drop_rate/", loadordoubleclick, 0)
        publichotfixes("customization_drop_rate_frequent.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/customization_drop_rate/", loadordoubleclick, 0)
        publichotfixes("customization_drop_rate_improved.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/customization_drop_rate/", loadordoubleclick, 0)
        publichotfixes("customization_drop_rate_none.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/customization_drop_rate/", loadordoubleclick, 0)
        publichotfixes("Custom Loader Names.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick, 0)
        publichotfixes("dlc_loot_de-emphasizer.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/dlc_loot_de-emphasizer/", loadordoubleclick, 0)
        publichotfixes("dna_buff.bl3hotfix", "bl3mods/SSpyR/gear-general/", loadordoubleclick, 0)
        publichotfixes("early_bloomer.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/early_bloomer/", loadordoubleclick, 0)
        publichotfixes("Elements_Dots_Overhaul.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick, 0)
        publichotfixes("enable_pendant_of_terra", "bl3mods/Apocalyptech/loot_changes/enable_pendant_of_terra/", loadordoubleclick, 0)
        publichotfixes("enemy_equips_all.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/enemy_equips/", loadordoubleclick, 0)
        publichotfixes("enemy_equips_legendaries_all.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/enemy_equips/", loadordoubleclick, 0)
        publichotfixes("enemy_equips_legendaries_typelocked.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/enemy_equips/", loadordoubleclick, 0)
        publichotfixes("enemy_equips_shoddy.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/enemy_equips/", loadordoubleclick, 0)
        publichotfixes("enemy_equips_typelocked.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/enemy_equips/", loadordoubleclick, 0)
        publichotfixes("enemy_gear_drops.bl3hotfix", "bl3mods/SSpyR/enemy/", loadordoubleclick, 0)
        publichotfixes("Enhanced Enemies Mayhem10.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick, 0)
        publichotfixes("expanded_legendary_pools.bl3hotfix", "bl3mods/Apocalyptech/loot_changes/expanded_legendary_pools/", loadordoubleclick, 0)
        publichotfixes("fabricator_eridium.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/fabricator/", loadordoubleclick, 0)
        publichotfixes("fabricator_rapidfire.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/fabricator/", loadordoubleclick, 0)
        publichotfixes("fabricator_replicator.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/fabricator/", loadordoubleclick, 0)
        publichotfixes("Faster Slide.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("FITSK Nuclear fallout.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("Fixed Weapon Cards.bl3hotfix", "bl3mods/lollixlii/Fixed Weapon Cards/", loadordoubleclick, 0)
        publichotfixes("fix_siren_com_blank_parts.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/fix_siren_com_blank_parts/", loadordoubleclick, 0)
        publichotfixes("Fl4k.bl3hotfix", "bl3mods/Grimm/FL4K/", loadordoubleclick, 0)
        publichotfixes("Floor_Under_Kritchy.bl3hotfix", "bl3mods/DexManly/FloorUnderKritchy/", loadordoubleclick, 0)
        publichotfixes("free_respawn.bl3hotfix", "bl3mods/Apocalyptech/economy/free_respawn/", loadordoubleclick, 0)
        publichotfixes("free_respec.bl3hotfix", "bl3mods/Apocalyptech/economy/free_respec/", loadordoubleclick, 0)
        publichotfixes("FullAutoAnarchy.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("Garcia_Full_Auto.bl3hotfix", "bl3mods/Grimm/Gear/Garcia/", loadordoubleclick, 0)
        publichotfixes("gear_randomizer_nade.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick, 0)
        publichotfixes("gear_randomizer_relic.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick, 0)
        publichotfixes("gear_randomizer_shield.bl3hotfix", "bl3mods/SSpyR/randomizer/", loadordoubleclick, 0)
        publichotfixes("god_bear.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick, 0)
        publichotfixes("god_clone.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick, 0)
        publichotfixes("god_skag.bl3hotfix", "bl3mods/SSpyR/cheat_or_joke/", loadordoubleclick, 0)
        publichotfixes("green_monster_clickclick_fix.bl3hotfix", "bl3mods/SSpyR/bugfix/", loadordoubleclick, 0)
        publichotfixes("guaranteed_rare_spawns.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/guaranteed_rare_spawns/", loadordoubleclick, 0)
        publichotfixes("Guardian Angel Nerf 250%.bl3hotfix", "bl3mods/TheGigaMaster/Guardian Angel Nerf/", loadordoubleclick, 0)
        publichotfixes("Guardian Angel Nerf 400%.bl3hotfix", "bl3mods/TheGigaMaster/Guardian Angel Nerf/", loadordoubleclick, 0)
        publichotfixes("guardiantd_health_changes.bl3hotfix", "bl3mods/SSpyR/enemy/", loadordoubleclick, 0)
        publichotfixes("Increased Mayhem8+ Enemy Health.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick, 0)
        publichotfixes("Increased Spawns.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("Increased spawns x4.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("Increased spawns x10.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("Increased spawns x15.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("Increased spawns x20.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("Increased spawns x40.bl3hotfix", "CZ47/Increased Spawns/", loadordoubleclick, 0)
        publichotfixes("infighting.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/infighting/", loadordoubleclick, 0)
        publichotfixes("Infinite_Fade_Away_Duration.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick, 0)
        publichotfixes("Infinite_Gamma_Burst_Duration.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick, 0)
        publichotfixes("infinite_slide.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/infinite_slide/", loadordoubleclick, 0)
        publichotfixes("Infinite_SNTNL_Drone_Duration.bl3hotfix", "bl3mods/Phenom/Operative/", loadordoubleclick, 0)
        publichotfixes("Instant_Pet_Respawn.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick, 0)
        publichotfixes("Leave_No_Trace_Old_Version.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick, 0)
        publichotfixes("Legendary Arms Race.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("Legendary_Price_Scaling.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("LessPunishingGuardianTakedownPlatforming.bl3hotfix", "bl3mods/DexManly/LessPunishingGuardianTakedownPlatforming/", loadordoubleclick, 0)
        publichotfixes("less_guaranteed_gun_accessoires.bl3hotfix", "bl3mods/Jalokin333/", loadordoubleclick, 0)
        publichotfixes("Loot_the_Universe_Artifacts_to_Slaughterstar_3000.bl3hotfix", "bl3mods/Litch/", loadordoubleclick, 0)
        publichotfixes("Loot_the_Universe_COMs_to_Slaughter_Shaft.bl3hotfix", "bl3mods/Litch/", loadordoubleclick, 0)
        publichotfixes("MaggieTrickshotBalancing.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("map_defogger.bl3hotfix", "bl3mods/Novenic/Map Defogger/", loadordoubleclick, 0)
        publichotfixes("mayhem2_mods_no_weights.bl3hotfix", "bl3mods/SSpyR/mayhem/", loadordoubleclick, 0)
        publichotfixes("MayhemScaled StatuseffectDamage.bl3hotfix", "CZ47/Mayhem/", loadordoubleclick, 0)
        publichotfixes("Melee Amara Adjustments.bl3hotfix", "bl3mods/Freezer/Amara/", loadordoubleclick, 0)
        publichotfixes("mitosis.bl3hotfix", "bl3mods/skruntskrunt/mitosisharker/", loadordoubleclick, 0)
        publichotfixes("money_grenade_changes_diamondkeys.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/money_grenade_changes/", loadordoubleclick, 0)
        publichotfixes("money_grenade_changes_eridium.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/money_grenade_changes/", loadordoubleclick, 0)
        publichotfixes("money_grenade_changes_grenades.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/money_grenade_changes/", loadordoubleclick, 0)
        publichotfixes("money_grenade_changes_loot.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/money_grenade_changes/", loadordoubleclick, 0)
        publichotfixes("moreMaxAmmo.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("movement_speed_cheats_extreme.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/movement_speed_cheats/", loadordoubleclick, 0)
        publichotfixes("Moxxis_Tipping_Jar_Rewards.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("No Barrier AmpShot VFX.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("No DOT Screams.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("No Elemental Penalties or Bonuses.bl3hotfix", "bl3mods/CZ47/Utility/", loadordoubleclick, 0)
        publichotfixes("non_slippery_crit.bl3hotfix", "bl3mods/Rumo/WeaponChanges/", loadordoubleclick, 0)
        publichotfixes("No Scaling.bl3hotfix", "bl3mods/shadowevil/", loadordoubleclick, 0)
        publichotfixes("NoXPBar.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick, 0)
        publichotfixes("No_Action_Skills_Cooldown_Beastmaster.bl3hotfix", "bl3mods/Phenom/Beastmaster/", loadordoubleclick, 0)
        publichotfixes("No_Action_Skills_Cooldown_Operative.bl3hotfix", "bl3mods/Phenom/Operative/", loadordoubleclick, 0)
        publichotfixes("no_anoint_balance.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick, 0)
        publichotfixes("no_world_drops.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick, 0)
        publichotfixes("Nuclear Moze.bl3hotfix", "bl3mods/Freezer/Moze/", loadordoubleclick, 0)
        publichotfixes("nvhm_gamestage_follows_level.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/nvhm_gamestage_follows_level/", loadordoubleclick, 0)
        publichotfixes("Oldschool Mayhem.bl3hotfix", "bl3mods/lollixlii/Oldschool Mayhem/", loadordoubleclick, 0)
        publichotfixes("omegamantakoreraid.bl3hotfix", "bl3mods/skruntskrunt/omegamantakoreraid/", loadordoubleclick, 0)
        publichotfixes("OneOrphan.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("Patch_Slaughterstar3000_BossLootDrop.bl3hotfix", "bl3mods/DexManly/PatchSlaughterstar3000BossDrop/", loadordoubleclick, 0)
        publichotfixes("PetZilla.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick, 0)
        publichotfixes("PokePet.bl3hotfix", "bl3mods/Phenom/Beastmaster/Pets/", loadordoubleclick, 0)
        publichotfixes("Purple Tree Fl4k Overhaul.bl3hotfix", "CZ47/Fl4k/", loadordoubleclick, 0)
        publichotfixes("raid.bl3hotfix", "bl3mods/skruntskrunt/raid/", loadordoubleclick, 0)
        publichotfixes("Really Lucky 7.bl3hotfix", "CZ47/Gear/", loadordoubleclick, 0)
        publichotfixes("RecursionBuff.bl3hotfix", "bl3mods/niol/Recursion Buff/", loadordoubleclick, 0)
        publichotfixes("Reduced SpawnDelay MTD.bl3hotfix", "CZ47/Takedown/", loadordoubleclick, 0)
        publichotfixes("Remove Health Gates.bl3hotfix", "bl3mods/Lonemasterino/", loadordoubleclick, 0)
        publichotfixes("ReVolter 150% Reduction.bl3hotfix", "bl3mods/TheGigaMaster/ReVolter Nerf/", loadordoubleclick, 0)
        publichotfixes("ReVolter 175% Reduction.bl3hotfix", "bl3mods/TheGigaMaster/ReVolter Nerf/", loadordoubleclick, 0)
        publichotfixes("Rough Rider Reborn.bl3hotfix", "bl3mods/Freezer/", loadordoubleclick, 0)
        publichotfixes("ShowMeThePurplex2.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick, 0)
        publichotfixes("ShowMeThePurplex5.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick, 0)
        publichotfixes("ShowMeThePurplex20.bl3hotfix", "bl3mods/ZetaDaemon/ShowMeThePurple/", loadordoubleclick, 0)
        publichotfixes("Silent ActionSkill Cooldowns.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("sizemod_npc_0.4_tiny.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/sizemod/", loadordoubleclick, 0)
        publichotfixes("sizemod_npc_0.7_smol.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/sizemod/", loadordoubleclick, 0)
        publichotfixes("sizemod_npc_2.0_big.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/sizemod/", loadordoubleclick, 0)
        publichotfixes("sizemod_npc_3.0_huge.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/sizemod/", loadordoubleclick, 0)
        publichotfixes("sizemod_npc_5.0_giant.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/sizemod/", loadordoubleclick, 0)
        publichotfixes("Slide Jumper.bl3hotfix", "bl3mods/Poïpoï/", loadordoubleclick, 0)
        publichotfixes("Small_Hud.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick, 0)
        publichotfixes("Small_Hud_NoXPBar.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick, 0)
        publichotfixes("Small_Hud_NoXPBar_NoCrosshair.bl3hotfix", "bl3mods/Elektrohund/UI_Mods/", loadordoubleclick, 0)
        publichotfixes("SolekiOrion.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("Spiritual Driver V1.bl3hotfix", "CZ47/Gear/", loadordoubleclick, 0)
        publichotfixes("StackingR&R.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("Standalone Third Person.bl3hotfix", "bl3mods/screen names/", loadordoubleclick, 0)
        publichotfixes("Stronger Enemies Arms Race.bl3hotfix", "CZ47/Arms Race/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_Consistent_Mitigated_Element_Influence.bl3hotfix", "bl3mods/Stygian Emperor/Consistent Mitigated Element Influence/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_COV_FasterEquipSpeed.bl3hotfix", "bl3mods/Stygian Emperor/COV/FasterEquipSpeed/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_HeavyWeapons_NoSpeedPenalty.bl3hotfix", "bl3mods/Stygian Emperor/HeavyWeapons/NoSpeedPenalty/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_IronBearNoSelfDamage.bl3hotfix", "bl3mods/Stygian Emperor/Moze/Iron Bear No Self Damage/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_IronBearUnlimitedFuel.bl3hotfix", "bl3mods/Stygian Emperor/Moze/IronBearUnlimitedFuel/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_IronBearUnlimitedFuel_FullRefund.bl3hotfix", "bl3mods/Stygian Emperor/Moze/IronBearUnlimitedFuel/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_Moze_ReactiveArmor.bl3hotfix", "bl3mods/Stygian Emperor/Moze/Reactive Armor/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_RelaxedSkillRequirements.bl3hotfix", "bl3mods/Stygian Emperor/Relaxed Skill Requirements/", loadordoubleclick, 0)
        publichotfixes("StygianEmperor_SilenceMessyBreakup.bl3hotfix", "bl3mods/Stygian Emperor/Shields/SilenceMessyBreakup/", loadordoubleclick, 0)
        publichotfixes("SuperballBuff.bl3hotfix", "bl3mods/niol/Superball Buff/", loadordoubleclick, 0)
        publichotfixes("supercharged_crystals.bl3hotfix", "bl3mods/SSpyR/event/", loadordoubleclick, 0)
        publichotfixes("TheNotSoFakobs.bl3hotfix", "bl3mods/TheGigaMaster/The Fakobs Buff/", loadordoubleclick, 0)
        publichotfixes("TheNotSoFakobs_Redux_Compatible.bl3hotfix", "bl3mods/TheGigaMaster/The Fakobs Buff/", loadordoubleclick, 0)
        publichotfixes("TrialNames_DisplayOnly.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick, 0)
        publichotfixes("TrialNames_Full.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick, 0)
        publichotfixes("TrialNames_Full_FR.bl3hotfix", "bl3mods/Phenom/French Translations/", loadordoubleclick, 0)
        publichotfixes("TrialNames_SubHeader.bl3hotfix", "bl3mods/DexManly/TrialNames/", loadordoubleclick, 0)
        publichotfixes("trials_loot_changes.bl3hotfix", "bl3mods/SSpyR/loot-system/", loadordoubleclick, 0)
        publichotfixes("truetrials.bl3hotfix", "bl3mods/skruntskrunt/truetrials/", loadordoubleclick, 0)
        publichotfixes("TVHM_Scale_From_Level1.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("unBurstPlasma.bl3hotfix", "bl3mods/ZetaDaemon/", loadordoubleclick, 0)
        publichotfixes("UndoMayhemLootHotfix.bl3hotfix", "bl3mods/notrixatenza/", loadordoubleclick, 0)
        publichotfixes("uniques_are_legendary.bl3hotfix", "bl3mods/Apocalyptech/gear_changes/uniques_are_legendary/", loadordoubleclick, 0)
        publichotfixes("Unlimited_Bank_Backpack.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("Unlimited_Vehicles_Boost.bl3hotfix", "bl3mods/Phenom/General/", loadordoubleclick, 0)
        publichotfixes("unlocked_parts.bl3hotfix", "bl3mods/Jalokin333/Unlock Part Restrictions/", loadordoubleclick, 0)
        publichotfixes("unlocked_vermivorous.bl3hotfix", "bl3mods/Apocalyptech/enemy_spawn_changes/unlocked_vermivorous/", loadordoubleclick, 0)
        publichotfixes("unlock_dlc3_tech.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/unlock_dlc3_tech/", loadordoubleclick, 0)
        publichotfixes("Unrestricted Skilltrees.bl3hotfix", "bl3mods/CZ47/Utility/", loadordoubleclick, 0)
        publichotfixes("varkid_always_evolve.bl3hotfix", "bl3mods/TheGigaMaster/Varkid Evolution Increase/", loadordoubleclick, 0)
        publichotfixes("varkid_evolution_increase.bl3hotfix", "bl3mods/TheGigaMaster/Varkid Evolution Increase/", loadordoubleclick, 0)
        publichotfixes("vehicle_unlocks.bl3hotfix", "bl3mods/Apocalyptech/gameplay_changes/vehicle_unlocks/", loadordoubleclick, 0)
        publichotfixes("Ward Reborn.bl3hotfix", "bl3mods/Freezer/", loadordoubleclick, 0)
        publichotfixes("Weapon_Balance_Overhaul.bl3hotfix", "bl3mods/TheGigaMaster/Major Weapon Overhaul/", loadordoubleclick, 0)
        publichotfixes("webslinger_buff.bl3hotfix", "bl3mods/SSpyR/gear-general/", loadordoubleclick, 0)
        publichotfixes("Weighted_Ammo.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick, 0)
        publichotfixes("White Elephant Rework.bl3hotfix", "bl3mods/Freezer/Artifacts/", loadordoubleclick, 0)
        publichotfixes("World_Drop_Scales_With_Your_Level.bl3hotfix", "bl3mods/Grimm/", loadordoubleclick, 0)
        publichotfixes("zane_anarchy.bl3hotfix", "bl3mods/SSpyR/skill-changes/", loadordoubleclick, 0)

        Return 0
    End Function
#End Region

    Function randomizerfromfile(filepath As String, richy As RichTextBoxEx)
        richy.Clear()
        Dim int As Integer
        For int = 0 To NumericUpDown2.Value - 1
            Static Dim randomint As New Random
            Dim stringresult As String = File.ReadLines(filepath)(randomint.Next(0, File.ReadLines(filepath).Count))



            richy.AppendText(stringresult + Environment.NewLine)
        Next
        Return 0
    End Function




    Function WriteTextToFile(filename As String, ext As String, textbox As RichTextBoxEx)
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.Filter = "" + ext + " Files (*." + ext + "*)|*." + ext + ""
        SaveFileDialog1.Title = "Save " + ext + " File/s."
        SaveFileDialog1.FileName = filename + "." + ext + ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            savefilepath = SaveFileDialog1.FileName
            File.WriteAllText(SaveFileDialog1.FileName, textbox.Text)
        End If
        Return 0
    End Function

    Function Listboxrefresh(listybox As ListBox)
        listybox.Items.Clear()
        Dim files() As String = IO.Directory.GetFiles(selectedfolder)
        For Each item In files
            If item.Contains(".bl3hotfix") Then
                listybox.Items.Add(item)
            End If
        Next
        Return 0
    End Function

    Function Searchresults(listtosearch As ListBox, texttosearchfor As TextBoxX, listtosearchfrom As ListBox, richtextboxtosearchfrom As RichTextBoxEx, switchforcontrol As Integer, e As KeyEventArgs)

        If e.KeyData = Keys.Enter Then
            listtosearch.Items.Clear()
            If switchforcontrol = 0 Then
                For Each item As String In listtosearchfrom.Items
                    If Regex.IsMatch(item, texttosearchfor.Text, RegexOptions.IgnoreCase) Then
                        listtosearch.Items.Add(item)
                    Else
                        listtosearch.Visible = False
                    End If
                Next
            Else
                For Each item As String In richtextboxtosearchfrom.Lines
                    If Regex.IsMatch(item, texttosearchfor.Text, RegexOptions.IgnoreCase) Then
                        listtosearch.Items.Add(item)
                    Else
                        listtosearch.Visible = False
                    End If
                Next
            End If

            If String.IsNullOrEmpty(texttosearchfor.Text) Then
                listtosearch.Visible = False
            Else
                If listtosearch.Items.Count > 0 Then
                    listtosearch.Visible = True
                End If
            End If
        End If
        Return 0
    End Function

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If Not ListBox1.SelectedItem = Nothing Then
            selectedtext = ListBox1.SelectedItem
            TabControl1.SelectedTabIndex = 1
            If selectedtext.Contains(".bl3hotfix") Then
                RichTextBoxEx1.Clear()
                If CheckBoxX2.Checked Then
                    File.WriteAllText(Path.GetFileName(selectedtext) + ".bak", File.ReadAllText(selectedtext))

                End If
                RichTextBoxEx1.Text = File.ReadAllText(selectedtext)
                TabItem2.Visible = True
                TabItem6.Text = "Session Editor ( Lines " + RichTextBoxEx1.Lines.Count.ToString + ")"

            Else
                MessageBox.Show("Please Only Load bl3hotfix Files.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileToolStripMenuItem.Click
        WriteTextToFile("Tweaked_" + Path.GetFileName(selectedtext), "bl3hotfix", RichTextBoxEx1)
    End Sub

    Private Sub AddItemToLisboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemToLisboxToolStripMenuItem.Click
        ListBox1.Items.Add(ToolStripTextBox1.Text)
        TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
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
        TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
    End Sub

    Private Sub RefreshCurrentSelectedDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshCurrentSelectedDirectoryToolStripMenuItem.Click
        If ListBox1.Items.Count > 0 Then

            Listboxrefresh(ListBox1)
            TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
        End If
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        MessageBox.Show(ListBox2.SelectedItem, "Heads Up !", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
    End Sub

    Private Sub ListBox3_DoubleClick(sender As Object, e As EventArgs) Handles ListBox3.DoubleClick
        ListboxPopulationFunc(0)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        WriteTextToFile("HotFix", "bl3hotfix", RichTextBoxEx2)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ToolStripMenuItem2.Checked = True Then
            RichTextBoxEx2.WordWrap = True
        Else
            RichTextBoxEx2.WordWrap = False
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        File.WriteAllText(My.Application.Info.DirectoryPath + "\HotFixTweakerSettings.hfts",
"Only Change Stuff Wrapped In Brackets () And Do Not Add/Remove Any Lines Or You Will Break Stuff.

Use Initial HotFixes Directory On Load : (" + CheckBoxX1.Checked.ToString + ")
Initial HotFixes Directory : (" + TextBoxX1.Text + ")
Session Editor Background Color R : (" + ColorPickerButton1.SelectedColor.R.ToString + ")
Session Editor Background Color G : (" + ColorPickerButton1.SelectedColor.G.ToString + ")
Session Editor Background Color B : (" + ColorPickerButton1.SelectedColor.B.ToString + ")
Session Editor Text Color R : (" + ColorPickerButton2.SelectedColor.R.ToString + ")
Session Editor Text Color G : (" + ColorPickerButton2.SelectedColor.G.ToString + ")
Session Editor Text Color B : (" + ColorPickerButton2.SelectedColor.B.ToString + ")
HotFix Code Background Color R : (" + ColorPickerButton4.SelectedColor.R.ToString + ")
HotFix Code Background Color G : (" + ColorPickerButton4.SelectedColor.G.ToString + ")
HotFix Code Background Color B : (" + ColorPickerButton4.SelectedColor.B.ToString + ")
HotFix Code Text Color R : (" + ColorPickerButton3.SelectedColor.R.ToString + ")
HotFix Code Text Color G : (" + ColorPickerButton3.SelectedColor.G.ToString + ")
HotFix Code Text Color B : (" + ColorPickerButton3.SelectedColor.B.ToString + ")
Create Backups : (" + CheckBoxX2.Checked.ToString + ")
")
        If ListBox4.Items.Count > 0 Then
            File.Delete(My.Application.Info.DirectoryPath + "\HotFixTweakerFavorites.hfts")
            For Each item In ListBox4.Items
                File.AppendAllText(My.Application.Info.DirectoryPath + "\HotFixTweakerFavorites.hfts", item)

            Next
        End If


    End Sub

    Private Sub AddToFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToFavoritesToolStripMenuItem.Click
        ListBox4.Items.Add(RichTextBoxEx1.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub AddItemToListboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemToListboxToolStripMenuItem.Click
        ListBox4.Items.Add(ToolStripTextBox2.Text)

        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub RemoveSelectedItemFromFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSelectedItemFromFavoritesToolStripMenuItem.Click
        If Not ListBox4.SelectedItem = Nothing Then
            ListBox4.Items.Remove(ListBox4.SelectedItem)
            TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
        End If
    End Sub

    Private Sub AddToFavoritesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToFavoritesToolStripMenuItem1.Click
        ListBox4.Items.Add(RichTextBoxEx2.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ListBox4.Items.Add(RichTextBoxEx6.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If ToolStripMenuItem5.Checked = True Then
            RichTextBoxEx6.WordWrap = True
        Else
            RichTextBoxEx6.WordWrap = False
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        WriteTextToFile("Inventory_Raw", "json", RichTextBoxEx6)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ListBox4.Items.Add(RichTextBoxEx7.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Static Dim randomnow As New Random
        WriteTextToFile("PlayerCodes_" + randomnow.Next(0, 1000).ToString, "txt", RichTextBoxEx7)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If ToolStripMenuItem8.Checked = True Then
            RichTextBoxEx7.WordWrap = True
        Else
            RichTextBoxEx7.WordWrap = False
        End If
    End Sub

    Private Sub ListBox5_DoubleClick(sender As Object, e As EventArgs) Handles ListBox5.DoubleClick
        ListUserCodeItems(0)
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim folderbroswer As New FolderBrowserDialog
        If folderbroswer.ShowDialog() = DialogResult.OK Then
            TextBoxX1.Text = folderbroswer.SelectedPath
        End If
    End Sub

    Private Sub TextBoxX2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX2.KeyDown
        Searchresults(ListBox6, TextBoxX2, ListBox1, Nothing, 0, e)
    End Sub

    Private Sub CopySelectedItemToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySelectedItemToClipboardToolStripMenuItem.Click
        If Not ListBox4.SelectedItem = Nothing Then

            Clipboard.SetText(ListBox4.SelectedItem)
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Clipboard.SetText(RichTextBoxEx1.Text)
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        If Not ListBox1.SelectedItem = Nothing Then

            Clipboard.SetText(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Clipboard.SetText(RichTextBoxEx2.SelectedText)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Clipboard.SetText(RichTextBoxEx6.SelectedText)
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Clipboard.SetText(RichTextBoxEx7.SelectedText)
    End Sub

    Private Sub TextBoxX3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX3.KeyDown
        Searchresults(ListBox7, TextBoxX3, Nothing, RichTextBoxEx1, 1, e)
    End Sub

    Private Sub ListBox7_DoubleClick(sender As Object, e As EventArgs) Handles ListBox7.DoubleClick
        RichTextBoxEx1.Focus()
        RichTextBoxEx1.Find(ListBox7.SelectedItem)
    End Sub

    Private Sub ListBox6_DoubleClick(sender As Object, e As EventArgs) Handles ListBox6.DoubleClick
        ListBox1.SelectedItem = ListBox6.SelectedItem
    End Sub

    Private Sub TextBoxX5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX5.KeyDown
        Searchresults(ListBox8, TextBoxX5, Nothing, RichTextBoxEx2, 1, e)
    End Sub

    Private Sub ListBox8_DoubleClick(sender As Object, e As EventArgs) Handles ListBox8.DoubleClick
        RichTextBoxEx2.Focus()
        RichTextBoxEx2.Find(ListBox8.SelectedItem)
    End Sub

    Private Sub TextBoxX6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX6.KeyDown
        Searchresults(ListBox9, TextBoxX6, ListBox3, Nothing, 0, e)
    End Sub

    Private Sub ListBox9_DoubleClick(sender As Object, e As EventArgs) Handles ListBox9.DoubleClick
        ListBox3.SelectedItem = ListBox9.SelectedItem
    End Sub

    Private Sub TextBoxX7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX7.KeyDown
        Searchresults(ListBox10, TextBoxX7, Nothing, RichTextBoxEx6, 1, e)
    End Sub

    Private Sub ListBox10_DoubleClick(sender As Object, e As EventArgs) Handles ListBox10.DoubleClick
        RichTextBoxEx6.Focus()
        RichTextBoxEx6.Find(ListBox10.SelectedItem)
    End Sub

    Private Sub TextBoxX8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX8.KeyDown
        Searchresults(ListBox11, TextBoxX8, Nothing, RichTextBoxEx7, 1, e)
    End Sub

    Private Sub ListBox11_DoubleClick(sender As Object, e As EventArgs) Handles ListBox11.DoubleClick
        RichTextBoxEx7.Focus()
        RichTextBoxEx7.Find(ListBox11.SelectedItem)
    End Sub

    Private Sub TextBoxX4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX4.KeyDown
        Searchresults(ListBox12, TextBoxX4, ListBox4, Nothing, 0, e)
    End Sub

    Private Sub ListBox12_DoubleClick(sender As Object, e As EventArgs) Handles ListBox12.DoubleClick
        ListBox4.SelectedItem = ListBox12.SelectedItem
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Clipboard.SetText(RichTextBoxEx3.SelectedText)
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        ListBox4.Items.Add(RichTextBoxEx3.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click

        Static Dim randonow As New Random
        WriteTextToFile("RandomHotFix_" + randonow.Next(0, 1000).ToString, "bl3hotfix", RichTextBoxEx3)
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        If ToolStripMenuItem17.Checked = True Then
            RichTextBoxEx3.WordWrap = True
        Else
            RichTextBoxEx3.WordWrap = False
        End If
    End Sub

    Private Sub ListBox13_DoubleClick(sender As Object, e As EventArgs) Handles ListBox13.DoubleClick
        If Not ListBox13.SelectedItem = Nothing Then
            If ListBox13.SelectedItem = "Borderlands Modding Community Discord" Then
                Process.Start("https://discord.gg/jGXXxHz3Hr")
            End If
            If ListBox13.SelectedItem = "How to use HotFix Merger" Then
                Process.Start("https://www.youtube.com/watch?v=KYgUzKomXrk")
            End If
            If ListBox13.SelectedItem = "How to use Raptors Save Editor" Then
                Process.Start("https://www.youtube.com/watch?v=WTD2eBeIJVw")
            End If
            If ListBox13.SelectedItem = "Apocalyptech Commandline Editor" Then
                Process.Start("https://github.com/apocalyptech/bl3-cli-saveedit")
            End If
            If ListBox13.SelectedItem = "Raptor's graphical save editor" Then
                Process.Start("https://github.com/cfi2017/bl3-save")
                Process.Start("https://github.com/cfi2017/bl3-save-frontend")
            End If
            If ListBox13.SelectedItem = "CSave Commandline Save Editor" Then
                Process.Start("https://github.com/HackerSmacker/CSave ")
            End If
            If ListBox13.SelectedItem = "Lootlemon" Then
                Process.Start("https://www.lootlemon.com/db/borderlands-3/weapons")
            End If
            If ListBox13.SelectedItem = "Spreedsheet of Item Parts/Stats" Then
                Process.Start("https://docs.google.com/spreadsheets/d/16b7bGPFKIrNg_cJm_WCMO6cKahexBs7BiJ6ja0RlD04/edit#gid=1321122034")
            End If
            If ListBox13.SelectedItem = "Borderlands 3 Weapon/Item Parts + Weights" Then
                Process.Start("https://docs.google.com/spreadsheets/d/1XYG30B6CulmcmmVDuq-PkLEJVtjAFacx7cuSkqbv5N4/edit#gid=236414762")
            End If
            If ListBox13.SelectedItem = "Weapon Parts Compendium" Then
                Process.Start("https://docs.google.com/spreadsheets/d/1daTpPa_uxJ0FUdVoAMjDY54GVQhwGRl51LCTsAY6AlU/edit#gid=1048758721")
            End If
            If ListBox13.SelectedItem = "BL3 Legendary & Unique Codes" Then
                Process.Start("https://docs.google.com/spreadsheets/d/1scyeHjKVddQ-uSAq-cn3KTJmpllrgLDAjZSY-LIcqRg/edit#gid=0")
            End If

            If ListBox13.SelectedItem = "Images with Item Codes (Gibbed Format)" Then
                Process.Start("https://imgur.com/user/bl3mods/posts")
            End If
            If ListBox13.SelectedItem = "Purple Grenade Parts List" Then
                Process.Start("https://docs.google.com/spreadsheets/d/1emE7ne8dwspx_MeUFqYoHV2GP1352A0-cCGA1g9NMts/edit#gid=196551301")
            End If
            If ListBox13.SelectedItem = "Purple Shield Parts Checklist" Then
                Process.Start("https://docs.google.com/spreadsheets/d/1QoVJYck7qVilOkFeGSEKg4eGJdkZaBJDbqwLRl48LIA/edit#gid=60397113")
            End If
            If ListBox13.SelectedItem = "Web Vault Hunter Skill Build Planner" Then
                Process.Start("https://bl3skills.com/")
            End If
            If ListBox13.SelectedItem = "Modding Fabricator Itempool" Then
                Process.Start("https://www.youtube.com/watch?v=Kz06jPvYWiY")
            End If
        End If
    End Sub

    Private Sub TextBoxX9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX9.KeyDown
        Searchresults(ListBox14, TextBoxX9, Nothing, RichTextBoxEx3, 1, e)

    End Sub

    Private Sub ListBox14_DoubleClick(sender As Object, e As EventArgs) Handles ListBox14.DoubleClick
        RichTextBoxEx3.Focus()
        RichTextBoxEx3.Find(ListBox14.SelectedItem)
    End Sub

    Private Sub ListBox15_DoubleClick(sender As Object, e As EventArgs) Handles ListBox15.DoubleClick
        If Not ListBox15.SelectedItem = Nothing Then
            RichTextBoxEx4.Clear()
            Dim lines As String() = RichTextBoxEx5.Lines
            For line As Integer = 0 To lines.Count - 1

                If Regex.IsMatch(lines(line), ListBox15.SelectedItem) Then


                    RichTextBoxEx4.AppendText(Environment.NewLine + lines(line) + Environment.NewLine + lines(line + 1))

                End If
            Next
            TabControl8.SelectedTabIndex = 1
        End If
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Clipboard.SetText(RichTextBoxEx4.SelectedText)
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        ListBox4.Items.Add(RichTextBoxEx4.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        If ToolStripMenuItem21.Checked = True Then
            RichTextBoxEx4.WordWrap = True
        Else
            RichTextBoxEx4.WordWrap = False
        End If
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Clipboard.SetText(RichTextBoxEx5.SelectedText)

    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        ListBox4.Items.Add(RichTextBoxEx5.SelectedText)
        TabItem13.Text = "Favorites (" + ListBox4.Items.Count.ToString + ")"

    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        If ToolStripMenuItem23.Checked = True Then
            RichTextBoxEx5.WordWrap = True
        Else
            RichTextBoxEx5.WordWrap = False
        End If
    End Sub

    Private Sub TextBoxX10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX10.KeyDown
        Searchresults(ListBox16, TextBoxX10, Nothing, RichTextBoxEx5, 1, e)
    End Sub

    Private Sub ListBox16_DoubleClick(sender As Object, e As EventArgs) Handles ListBox16.DoubleClick
        RichTextBoxEx5.Focus()
        RichTextBoxEx5.Find(ListBox16.SelectedItem)
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If ComboBoxEx1.SelectedIndex = 0 Then
            randomizerfromfile("WeaponRandomizer.txt", RichTextBoxEx3)
        End If
        If ComboBoxEx1.SelectedIndex = 1 Then
            randomizerfromfile("EnemiesRandomizer.txt", RichTextBoxEx3)
        End If
        If ComboBoxEx1.SelectedIndex = 2 Then
            randomizerfromfile("LootRandomizer.txt", RichTextBoxEx3)
        End If
        If ComboBoxEx1.SelectedIndex = 3 Then
            Static Dim randomint As New Random
            If Not File.Exists("HotFixPatches.hfts") Then
                MessageBox.Show("HotFixPatches.hfts Does Not Exist Please Create It And Paste Your Spark Patches In It.", "Heads Up !", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                NumericUpDown2.Maximum = File.ReadAllLines("HotFixPatches.hfts").Count
                RichTextBoxEx3.Clear()
                RichTextBoxEx3.AppendText("#Generated Random HotFix " + randomint.Next(0, 1000).ToString + "
#Using HotFix Tweaker By James reborn
#Date : " + DateAndTime.DateString.ToString + " / Time : " + TimeOfDay.ToString("hh:mm:ss") + "

")
                Dim int As Integer
                For int = 0 To NumericUpDown2.Value - 1

                    Dim stringresult As String
                    stringresult = File.ReadLines("HotFixPatches.hfts")(randomint.Next(0, File.ReadLines("HotFixPatches.hfts").Count))
                    If Not String.IsNullOrEmpty(stringresult) Or Not String.IsNullOrWhiteSpace(stringresult) Then 'checksforemptiesanddoesnotrun

                        If Not RichTextBoxEx3.Text.Contains(stringresult) Then

                            If Regex.IsMatch(stringresult, "Spar", RegexOptions.IgnoreCase) Then


                                RichTextBoxEx3.AppendText(stringresult + Environment.NewLine)

                            End If


                        Else
                            'RichTextBoxEx3.AppendText("#DUPPEDOUTPUT" + Environment.NewLine) 'checksfordups
                        End If
                    End If
                Next
            End If
        End If

        If ComboBoxEx1.SelectedIndex = 4 Then
            randomizerfromfile(TextBoxX11.Text, RichTextBoxEx3)
        End If

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim openfiledialog As New OpenFileDialog

        If openfiledialog.ShowDialog() = DialogResult.OK Then
            TextBoxX11.Text = openfiledialog.FileName
        End If

    End Sub

    Private Sub RemoveItemFromListboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveItemFromListboxToolStripMenuItem.Click
        If Not ListBox1.SelectedItem = Nothing Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
        End If
    End Sub

    Private Sub DeleteSelectedFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedFileToolStripMenuItem.Click
        If MessageBox.Show("Are You Sure You Want To Delete " + ListBox1.SelectedItem + "", "Heads Up !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            If File.Exists(ListBox1.SelectedItem) Then
                File.Delete(ListBox1.SelectedItem)
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                TabItem1.Text = "Loading (" + ListBox1.Items.Count.ToString + ")"
            End If
        End If
    End Sub
End Class
