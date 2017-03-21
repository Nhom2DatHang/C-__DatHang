insert into NhanVien (MaNV, HoTenNV, GioiTinh, DiaChi, SDTNV, TaiKhoan, MatKhau, LoaiTaiKhoan)
values ('NV06', N'Nguyễn Vũ Duy', 'Nam', N'Vũng Tàu', '01692235864', 'admin', PWDENCRYPT('admin'),1)

update NhanVien set MatKhau = PWDENCRYPT('123456') where TaiKhoan != 'admin'
go