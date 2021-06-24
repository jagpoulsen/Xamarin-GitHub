using System;
using System.Collections.Generic;
using Xamarin_GitHub.Data.Entity;
using Xamarin_GitHub.Domain;

namespace Xamarin_GitHub.Presentation.View
{
    public interface IGitHubUserView
    {
        void OnLoadingStart();

        void Render(List<GitHubUserModel> list);

        void RenderError(Exception error);

        void OnNetworkDisabledError();
    }
}