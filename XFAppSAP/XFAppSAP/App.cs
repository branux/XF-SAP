

#if __IOS__
using UIKit;
#endif

using Xamarin.Forms;

namespace XFAppSAP
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            Label label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                //Utilizando condicionais com Device.OS - Somente para Android ou outros
                BackgroundColor = Device.OS.Equals(TargetPlatform.Android) ? Color.White : Color.Red,
                //Utilizando Device.OnPlatforma<T>(T,T,T)
                TextColor = Device.OnPlatform<Color>(Color.Gray, Color.Green, Color.Blue)
            };

            //Utilizando Condicionais de Compilação
            #if __ANDROID__
                label.Text = $"Android API {Android.OS.Build.VERSION.Sdk}";
            #elif __IOS__
                UIDevice device = new UIDevice();
                label.Text = $"{device.SystemName} {device.SystemVersion}";
            #endif
          
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                       label
                    }

                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
