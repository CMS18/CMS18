using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Image File", GUID = "15fea603-d21d-4a77-b917-5137df364ba0", Description = "Use this to upload image files.")]
    [MediaDescriptor(ExtensionString = "png,gif,jpg,jpeg")]
    public class ImageFile : ImageData
    {
        [CultureSpecific]
        [Editable(true)]
        public virtual string Description { get; set; }
    }
}