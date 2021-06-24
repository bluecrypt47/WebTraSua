﻿namespace WebBanTranSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public long maSanPham { get; set; }

        public long maLoaiSanPham { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        public string tenSanPham { get; set; }

        [StringLength(1000)]
        [Display(Name = "Hình ảnh")]
        public string hinhAnh { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ngayCapNhat { get; set; }

        [Display(Name = "Giá bán")]
        public double? giaBan { get; set; }

        [Display(Name = "Đơn vị tính")]
        [StringLength(100)]
        public string dvt { get; set; }

        [Display(Name = "Giảm giá")]
        public double? giamGia { get; set; }

        [StringLength(1000)]
        [Display(Name = "Giới thiệu sản phẩm")]
        public string gioiThieuSanPham { get; set; }

        [Display(Name = "Sản phẩm mới")]
        public bool? sanPhamMoi { get; set; }

        [Display(Name = "Sản phẩm nổi bật")]
        public bool? sanPhamNoiBat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
