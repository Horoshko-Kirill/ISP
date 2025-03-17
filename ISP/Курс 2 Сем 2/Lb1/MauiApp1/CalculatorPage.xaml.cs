using Windows.ApplicationModel.Appointments.DataProvider;
using Windows.Media.AppBroadcasting;
using Windows.Media.Devices;

namespace MauiApp1;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
	}

    double memory = 0;
    char ch = ' ';
    bool punct = true;
    double calMemory;

	private void OnButtonPress(object sender, EventArgs e)
	{
        if (sender == ButtonEqual)
		{
			ButtonEqual.BackgroundColor = Color.FromArgb("#FF9F80");
		}
		else if (sender is Button button)
		{
			button.BackgroundColor = Color.FromArgb("#808080");
        }
    }

    private void OnButtonReleased(object sender, EventArgs e)
    {
        if (sender == ButtonEqual)
        {
            ButtonEqual.BackgroundColor = Color.FromArgb("#FF4F00");
        }
        else if (sender is Button button)
        {
            button.BackgroundColor = Colors.Transparent;
        }
    }

    private void OnButton0Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "0";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "0";
            }
        }
    }

    private void OnButton1Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "1";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "1";
            }
        }
    }

    private void OnButton2Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "2";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "2";
            }
        }
    }

    private void OnButton3Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "3";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "3";
            }
        }
    }

    private void OnButton4Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "4";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "4";
            }
        }
    }

    private void OnButton5Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "5";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "5";
            }
        }
    }

    private void OnButton6Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "6";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "6";
            }
        }
    }

    private void OnButton7Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "7";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "7";
            }
        }
    }

    private void OnButton8Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "8";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "8";
            }
        }
    }

    private void OnButton9Cliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text == "0")
        {
            LableDisplay.Text = "9";
        }
        else
        {
            if (LableDisplay.Text.Length < 14)
            {
                LableDisplay.Text += "9";
            }
        }
    }

    private void OnButtonPunctCliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text.Length < 13 && punct)
        {
            LableDisplay.Text += ",";
            punct = false;
        }
    }

    private void OnButtonSignCliced(object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            if (LableDisplay.Text[0] != '-')
            {
                LableDisplay.Text = "-" + LableDisplay.Text;
            }
            else
            {
                LableDisplay.Text = LableDisplay.Text.Remove(0, 1);
            }
        }
    }

    private string SetText(double value)
    {

        while (value > 999999999999999)
        {
            value /= 10;
        }

        long z = (long)value;

        double o = value - z;


        string zs = Convert.ToString(z);
        string os = Convert.ToString(o);

        string ans = "";

        int i = 2;

        if (o < 0)
        {
            if (z >= 0)
            {
                ans += '-';
            }
            i = 3;
        }

        
        ans += zs;

        if (ans.Length < 13 && os.Length > 2)
        {
            ans += ',';
            punct = false;
        }
        else
        {
            punct = true;
        }

        bool flag = false;

        while (ans.Length < 14 && i < os.Length)
        {
            if (os[i] == 'E')
            {
                flag = true;
            }

            if (!flag)
            {
                ans += os[i];
                i++;
            }
            else
            {
                ans += "0";
            }
        }

        return ans;
    }

    private void OnButtonOppositeCliced(Object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            double buffer = Convert.ToDouble(LableDisplay.Text);

            if (buffer != 0)
            {
                buffer = 1 / buffer;
                LableDisplay.Text = SetText(buffer);
            }
            else
            {
                LableDisplay.Text = "0";
            }

            
        }
    }

    private void OnButtonPowCliced(Object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            double buffer = Convert.ToDouble(LableDisplay.Text);

            buffer = buffer*buffer;

            LableDisplay.Text = SetText(buffer);
        }
    }

    private void OnButtonRootCliced(Object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            double buffer = Convert.ToDouble(LableDisplay.Text);

            if (buffer <= 0)
            {
                LableDisplay.Text = "0";
                punct = true;
            }
            else
            {
                buffer = Math.Sqrt(buffer);

                LableDisplay.Text = SetText(buffer);
            }

            
        }
    }

    private void OnButtonProcCliced(Object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            double buffer = Convert.ToDouble(LableDisplay.Text);

            if (buffer == 0)
            {
                LableDisplay.Text = "0";
                punct = true;
            }
            else
            {
                buffer /= 100;

                LableDisplay.Text = SetText(buffer);
            }


        }
    }

    private void OnButtonAbsCliced(Object sender, EventArgs e)
    {
        if (LableDisplay.Text != "0")
        {
            double buffer = Convert.ToDouble(LableDisplay.Text);

            if (buffer == 0)
            {
                LableDisplay.Text = "0";
                punct = true;
            }
            else
            {
                buffer = Math.Abs(buffer);

                LableDisplay.Text = SetText(buffer);
            }


        }
    }

    private void OnButtonDeleteCliced(Object sender, EventArgs e)
    {
        LableDisplay.Text = "0";
        punct = true;
    }

    private void OnButtonCCliced(Object sender, EventArgs e)
    {
        LableDisplay.Text = "0";
        punct = true;
        memory = 0;
    }

    private void OnButtonSumCliced(Object sender, EventArgs e)
    {
        if (ch == ' ')
        {
            memory = Convert.ToDouble(LableDisplay.Text);
            LableDisplay.Text = "0";
            punct = true;
        }
        ch = '+';
    }

    private void OnButtonDiffCliced(Object sender, EventArgs e)
    {
        if (ch == ' ')
        {
            memory = Convert.ToDouble(LableDisplay.Text);
            LableDisplay.Text = "0";
            punct = true;
        }
        ch = '-';
    }

    private void OnButtonMultiplyCliced(Object sender, EventArgs e)
    {
        if (ch == ' ')
        {
            memory = Convert.ToDouble(LableDisplay.Text);
            LableDisplay.Text = "0";
            punct = true;
        }
        ch = '*';
    }

    private void OnButtonDevCliced(Object sender, EventArgs e)
    {
        if (ch == ' ')
        {
            memory = Convert.ToDouble(LableDisplay.Text);
            LableDisplay.Text = "0";
            punct = true;
        }
        ch = '/';
    }

    private void OnButtonEqualCliced(Object sender, EventArgs e)
    {
        if (ch != ' ')
        {
            if (ch == '+')
            {
               LableDisplay.Text = SetText(memory+Convert.ToDouble(LableDisplay.Text));
            }
            else if (ch == '-')
            {
                LableDisplay.Text = SetText(memory - Convert.ToDouble(LableDisplay.Text));
            }
            else if (ch == '*')
            {
                LableDisplay.Text = SetText(memory * Convert.ToDouble(LableDisplay.Text));
            }
            else if (ch == '/')
            {
                if (Convert.ToDouble(LableDisplay.Text) != 0)
                {
                    LableDisplay.Text = SetText(memory / Convert.ToDouble(LableDisplay.Text));
                }
                else
                {
                    LableDisplay.Text = "0";
                    punct = true;
                }
            }

            memory = 0;
            ch = ' ';
        }
    }

    private void OnButtonMSelectCliced(Object sender, EventArgs e)
    {
        calMemory = Convert.ToDouble(LableDisplay.Text);
    }

    private void OnButtonMAddCliced(Object sender, EventArgs e)
    {
        calMemory += Convert.ToDouble(LableDisplay.Text);
    }

    private void OnButtonMDiffCliced(Object sender, EventArgs e)
    {
        calMemory -= Convert.ToDouble(LableDisplay.Text);
    }

    private void OnButtonMCCliced(Object sender, EventArgs e)
    {
        calMemory = 0;
    }

    private void OnButtonMRCliced(Object sender, EventArgs e)
    {
        LableDisplay.Text = SetText(calMemory);
        calMemory = Convert.ToDouble(LableDisplay.Text);
    }
}