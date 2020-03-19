using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RichTextBuilder
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