CREATE DATABASE QL_DanhSachSinhVien
GO
USE QL_DanhSachSinhVien
GO

CREATE TABLE Student
(
	MSSV VARCHAR(7) PRIMARY KEY,
	HoDem NVARCHAR(50),
	Ten NVARCHAR(10),
)
GO

INSERT INTO Student(MSSV,HoDem,Ten) 
VALUES 
	('1812751',N'Nguyễn Thị',N'Hà'),
	('1812750',N'Lệ Ái',N'Mỹ'),
	('1812756',N'Nguyễn Trọng',N'Bóng')
SELECT * FROM Student
GO

 CREATE PROC _getAllStudent
 AS
	 SELECT * FROM Student

GO

EXEC _getAllStudent
