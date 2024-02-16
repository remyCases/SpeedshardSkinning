function scr_npc_can_study_skinning() //gml_Script_scr_npc_can_study_skinning
{
    with (o_skill_flaying_ico)
    {
        if (!is_open)
        {
            return 1;
        }
    }
    return 0;
}