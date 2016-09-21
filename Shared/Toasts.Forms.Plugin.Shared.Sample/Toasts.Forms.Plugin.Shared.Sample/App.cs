﻿using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Toasts.Forms.Plugin.Shared.Sample
{
	public class App : Application
	{
        public App()
        {
            Button showInfo = new Button { Text = "Info" };
            showInfo.Clicked += (s, e) => ShowToast(ToastNotificationType.Info);

            Button showSuccess = new Button { Text = "Success" };
            showSuccess.Clicked += (s, e) => ShowToast(ToastNotificationType.Success);

            Button showWarning = new Button { Text = "Warning" };
            showWarning.Clicked += (s, e) => ShowToast(ToastNotificationType.Warning);

            Button showError = new Button { Text = "Error" };
            showError.Clicked += (s, e) => ShowToast(ToastNotificationType.Error);

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        showInfo,
                        showSuccess,
                        showWarning,
                        showError
                    }
                }
            };


        }

        private async void ShowToast(ToastNotificationType type)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, "Some " + type.ToString().ToLower(), "Some description", TimeSpan.FromSeconds(2));
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}