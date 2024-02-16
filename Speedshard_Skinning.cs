// Copyright (C) 2024 Rémy Cases
// See LICENSE file for extended copyright information.
// This file is part of the Speedshard repository from https://github.com/remyCases/SpeedshardSkinning.

using ModShardLauncher;
using ModShardLauncher.Mods;
using Newtonsoft.Json;
using System.IO;

namespace Speedshard_Skinning;
public class SpeedshardSkinning : Mod
{
    public override string Author => "zizani";
    public override string Name => "Speedshard - Skinning";
    public override string Description => "I've heard someone can teach you how to skin for free.";
    public override string Version => "0.1.0.0";

    public override void PatchMod()
    {
        File.WriteAllText("_before.json", JsonConvert.SerializeObject(ModLoader.GetTable("gml_GlobalScript_table_NPC_Lines")).Replace("\n", ""));

       LocalizationDialog localizationDialog = new(
            new LocalizationSentence(
                id: "asking_for_something_free",
                sentence: "Can you teach me something to help me ? Fighting in the woods is so costly."),
            new LocalizationSentence(
                id: "tips_learning_how_to_skin",
                sentence: "HAHAHA, you seem sympathic to me, I can show a trick or two."),
            new LocalizationSentence(
                id: "learn_skinning_for_free",
                sentence: "*You learn how to skin dead animals.*"),
            new LocalizationSentence(
                id: "custom_learn_nolevel",
                sentence: "I'm too novice to learn something, I should come back later.")
        );
        localizationDialog.InjectTable(); 

        File.WriteAllText("_after.json", JsonConvert.SerializeObject(ModLoader.GetTable("gml_GlobalScript_table_NPC_Lines")).Replace("\n", ""));

        Msl.AddFunction(ModFiles.GetCode("scr_unlock_skinning_for_free.gml"), "scr_unlock_skinning_for_free");
        Msl.AddFunction(ModFiles.GetCode("scr_npc_can_study_skinning.gml"), "scr_npc_can_study_skinning");
        Msl.AddFunction(ModFiles.GetCode("scr_npc_check_level.gml"), "scr_npc_check_level");
        Msl.AddFunction(ModFiles.GetCode("scr_npc_uncheck_level.gml"), "scr_npc_uncheck_level");
    }
}
