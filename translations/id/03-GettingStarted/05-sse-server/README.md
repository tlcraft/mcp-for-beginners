<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T19:59:00+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "id"
}
-->
Sekarang setelah kita tahu sedikit lebih banyak tentang SSE, mari kita buat server SSE selanjutnya.

## Latihan: Membuat Server SSE

Untuk membuat server kita, kita perlu mengingat dua hal:

- Kita perlu menggunakan web server untuk membuka endpoint untuk koneksi dan pesan.
- Bangun server kita seperti biasa dengan tools, resources, dan prompt saat kita menggunakan stdio.

### -1- Membuat instance server

Untuk membuat server, kita menggunakan tipe yang sama seperti dengan stdio. Namun, untuk transport, kita perlu memilih SSE.

---

Mari kita tambahkan rute yang dibutuhkan selanjutnya.

### -2- Menambahkan rute

Mari tambahkan rute yang menangani koneksi dan pesan masuk:

---

Selanjutnya, mari tambahkan kemampuan ke server.

### -3- Menambahkan kemampuan server

Sekarang setelah kita mendefinisikan semua yang spesifik untuk SSE, mari tambahkan kemampuan server seperti tools, prompt, dan resources.

---

Kode lengkap Anda harus terlihat seperti ini:

---

Bagus, kita sudah memiliki server menggunakan SSE, mari kita coba jalankan selanjutnya.

## Latihan: Debugging Server SSE dengan Inspector

Inspector adalah alat yang hebat yang sudah kita lihat di pelajaran sebelumnya [Membuat server pertama Anda](/03-GettingStarted/01-first-server/README.md). Mari kita lihat apakah kita bisa menggunakan Inspector di sini juga:

### -1- Menjalankan inspector

Untuk menjalankan inspector, Anda harus memiliki server SSE yang berjalan terlebih dahulu, jadi mari lakukan itu sekarang:

1. Jalankan server

---

1. Jalankan inspector

    > ![NOTE]
    > Jalankan ini di jendela terminal yang terpisah dari tempat server berjalan. Juga perhatikan, Anda perlu menyesuaikan perintah di bawah ini agar sesuai dengan URL tempat server Anda berjalan.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Menjalankan inspector terlihat sama di semua runtime. Perhatikan bagaimana kita tidak melewatkan path ke server dan perintah untuk memulai server, melainkan melewatkan URL tempat server berjalan dan juga menentukan rute `/sse`.

### -2- Mencoba alat ini

Hubungkan server dengan memilih SSE di daftar dropdown dan isi kolom url dengan alamat tempat server Anda berjalan, misalnya http:localhost:4321/sse. Sekarang klik tombol "Connect". Seperti sebelumnya, pilih untuk menampilkan daftar tools, pilih sebuah tool dan berikan nilai input. Anda akan melihat hasil seperti di bawah ini:

![Server SSE berjalan di inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.id.png)

Bagus, Anda bisa bekerja dengan inspector, mari kita lihat bagaimana cara bekerja dengan Visual Studio Code selanjutnya.

## Tugas

Cobalah membangun server Anda dengan lebih banyak kemampuan. Lihat [halaman ini](https://api.chucknorris.io/) untuk, misalnya, menambahkan tool yang memanggil API. Anda yang menentukan seperti apa servernya. Selamat bersenang-senang :)

## Solusi

[Solusi](./solution/README.md) Berikut adalah solusi yang mungkin dengan kode yang berfungsi.

## Poin Penting

Poin penting dari bab ini adalah sebagai berikut:

- SSE adalah transport kedua yang didukung setelah stdio.
- Untuk mendukung SSE, Anda perlu mengelola koneksi masuk dan pesan menggunakan framework web.
- Anda dapat menggunakan baik Inspector maupun Visual Studio Code untuk mengkonsumsi server SSE, sama seperti server stdio. Perhatikan perbedaannya sedikit antara stdio dan SSE. Untuk SSE, Anda perlu menjalankan server secara terpisah lalu menjalankan alat inspector Anda. Untuk alat inspector, ada juga beberapa perbedaan yaitu Anda perlu menentukan URL.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Selanjutnya

- Selanjutnya: [HTTP Streaming dengan MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.