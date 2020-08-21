using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    class CardController : Control
    {
        [Browsable(true)]
        [Category("OMM")]
        private readonly Dictionary<string, Control> Cards;
        public CardController()
        {
            Cards = new Dictionary<string, Control>();
            DoubleBuffered = true;
        }

        public Control CurrentCard => this.Controls.Count > 0 ? GetFirstVisible() : null;

        public void SetCard(string value)
        {
            var o = Cards[value];
            if (GetFirstVisible() == o) return;
            o.ResumeLayout();
            o.Refresh();
            HideAll();
            o.Visible = true;
        }

        public void AddCard(string key, Control value)
        {
            Cards.Add(key, value);
            value.Visible = (Cards.Count == 1);
            value.Dock = DockStyle.Fill;
            if (!value.Visible)
            {
                value.SuspendLayout();
            }
            Controls.Add(value);
        }

        private Control GetFirstVisible()
        {
            foreach (var c in Controls)
                if (((Control)c).Visible) return (Control)c;
            return null;
        }

        private void HideAll()
        {
            foreach (var c in Controls)
                ((Control)c).Visible = false;
        } 

        public void RemoveCard(string key)
        {
            Cards.Remove(key);
        }
    }
}
