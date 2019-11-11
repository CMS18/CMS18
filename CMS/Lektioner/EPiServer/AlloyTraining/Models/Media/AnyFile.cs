using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Any File", GUID = "30e8fe16-9072-45b5-9459-0c700e48eba8", Description = "Use this to upload any type of file.")]
    public class AnyFile : MediaData
    {
    }
}