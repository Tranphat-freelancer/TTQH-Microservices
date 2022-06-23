using Localization.Resources.AbpUi;
using Tasky.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Tasky.Administration;

[DependsOn(
    typeof(AdministrationApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(AbpPermissionManagementHttpApiModule))]
[DependsOn(typeof(AbpSettingManagementHttpApiModule))]
[DependsOn(typeof(AbpFeatureManagementHttpApiModule))]
public class AdministrationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AdministrationHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AdministrationResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
