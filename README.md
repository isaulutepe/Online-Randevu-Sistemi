# Online-Randevu-Sistemi
Randevu Yönetim Sistemi - Katmanlı Mimari ve Web API

Bu proje, katmanlı mimari kullanılarak geliştirilen bir randevu yönetim sistemidir. Platform, hastaların doktorlardan randevu alabileceği, randevularını görüntüleyebileceği ve yönetebileceği bir yapı sunar.
##  Proje Yapısı
Proje, aşağıdaki temel katmanlardan oluşmaktadır:

* **Entity Katmanı**: Veri modelleri (Appointment, Patient, Doctor).
* **Data Access Katmanı**: Veritabanı işlemleri (CRUD).
* **Business Katmanı**: İş kuralları ve mantıksal kontrol işlemleri.
* **API Katmanı**: RESTful API endpoint'ler

##  Temel İşlevler
### ‍ Kullanıcı İşlemleri
* 🟢 Kullanıcı ekleyebilme, listeleyebilme, güncelleyebilme ve silebilme.
* 🟢 Ad, soyad ve e-posta adresi, şifre bilgileri.
* 🟢 ID üzerinden tekil erişim

### Doktor İşlemleri
* 🟢 Doktor ekleyebilme, listeleyebilme, güncelleyebilme ve silebilme.
* 🟢 Ad, soyad ve e-posta adresi, uzmanlık alanı, telefon numarası bilgileri.
* 🟢 ID üzerinden tekil erişim.
* 🟢 Uzmanlık alanlarına göre listeleme.

### Randevu İşlemleri
* 🟢 Randevu ekleyebilme, listeleyebilme, güncelleyebilme ve silebilme.
* 🟢 Doktorun uygunluk kontrolü.
* 🟢 Hastanın aynı gün içinde birden fazla randevu almasını engelleme.
* 🟢 ID üzerinden tekil erişim.

## API Endpoint'leri
| İşlem               | HTTP Metodu | Endpoint                                     |
| :------------------ | :---------- | :--------------------                        |
| Kullanıcı Listele     | GET       | /api/user                               |
| Tekil Kullanıcı Getir | GET       | /api/user/{id}                          |
| Kullanıcı Ekle        | POST      | /api/user                               |
| Kullanıcı Güncelle    | PUT       | /api/user/{id}                          |
| Kullanıcı Sil         | DELETE    | /api/user/{id}                          |
| Doktor Listele        | GET       | /api/doctor                                  |
| Tekil Doktor Getir    | GET       | /api/doctor/by-id/{id}                             |
| Doktor Listele(Uzmanlık Alanına Göre)    | GET       | /api/doctor/by-specialization/{specialization}                             |
| Doktor Ekle           | POST      | /api/doctor                                  |  
| Doktor Güncelle       | PUT       | /api/doctor/{id}                             |
| Doktor Sil            | DELETE    | /api/doctor/{id}                             |
| Randevu Ekle          | POST      | /api/appointment      |
| Randevu Sil           | DELETE    | /api/appointment/{id}                            |
| Randevu Güncelle       | PUT       | /api/appointment/{id}                            |
| Randevu Listele        | GET       | /api/appointment                                 |
| Tekil Randevu Getir    | GET       | /api/appointment/{id}                            |
