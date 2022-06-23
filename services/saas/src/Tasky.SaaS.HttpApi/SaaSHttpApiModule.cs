﻿using Localization.Resources.AbpUi;
using Tasky.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Tasky.SaaS;

[DependsOn(
    typeof(SaaSApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SaaSHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SaaSHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SaaSResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
