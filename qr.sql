CREATE DATABASE QUANLYVANCHUYEN

CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
    TenKhachHang NVARCHAR(100),
    SDT VARCHAR(15),
    DiaChi NVARCHAR(200)
);

ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKhachHang)
REFERENCES KhachHang(MaKhachHang)
ON DELETE CASCADE;


CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    NgayDatHang DATE,
    TrangThai NVARCHAR(50),
    GhiChu NVARCHAR(200)
);
ALTER TABLE DonHang
ADD CONSTRAINT DF_NgayDatHang DEFAULT GETDATE() FOR NgayDatHang;
ALTER TABLE DonHang
ADD CONSTRAINT DF_TrangThai DEFAULT N'Chờ xác nhận' FOR TrangThai;


CREATE TABLE XeVanChuyen (
    MaXe INT PRIMARY KEY IDENTITY(1,1),
    BienSo VARCHAR(20),
    TaiXe NVARCHAR(100),
    LoaiXe NVARCHAR(50)
);
ALTER TABLE XeVanChuyen
ADD CONSTRAINT UQ_BienSo UNIQUE (BienSo);

CREATE TABLE ChiTietVanChuyen (
    MaVanChuyen INT PRIMARY KEY IDENTITY(1,1),
    MaDonHang INT FOREIGN KEY REFERENCES DonHang(MaDonHang),
    MaXe INT FOREIGN KEY REFERENCES XeVanChuyen(MaXe),
    NgayGiaoHang DATE,
    TrangThaiVanChuyen NVARCHAR(50)
);
ALTER TABLE ChiTietVanChuyen
DROP COLUMN NgayGiaoHang;

ALTER TABLE ChiTietVanChuyen
ADD CONSTRAINT FK_ChiTietVanChuyen_DonHang FOREIGN KEY (MaDonHang)
REFERENCES DonHang(MaDonHang)
ON DELETE CASCADE;


ALTER TABLE ChiTietVanChuyen
ADD CONSTRAINT FK_ChiTietVanChuyen_XeVanChuyen FOREIGN KEY (MaXe)
REFERENCES XeVanChuyen(MaXe)
ON DELETE CASCADE;
CREATE TABLE Users(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Pass NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
);

INSERT INTO KhachHang VALUES
('Le tien hai', '0377586361','Vinh Phuc'),
(N'Lò Văn Anh', '0396158395', 'NSơn La'),
(N'Đinh Hải Dương', '0396158395', 'NThanh Hóa')

INSERT INTO DonHang 
VALUES
(1, '2024-10-28', N'Đang vận chuyển', N'Hàng cồng kềnh'),
(2, '2024-1-10',N'Chờ xác nhận',N'Hàng dễ vỡ xin nhẹ tay'),
(3,'2024-12-12',N'Giao thành công','')

INSERT INTO XeVanChuyen
VALUES
('88C-F1-10235',N'Hoàng Minh Quân', 'Wave Alpha'),
('37C-AB-20596',N'Lê Thiên An', 'SH Model'),
('34C-F1-58234',N'Vũ Kim Quý', 'Wave Alpha')


SELECT UserID, Username, Role FROM Users
SELECT COUNT(*) FROM DonHang
SELECT * FROM DonHang WHERE (  NgayDatHang = '2024-01-10' AND TrangThai = 'Chờ xác nhận') OR ( MaDonHang = -1)

SELECT * FROM Users
SELECT * FROM ChiTietVanChuyen
SELECT * FROM KhachHang
SELECT * FROM XeVanChuyen
SELECT * FROM DonHang
SELECT * FROM ChiTietVanChuyen WHERE MaDonHang = '8'
DELETE DonHang WHERE MaDonHang = 7

INSERT INTO KhachHang (TenKhachHang, SDT, DiaChi) VALUES
(N'Nguyễn Văn A', '0357123456', N'Hà Nội'),
(N'Trần Thị B', '0389765432', N'Hải Phòng'),
(N'Lê Văn C', '0377896543', N'Đà Nẵng'),
(N'Phạm Văn D', '0391122334', N'Quảng Ninh'),
(N'Hoàng Thị E', '0365566778', N'Thái Bình'),
(N'Vũ Thị F', '0344455667', N'Nam Định'),
(N'Đỗ Văn G', '0337788990', N'Hồ Chí Minh'),
(N'Lý Thị H', '0321122334', N'Cần Thơ'),
(N'Tô Văn I', '0313344556', N'Bắc Ninh'),
(N'Huỳnh Thị K', '0309876543', N'Nha Trang');

INSERT INTO DonHang (MaKhachHang, NgayDatHang, TrangThai, GhiChu) VALUES
(21, '2024-11-01', N'Chờ xác nhận', N'Hàng dễ vỡ'),
(22, '2024-11-02', N'Đang vận chuyển', N'Giao sau 5h chiều'),
(23, '2024-11-03', N'Giao thành công', N'Khách yêu cầu kiểm tra hàng'),
(24, '2024-11-04', N'Chờ xác nhận', N'Giao nhanh trước 12h'),
(26, '2024-11-06', N'Đang vận chuyển', N'Trọng lượng nặng, cần xe lớn'),
(27, '2024-11-07', N'Giao thành công', N''),
(28, '2024-11-08', N'Chờ xác nhận', N'Đơn hàng số lượng lớn'),
(29, '2024-11-09', N'Đang vận chuyển', N'Khách không liên lạc được'),
(21, '2024-11-11', N'Giao thành công', N''),
(22, '2024-11-12', N'Chờ xác nhận', N'Giao hàng nhanh'),
(23, '2024-11-13', N'Đang vận chuyển', N'Hàng dễ vỡ, cần cẩn thận'),
(24, '2024-11-14', N'Giao thành công', N'Khách phản hồi tích cực'),
(25, '2024-11-15', N'Hủy đơn', N'Lỗi từ phía nhà cung cấp'),
(26, '2024-11-16', N'Đang vận chuyển', N'Hàng chuyển sang ngày mai'),
(27, '2024-11-17', N'Giao thành công', N'Hàng nguyên vẹn'),
(28, '2024-11-18', N'Chờ xác nhận', N'Khách cần nhận vào sáng sớm'),
(29, '2024-11-19', N'Đang vận chuyển', N'Không liên lạc được với tài xế')

INSERT INTO ChiTietVanChuyen (MaDonHang, MaXe, TrangThaiVanChuyen) VALUES
(41, 1, N'Đã nhận hàng từ kho'),
(42, 2, N'Đang giao hàng'),
(43, 3, N'Đã giao hàng'),
(44, 1, N'Chưa giao hàng'),
(45, 2, N'Hủy giao hàng'),
(46, 3, N'Đang xử lý vận chuyển'),
(47, 1, N'Giao hàng thành công'),
(48, 2, N'Chờ giao'),
(49, 3, N'Giao thất bại'),
(50, 1, N'Đã hủy giao hàng');





