using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public static class PlayerData
{
    public static int hooks = 0;
    public static int lasers = 0;
    public static int total_laser_damage = 0;

    public static string failWay = "";

    public static int score = 0;

    public static int height_score = 0;
    public static int buff = 0;
    public static int debuff = 0;
    public static float health = 0;

    public static void debug()
    {
        Debug.Log("hook: " + hooks + ", lasers: " + lasers + ", total_laser_damage: " + total_laser_damage + ", failWay: " + failWay +
        ", score: " + score + ", height_score: " + height_score + ", buff: " + buff + ", debuff: " + debuff);
    }

    public static void UploadData()
    {
        Dictionary<string, object> data = new Dictionary<string, object> {
            {"hooks", hooks},
            {"lasers", lasers},
            {"total_laser_damage", total_laser_damage},
            {"failWay", failWay},
            {"score", score},
            {"health", health},
            {"height_score", height_score},
            {"buff", buff},
            {"defuff", debuff}
        };
        AnalyticsResult res = Analytics.CustomEvent("PlayerData", data);
        Debug.Log("Upload player data" + res);
        clear();
    }

    // Reset user data when player dead.
    public static void clear()
    {
        hooks = 0;
        lasers = 0;
        total_laser_damage = 0;
        failWay = "";
        score = 0;
        buff = 0;
        debuff = 0;
        health = 0;
    }
}
