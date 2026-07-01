using MangaWorkflow.MauiHybridWebApp.HuyNQ.Shared.Services;

namespace MangaWorkflow.MauiHybridWebApp.HuyNQ.Web.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
