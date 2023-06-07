using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public double? FileSize { get; set; }
        public int? TaskId { get; set; }

        public virtual AssignTask? Task { get; set; }
    }
}
