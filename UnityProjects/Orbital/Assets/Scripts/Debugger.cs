using UnityEngine;
using System.Collections.Generic;
using System.Text; // For using StringBuilder

public static class Debugger
{
    // Print the content of any dictionary that has a list as values
    public static void PrintDict<TKey, TValue>(Dictionary<TKey, List<TValue>> dict, string msg = "")
    {
        StringBuilder sb = new StringBuilder();
        if (!string.IsNullOrEmpty(msg))
        {
            sb.AppendLine(msg + ":");
        }

        // Iterate over the dictionary
        foreach (KeyValuePair<TKey, List<TValue>> kvp in dict)
        {
            sb.Append($"Key = {kvp.Key}, Values = [");
            // Call PrintList to append list values into sb
            PrintList(kvp.Value, sb);
            sb.AppendLine("]"); // Close the list of values
        }

        // Log the complete dictionary content
        Debug.Log(sb.ToString());
    }

    // Print the content of any list
    public static void PrintList<T>(List<T> list, StringBuilder sb = null)
    {
        bool isNewStringBuilder = false;
        if (sb == null)
        {
            sb = new StringBuilder();
            isNewStringBuilder = true;
        }

        // Append each item in the list to StringBuilder
        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(list[i]);
            if (i < list.Count - 1)
                sb.Append(", "); // Add comma between items
        }

        // If a new StringBuilder was created, log the list as a standalone message
        if (isNewStringBuilder)
        {
            Debug.Log(sb.ToString());
        }
    }
}
