using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RichTextBuilder
{
    public static string AddTagToString(string message, string tag)
    {
        message = "<" + tag + ">" + message + "</" + tag + ">";
        return message;
    }

    public static string AddTagToString(string message, string tag, string value)
    {
        message = "<" + tag + "=" + value + ">" + message + "</" + tag + ">";
        return message;
    }
}