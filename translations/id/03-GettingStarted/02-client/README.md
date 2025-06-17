<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:01:01+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "id"
}
-->
Dalam kode sebelumnya kita:

- Mengimpor perpustakaan
- Membuat instance klien dan menghubungkannya menggunakan stdio sebagai transport.
- Mendaftar prompt, sumber daya, dan alat, lalu memanggil semuanya.

Itu dia, sebuah klien yang dapat berkomunikasi dengan MCP Server.

Mari kita luangkan waktu di bagian latihan berikutnya untuk membahas setiap potongan kode dan menjelaskan apa yang terjadi.

## Latihan: Menulis klien

Seperti yang sudah disebutkan, mari kita luangkan waktu untuk menjelaskan kode ini, dan silakan mengikuti sambil mengetik jika kamu mau.

### -1- Mengimpor perpustakaan

Mari kita impor perpustakaan yang kita butuhkan, kita akan membutuhkan referensi ke klien dan protokol transport yang kita pilih, yaitu stdio. stdio adalah protokol untuk hal-hal yang dijalankan di mesin lokalmu. SSE adalah protokol transport lain yang akan kita tunjukkan di bab-bab berikutnya, tapi itu adalah opsi lainnya. Untuk sekarang, mari lanjutkan dengan stdio.

---

Mari kita lanjut ke instansiasi.

### -2- Menginstansiasi klien dan transport

Kita perlu membuat instance dari transport dan juga dari klien kita:

---

### -3- Mendaftar fitur server

Sekarang, kita sudah memiliki klien yang bisa terhubung ketika program dijalankan. Namun, klien ini belum benar-benar mendaftar fiturnya, jadi mari kita lakukan itu selanjutnya:

---

Bagus, sekarang kita sudah menangkap semua fitur. Sekarang pertanyaannya, kapan kita menggunakannya? Klien ini cukup sederhana, maksudnya kita harus secara eksplisit memanggil fitur-fitur tersebut saat kita membutuhkannya. Di bab berikutnya, kita akan membuat klien yang lebih canggih yang memiliki akses ke model bahasa besar (LLM) miliknya sendiri. Untuk sekarang, mari kita lihat bagaimana kita bisa memanggil fitur-fitur pada server:

### -4- Memanggil fitur

Untuk memanggil fitur, kita perlu memastikan kita menyertakan argumen yang benar dan dalam beberapa kasus nama dari apa yang ingin kita panggil.

---

### -5- Menjalankan klien

Untuk menjalankan klien, ketik perintah berikut di terminal:

---

## Tugas

Dalam tugas ini, kamu akan menggunakan apa yang telah kamu pelajari dalam membuat klien, tetapi buatlah klienmu sendiri.

Berikut adalah server yang dapat kamu gunakan yang harus kamu panggil melalui kode klienmu, lihat apakah kamu bisa menambahkan lebih banyak fitur ke server agar menjadi lebih menarik.

---

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini tentang klien adalah sebagai berikut:

- Dapat digunakan untuk menemukan dan memanggil fitur-fitur pada server.
- Dapat memulai server sekaligus menjalankan dirinya sendiri (seperti di bab ini), tetapi klien juga bisa terhubung ke server yang sudah berjalan.
- Merupakan cara yang bagus untuk menguji kemampuan server selain menggunakan alternatif seperti Inspector yang telah dijelaskan di bab sebelumnya.

## Sumber Tambahan

- [Membangun klien di MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Selanjutnya

- Selanjutnya: [Membuat klien dengan LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.