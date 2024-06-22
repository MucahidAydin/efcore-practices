using Querying.Contexts;
using Querying.Entities;

namespace Querying.CRUD
{
    public class Insert
    {
        private static readonly Random _random = new Random();

        public async Task InsertData()
        {
            ETicaretContext context = new ETicaretContext();

            Urun urun1 = new Urun
            {
                UrunAdi = $"Urun-{Guid.NewGuid()}",
                Fiyat = _random.Next(1000, 10000),
                StokAdedi = _random.Next(1, 200)
            };

            List<string> parcaAdlari = new List<string>
            {
                "Ekran Kartı", "Anakart", "İşlemci", "Ram", "SSD", "HDD", "Kasa", "Güç Kaynağı", "Soğutucu", "Monitör", "Klavye", "Fare",
                "CD/DVD Sürücü", "Blu-ray Sürücü", "Hoparlör", "Kulaklık", "Webcam", "Ethernet Kablosu", "USB Bellek", "Harici Hard Disk",
                "Mikrofon", "Modem", "Router", "Switch", "Joystick", "Gamepad", "VR Gözlüğü", "Mousepad", "Laptop Çantası", "Soğutucu Pad",
                "Yazıcı", "Tarayıcı", "Kablo Yönetim Sistemi", "Adaptör", "Çoklayıcı", "KVM Switch", "Docking Station", "Dijital Kalem",
                "Hafıza Kartı", "Kart Okuyucu", "PCI Kart", "WiFi Kartı", "Bluetooth Adaptörü", "Tablet", "Elektronik Kitap Okuyucu",
                "Kablolu Kulaklık", "Kablosuz Kulaklık", "Powerbank", "Şarj Cihazı", "Laptop Standı", "Güç Kablosu", "Fan", "LED Aydınlatma",
                "Thermal Macun", "Soğutma Bloğu", "Klima", "UPS", "CCTV Kamera", "Dijital Fotoğraf Makinesi", "Lens", "Tripod", "Projektör",
                "Projeksiyon Perdesi", "Masa Lambası", "Şarj Kablosu", "Pil", "Taşınabilir Hoparlör", "Mikro SD Kart", "Micro USB Kablosu",
                "Lightning Kablosu", "Type-C Kablosu", "VGA Kablosu", "HDMI Kablosu", "DVI Kablosu", "DisplayPort Kablosu", "SATA Kablosu",
                "RGB Kontrolcü", "RGB Şerit LED", "Arka Aydınlatma", "Ön Panel", "Yan Panel", "İşlemci Soğutucusu", "Ekran Kartı Soğutucusu",
                "Hard Disk Kutusu", "Hard Disk Mounting Bracket", "SSD Mounting Bracket", "USB Hub", "USB Uzatma Kablosu", "USB-C Hub",
                "USB-C Adaptör", "Mini DisplayPort Adaptör", "HDMI Splitter", "HDMI Switch", "DVI Adaptör", "VGA Adaptör", "Yedek Parça Seti",
                "Anti-Static Bileklik", "PC Temizleme Seti", "PC Temizleme Fırçası", "PC Temizleme Spreyi", "PC Tamir Kiti", "Network Tester",
                "Crimping Tool", "Kablo Kesici", "Kablo Soyucu", "Network Konektör", "Patch Panel", "Keystone Jack", "Fiber Optik Kablo",
                "Fiber Optik Konnektör", "Fiber Optik Kesici", "Fiber Optik Temizleyici", "Fiber Optik Splice", "Fiber Optik Kiti",
                "Network Rack", "Network Kabin", "Server Kabin", "Data Center Ekipmanları", "Network Kartı", "Network Adaptörü",
                "Power Over Ethernet Injector", "Power Over Ethernet Splitter", "Modem Router", "Access Point", "Wireless Extender",
                "Network Switch", "Managed Switch", "Unmanaged Switch", "Gigabit Switch", "10-Gigabit Switch", "Network Analyzer",
                "Network Monitor", "Bandwidth Monitor", "Network Tap", "Network Probe", "Network Sniffer", "Packet Analyzer", "Packet Capturer"
            };

            int parcaSayisi = _random.Next(1, parcaAdlari.Count);

            List<Parca> parcalar1 = new List<Parca>();
            List<string> rastgeleParcalar = parcaAdlari.OrderBy(x => _random.Next()).Take(parcaSayisi).ToList();

            foreach (string parcaAdi in rastgeleParcalar)
            {
                parcalar1.Add(new Parca { ParcaAdi = $"{parcaAdi}-{Guid.NewGuid()}" });
            }

            await context.Urunler.AddRangeAsync(urun1);
            await context.Parcalar.AddRangeAsync(parcalar1);
            await context.SaveChangesAsync();

            List<UrunParca> urunParcalar = new List<UrunParca>();
            foreach (Parca parca in parcalar1)
            {
                urunParcalar.Add(new UrunParca
                {
                    UrunId = urun1.Id,
                    ParcaId = parca.Id
                });
            }

            await context.UrunParcalar.AddRangeAsync(urunParcalar);
            await context.SaveChangesAsync();
        }
    }
}
