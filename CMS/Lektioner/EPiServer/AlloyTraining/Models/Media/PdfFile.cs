using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Portable Document Format", GUID = "b2c9be04-15eb-43f2-8ebd-b4c898b0035a", Description = "Use this to upload Portable Document Format(PDF) files.")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PdfFile : MediaData
    {
        [Display(Name = "Render preview image")]
        public virtual bool RenderPreviewImage { get; set; }
    }
}