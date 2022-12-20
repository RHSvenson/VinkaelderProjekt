using System;
using System.Diagnostics;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TestProject
{
    public partial class DVI_Monitor : Form
    {
        public static DVIService.monitorSoapClient ds = new DVIService.monitorSoapClient();
        clockEditor clockCfg = new clockEditor();
        Timer stockTimer = new Timer(5000);
        Timer clockTimer = new Timer(1000);
        public DVI_Monitor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stockTimer.Elapsed += UpdateInfo;
            UpdateInfo(null, null);
            stockTimer.Start();

            clockTimer.Elapsed += UpdateClocks;
            clockTimer.Start();
            foreach (TimeZoneInfo timeZones in TimeZoneInfo.GetSystemTimeZones())
            {
                Debug.WriteLine(timeZones.DisplayName + " : " + timeZones.BaseUtcOffset); 
            }
        }

        private void UpdateClocks(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }

        private void UpdateInfo(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () 
            { 
                strgTmpLbl.Text = $"Temp: {ds.StockTemp()}°C"; 
                strgHmdLbl.Text = $"Hummidity: {ds.StockHumidity()} %";

                outTmpLbl.Text = $"Temp: {ds.OutdoorTemp()}°C"; 
                outHmdLbl.Text = $"Hummidity: {ds.OutdoorHumidity()} %";

                stockMin.Items.Clear();
                stockMax.Items.Clear();
                stockSold.Items.Clear();

                stockMin.Items.AddRange(ds.StockItemsUnderMin().ToArray());
                stockMax.Items.AddRange(ds.StockItemsOverMax().ToArray());
                stockSold.Items.AddRange(ds.StockItemsMostSold().ToArray());
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clockCfg.Show();
        }
    }
}
