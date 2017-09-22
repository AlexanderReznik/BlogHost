namespace BlogHost.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comment")]
    public partial class Comment
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
