namespace PhanCongViec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CongViecs",
                c => new
                    {
                        idCongViec = c.Int(nullable: false, identity: true),
                        tenCongViec = c.String(nullable: false, maxLength: 255),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.idCongViec);
            
            CreateTable(
                "dbo.PhanCongs",
                c => new
                    {
                        idPhanCong = c.Int(nullable: false, identity: true),
                        ngayGiao = c.String(),
                        ngayHoanThanh = c.String(),
                        tinhTrang = c.String(),
                        danhGia = c.String(),
                        idNguoiDung = c.Int(nullable: false),
                        idCongViec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPhanCong)
                .ForeignKey("dbo.CongViecs", t => t.idCongViec)
                .ForeignKey("dbo.NguoiDungs", t => t.idNguoiDung)
                .Index(t => t.idNguoiDung)
                .Index(t => t.idCongViec);
            
            CreateTable(
                "dbo.NguoiDungs",
                c => new
                    {
                        idNguoiDung = c.Int(nullable: false, identity: true),
                        taiKhoan = c.String(nullable: false, maxLength: 255),
                        matKhau = c.String(nullable: false, maxLength: 255),
                        hoTen = c.String(nullable: false, maxLength: 255),
                        soDienThoai = c.String(maxLength: 255),
                        email = c.String(maxLength: 255),
                        diaChi = c.String(),
                        idQuyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idNguoiDung)
                .ForeignKey("dbo.Quyens", t => t.idQuyen)
                .Index(t => t.idQuyen);
            
            CreateTable(
                "dbo.Quyens",
                c => new
                    {
                        idQuyen = c.Int(nullable: false, identity: true),
                        tenQuyen = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idQuyen);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NguoiDungs", "idQuyen", "dbo.Quyens");
            DropForeignKey("dbo.PhanCongs", "idNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.PhanCongs", "idCongViec", "dbo.CongViecs");
            DropIndex("dbo.NguoiDungs", new[] { "idQuyen" });
            DropIndex("dbo.PhanCongs", new[] { "idCongViec" });
            DropIndex("dbo.PhanCongs", new[] { "idNguoiDung" });
            DropTable("dbo.Quyens");
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.PhanCongs");
            DropTable("dbo.CongViecs");
        }
    }
}
