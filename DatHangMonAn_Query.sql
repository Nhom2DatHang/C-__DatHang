create proc [dbo].[SP_ChonTaiKhoan]
as
	select MaTaiKhoan, TenTaiKhoan
	from TaiKhoan
	where TinhTrang = 1
go

create proc [dbo].[SP_ChucNang_Combobox]
@mataikhoan int
as
	select MaChucNang, TenChucNang
	from ChucNang
	where TinhTrang = 1 and MaChucNang not in (select MaChucNang from  PhanQuyen where MaTaiKhoan=@mataikhoan)
go

create proc [dbo].[SP_PhanQuyen_Insert]
@machucnang int,
@mataikhoan int,
@giatriquyen int
as
	if exists (select 1 from PhanQuyen where MaTaiKhoan = @mataikhoan and MaChucNang = @machucnang)
		begin
			update PhanQuyen
			set GiaTriQuyen = @giatriquyen
			where MaTaiKhoan = @mataikhoan and MaChucNang = @machucnang
		end
	else
		begin
			insert into PhanQuyen(MaChucNang, MaTaiKhoan, GiaTriQuyen)
			values(@machucnang, @mataikhoan, @giatriquyen)
		end
go

create proc [dbo].[SP_PhanQuyen_Select]
@mataikhoan int
as

	select ROW_NUMBER() over (order by (select 1)) as STT, a.MaChucNang,TenChucNang,a.MaTaiKhoan, GiaTriQuyen,0 as xem,0 as them,0 as sua,0 as xoa
	from PhanQuyen a  inner join ChucNang b on a.MaChucNang=b.MaChucNang inner join TaiKhoan c on a.MaTaiKhoan=c.MaTaiKhoan
	where a.MaTaiKhoan=@mataikhoan
go

--Trang
Go
alter proc [dbo].[sp_KhachHang_SelectIDMax]
as
select isnull(max(Convert(int,substring(MaKH,3,9))),0)+1 as MaKH 
from KhachHang
Go


create proc [dbo].[sp_KhachHang_Chon]
as
select ROW_NUMBER() over (order by (select 1)) as STT,MaKH, TenKH, DiaChiKH, SDTKH, Email, CMND,0 as Xoa
from KhachHang
order by MaKH asc
Go

alter proc [dbo].[sp_KhachHang_Xoa]
@MaKH varchar(10)
as
delete KhachHang
where MaKH=@MaKH
Go


create proc [dbo].[sp_KhachHang_Them_Sua]
@MaKH varchar(10), 
@TenKH  nvarchar(50), 
@DiaChiKH nvarchar(100), 
@Email varchar(50), 
@SoDienThoai varchar(20),
@CMND int
as
if exists (select 1 from KhachHang where MaKH=@MaKH)
begin
	update KhachHang
	set 
	
	 TenKH=@TenKH, 
	 DiaChiKH=@DiaChiKH, 
	 Email=@Email,
	 CMND=@CMND,
	 SDTKH=@SoDienThoai
	 where MaKH=@MaKH
		
end
else
begin
	insert into KhachHang(MaKH, TenKH, DiaChiKH, SDTKH, Email, CMND)
	values(@MaKH, @TenKH, @DiaChiKH, @SoDienThoai,@Email,@CMND)
end

