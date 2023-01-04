using System;
using System.Windows.Forms;

namespace TestProject
{

    public partial class clockEditor : Form
    {
        public string Clock1_Selection;
        public string Clock2_Selection;
        public string Clock3_Selection;

        public clockEditor()
        {
            InitializeComponent();

            //Placeholder for no selected clocks
            Clock1_Select.Items.Add("None");
            Clock2_Select.Items.Add("None");
            Clock3_Select.Items.Add("None");

            Clock1_Select.SelectedIndex = 0;
            Clock2_Select.SelectedIndex = 0;
            Clock3_Select.SelectedIndex = 0;

            //Get system timezones
            foreach (TimeZoneInfo timeZones in TimeZoneInfo.GetSystemTimeZones())
            {
                Clock1_Select.Items.Add(timeZones.Id);
                Clock2_Select.Items.Add(timeZones.Id);
                Clock3_Select.Items.Add(timeZones.Id);
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hide window instead of closing it to preserve data
            Hide();

            //cancels the close event
            e.Cancel = true;
        }

        public void updClckLst(object sender, EventArgs e)
        {
            //update public strings to match current clock selections
            if (Clock1_Select.SelectedIndex != -1) { Clock1_Selection = Clock1_Select.Items[Clock1_Select.SelectedIndex].ToString(); }
            if (Clock2_Select.SelectedIndex != -1) { Clock2_Selection = Clock2_Select.Items[Clock2_Select.SelectedIndex].ToString(); }
            if (Clock3_Select.SelectedIndex != -1) { Clock3_Selection = Clock3_Select.Items[Clock3_Select.SelectedIndex].ToString(); }
        }

    }
}