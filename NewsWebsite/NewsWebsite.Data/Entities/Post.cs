namespace NewsWebsite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public long Id { get; set; }

        public long? CategoryId { get; set; }

        [StringLength(500)]
        [Display(Name = "Tiêu đề")]
        [Required]
        public string Title { get; set; }

        [StringLength(500)]
        public string Alias { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required]
        public string Content { get; set; }

        [StringLength(100)]
        [Display(Name = "Trích dẫn")]
        [Required]
        public string Summary { get; set; }

        [StringLength(50)]
        [Display(Name = "Nguồn")]
        [Required]
        public string Resource { get; set; }

        [StringLength(1000)]
        [Display(Name = "Ảnh")]
        [Required]
        public string Image { get; set; }

        public long? View { get; set; }

        [StringLength(500)]
        [Display(Name = "Tag")]
        [Required]
        public string Tags { get; set; }

        public short? PostStatus { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
    }
}
