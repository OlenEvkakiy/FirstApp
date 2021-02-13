using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {        
        int summ;
        bool buttonEnable = false;
        
        public FirstPage()
        {
            InitializeComponent();
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            summ = Convert.ToInt32(Label1.Text);         

        }      
        
        private void Button_Click1(object sender, EventArgs e)
        {            
            summ++;
            Label1.Text = Convert.ToString(summ);
            ButtonEnable();
            EpilepsyMode();
            EndToEverything();
            Vibration.Vibrate(TimeSpan.FromMilliseconds(25));

        }        
        private void Button_Click2(object sender, EventArgs e)
        {         
            summ +=10;
            Label1.Text = Convert.ToString(summ);
            ButtonEnable();
            EpilepsyMode();
            EndToEverything();
            Vibration.Vibrate(TimeSpan.FromMilliseconds(45));
        }
        private void Button_Click3(object sender, EventArgs e)
        {            
            summ +=100;
            Label1.Text = Convert.ToString(summ);
            ButtonEnable();
            EpilepsyMode();
            EndToEverything();
            Vibration.Vibrate(TimeSpan.FromMilliseconds(65));
        }
        private void Button_Click4(object sender, EventArgs e)
        {
            if (buttonEnable == true)
            {
                buttonEnable = false;
            }
            else
            {
                buttonEnable = true;
                AutoClick();                
            }
            Button4.IsEnabled = false;            
            EpilepsyMode();
            EndToEverything();
            Vibration.Vibrate(TimeSpan.FromMilliseconds(60));
        }
        private async void CheckOn(object sender, EventArgs e) 
        {
            if (CheckBox1.IsChecked)
            {
                await DisplayAlert("EpilepsyMode включен!", "Ты включил EpilepsyMode, он сломает твои глаза и само приложение", "Мне норм))0)");
            }
            EndToEverything();
        }     
        private void ButtonEnable()
        {
            if (summ >= 15)
            {
                Button2.IsEnabled = true;                
            }
            else Button2.IsEnabled = false;

            if (summ >= 350)
            {
                Button3.IsEnabled = true;
            }
            else Button3.IsEnabled = false;

            if (summ >= 1000)
            {
                Button4.IsEnabled = true;
            }
            else Button4.IsEnabled = false;
        }  
        private bool ButtonEnable(bool enable)
        {
            if(summ > 1500)
            {
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                CheckBox1.IsEnabled = false;
            }
            return false;
        }
   
        private void AutoClick()
        {
            int counter = 11;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                
                Device.BeginInvokeOnMainThread(() =>
                {                    
                    TimerLabel.Text = Convert.ToString(counter);
                    if(TimerLabel.Text == Convert.ToString(0))
                    {                        
                        summ += 5;
                        AutoClick();
                        EpilepsyMode();
                        EndToEverything();
                        Vibration.Vibrate(TimeSpan.FromMilliseconds(20));
                    }                    
                    Label1.Text = Convert.ToString(summ);                    
                });
                return counter--> 1;                
            });            
        }

        private void EpilepsyMode()
        {
            var rand = new Random();
            if (CheckBox1.IsChecked)
            {
                Button1.BackgroundColor = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                Button2.BackgroundColor = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                Button3.BackgroundColor = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                Button4.BackgroundColor = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                StackLayout.BackgroundColor = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            }
        }

        private async void EndToEverything()
        {  if(summ > 1500)
            {
                bool result = await DisplayAlert("Это конец", "Понравилось?", "Да!", "Я плохой человек");
                if (result)
                {
                    await DisplayAlert("Ты не очень", "А мне нет", "ок((");
                    ButtonEnable(false);
                }

                else
                {
                    await DisplayAlert("Ты не очень", "Я так и знал", "ок((");
                    ButtonEnable(false);
                }

            }         
           
        }
    }
}