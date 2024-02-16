function scr_npc_check_level(argument0)
{
    if (scr_atr("LVL") >= argument0)
    {
        return 1;
    }
    return 0;
}