using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace NewEpiserver
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ExtendedTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default()
                    .AddPlugin("media wordcount anchor code table")
                    .Toolbar("formatselect | epi-personalized-content epi-link anchor numlist bullist indent outdent bold italic underline alignleft aligncenter alignright | image epi-image-editor media code | epi-dnd-processor | removeformat | table tabledelete | tableprops tablerowprops tablecellprops | tableinsertrowbefore tableinsertrowafter tabledeleterow | tableinsertcolbefore tableinsertcolafter tabledeletecol | fullscreen")
                    .AddSetting("image_caption", true)
                    .AddSetting("image_advtab", true);
            });
        }
    }
}