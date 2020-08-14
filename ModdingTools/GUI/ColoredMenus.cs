using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    class MenuColorTable : ProfessionalColorTable
    {
        public MenuColorTable()
        {
            // see notes
            base.UseSystemColors = false;
        }
        public override System.Drawing.Color MenuBorder
        {
            get { return ThemeConstants.BorderColor; }
        }
        public override System.Drawing.Color MenuItemBorder
        {
            get { return ThemeConstants.BorderColor; }
        }
        public override Color MenuItemSelected
        {
            get { return ThemeConstants.BorderColor; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return ThemeConstants.BorderColor; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return ThemeConstants.BorderColor; }
        }
        public override Color MenuStripGradientBegin
        {
            get { return ThemeConstants.BackgroundColor; }
        }
        public override Color MenuStripGradientEnd
        {
            get { return ThemeConstants.BackgroundColor; }
        }
    }
}
