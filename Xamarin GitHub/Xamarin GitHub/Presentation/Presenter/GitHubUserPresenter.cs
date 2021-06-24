using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin_GitHub.Data.Entity;
using Xamarin_GitHub.Data.Entity.Mapper;
using Xamarin_GitHub.Domain.UseCase;
using Xamarin_GitHub.Presentation.View;

namespace Xamarin_GitHub.Presentation.Presenter
{
    public class GitHubUserPresenter
    {
        GetAllGitHubUsersUseCase UseCase = new GetAllGitHubUsersUseCase();
        public GitHubUserView View { get; set; }

        public void LoadGithubUsers(string query)
        {
            UseCase.Execute(new GitHubUserListListObserver { Presenter = this}, new Params { Query = query });

            View.OnLoadingStart();
        }

        class GitHubUserListListObserver : DefaultObserver<List<GitHubUserEntity>>
        {
            GitHubUserMapper Mapper = new GitHubUserMapper();

            public GitHubUserPresenter Presenter { get; set; }

            public override void OnCompleted()
            {
                
            }

            public override void OnError(Exception error)
            {
                if (error.InnerException is HttpRequestException && !App.IsNetworkAvailable())
                {
                    Presenter.View.OnNetworkDisabledError();
                }
                else
                {
                    Presenter.View.RenderError(error);
                }
            }

            public override void OnNext(List<GitHubUserEntity> value)
            {
                if (value != null)
                {
                    Presenter.View.Render(Mapper.TransformList(value));
                }
            }
        }
    }
}