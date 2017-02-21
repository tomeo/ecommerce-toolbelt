using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace Toolbelt.UserControls
{
    public partial class CoverImageDownloader
    {
        public delegate void ProgressUpdate(ProgressEventArg eventArg);
        public event ProgressUpdate OnProgressUpdate;

        public CoverImageDownloader()
        {
            InitializeComponent();
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            TxtLog.Text = string.Empty;
            var worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            worker.DoWork += export_DoWork;
            worker.RunWorkerCompleted += export_RunWorkerCompleted;
            worker.ProgressChanged += (s, ev) =>
            {
                ProgressBar.Value = ev.ProgressPercentage;
                var status = ((ProgressEventArg) ev.UserState).Status;
                if (!string.IsNullOrWhiteSpace(status))
                {
                    TxtStatus.Text = status;
                }
                var log = ((ProgressEventArg)ev.UserState).Log;
                if (!string.IsNullOrWhiteSpace(log))
                {
                    TxtLog.AppendText(log);
                    TxtLog.AppendText(Environment.NewLine);
                    TxtLog.ScrollToEnd();
                }
                var imagePath = ((ProgressEventArg)ev.UserState).ImagePath;
                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    var src = new BitmapImage();
                    src.BeginInit();
                    src.UriSource = new Uri(imagePath, UriKind.Absolute);
                    src.CacheOption = BitmapCacheOption.OnLoad;
                    src.EndInit();
                    CoverImage.Source = src;
                }
            };

            var arguments = new CoverImageDownloadArguments
            {
                Path = TxtExportFileBrowse.Text,
                ProductIds = TxtProductIds.Text
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList(),
                Eans = TxtEans.Text
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList()
            };

            if (string.IsNullOrWhiteSpace(arguments.Path))
            {
                MessageBox.Show(
                    "No output directory set",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            Directory.CreateDirectory(arguments.Path);

            if (!arguments.ProductIds.Any())
            {
                MessageBox.Show(
                    "No product ids",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (!arguments.Eans.Any())
            {
                MessageBox.Show(
                    "No EANs",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (arguments.ProductIds.Count != arguments.Eans.Count)
            {
                MessageBox.Show(
                    "Uneven number of productIds and EANs",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            ProgressContainer.Visibility = Visibility.Visible;
            worker.RunWorkerAsync(arguments);
        }

        private void export_DoWork(object sender, DoWorkEventArgs e)
        {
            var handler = new ProgressUpdate(
                m => (sender as BackgroundWorker).ReportProgress(m.Percentage, m));
            OnProgressUpdate += handler;
            GetImages((CoverImageDownloadArguments)e.Argument);
            OnProgressUpdate -= handler;
        }

        private void export_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnGetImages.IsEnabled = true;
            BtnExportFileBrowse.IsEnabled = true;
            ProgressContainer.Visibility = Visibility.Hidden;
        }

        public void GetImages(CoverImageDownloadArguments arguments)
        {
            try
            {
                var total = arguments.Eans.Count;
                var dict = arguments.ProductIds.Zip(arguments.Eans, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
                var baseUrl = @"http://media2.jpc.de/image/w600/front/0/";

                var found = new List<string>();
                var notFound = new List<string>();
                using (var client = new WebClient())
                {
                    var i = 0;
                    foreach (var kvp in dict)
                    {
                        var url = $"{baseUrl}{kvp.Value}.jpg";
                        var p = i++ / (double)dict.Keys.Count * 100;
                        try
                        {
                            OnProgressUpdate?.Invoke(new ProgressEventArg(Convert.ToInt32(p), $"Downloading {url}", null, null));
                            var dl = Path.Combine(arguments.Path, $"{kvp.Key}.jpg");
                            client.DownloadFile(url, dl);
                            found.Add(kvp.Value);
                            OnProgressUpdate?.Invoke(new ProgressEventArg(Convert.ToInt32(p), null, $"Found {kvp.Value}", dl));
                        }
                        catch (Exception)
                        {
                            notFound.Add(kvp.Value);
                            OnProgressUpdate?.Invoke(new ProgressEventArg(Convert.ToInt32(p), null, $"Did not find {kvp.Value}", null));
                        }
                    }
                }
                OnProgressUpdate?.Invoke(new ProgressEventArg(
                    100,
                    string.Empty,
                    "---------------",
                    null));
                OnProgressUpdate?.Invoke(new ProgressEventArg(
                    100,
                    string.Empty,
                    $"Found {found.Count}/{total}. Missed {notFound.Count}/{total}:{Environment.NewLine}{string.Join($"{Environment.NewLine}", notFound)}", null));
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

        // http://stackoverflow.com/questions/11624298/how-to-use-openfiledialog-to-select-a-folder
        private void ExportFileBrowse_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            TxtExportFileBrowse.Text = fbd.SelectedPath;
        }
    }
}
