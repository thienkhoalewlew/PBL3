CREATE DATABASE Typing_Practice_DB

use Typing_Practice_DB

CREATE TABLE nguoidung (
  manguoidung varchar(10) PRIMARY KEY,
  hoten NVARCHAR(255),
  gioitinh BIT,
  ngaysinh DATE,
  sdt VARCHAR(10),
  tongdiem float
);

ALTER TABLE taikhoan
ADD FOREIGN KEY (manguoidung)
REFERENCES nguoidung(manguoidung);

ALTER TABLE diemdanh
ADD FOREIGN KEY (manguoidung)
REFERENCES nguoidung(manguoidung);

ALTER TABLE kiluc
ADD FOREIGN KEY (manguoidung)
REFERENCES nguoidung(manguoidung);

CREATE TABLE taikhoan(
	mataikhoan varchar(10) PRIMARY KEY,
	manguoidung varchar(10),
	email varchar(50),
	password varchar(20),
	role BIT
);

create table baitap (
	mabaitap varchar(10) primary key,
	tenbaitap varchar(50),
	noidung varchar(255),
	dokho varchar(20),
	thoigian time,
	ngaytao date,
	diemmokhoa float
);


ALTER TABLE kiluc
ADD FOREIGN KEY (mabaitap)
REFERENCES baitap(mabaitap);

CREATE TABLE kiluc (
	makiluc varchar(10) primary key,
	manguoidung varchar(10),
	mabaitap varchar(10),
	tilegosai float,
	diembaitap float,
	solanthuchien int
);

CREATE TABLE diemdanh (
	manguoidung varchar(10),
	ngay date,
 PRIMARY KEY (manguoidung, ngay)
 );

ALTER TABLE kiluc
DROP COLUMN tilegosai;
 
 ALTER TABLE kiluc
DROP COLUMN solanthuchien;

ALTER TABLE baitap ADD solanthuchien int

ALTER TABLE baitap
DROP COLUMN solanthuchien

ALTER TABLE kiluc ADD solanthuchien int

ALTER TABLE baitap ADD Xoa BIT NOT NULL DEFAULT 1;