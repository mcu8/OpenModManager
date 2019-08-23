using ModdingTools.GUI;
using ModdingTools.Modding;
using ModManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace ModdingTools
{
    public class Utils
    {
        public static string[] Split(string source, string key)
        {
            return source.Split(new[] { key }, StringSplitOptions.None);
        }

        public static string ClearWhitespaces(string source, bool keepSingleSpace = true)
        {
            return Regex.Replace(source, @"\s+", keepSingleSpace ? " " : "");
        }

        public static bool CollectionContains(string find, string[] haystack)
        {
            foreach (var item in haystack)
            {
                if (item.Equals(find))
                {
                    return true;
                }
            }
            return false;
        }

        public static void OpenInExplorer(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + path + "\"");
        }

        public static void KillEditor()
        {
            System.Diagnostics.Process.Start("taskkill.exe", "/F /IM HatInTimeEditor.exe");
        }

        // "Hacks" section
        public static T GetField<T>(string fieldName, Object w)
        {
            return (T)w.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(w);
        }
    
        public static void InvokeMeth(object o, string methodName, params object[] args)
        {
            Debug.WriteLine(o.GetType().ToString());
            args = args.Count() > 0 ? args : null;
            o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(o, args);
        }

        public static T InvokeFunct<T>(object o, string methodName, params object[] args)
        {
            Debug.WriteLine(o.GetType().ToString());
            args = args.Count() > 0 ? args : null;
            return (T)o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(o, args);
        }

        public static void CleanEvents(Control ctrl)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(ctrl);
            PropertyInfo pi = ctrl.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(ctrl, null);
            list.RemoveHandler(obj, list[obj]);
        }

        public static void ApplyTheme(Control c)
        {
            foreach (var control in c.Controls)
            {
                var ctrl = ((Control)control);
                if (ctrl is Button)
                {
                    ApplyButtonTheme((Button)ctrl);
                }
                else
                {
                    if (ctrl is Panel)
                    {
                        ((Panel)ctrl).BorderStyle = BorderStyle.FixedSingle;
                    }

                    if (ctrl is TabControl)
                    {
                        foreach (var tab in ((TabControl)ctrl).TabPages)
                        {
                            ((TabPage)tab).BackColor = ThemeConstants.BackgroundColor;
                            ((TabPage)tab).ForeColor = ThemeConstants.ForegroundColor;
                        }
                    }

                    try
                    {
                        ctrl.BackColor = ThemeConstants.BackgroundColor;
                        ctrl.ForeColor = ThemeConstants.ForegroundColor;
                    }
                    catch (Exception e)
                    {

                    }
                    if (ctrl.Controls.Count > 0)
                    {
                        ApplyTheme(ctrl);
                    }
                }
            }
        }

        public static ModObject GetModObjectFromControl(object e)
        {
            var c = (Control)e;
            EditMod obj = (EditMod)c.FindForm();
            return (ModObject)obj.Tag;
        }

        public static Control GetFirstControlForm(object e)
        {
            foreach (var c in ((Control)e).Controls)
            {
                if (c is Form)
                {
                    return (Control)c;
                }
            }
            return null;
        }

        public static void ApplyButtonTheme(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = ThemeConstants.BorderColor;
            b.FlatAppearance.BorderColor = ThemeConstants.BorderColor;
            b.FlatAppearance.BorderSize = 1;
            b.ForeColor = ThemeConstants.ForegroundColor;
        }
    }
}
