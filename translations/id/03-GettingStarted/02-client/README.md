<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T18:09:24+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "id"
}
-->
Dalam kode sebelumnya kita:

- Mengimpor pustaka
- Membuat instance klien dan menghubungkannya menggunakan stdio sebagai transport.
- Mendaftar prompt, sumber daya, dan alat, lalu memanggil semuanya.

Itulah, sebuah klien yang dapat berkomunikasi dengan MCP Server.

Mari kita luangkan waktu di bagian latihan berikutnya untuk membahas setiap potongan kode dan menjelaskan apa yang terjadi.

## Latihan: Menulis klien

Seperti yang sudah disebutkan, mari kita luangkan waktu untuk menjelaskan kode ini, dan silakan ikuti kodenya jika ingin.

### -1- Mengimpor pustaka

Mari kita impor pustaka yang kita butuhkan, kita akan membutuhkan referensi ke klien dan protokol transport yang kita pilih, yaitu stdio. stdio adalah protokol untuk hal-hal yang dijalankan di mesin lokal Anda. SSE adalah protokol transport lain yang akan kita tunjukkan di bab-bab berikutnya, tapi itu adalah opsi lain. Untuk sekarang, mari lanjutkan dengan stdio.

Mari kita lanjut ke instansiasi.

### -2- Menginstansiasi klien dan transport

Kita perlu membuat instance dari transport dan juga dari klien kita:

### -3- Mendaftar fitur server

Sekarang, kita sudah memiliki klien yang dapat terhubung saat program dijalankan. Namun, klien ini belum benar-benar mendaftar fiturnya, jadi mari kita lakukan itu sekarang:

Bagus, sekarang kita sudah menangkap semua fitur. Pertanyaannya, kapan kita menggunakannya? Nah, klien ini cukup sederhana, sederhana dalam arti kita harus memanggil fitur-fitur tersebut secara eksplisit saat kita membutuhkannya. Di bab berikutnya, kita akan membuat klien yang lebih canggih yang memiliki akses ke model bahasa besar (LLM) miliknya sendiri. Untuk sekarang, mari kita lihat bagaimana cara memanggil fitur-fitur di server:

### -4- Memanggil fitur

Untuk memanggil fitur, kita harus memastikan kita memberikan argumen yang benar dan dalam beberapa kasus nama dari apa yang ingin kita panggil.

### -5- Menjalankan klien

Untuk menjalankan klien, ketik perintah berikut di terminal:

## Tugas

Dalam tugas ini, Anda akan menggunakan apa yang telah Anda pelajari dalam membuat klien, tapi buatlah klien Anda sendiri.

Berikut adalah server yang bisa Anda gunakan dan harus Anda panggil melalui kode klien Anda, lihat apakah Anda bisa menambahkan lebih banyak fitur ke server agar lebih menarik.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini tentang klien adalah sebagai berikut:

- Dapat digunakan untuk menemukan dan memanggil fitur di server.
- Dapat memulai server saat klien itu sendiri dijalankan (seperti di bab ini), tapi klien juga bisa terhubung ke server yang sudah berjalan.
- Merupakan cara yang bagus untuk menguji kemampuan server selain alternatif seperti Inspector yang dijelaskan di bab sebelumnya.

## Sumber Tambahan

- [Membangun klien di MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Selanjutnya

- Selanjutnya: [Membuat klien dengan LLM](../03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.