namespace WebBanTranSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int maSlide { get; set; }

        [StringLength(1000)]
        [Display(Name = "Hình ảnh")]
        public string hinhAnh { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        public string name { get; set; }

        [StringLength(100)]
        [Display(Name = "Mô tả ngắn")]
        public string moTaNgan { get; set; }
    }
}
