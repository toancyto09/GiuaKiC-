using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuynhVanToan_0153_BaiKiemTraGiuaKi
{
    class Program
    {
        class Nguoi
        {
            public string HoTen { get; set; }
            public int Tuoi { get; set; }
            public string NgheNghiep { get; set; }
            public string SoCMND { get; set; }
        }

        class HoGiaDinh
        {
            public int SoThanhVien { get; set; }
            public int SoConTrai { get; set; }
            public int SoConGai => SoThanhVien - SoConTrai;
            public string SoNha { get; set; }
            public List<Nguoi> ThanhVien { get; set; }
        }

        class KhuPho
        {
            public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }

            public KhuPho()
            {
                DanhSachHoGiaDinh = new List<HoGiaDinh>();
            }

            public void ThemHoGiaDinh(HoGiaDinh hoGiaDinh)
            {
                DanhSachHoGiaDinh.Add(hoGiaDinh);
            }

            public void HienThiThongTinHoGiaDinh()
            {
                Console.WriteLine("Thong tin cac ho dan trong khu pho:");
                foreach (var hoGiaDinh in DanhSachHoGiaDinh)
                {
                    Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
                    Console.WriteLine($"So thanh vien: {hoGiaDinh.SoThanhVien}");
                    Console.WriteLine($"So con trai: {hoGiaDinh.SoConTrai}");
                    Console.WriteLine($"So con gai: {hoGiaDinh.SoConGai}");
                    Console.WriteLine("Danh sach thanh vien:");
                    foreach (var nguoi in hoGiaDinh.ThanhVien)
                    {
                        Console.WriteLine($"Ho ten: {nguoi.HoTen}, Tuoi: {nguoi.Tuoi}, Nghe nghiep: {nguoi.NgheNghiep}, So CMND: {nguoi.SoCMND}");
                    }
                    Console.WriteLine();
                }
            }

            public List<HoGiaDinh> TimHoGiaDinhCoHaiConTraiTroLen()
            {
                return DanhSachHoGiaDinh.Where(hoGiaDinh => hoGiaDinh.SoConTrai >= 2).ToList();
            }

            public List<HoGiaDinh> TimHoGiaDinhCoTuNamDenMuoiCon()
            {
                return DanhSachHoGiaDinh.Where(hoGiaDinh => hoGiaDinh.SoThanhVien >= 5 && hoGiaDinh.SoThanhVien <= 10).ToList();
            }

            public int TinhTongSoThanhVienTrongKhuPho()
            {
                return DanhSachHoGiaDinh.Sum(hoGiaDinh => hoGiaDinh.SoThanhVien);
            }

            public List<HoGiaDinh> TimHoGiaDinhCoNguoiTenHung()
            {
                return DanhSachHoGiaDinh.Where(hoGiaDinh => hoGiaDinh.ThanhVien.Any(nguoi => nguoi.HoTen.ToLower().Contains("hùng"))).ToList();
            }

            public void ThongKeSoConNamNu()
            {
                int tongConNam = DanhSachHoGiaDinh.Sum(hoGiaDinh => hoGiaDinh.SoConTrai);
                int tongConNu = DanhSachHoGiaDinh.Sum(hoGiaDinh => hoGiaDinh.SoConGai);

                Console.WriteLine($"Tong so nam trong khu pho: {tongConNam}");
                Console.WriteLine($"Tổng so nu trong khu pho: {tongConNu}");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap n ho dan: ");
            int soHoGiaDinh = int.Parse(Console.ReadLine());
            KhuPho khuPho = new KhuPho();
            for (int i = 0; i < soHoGiaDinh; i++)
            {
                Console.WriteLine($"Nhap thong tin cho ho gia dinh thu {i + 1}:");
                HoGiaDinh hoGiaDinh = new HoGiaDinh();

                Console.Write("So thanh vien trong ho: ");
                hoGiaDinh.SoThanhVien = int.Parse(Console.ReadLine());

                Console.Write("So con trai: ");
                hoGiaDinh.SoConTrai = int.Parse(Console.ReadLine());

                Console.Write("So nha: ");
                hoGiaDinh.SoNha = Console.ReadLine();

                hoGiaDinh.ThanhVien = new List<Nguoi>();
                for (int j = 0; j < hoGiaDinh.SoThanhVien; j++)
                {
                    Console.WriteLine($"Nhap thong tin thanh vien thu  {j + 1} trong ho:");
                    Nguoi nguoi = new Nguoi();

                    Console.Write("Ho ten: ");
                    nguoi.HoTen = Console.ReadLine();

                    Console.Write("Tuoi: ");
                    nguoi.Tuoi = int.Parse(Console.ReadLine());

                    Console.Write("Nghe nghiep: ");
                    nguoi.NgheNghiep = Console.ReadLine();

                    Console.Write("So CMND: ");
                    nguoi.SoCMND = Console.ReadLine();

                    hoGiaDinh.ThanhVien.Add(nguoi);
                }

                khuPho.ThemHoGiaDinh(hoGiaDinh);
            }

            khuPho.HienThiThongTinHoGiaDinh();

            Console.WriteLine("Cac ho gia dinh co it nhat 2 con trai:");
            var danhSachHaiConTrai = khuPho.TimHoGiaDinhCoHaiConTraiTroLen();
            if (danhSachHaiConTrai.Count == 0)
            {
                Console.WriteLine("Khong co ho gia dinh co it nhat 2 con trai.");
            }
            else
            {
                foreach (var hoGiaDinh in danhSachHaiConTrai)
                {
                    Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
                }
            }

            Console.WriteLine("Cac ho gia dinh co tu 5 --> 10 thanh vien:");
            var danhSachTuNamDenMuoiThanhVien = khuPho.TimHoGiaDinhCoTuNamDenMuoiCon();
            if (danhSachTuNamDenMuoiThanhVien.Count == 0)
            {
                Console.WriteLine("Khong co ho gia dinh thoa man dieu kien");
            }
            else
            {
                foreach (var hoGiaDinh in danhSachTuNamDenMuoiThanhVien)
                {
                    Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
                }
            }

            Console.WriteLine("Tong so thanh vien trong khu pho: " + khuPho.TinhTongSoThanhVienTrongKhuPho());

            Console.WriteLine("Cac ho gia dinh co nguoi ten \"Hùng\":");
            var danhSachCoTenHung = khuPho.TimHoGiaDinhCoNguoiTenHung();
            if (danhSachCoTenHung.Count == 0)
            {
                Console.WriteLine("Khong co ho gia dinh co nguoi ten Hung");
            }
            else
            {
                foreach (var hoGiaDinh in danhSachCoTenHung)
                {
                    Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
                }
            }

            Console.WriteLine("Thong ke so con nam nu trong khu pho:");
            khuPho.ThongKeSoConNamNu();

            Console.ReadKey();
        }
    }
}
