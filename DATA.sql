USE master
GO
IF EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = 'QLVP')
			DROP DATABASE QLVP
GO
CREATE DATABASE QLVP
GO
USE QLVP
GO

CREATE TABLE BenhNhan(
		MABN			VARCHAR(15),
		SoCMND			VARCHAR(20),
		HoTen			NVARCHAR(200) NOT NULL,
		NgaySinh 		DATE,
		GioiTinh		NVARCHAR(10),
		SDT				VARCHAR(15),
		DiaChi			NVARCHAR(300),
		MAPK			INT,
		NgayKham		DATE,
		CONSTRAINT PK_BENH_NHAN PRIMARY KEY(MABN)
)
GO
CREATE TABLE PhongKham(
		MAPK INT IDENTITY( 1, 1)		PRIMARY KEY,
		TenPhongKham	NVARCHAR(30) NOT NULL
)
GO
CREATE TABLE Khoa (
		MaKhoa	VARCHAR(10) PRIMARY KEY NOT NULL,
		TenKhoa	NVARCHAR(50) NOT NULL,
		SoLuong	INT NULL
)
GO
CREATE TABLE BacSi(
		MABS			VARCHAR(10) PRIMARY KEY,
		TenBS			NVARCHAR(100) NOT NULL,
		Ngaysinh		DATE NOT NULL,
		DiaChi			NVARCHAR(300) NOT NULL,
		GioiTinh		NVARCHAR(10),
		SDT				VARCHAR(15) NOT NULL,
		Email			VARCHAR(100),
		MAPK			INT,
		MaKhoa			VARCHAR(10)
)
GO
CREATE TABLE NhanVien(
		MANV			VARCHAR(10) PRIMARY KEY,
		TenNV			NVARCHAR(100) NOT NULL,
		NgaySinh		DATE NOT NULL,
		DiaChi			NVARCHAR(300) NOT NULL,
		GioiTinh		NVARCHAR(10),
		SDT				VARCHAR(15) NOT NULL,
		Email			VARCHAR(100)
)
GO
CREATE TABLE TaiKhoan(
		TenDangNhap		VARCHAR(30) NOT NULL PRIMARY KEY,
		MatKhau			VARCHAR(30) NOT NULL,
		MANV			VARCHAR(10),
		MaLoai			VARCHAR(10)
)
GO
CREATE TABLE BienLai(
		SoBienLai INT IDENTITY(1,1) PRIMARY KEY,
		MABN VARCHAR(15),
		NgayThanhToan DATE,
		TongTien FLOAT,
		TaiKhoan VARCHAR(30)
)
GO
CREATE TABLE KhoanCP(
		MaKhoanCP INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
		TenKhoanCP NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE CT_BienLai(
		MABL		INT,
		MACP		INT,
		SoTien		FLOAT,
		CONSTRAINT PK_CT_BIENLAI PRIMARY KEY(MABL, MACP)
)
GO
CREATE TABLE Loai
(
	MaLoai VARCHAR(10) PRIMARY KEY NOT NULL,
	TenLoai	NVARCHAR(20) NOT NULL
)
GO
ALTER TABLE TaiKhoan	ADD CONSTRAINT FK_TAIKHOAN_LOAI FOREIGN KEY(MALOAI) REFERENCES Loai(MaLoai),
							CONSTRAINT FK_TAIKHOAN_NV FOREIGN KEY(MANV) REFERENCES NhanVien(MANV)
GO
ALTER TABLE BacSi		ADD CONSTRAINT FK_BACSI_KHOA FOREIGN KEY(MAKHOA) REFERENCES Khoa(MaKhoa),
							CONSTRAINT FK_BACSI_PK FOREIGN KEY(MAPK) REFERENCES PhongKham(MAPK)
GO
ALTER TABLE BenhNhan	ADD CONSTRAINT FK_BENHNHAN_PHK FOREIGN KEY(MAPK) REFERENCES PhongKham(MAPK)
GO
ALTER TABLE BienLai		ADD CONSTRAINT FK_BL_BENHNHAN FOREIGN KEY(MABN) REFERENCES BenhNhan(MABN),
							CONSTRAINT FK_BL_TAIKHOAN FOREIGN KEY(TAIKHOAN) REFERENCES TaiKhoan(TenDangNhap)
GO
ALTER TABLE CT_BienLai	 ADD CONSTRAINT FK_CT_BIENLAI_BL FOREIGN KEY(MABL) REFERENCES BienLai(SoBienLai),
							CONSTRAINT FK_CT_BIENLAI_KHOANCP FOREIGN KEY(MACP) REFERENCES KhoanCP(MaKhoanCP)
GO
----------------------------------------------------- THÊM -----------------------------------------------------
------------------------ PROCEDURE THÊM MỚI BỆNH NHÂN ----------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemBN
(
	@MABN			VARCHAR(15),
	@SoCMND			VARCHAR(20),
	@HoTen			NVARCHAR(200),
	@NgaySinh		DATE,
	@GioiTinh		NVARCHAR(10),
	@SDT			VARCHAR(15),
	@DiaChi			NVARCHAR(300),
	@PhongKham		INT,
	@NgayKham		DATE
)AS
	BEGIN
		IF EXISTS(SELECT * FROM BenhNhan WHERE MABN = @MABN)
		BEGIN
			RAISERROR(N'BỆNH NHÂN CÓ MÃ SỐ : %s NÀY ĐÃ TỒN TẠI RỒI!!!', 16, 1, @MABN)
		END
		ELSE IF NOT EXISTS(SELECT * FROM PhongKham WHERE MAPK = @PhongKham)
			RAISERROR(N'KHÔNG CÓ PHÒNG KHÁM %s ', 16, 1, @PhongKham)
		ELSE
			BEGIN
				INSERT INTO BenhNhan(MABN, SoCMND, HoTen, NgaySinh, GioiTinh, SDT, DiaChi, MAPK, NgayKham) 
					VALUES(@MABN, @SoCMND, @HoTen, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @PhongKham, @NgayKham)
				INSERT INTO BienLai(MABN) 
					VALUES(@MABN)
			END
	END
GO
------------------------ PROCEDURE THÊM MỚI BÁC SĨ -------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemBS(
		@MABS			VARCHAR(10),
		@TenBS			NVARCHAR(100),
		@NgaySinh		DATE,
		@DiaChi 		NVARCHAR(300),
		@GioiTinh		NVARCHAR(10),
		@SDT			VARCHAR(15),
		@Email			VARCHAR(100),
		@MAPK			INT,
		@MaKhoa			VARCHAR(10)
)AS
BEGIN
		IF EXISTS(SELECT * FROM BacSi WHERE MABS = @MABS)
			RAISERROR(N'BÁC SĨ CÓ MÃ SỐ : %s NÀY ĐÃ TỒN TẠI RỒI!!!',16,1,@MABS)
		ELSE IF NOT EXISTS(SELECT * FROM Khoa WHERE MaKhoa = @MaKhoa)
			RAISERROR(N'KHOA %s NÀY KHÔNG CÓ TRONG BỆNH VIỆN', 16,1,@MAKHOA)
		ELSE IF NOT EXISTS(SELECT * FROM PhongKham WHERE MAPK = @MAPK)
			RAISERROR(N'PHÒNG KHÁM %s NÀY KHÔNG TỒN TẠI', 16, 1, @MAPK)
		ELSE
			BEGIN
				INSERT INTO BacSi(MABS,TenBS,Ngaysinh,GioiTinh,DiaChi,SDT,Email, MaKhoa, MAPK)
						VALUES(@MABS,@TenBS, @Ngaysinh, @GioiTinh, @DiaChi, @SDT, @Email, @MaKhoa, @MAPK)
				DECLARE	CS_KHOA CURSOR FOR
						SELECT Khoa.MaKhoa, COUNT(BacSi.MABS) AS 'TT'
						FROM Khoa INNER JOIN BacSi ON KHOA.MAKHOA = BacSi.MaKhoa
						GROUP BY Khoa.MaKhoa
					OPEN CS_KHOA
					DECLARE @MK VARCHAR(30),
							@TT INT
					FETCH NEXT FROM CS_KHOA INTO @MK, @TT
					WHILE @@FETCH_STATUS = 0
						BEGIN
							UPDATE Khoa
								SET SoLuong = @TT
							WHERE MaKhoa = @MK
							FETCH NEXT FROM CS_KHOA INTO @MK, @TT
						END
					CLOSE CS_KHOA
				DEALLOCATE CS_KHOA
			END
END
GO
------------------------ PROCEDURE THÊM MỚI NHÂN VIÊN ----------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemNV(
		@MANV			CHAR(10),
		@TenNV			NVARCHAR(100),
		@NgaySinh		DATE,
		@DiaChi		NVARCHAR(300),
		@GioiTinh		NVARCHAR(10),
		@SDT			CHAR(15),
		@Email			VARCHAR(100)
)AS
BEGIN
		IF EXISTS(SELECT * FROM NhanVien WHERE MANV = @MANV)
			RAISERROR(N'NHÂN VIÊN CÓ MÃ SỐ : %s NÀY ĐÃ TỒN TẠI RỒI!!!',16,1,@MANV)
		ELSE
			INSERT INTO NhanVien(MANV,TenNV,NgaySinh,GioiTinh,DiaChi,SDT,Email)
				VALUES(@MANV,@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SDT,@Email)
END
GO
------------------------ PROCEDURE THÊM MỚI KHOA ---------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemKhoa
(
	@MaKhoa		CHAR(10),
	@TenKhoa	NVARCHAR(50)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM Khoa WHERE MaKhoa = @MaKhoa)
				RAISERROR(N'MÃ KHOA : %s ĐÃ TỒN TẠI RỒI!!!', 16, 1, @MaKhoa)
		ELSE
			INSERT INTO Khoa(MaKhoa, TenKhoa, SoLuong) VALUES(@MaKhoa, @TenKhoa, 0)
	END
GO
------------------------ PROCEDURE THÊM MỚI KHOẢN CHI PHÍ ------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemCP
(
	@TenCP NVARCHAR(100)
)AS
	BEGIN
		INSERT INTO KhoanCP(TenKhoanCP) VALUES(@TenCP)
	END
GO
------------------------ PROCEDURE THÊM MỚI PHÒNG KHÁM ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemPK
(
	@TenPK NVARCHAR(30)
)AS
	BEGIN
		INSERT INTO PhongKham(TenPhongKham) VALUES(@TenPK)
	END
GO
------------------------ PROCEDURE THÊM TÀI KHOẢN --------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemTaiKhoan
(
	@TaiKhoan	 	VARCHAR(30),
	@MatKhau		VARCHAR(30),
	@MANV			CHAR(10),
	@MaLoai			CHAR(10)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM TaiKhoan WHERE TenDangNhap = @TaiKhoan)
				RAISERROR(N'TÀI KHOẢN :%s ĐÃ TỒN TẠI RỒI!!!', 16, 1, @TaiKhoan)
		ELSE IF NOT EXISTS(SELECT * FROM NhanVien WHERE MANV = @MANV)
				RAISERROR(N'NHÂN VIÊN CÓ MÃ SỐ : %s NÀY CHƯA TỒN TẠI', 16, 1, @MANV)
		ELSE IF NOT EXISTS(SELECT * FROM LOAI WHERE MALOAI = @MALOAI)
				RAISERROR(N'TÀI KHOẢN CÓ MÃ LOẠI : %s NÀY CHƯA TỒN TẠI VUI LÒNG THÊM MÃ LOẠI %s VÀO LOẠI TÀI KHOẢN', 16, 1, @MALOAI, @MALOAI)
		ELSE
				INSERT INTO TaiKhoan(TenDangNhap, MatKhau, MANV, MALOAI) VALUES(@TaiKhoan, HASHBYTES('MD5', @MatKhau), @MANV, @MaLoai)
	END
GO
------------------------ PROCEDURE THÊM LOẠI TÀI KHOẢN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemLoai
(
	@MaLoai		CHAR(10),
	@TenLoai	NVARCHAR(20)
)AS
	BEGIN
			IF EXISTS(SELECT * FROM Loai WHERE MaLoai = @MaLoai)
					RAISERROR(N'TÀI KHOẢN CÓ MÃ LOẠI : %s ĐÃ TỒN TẠI RỒI', 16, 1, @MaLoai)
			ELSE
				INSERT INTO Loai(MaLoai, TenLoai) VALUES(@MaLoai, @TenLoai)
	END

GO
------------------------------- TẠO PROCEDURE CẬP NHẬT TỔNG TIỀN CỦA BIÊN LAI ----------------------------------
CREATE OR ALTER PROCEDURE SP_TongTien
(
	@MABL INT,
	@MACP INT,
	@Gia  FLOAT
)AS
	BEGIN
		IF NOT EXISTS(SELECT * FROM BienLai WHERE SoBienLai = @MABL)
				RAISERROR(N'BIÊN LAI CÓ MÃ SỐ : %d NÀY KHÔNG TỒN TẠI', 16, 1, @MABL)
		ELSE IF NOT EXISTS(SELECT * FROM KhoanCP WHERE MaKhoanCP = @MACP)
				RAISERROR(N'CHI PHÍ CÓ MÃ SỐ : %d NÀY KHÔNG TỒN TẠI', 16, 1, @MACP)
		ELSE 
			BEGIN
					INSERT INTO CT_BienLai(MABL, MACP, SoTien) VALUES(@MABL, @MACP, @GIA)
					DECLARE CS_TT CURSOR FOR
								SELECT MABL, SUM(SoTien) AS 'TT'
								FROM CT_BienLai
								GROUP BY MABL
						OPEN CS_TT
							DECLARE @TT FLOAT,
									@SBL INT
						FETCH NEXT FROM CS_TT INTO @SBL, @TT
							WHILE @@FETCH_STATUS = 0
								BEGIN
									UPDATE BienLai SET TongTien = @TT WHERE SoBienLai = @SBL
									FETCH NEXT FROM CS_TT INTO @SBL, @TT
								END
						CLOSE CS_TT
					DEALLOCATE CS_TT
			END
	END
GO
------------------------ PROCEDURE THÊM BIEN LAI ---------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ThemBienLai
	@MABN VARCHAR(20),
	@TaiKhoan VARCHAR(30)
AS
	BEGIN
		INSERT INTO BienLai(MABN, TaiKhoan) VALUES (@MABN, @TaiKhoan) 
	END
GO
------------------------------------------------- XÓA ----------------------------------------------------------
------------------------------ PROCEDURE XÓA BỆNH NHÂN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_XoaBN
(
	@MABN CHAR(15)
)AS
	BEGIN
		DECLARE @MABL INT
		SELECT @MABN = MABN, @MABL = SoBienLai
		FROM BienLai
		WHERE MABN = @MABN

		IF EXISTS(SELECT * FROM CT_BienLai WHERE MABL = @MABL)
			DELETE CT_BienLai WHERE MABL = @MABL
		IF EXISTS(SELECT * FROM BienLai WHERE MABN = @MABN)
			DELETE BienLai WHERE MABN = @MABN
		IF EXISTS(SELECT * FROM BenhNhan WHERE MABN = @MABN)
			DELETE BenhNhan WHERE MABN = @MABN
		ELSE
			RAISERROR(N'BỆNH NHÂN CÓ MÃ SỐ : %s KHÔNG TỒN TẠI', 16,1, @MABN)
	END
GO
------------------------------ PROCEDURE XÓA BÁC SĨ ------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_XoaBS
(
	@MABS CHAR(15)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM BacSi WHERE MABS = @MABS)
			BEGIN
				DELETE BacSi WHERE MABS = @MABS
				DECLARE	CS_KHOA CURSOR FOR
						SELECT Khoa.MaKhoa, COUNT(BacSi.MABS) AS 'TT'
						FROM Khoa INNER JOIN BacSi ON KHOA.MAKHOA = BacSi.MaKhoa
						GROUP BY Khoa.MaKhoa
					OPEN CS_KHOA
					DECLARE @MK VARCHAR(30),
							@TT INT
					FETCH NEXT FROM CS_KHOA INTO @MK, @TT
					WHILE @@FETCH_STATUS = 0
						BEGIN
							UPDATE Khoa
								SET SoLuong = @TT
							WHERE MaKhoa = @MK
							FETCH NEXT FROM CS_KHOA INTO @MK, @TT
						END
					CLOSE CS_KHOA
				DEALLOCATE CS_KHOA
			END
		ELSE
			RAISERROR(N'BÁC SĨ CÓ MÃ SỐ : %s KHÔNG TỒN TẠI', 16,1, @MABS)
	END
GO
------------------------------ PROCEDURE XÓA BỆNH NHÂN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_XoaNV
(
	@MANV CHAR(15)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM TaiKhoan WHERE MANV = @MANV)
			DELETE TaiKhoan WHERE MANV = @MANV
		IF EXISTS(SELECT * FROM NhanVien WHERE MANV = @MANV)
			DELETE NhanVien WHERE MANV = @MANV
		ELSE 
			RAISERROR(N'NHÂN VIÊN CÓ MÃ SỐ : %s KHÔNG TỒN TẠI', 16,1, @MANV)
	END
GO
-------- Xóa chi tiết biên lai ------
CREATE OR ALTER PROCEDURE SP_XoaCTBL
(
	@MABL INT,
	@MACP INT
)AS
	BEGIN
		IF EXISTS(SELECT * FROM CT_BienLai WHERE MABL = @MABL AND MACP = @MACP)
			BEGIN
				DELETE CT_BienLai WHERE MABL = @MABL AND MACP = @MACP
				DECLARE CS_TT CURSOR FOR
								SELECT MABL, SUM(SoTien) AS 'TT'
								FROM CT_BienLai
								GROUP BY MABL
					OPEN CS_TT
						DECLARE @TT FLOAT,
								@SBL INT
					FETCH NEXT FROM CS_TT INTO @SBL, @TT
						WHILE @@FETCH_STATUS = 0
						BEGIN
							UPDATE BienLai SET TongTien = @TT WHERE SoBienLai = @SBL
							FETCH NEXT FROM CS_TT INTO @SBL, @TT
						END
					CLOSE CS_TT
				DEALLOCATE CS_TT
			END
	END
GO
------------------------------------------------- SỬA ----------------------------------------------------------
------------------------------ PROCEDURE SỬA BỆNH NHÂN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateBN
(
	@MABN			VARCHAR(15),
	@SoCMND			VARCHAR(20),
	@HoTen			NVARCHAR(200),
	@NgaySinh		DATE,
	@GioiTinh		NVARCHAR(10),
	@SDT			VARCHAR(15),
	@DiaChi			NVARCHAR(300),
	@PhongKham		INT,
	@NgayKham		DATE
)AS
	BEGIN
		IF EXISTS(SELECT * FROM BenhNhan WHERE MABN = @MABN)
		BEGIN
			UPDATE BenhNhan
					SET SoCMND		= @SoCMND,
						HoTen		= @HoTen,
						NgaySinh	= @NgaySinh,
						GioiTinh	= @GioiTinh,
						SDT			= @SDT,
						DiaChi		= @DiaChi,
						MAPK		= @PhongKham,
						NgayKham	= @NgayKham
			WHERE MABN = @MABN
		END
	END
GO
------------------------------ PROCEDURE SỬA BÁC SĨ ------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateBS(
		@MABS			VARCHAR(10),
		@TenBS			NVARCHAR(100),
		@NgaySinh		DATE,
		@DiaChi			NVARCHAR(300),
		@GioiTinh		NVARCHAR(10),
		@SDT			VARCHAR(15),
		@Email			VARCHAR(100),
		@MAPK			INT,
		@MaKhoa			VARCHAR(10)
)AS
	BEGIN
			IF EXISTS(SELECT * FROM BacSi WHERE MABS = @MABS)
				BEGIN
					UPDATE BacSi 
						SET TenBS		= @TenBS,
							Ngaysinh	= @NgaySinh,
							DiaChi		= @DiaChi,
							GioiTinh	= @GioiTinh,
							SDT			= @SDT,
							Email		= @Email,
							MAPK		= @MAPK,
							MaKhoa		= @MaKhoa
					WHERE MABS = @MABS
					DECLARE	CS_KHOA CURSOR FOR
							SELECT Khoa.MaKhoa, COUNT(BacSi.MABS) AS 'TT'
							FROM Khoa INNER JOIN BacSi ON KHOA.MAKHOA = BacSi.MaKhoa
							GROUP BY Khoa.MaKhoa
						OPEN CS_KHOA
						DECLARE @MK VARCHAR(30),
								@TT INT
						FETCH NEXT FROM CS_KHOA INTO @MK, @TT
						WHILE @@FETCH_STATUS = 0
							BEGIN
								UPDATE Khoa
									SET SoLuong = @TT
								WHERE MaKhoa = @MK
								FETCH NEXT FROM CS_KHOA INTO @MK, @TT
							END
						CLOSE CS_KHOA
					DEALLOCATE CS_KHOA
				END
	END
GO
------------------------------ PROCEDURE SỬA LOẠI TÀI KHOẢN ----------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateLoai
(
	@MaLoai		VARCHAR(10),
	@TenLoai	NVARCHAR(20)
)AS
	BEGIN
			IF EXISTS(SELECT * FROM Loai WHERE MaLoai = @MALOAI)
					UPDATE Loai
						SET MaLoai = @MaLoai,
							TenLoai = @TenLoai
					WHERE MaLoai = @MaLoai
	END
GO
------------------------------ PROCEDURE SỬA TÀI KHOẢN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateTaiKhoan
(
	@TaiKhoan		VARCHAR(30),
	@MatKhau		VARCHAR(30),
	@MANV			VARCHAR(10),
	@MaLoai			VARCHAR(10)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM TaiKhoan WHERE TenDangNhap = @TaiKhoan)
				UPDATE TaiKhoan
					SET MatKhau		= HASHBYTES( 'MD5', @MatKhau),
						MANV			= @MANV,
						MaLoai			= @MaLoai
				WHERE TenDangNhap = @TaiKhoan
	END
GO
------------------------------ PROCEDURE SỬA NHÂN VIÊN ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateNV(
		@MANV			VARCHAR(10),
		@TenNV			NVARCHAR(100),
		@NgaySinh		DATE,
		@DiaChi			NVARCHAR(300),
		@GioiTinh		NVARCHAR(10),
		@SDT			VARCHAR(15),
		@Email			VARCHAR(100)
)AS
	BEGIN
			IF EXISTS(SELECT * FROM NhanVien WHERE MANV = @MANV)
				BEGIN
						UPDATE NhanVien
							SET TenNV = @TenNV,
								NgaySinh = @NgaySinh,
								DiaChi = @DiaChi,
								GioiTinh = @GioiTinh,
								SDT = @SDT,
								Email = @Email
						WHERE MANV = @MANV
				END
	END
GO
------------------------------ PROCEDURE SỬA KHOA ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateKhoa
(
	@MaKhoa		VARCHAR(10),
	@TenKhoa	NVARCHAR(50)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM Khoa WHERE MaKhoa = @MaKhoa)
				UPDATE Khoa
					SET TenKhoa = @TenKhoa
				WHERE MaKhoa = @MaKhoa
	END
GO
------------------------------ PROCEDURE SỬA KHOẢN CHI PHÍ ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateKhoanCP
(
	@MaKhoanCP INT,
	@TenKhoanCP NVARCHAR(100)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM KhoanCP WHERE MaKhoanCP = @MaKhoanCP)
				UPDATE KhoanCP
					SET TenKhoanCP = @TenKhoanCP
				WHERE MaKhoanCP = @MaKhoanCP
	END
GO
------------------------------ PROCEDURE SỬA BIÊN LAI ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateBL
(
		@SoBienLai INT,
		@MABN VARCHAR(15),
		@NgayThanhToan DATE,
		@TaiKhoan VARCHAR(30)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM BienLai WHERE SoBienLai = @SoBienLai)
				UPDATE BienLai
						SET NgayThanhToan = @NgayThanhToan,
							TaiKhoan = @TaiKhoan,
							TongTien = 0
				WHERE SoBienLai = @SoBienLai AND MABN = @MABN
	END
GO
------------------------------ PROCEDURE SỬA CT_BIÊN LAI ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdateCTBL
(
	@MABL INT,
	@MACP INT,
	@SoTien FLOAT
)AS
	BEGIN
		IF EXISTS(SELECT * FROM CT_BienLai WHERE MABL = @MABL AND MACP = @MACP)
			BEGIN
				UPDATE CT_BienLai SET SoTien = @SoTien WHERE MABL = @MABL AND MACP = @MACP
				DECLARE CS_TT CURSOR FOR
								SELECT MABL, SUM(SoTien) AS 'TT'
								FROM CT_BienLai
								GROUP BY MABL
					OPEN CS_TT
						DECLARE @TT FLOAT,
								@SBL INT
					FETCH NEXT FROM CS_TT INTO @SBL, @TT
						WHILE @@FETCH_STATUS = 0
						BEGIN
							UPDATE BienLai SET TongTien = @TT WHERE SoBienLai = @SBL
							FETCH NEXT FROM CS_TT INTO @SBL, @TT
						END
					CLOSE CS_TT
				DEALLOCATE CS_TT
			END
	END
GO
------------------------------ PROCEDURE SỬA PHÒNG KHÁM ---------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_UpdatePK
(
	@MAPK INT,
	@TenPhongKham NVARCHAR(30)
)AS
	BEGIN
		IF EXISTS(SELECT * FROM PhongKham WHERE MAPK = @MAPK)
				UPDATE PhongKham
					SET TenPhongKham = @TenPhongKham
				WHERE MAPK = @MAPK
	END
GO

-------------------------------- PROCEDUER ĐĂNG NHẬP -----------------------------------------------------------
CREATE OR ALTER PROCEDURE DangNhap
(
	@TaiKhoan VARCHAR(30),
	@MatKhau VARCHAR(30),
	@MaLoai CHAR(10)
)AS
	BEGIN
			IF EXISTS(SELECT * FROM TaiKhoan WHERE TenDangNhap = @TaiKhoan AND MatKhau = HASHBYTES('MD5', @MatKhau) AND MALOAI = @MaLoai)
					SELECT 1 AS code
			ELSE IF EXISTS(SELECT * FROM TaiKhoan WHERE TenDangNhap = @TaiKhoan AND MatKhau = HASHBYTES('MD5', @MatKhau) AND MALOAI != @MaLoai)
					SELECT 2 AS code
			ELSE SELECT 0 AS code
	END
GO

CREATE OR ALTER VIEW VTaiKhoan
	AS	SELECT TenDangNhap, MatKhau, Loai.TenLoai, NhanVien.MANV, NhanVien.TenNV 
		FROM (NhanVien INNER JOIN TaiKhoan ON TaiKhoan.MANV = NhanVien.MANV) INNER JOIN Loai ON Loai.MaLoai = TaiKhoan.MaLoai
GO
CREATE OR ALTER VIEW VBenhNhan
		AS	SELECT MABN, SoCMND, HoTen, GioiTinh, NgaySinh, SDT, DiaChi, NgayKham, TenPhongKham
			FROM BenhNhan INNER JOIN PhongKham ON BenhNhan.MAPK = PhongKham.MAPK
GO
CREATE OR ALTER VIEW VBacSi
	AS	SELECT	MABS, TenBS, Ngaysinh, GioiTinh, BacSi.SDT, BacSi.Email, BacSi.DiaChi, PhongKham.TenPhongKham, Khoa.TenKhoa
		FROM	(BacSi INNER JOIN Khoa ON BacSi.MaKhoa = Khoa.MaKhoa) INNER JOIN PhongKham ON BacSi.MAPK = PhongKham.MAPK
GO
CREATE OR ALTER VIEW VCT_BienLai
		AS	SELECT MABL, CT_BienLai.MACP, TenKhoanCP, SoTien
			FROM CT_BienLai INNER JOIN KhoanCP ON CT_BienLai.MACP = KhoanCP.MaKhoanCP
GO
------------------------------------------------- GỌI PROCEDURE ------------------------------------------------
--- NHẬP DỮ LIỆU CHO KHOA
[dbo].[SP_ThemKhoa] 'TM', N'Tim mạch'
GO
[dbo].[SP_ThemKhoa] 'HH', N'Hô hấp'
GO
[dbo].[SP_ThemKhoa] 'TK', N'Khoa thần kinh'
GO
[dbo].[SP_ThemKhoa] 'KNHI', N'Khoa nhi'
GO
[dbo].[SP_ThemKhoa] 'KHNOI', N'Khoa nội'
GO
[dbo].[SP_ThemKhoa] 'KHNG', N'Khoa ngoại'
GO
--- NHẬP DỮ LIỆU CHO PHÒNG KHÁM
[dbo].[SP_ThemPK] N'Phòng khám số 1'
GO
[dbo].[SP_ThemPK] N'Phòng xét nghiệm'
GO
[dbo].[SP_ThemPK] N'Phòng cấp cứu'
GO
[dbo].[SP_ThemPK] N'Phòng chụp x-quang'
GO
--- NHẬP DỮ LIỆU CHO LOẠI TÀI KHOẢN
[dbo].[SP_ThemLoai] 'AD', N'Admin'
GO
[dbo].[SP_ThemLoai] 'KT', N'Kế toán'
GO
[dbo].[SP_ThemLoai] 'NV', N'Nhân viên'
GO
[dbo].[SP_ThemNV] 'NV01789462', N'Nguyễn Bảo Long', '1996-7-23', N'TBSQ/34/DR', N'Nam', '0976686348', 'nblong@gmail.com'
GO
[dbo].[SP_ThemNV] 'NV78945302', N'Nguyễn Thị Thu', '1992-8-26', N'Quãng Bình', N'Nữ', '0976598248', 'ntthu@gmail.com'
GO
[dbo].[SP_ThemNV] 'NV78942038', N'Trương Công Huân', '1998-7-24', N'Quãng Ngãi', N'Nam', '0979834748', 'tchuan@gmail.com'
GO
[dbo].[SP_ThemTaiKhoan] 'admin', 'admin', 'NV01789462', 'AD'
GO
[dbo].[SP_ThemTaiKhoan] 'ntthu', 'ntthu', 'NV78945302', 'KT'
GO
[dbo].[SP_ThemTaiKhoan] 'tchuan', 'tchuan', 'NV78942038', 'NV'
GO
--- NHẬP DỮ LIỆU CHO KHOẢN CHI PHÍ
[dbo].[SP_ThemCP] N'Chi phí khám bệnh'
GO
[dbo].[SP_ThemCP] N'Chi phí nhập viện'
GO
[dbo].[SP_ThemCP] N'Chi phí xét nghiệm'
GO
[dbo].[SP_ThemCP] N'Chi phí chụp x-quang'
GO
[dbo].[SP_ThemCP] N'Chi phí thuốc'
GO



SELECT * FROM Khoa
SELECT * FROM KhoanCP
SELECT * FROM LOAI
SELECT * FROM PhongKham
SELECT * FROM BacSi
SELECT * FROM NhanVien
SELECT * FROM TaiKhoan
SELECT * FROM BenhNhan
SELECT * FROM BienLai
SELECT * FROM CT_BienLai