function scr_npc_uncheck_level(argument0)
{
    if (scr_atr("LVL") < argument0)
    {
        return 1;
    }
    return 0;
}