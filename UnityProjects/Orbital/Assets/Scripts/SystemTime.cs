using UnityEngine;
using System;
using System.Collections.Generic;

public static class SystemTime
{
    public static Dictionary<string, int> dayDict = new Dictionary<string, int>
    {
        {"mon", 1},
        {"tue", 2},
        {"wed", 3},
        {"thu", 4},
        {"fri", 5},
        {"sat", 6},
        {"sun", 0}
    };
    
    public static Dictionary<int, string>reverseDayDict = new Dictionary<int, string>
    {
        {1, "mon"},
        {2, "tue"},
        {3, "wed"},
        {4, "thu"},
        {5, "mon"},
        {6, "sat"},
        {0, "sun"}
    };

    public static string ConvertToSystemDay(string day)
    {
        switch(day)
        {
            case "Monday":
                return "mon";
            case "Tuesday":
                return "tue";
            case "Wednesday":
                return "wed";
            case "Thursday":
                return "thu";
            case "Friday":
                return "fri";
            case "Saturday":
                return "sat";
            case "Sunday":
                return "sun";
            default:
                return day;
        }

    }

    public static string GetYear(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;

        return year.ToString();
    }

    public static string GetDate(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;

        return day.ToString();
    }

    public static string GetMonth(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;

        return month.ToString();
    }

    public static string GetHHMM(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;
        return GetHour(now) + GetMinute(now);
    }

    public static string GetYYYYMMDD(DateTime now)
    {
        return GetYear(now) + GetMonth(now) + GetDate(now);
    }

    public static string GetHour(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;
        return hour.ToString();
    }

    public static string GetMinute(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;
        return minute.ToString();
    }

    public static string GetSecond(DateTime now)
    {
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;
        return second.ToString();
    }

    public static string GetDayOfWeek(DateTime now)
    {
        return ConvertToSystemDay(now.DayOfWeek.ToString());
    }

    public static DateTime Now()
    {
        return DateTime.Now;
    }

    public static DateTime AddDate(int num)
    {
        return Now().AddDays(num);
    }

    public static DateTime AddMinute(int num)
    {
        return Now().AddMinutes(num);
    }

    public static DateTime AddHour(int num)
    {
        return Now().AddHours(num);
    }

    public static int DateDifference(DateTime date1, DateTime date2)
    {
        TimeSpan difference = (date1 - date2).Duration();
        return (int)difference.TotalDays;
    }

    public static int HourDifference(DateTime date1, DateTime date2)
    {
        TimeSpan difference = (date1 - date2).Duration();
        return (int)difference.TotalHours;
    }

    public static int MinuteDifference(DateTime date1, DateTime date2)
    {
        TimeSpan difference = (date1 - date2).Duration();
        return (int)difference.TotalMinutes;
    }
}
