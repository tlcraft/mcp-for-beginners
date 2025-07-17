<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:46:22+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "id"
}
-->
# Kontrol Keamanan MCP Terbaru - Pembaruan Juli 2025

Seiring dengan perkembangan Model Context Protocol (MCP), keamanan tetap menjadi perhatian utama. Dokumen ini menjelaskan kontrol keamanan terbaru dan praktik terbaik untuk mengimplementasikan MCP secara aman per Juli 2025.

## Otentikasi dan Otorisasi

### Dukungan Delegasi OAuth 2.0

Pembaruan terbaru pada spesifikasi MCP kini memungkinkan server MCP mendelegasikan otentikasi pengguna ke layanan eksternal seperti Microsoft Entra ID. Hal ini secara signifikan meningkatkan postur keamanan dengan:

1. **Menghilangkan Implementasi Otentikasi Kustom**: Mengurangi risiko celah keamanan pada kode otentikasi kustom  
2. **Memanfaatkan Penyedia Identitas Terpercaya**: Mendapatkan keuntungan dari fitur keamanan tingkat perusahaan  
3. **Mencentralisasi Manajemen Identitas**: Mempermudah pengelolaan siklus hidup pengguna dan kontrol akses  


## Pencegahan Token Passthrough

Spesifikasi Otorisasi MCP secara tegas melarang token passthrough untuk mencegah pengelakan kontrol keamanan dan masalah akuntabilitas.

### Persyaratan Utama

1. **Server MCP TIDAK BOLEH menerima token yang tidak diterbitkan untuk mereka**: Validasi bahwa semua token memiliki klaim audience yang benar  
2. **Terapkan validasi token yang tepat**: Periksa issuer, audience, masa berlaku, dan tanda tangan  
3. **Gunakan penerbitan token terpisah**: Terbitkan token baru untuk layanan downstream daripada meneruskan token yang sudah ada  

## Manajemen Sesi yang Aman

Untuk mencegah pembajakan dan serangan session fixation, terapkan kontrol berikut:

1. **Gunakan ID sesi yang aman dan non-deterministik**: Dibuat dengan generator angka acak kriptografis  
2. **Ikatan sesi dengan identitas pengguna**: Gabungkan ID sesi dengan informasi spesifik pengguna  
3. **Terapkan rotasi sesi yang tepat**: Setelah perubahan otentikasi atau eskalasi hak akses  
4. **Atur waktu habis sesi yang sesuai**: Menyeimbangkan keamanan dengan pengalaman pengguna  


## Sandboxing Eksekusi Alat

Untuk mencegah pergerakan lateral dan membatasi potensi kompromi:

1. **Isolasi lingkungan eksekusi alat**: Gunakan container atau proses terpisah  
2. **Terapkan batasan sumber daya**: Mencegah serangan kehabisan sumber daya  
3. **Terapkan akses dengan prinsip least privilege**: Berikan hanya izin yang diperlukan  
4. **Pantau pola eksekusi**: Deteksi perilaku anomali  

## Perlindungan Definisi Alat

Untuk mencegah keracunan alat:

1. **Validasi definisi alat sebelum digunakan**: Periksa instruksi berbahaya atau pola yang tidak sesuai  
2. **Gunakan verifikasi integritas**: Hash atau tanda tangan definisi alat untuk mendeteksi perubahan tidak sah  
3. **Terapkan pemantauan perubahan**: Beri peringatan pada modifikasi metadata alat yang tidak terduga  
4. **Kontrol versi definisi alat**: Lacak perubahan dan aktifkan rollback jika diperlukan  

Kontrol ini bekerja bersama untuk menciptakan postur keamanan yang kuat bagi implementasi MCP, mengatasi tantangan unik sistem berbasis AI sekaligus mempertahankan praktik keamanan tradisional yang kokoh.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.