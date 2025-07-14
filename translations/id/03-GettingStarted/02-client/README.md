<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:18:25+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "id"
}
-->
Dalam kode sebelumnya kita:

- Mengimpor pustaka
- Membuat instance client dan menghubungkannya menggunakan stdio sebagai transport.
- Mendaftar prompt, sumber daya, dan alat, lalu memanggil semuanya.

Itulah, sebuah client yang dapat berkomunikasi dengan MCP Server.

Mari kita luangkan waktu di bagian latihan berikutnya untuk membahas setiap potongan kode dan menjelaskan apa yang terjadi.

## Latihan: Menulis client

Seperti yang sudah disebutkan, mari kita luangkan waktu untuk menjelaskan kode ini, dan silakan ikuti kodenya jika kamu mau.

### -1- Mengimpor pustaka

Mari kita impor pustaka yang kita butuhkan, kita akan membutuhkan referensi ke client dan protokol transport yang kita pilih, yaitu stdio. stdio adalah protokol untuk hal-hal yang dijalankan di mesin lokalmu. SSE adalah protokol transport lain yang akan kita tunjukkan di bab-bab berikutnya, tapi itu adalah opsi lain. Untuk sekarang, mari lanjutkan dengan stdio.

---

Mari kita lanjut ke instansiasi.

### -2- Menginstansiasi client dan transport

Kita perlu membuat instance dari transport dan juga client kita:

---

### -3- Mendaftar fitur server

Sekarang, kita sudah memiliki client yang dapat terhubung saat program dijalankan. Namun, client ini belum benar-benar mendaftar fiturnya, jadi mari kita lakukan itu sekarang:

---

Bagus, sekarang kita sudah menangkap semua fitur. Pertanyaannya, kapan kita menggunakannya? Nah, client ini cukup sederhana, sederhana dalam arti kita harus memanggil fitur-fitur tersebut secara eksplisit saat kita membutuhkannya. Di bab berikutnya, kita akan membuat client yang lebih canggih yang memiliki akses ke model bahasa besar (LLM) miliknya sendiri. Untuk sekarang, mari kita lihat bagaimana kita bisa memanggil fitur-fitur di server:

### -4- Memanggil fitur

Untuk memanggil fitur, kita harus memastikan kita memberikan argumen yang benar dan dalam beberapa kasus nama dari apa yang ingin kita panggil.

---

### -5- Menjalankan client

Untuk menjalankan client, ketik perintah berikut di terminal:

---

## Tugas

Dalam tugas ini, kamu akan menggunakan apa yang sudah kamu pelajari dalam membuat client, tapi buatlah client milikmu sendiri.

Berikut adalah server yang bisa kamu gunakan dan harus kamu panggil melalui kode client-mu, lihat apakah kamu bisa menambahkan lebih banyak fitur ke server agar lebih menarik.

---

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini tentang client adalah sebagai berikut:

- Dapat digunakan untuk menemukan dan memanggil fitur di server.
- Dapat memulai server saat client itu sendiri dijalankan (seperti di bab ini), tapi client juga bisa terhubung ke server yang sudah berjalan.
- Merupakan cara yang bagus untuk menguji kemampuan server selain menggunakan alternatif seperti Inspector yang sudah dijelaskan di bab sebelumnya.

## Sumber Tambahan

- [Membangun client di MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Selanjutnya

- Selanjutnya: [Membuat client dengan LLM](../03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.