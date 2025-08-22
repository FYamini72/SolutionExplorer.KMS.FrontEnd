using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace SolutionExplorer.KMS.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                var bwv = new BlazorWebView()
                {
                    Dock = DockStyle.Fill,
                    HostPage = "wwwroot/index.html",
                    Services = Startup.Services!,
                    StartPath = "/"
                };

                bwv.RootComponents.Add<App>("#app");
                Controls.Add(bwv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Startup Error");
            }
        }
    }
}
