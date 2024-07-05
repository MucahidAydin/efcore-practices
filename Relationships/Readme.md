# Üniversite Veri Tabanı İlişkileri

Bu proje, bir üniversite veri tabanında farklı ilişki türlerini (one-to-one, one-to-many, many-to-many) örnekleyen bir yapı içermektedir.

## Tablolar ve İlişkiler

### Öğretmenler (Teachers) Tablosu
Bir öğretmenin yalnızca bir ofisi olabilir (one-to-one).

| id  | isim             |
|-----|------------------|
| 1   | Prof. Mücahid AYDİN |
| 2   | Dr. Leyla YILMAZ |

### Ofisler (Offices) Tablosu
| id  | numara | öğretmen_id |
|-----|--------|-------------|
| 1   | 101    | 1           |
| 2   | 102    | 2           |

### Bölümler (Departments) Tablosu
Bir öğretmen birden fazla bölümde çalışabilir (one-to-many).

| id  | ad             | öğretmen_id |
|-----|----------------|-------------|
| 1   | Bilgisayar     | 1           |
| 2   | Elektrik       | 1           |
| 3   | Makine         | 2           |

### Öğrenciler (Students) Tablosu
Bir öğrenci birçok derse kayıt olabilir ve bir ders birçok öğrenci tarafından alınabilir (many-to-many).

| id  | isim           |
|-----|----------------|
| 1   | Mehmet Can     |
| 2   | Fatma Demir    |
| 3   | Ali Veli       |

### Dersler (Courses) Tablosu
| id  | ders_adi       | öğretmen_id |
|-----|----------------|-------------|
| 1   | Algoritmalar   | 1           |
| 2   | Devre Teorisi  | 2           |
| 3   | Termodinamik   | 2           |

### Öğrenci-Ders (StudentCourses) Tablosu
| öğrenci_id | ders_id |
|------------|---------|
| 1          | 1       |
| 1          | 2       |
| 2          | 2       |
| 3          | 1       |
| 3          | 3       |

## Özet
- **One-to-One:** Öğretmenler ve Ofisler (her öğretmenin bir ofisi vardır).
- **One-to-Many:** Öğretmenler ve Bölümler (her öğretmen birden fazla bölümde çalışabilir).
- **Many-to-Many:** Öğrenciler ve Dersler (her öğrenci birçok derse kayıt olabilir ve her ders birçok öğrenci tarafından alınabilir).

Bu tablo yapıları, bir üniversite senaryosunda farklı ilişki türlerini test etmenize olanak sağlar.
