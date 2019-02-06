// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.ComponentModel.DataAnnotations;

namespace AppCore.Validation.DataAnnotations
{
    public class TestModel
    {
        [Required]
        public string Value1 { get; set; }

        [Required]
        public string Value2 { get; set; }
    }
}