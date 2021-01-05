using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;

namespace ModdingTools.Steam
{
    public abstract partial class AbstractModUploader
    {
        protected abstract void SetStatusText(string text);
        protected abstract void SetProgress(int value);
        protected abstract void SetState();
        protected abstract Form GetParentForm();
    }
}
