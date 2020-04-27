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
        [Required]
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }

        [StringLength(500)]
        public string Alias { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name ="Nội dung")]
        public string Content { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name ="Tổng quan")]
        public string Summary { get; set; }

        [StringLength(50)]
        [Required]
        public string Resource { get; set; }

        [StringLength(1000)]
        [Display(Name ="Hình ảnh")]
        public string Image { get; set; }

        public long? View { get; set; }

        [StringLength(500)]
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
