using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Toolbelt
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetImages(object sender, EventArgs e)
        {
            try
            {
                var path = TxtBrowse.Text;
                var productIds = TxtProductIds.Text
                    .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();
                TxtProductIds.Text = string.Join(Environment.NewLine, productIds);
                var eans = TxtEans.Text
                    .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();
                TxtEans.Text = string.Join(Environment.NewLine, eans);

                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show(
                        "No output directory set",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                Directory.CreateDirectory(path);

                if (!productIds.Any())
                {
                    MessageBox.Show(
                        "No product ids",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                if (!eans.Any())
                {
                    MessageBox.Show(
                        "No EANs",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                if (productIds.Count != eans.Count)
                {
                    MessageBox.Show(
                        "Uneven number of productIds and EANs",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                var total = eans.Count;
                var dict = productIds.Zip(eans, (k, v) => new {k, v}).ToDictionary(x => x.k, x => x.v);
                var baseUrl = @"http://media2.jpc.de/image/w600/front/0/";

                var found = new List<string>();
                var notFound = new List<string>();
                using (var client = new WebClient())
                {
                    foreach (var kvp in dict)
                    {
                        try
                        {
                            var url = $"{baseUrl}{kvp.Value}.jpg";
                            var dl = Path.Combine(path, $"{kvp.Key}.jpg");
                            client.DownloadFile(url, dl);
                            found.Add(kvp.Value);
                        }
                        catch (Exception)
                        {
                            notFound.Add(kvp.Value);
                        }
                    }
                }
                MessageBox.Show(
                        $"Found {found.Count}/{total}. Missed {notFound.Count}/{total}: {string.Join(", ", notFound)}",
                        "Done",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }

        private void testFileBrowse_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            TxtBrowse.Text = fbd.SelectedPath;
        }
    }
}
