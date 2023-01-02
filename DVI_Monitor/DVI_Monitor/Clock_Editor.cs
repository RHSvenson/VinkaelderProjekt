using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestProject
{

    public partial class clockEditor : Form
    {
        public ListBox.ObjectCollection currentClocks = new ListBox.ObjectCollection(new ListBox());
        public clockEditor()
        {
            InitializeComponent();
            foreach (TimeZoneInfo timeZones in TimeZoneInfo.GetSystemTimeZones())
            {
                possibleClocks.Items.Add(timeZones.Id);
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
        private void addClock_Click(object sender, EventArgs e)
        {
            currClocks.Items.Add(possibleClocks.Items[possibleClocks.SelectedIndex]);
            possibleClocks.Items.RemoveAt(possibleClocks.SelectedIndex);
            updClckLst();
        }

        private void rmvClock_Click(object sender, EventArgs e)
        {
            possibleClocks.Items.Add(currClocks.Items[currClocks.SelectedIndex]);
            currClocks.Items.RemoveAt(currClocks.SelectedIndex);
            updClckLst();
        }
        public void updClckLst()
        {
            currentClocks.Clear();
            currentClocks.AddRange(currClocks.Items);
        }

    }
}