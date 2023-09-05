using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("WebSection")]
	public class WebSection : TrackingData
	{
		[Key]
		public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

    }
}

