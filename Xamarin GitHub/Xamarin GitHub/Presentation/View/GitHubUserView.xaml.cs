using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_GitHub.Domain;
using Xamarin_GitHub.Presentation.Presenter;

namespace Xamarin_GitHub.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GitHubUserView :  ContentPage, IGitHubUserView
	{
		private enum ViewState
		{
			Normal, Error, Loading, Offline
		}

		private ObservableCollection<GitHubUserModel> GitHubUsers { get; set; }
		private readonly GitHubUserPresenter _presenter;
		public GitHubUserView()
		{
			InitializeComponent();

			Title = "Xamarin GitHub Users";

			GitHubUsers = new ObservableCollection<GitHubUserModel>();
			_presenter = new GitHubUserPresenter { View = this };
			UpdateViewState(ViewState.Normal);
		}

		#region View commands

		private async void OnTap(object sender, ItemTappedEventArgs e)
		{
			if (e.Item is GitHubUserModel item) await DisplayAlert("GitHub User", item.Name, "OK");
		}
		#endregion View commands

		public void OnLoadingStart()
		{
			UpdateViewState(ViewState.Loading);
		}

		public void Render(IEnumerable<GitHubUserModel> list)
		{
			Device.BeginInvokeOnMainThread(() => 
			{
				GitHubUsers.Clear();
				foreach (var item in list)
				{
					GitHubUsers.Add(item);
				}
				ListView.ItemsSource = GitHubUsers;

				ListView.IsRefreshing = false;

				UpdateViewState(ViewState.Normal);
			});
		}

		public async void RenderError(Exception error)
		{
			await DisplayAlert("Error", error.InnerException == null ? String.Empty : error.InnerException.ToString(), "OK");
		}

		public void OnNetworkDisabledError()
		{
			ListView.IsRefreshing = false;
			UpdateViewState(ViewState.Offline);
		}
		
		void UpdateViewState(ViewState viewState)
		{
			switch (viewState)
			{
				case ViewState.Normal:
					ErrorLayout.IsVisible = false;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = true;
					break;
				case ViewState.Loading:
					if (!ListView.IsRefreshing)
					{
						ErrorLayout.IsVisible = false;
						ProgressLayout.IsVisible = true;
						ListView.IsVisible = false;	
					}
					break;
				case ViewState.Error:
					ErrorTitle.Text = "Error";
					ErrorMessage.Text = "An error occurred";
					ErrorLayout.IsVisible = true;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = false;
					break;
				case ViewState.Offline:
					ErrorTitle.Text = "Error";
					ErrorMessage.Text = "Network Not Connected";
					ErrorLayout.IsVisible = true;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = false;
					break;
			}
		}
		
		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			_presenter.LoadGithubUsers(e.NewTextValue);
		}
	}
}