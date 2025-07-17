<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:54:19+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "id"
}
-->
# MCP Security Best Practices - Pembaruan Juli 2025

## Praktik Keamanan Komprehensif untuk Implementasi MCP

Saat bekerja dengan server MCP, ikuti praktik keamanan berikut untuk melindungi data, infrastruktur, dan pengguna Anda:

1. **Validasi Input**: Selalu validasi dan bersihkan input untuk mencegah serangan injeksi dan masalah confused deputy.
   - Terapkan validasi ketat untuk semua parameter alat
   - Gunakan validasi skema untuk memastikan permintaan sesuai format yang diharapkan
   - Saring konten yang berpotensi berbahaya sebelum diproses

2. **Kontrol Akses**: Terapkan autentikasi dan otorisasi yang tepat untuk server MCP Anda dengan izin yang terperinci.
   - Gunakan OAuth 2.0 dengan penyedia identitas yang sudah mapan seperti Microsoft Entra ID
   - Terapkan kontrol akses berbasis peran (RBAC) untuk alat MCP
   - Jangan pernah membuat autentikasi kustom jika solusi yang sudah ada tersedia

3. **Komunikasi Aman**: Gunakan HTTPS/TLS untuk semua komunikasi dengan server MCP dan pertimbangkan enkripsi tambahan untuk data sensitif.
   - Konfigurasikan TLS 1.3 jika memungkinkan
   - Terapkan certificate pinning untuk koneksi penting
   - Rotasi sertifikat secara berkala dan verifikasi keabsahannya

4. **Pembatasan Laju**: Terapkan pembatasan laju untuk mencegah penyalahgunaan, serangan DoS, dan mengelola konsumsi sumber daya.
   - Tetapkan batas permintaan yang sesuai berdasarkan pola penggunaan yang diharapkan
   - Terapkan respons bertingkat untuk permintaan berlebihan
   - Pertimbangkan batas laju spesifik pengguna berdasarkan status autentikasi

5. **Logging dan Monitoring**: Pantau server MCP Anda untuk aktivitas mencurigakan dan terapkan jejak audit yang komprehensif.
   - Catat semua upaya autentikasi dan pemanggilan alat
   - Terapkan peringatan real-time untuk pola mencurigakan
   - Pastikan log disimpan dengan aman dan tidak dapat diubah

6. **Penyimpanan Aman**: Lindungi data sensitif dan kredensial dengan enkripsi yang tepat saat disimpan.
   - Gunakan key vault atau penyimpanan kredensial aman untuk semua rahasia
   - Terapkan enkripsi tingkat field untuk data sensitif
   - Rotasi kunci enkripsi dan kredensial secara berkala

7. **Manajemen Token**: Cegah kerentanan token passthrough dengan memvalidasi dan membersihkan semua input dan output model.
   - Terapkan validasi token berdasarkan klaim audiens
   - Jangan terima token yang tidak secara eksplisit diterbitkan untuk server MCP Anda
   - Kelola masa berlaku token dan rotasi dengan benar

8. **Manajemen Sesi**: Terapkan penanganan sesi yang aman untuk mencegah pembajakan dan serangan session fixation.
   - Gunakan ID sesi yang aman dan tidak deterministik
   - Kaitkan sesi dengan informasi spesifik pengguna
   - Terapkan masa berlaku dan rotasi sesi yang tepat

9. **Sandboxing Eksekusi Alat**: Jalankan eksekusi alat di lingkungan terisolasi untuk mencegah pergerakan lateral jika terjadi kompromi.
   - Terapkan isolasi container untuk eksekusi alat
   - Terapkan batas sumber daya untuk mencegah serangan kelelahan sumber daya
   - Gunakan konteks eksekusi terpisah untuk domain keamanan yang berbeda

10. **Audit Keamanan Berkala**: Lakukan tinjauan keamanan secara berkala pada implementasi dan dependensi MCP Anda.
    - Jadwalkan pengujian penetrasi secara rutin
    - Gunakan alat pemindaian otomatis untuk mendeteksi kerentanan
    - Perbarui dependensi untuk mengatasi masalah keamanan yang diketahui

11. **Penyaringan Keamanan Konten**: Terapkan filter keamanan konten untuk input dan output.
    - Gunakan Azure Content Safety atau layanan serupa untuk mendeteksi konten berbahaya
    - Terapkan teknik prompt shield untuk mencegah prompt injection
    - Pindai konten yang dihasilkan untuk potensi kebocoran data sensitif

12. **Keamanan Rantai Pasokan**: Verifikasi integritas dan keaslian semua komponen dalam rantai pasokan AI Anda.
    - Gunakan paket yang ditandatangani dan verifikasi tanda tangan
    - Terapkan analisis software bill of materials (SBOM)
    - Pantau pembaruan dependensi yang berpotensi berbahaya

13. **Perlindungan Definisi Alat**: Cegah keracunan alat dengan mengamankan definisi dan metadata alat.
    - Validasi definisi alat sebelum digunakan
    - Pantau perubahan tak terduga pada metadata alat
    - Terapkan pemeriksaan integritas untuk definisi alat

14. **Monitoring Eksekusi Dinamis**: Pantau perilaku runtime server MCP dan alat.
    - Terapkan analisis perilaku untuk mendeteksi anomali
    - Siapkan peringatan untuk pola eksekusi yang tidak terduga
    - Gunakan teknik runtime application self-protection (RASP)

15. **Prinsip Hak Istimewa Minimum**: Pastikan server MCP dan alat beroperasi dengan izin seminimal mungkin.
    - Berikan hanya izin spesifik yang dibutuhkan untuk setiap operasi
    - Tinjau dan audit penggunaan izin secara rutin
    - Terapkan akses just-in-time untuk fungsi administratif

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.