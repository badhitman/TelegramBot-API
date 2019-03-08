﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;

namespace TelegramBot.TelegramMetadata
{
    public abstract class _AbstractMethodsManager : SerialiserJSON
    {
        public Dictionary<string, string> GetFiealds(string[] SkipFields)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (System.Reflection.FieldInfo fi in this.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (SkipFields.Where(c => c.Trim().ToLower() == fi.Name.Trim().ToLower()).Count() > 0)
                    continue;

                if (fi.FieldType == typeof(int) || fi.FieldType == typeof(Int64) || fi.FieldType == typeof(double) || fi.FieldType == typeof(string) || fi.FieldType == typeof(long))
                    d.Add(fi.Name, fi.GetValue(this).ToString());
                else if (fi.FieldType == typeof(bool))
                    d.Add(fi.Name, fi.GetValue(this).ToString().ToLower());
                else
                {
                   // int i = (int)fi.GetValue(this);
                }
            }
            return d;
        }
    }
}
