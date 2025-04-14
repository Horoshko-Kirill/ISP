using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class ProgressBar : ContentPage
{
    private CancellationTokenSource _cancellationTokenSource;

    public ProgressBar()
    {
        InitializeComponent();
        Cancel.IsEnabled = false; 
    }

    private async void CalculateSin(object sender, EventArgs e)
    {
        Start.IsEnabled = false;
        Cancel.IsEnabled = true;
        progressBar.Progress = 0;
        MainLable.Text = "Вычисление...";
        label.Text = "0%";

        _cancellationTokenSource = new CancellationTokenSource();
        double totalArea = 0;

        try
        {
            await Task.Run(() =>
            {
                const double width = 0.00000001;
                int lastReportedPercent = -1;

                for (double i = 0; i <= 1; i += width)
                {
                    
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                   
                    totalArea += Math.Sin(i) * width;

                    
                    int currentPercent = (int)(i * 100);
                    if (currentPercent != lastReportedPercent)
                    {
                        lastReportedPercent = currentPercent;
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            progressBar.Progress = i;
                            label.Text = $"{currentPercent}%";
                        });
                    }

                    
                    for (int j = 0; j < 1000; j++)
                    {
                        j++;
                        j--;
                    }
                }
            }, _cancellationTokenSource.Token);

            MainLable.Text = $"Площадь: {totalArea}";
            label.Text = "Завершено (100%)";
        }
        catch (OperationCanceledException)
        {
            MainLable.Text = "Вычисление отменено";
            label.Text = "Отменено";
        }
        finally
        {
            Start.IsEnabled = true;
            Cancel.IsEnabled = false;
            _cancellationTokenSource?.Dispose();
        }
    }

    private void Cancel_Click(object sender, EventArgs e)
    {
        _cancellationTokenSource?.Cancel();
    }
}