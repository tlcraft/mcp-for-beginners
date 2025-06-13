<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:49:33+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "id"
}
-->
Dalam kode sebelumnya kami:

- Mengimpor pustaka
- Membuat instance client dan menghubungkannya menggunakan stdio untuk transportasi.
- Mendaftar prompt, sumber daya, dan alat serta memanggil semuanya.

Itulah dia, sebuah client yang dapat berkomunikasi dengan MCP Server.

Mari kita luangkan waktu pada bagian latihan berikutnya untuk membedah setiap potongan kode dan menjelaskan apa yang sedang terjadi.

## Latihan: Menulis client

Seperti yang sudah disebutkan, mari kita luangkan waktu untuk menjelaskan kodenya, dan tentu saja kamu boleh mengikuti dengan mengetik kodenya juga jika ingin.

### -1- Mengimpor pustaka

Mari kita impor pustaka yang kita butuhkan, kita akan memerlukan referensi ke client dan ke protokol transportasi yang kita pilih, yaitu stdio. stdio adalah protokol untuk hal-hal yang dijalankan di mesin lokal kamu. SSE adalah protokol transportasi lain yang akan kita tunjukkan di bab-bab berikutnya, tapi itu adalah opsi lain kamu. Untuk sekarang, mari kita lanjutkan dengan stdio.

---

Mari kita lanjut ke instansiasi.

### -2- Menginstansiasi client dan transportasi

Kita perlu membuat instance dari transportasi dan juga dari client kita:

---

### -3- Mendaftar fitur server

Sekarang, kita sudah punya client yang bisa terhubung saat program dijalankan. Namun, client ini belum benar-benar menampilkan fitur-fiturnya, jadi mari kita lakukan itu sekarang:

---

Bagus, sekarang kita sudah menangkap semua fitur. Sekarang pertanyaannya, kapan kita menggunakannya? Nah, client ini cukup sederhana, sederhana dalam arti kita harus memanggil fitur-fitur tersebut secara eksplisit saat membutuhkannya. Di bab berikutnya, kita akan membuat client yang lebih canggih yang memiliki akses ke model bahasa besar miliknya sendiri, LLM. Tapi untuk sekarang, mari kita lihat bagaimana kita bisa memanggil fitur-fitur di server:

### -4- Memanggil fitur

Untuk memanggil fitur, kita harus memastikan kita memberikan argumen yang benar dan dalam beberapa kasus nama dari apa yang ingin kita panggil.

---

### -5- Menjalankan client

Untuk menjalankan client, ketik perintah berikut di terminal:

---

## Tugas

Dalam tugas ini, kamu akan menggunakan apa yang sudah kamu pelajari dalam membuat client, tetapi membuat client versi kamu sendiri.

Berikut adalah server yang bisa kamu gunakan dan harus kamu panggil melalui kode client kamu, coba tambahkan lebih banyak fitur ke server agar lebih menarik.

---

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini mengenai client adalah sebagai berikut:

- Dapat digunakan untuk menemukan dan memanggil fitur di server.
- Dapat memulai server saat client juga mulai (seperti di bab ini) tapi client juga bisa terhubung ke server yang sudah berjalan.
- Merupakan cara yang bagus untuk menguji kemampuan server selain alternatif seperti Inspector yang sudah dijelaskan di bab sebelumnya.

## Sumber Tambahan

- [Membangun client di MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Selanjutnya

- Selanjutnya: [Membuat client dengan LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.