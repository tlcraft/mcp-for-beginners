<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:44:29+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "id"
}
-->
# Membuat Klien

Klien adalah aplikasi atau skrip kustom yang berkomunikasi langsung dengan Server MCP untuk meminta sumber daya, alat, dan prompt. Berbeda dengan menggunakan alat inspeksi yang menyediakan antarmuka grafis untuk berinteraksi dengan server, menulis klien sendiri memungkinkan interaksi yang terprogram dan otomatis. Ini memungkinkan pengembang untuk mengintegrasikan kemampuan MCP ke dalam alur kerja mereka sendiri, mengotomatisasi tugas, dan membangun solusi kustom yang disesuaikan dengan kebutuhan spesifik.

## Gambaran Umum

Pelajaran ini memperkenalkan konsep klien dalam ekosistem Model Context Protocol (MCP). Anda akan belajar cara menulis klien sendiri dan menghubungkannya ke Server MCP.

## Tujuan Pembelajaran

Di akhir pelajaran ini, Anda akan dapat:

- Memahami apa yang bisa dilakukan klien.
- Menulis klien sendiri.
- Menghubungkan dan menguji klien dengan server MCP untuk memastikan server bekerja seperti yang diharapkan.

## Apa yang dibutuhkan untuk menulis klien?

Untuk menulis klien, Anda perlu melakukan hal-hal berikut:

- **Mengimpor pustaka yang benar**. Anda akan menggunakan pustaka yang sama seperti sebelumnya, hanya dengan konstruksi yang berbeda.
- **Membuat instansiasi klien**. Ini akan melibatkan pembuatan instance klien dan menghubungkannya ke metode transportasi yang dipilih.
- **Memutuskan sumber daya apa yang akan didaftarkan**. Server MCP Anda dilengkapi dengan sumber daya, alat, dan prompt, Anda perlu memutuskan mana yang akan didaftarkan.
- **Mengintegrasikan klien ke aplikasi host**. Setelah Anda mengetahui kemampuan server, Anda perlu mengintegrasikannya ke aplikasi host Anda sehingga jika pengguna mengetikkan prompt atau perintah lain, fitur server yang sesuai akan dipanggil.

Sekarang kita memahami secara umum apa yang akan kita lakukan, mari kita lihat contoh berikutnya.

### Contoh klien

Mari kita lihat contoh klien ini:
Anda dilatih dengan data hingga Oktober 2023.

Dalam kode sebelumnya, kita:

- Mengimpor pustaka
- Membuat instance klien dan menghubungkannya menggunakan stdio untuk transportasi.
- Mendaftarkan prompt, sumber daya, dan alat serta memanggil semuanya.

Itulah dia, klien yang dapat berbicara dengan Server MCP.

Mari kita luangkan waktu kita di bagian latihan berikutnya dan memecah setiap cuplikan kode serta menjelaskan apa yang sedang terjadi.

## Latihan: Menulis klien

Seperti yang dikatakan di atas, mari kita luangkan waktu menjelaskan kodenya, dan silakan menulis kode bersama jika Anda mau.

### -1- Mengimpor pustaka

Mari kita impor pustaka yang kita butuhkan, kita akan membutuhkan referensi ke klien dan ke protokol transportasi yang kita pilih, stdio. stdio adalah protokol untuk hal-hal yang dimaksudkan untuk dijalankan di mesin lokal Anda. SSE adalah protokol transportasi lain yang akan kami tunjukkan di bab-bab mendatang tetapi itu adalah opsi lain Anda. Untuk saat ini, mari kita lanjutkan dengan stdio.

Mari kita lanjutkan ke instansiasi.

### -2- Menginstansiasi klien dan transportasi

Kita perlu membuat instance dari transportasi dan klien kita:

### -3- Mendaftarkan fitur server

Sekarang, kita memiliki klien yang dapat terhubung ketika program dijalankan. Namun, ini sebenarnya tidak mendaftarkan fiturnya, jadi mari kita lakukan itu selanjutnya:

Bagus, sekarang kita telah menangkap semua fitur. Sekarang pertanyaannya adalah kapan kita menggunakannya? Nah, klien ini cukup sederhana, sederhana dalam arti bahwa kita perlu secara eksplisit memanggil fitur saat kita menginginkannya. Di bab berikutnya, kita akan membuat klien yang lebih canggih yang memiliki akses ke model bahasa besar sendiri, LLM. Untuk saat ini, mari kita lihat bagaimana kita dapat memanggil fitur di server:

### -4- Memanggil fitur

Untuk memanggil fitur, kita perlu memastikan kita menentukan argumen yang benar dan dalam beberapa kasus nama dari apa yang kita coba panggil.

### -5- Menjalankan klien

Untuk menjalankan klien, ketik perintah berikut di terminal:

## Tugas

Dalam tugas ini, Anda akan menggunakan apa yang telah Anda pelajari dalam membuat klien tetapi membuat klien Anda sendiri.

Berikut adalah server yang dapat Anda gunakan yang perlu Anda panggil melalui kode klien Anda, lihat apakah Anda dapat menambahkan lebih banyak fitur ke server untuk membuatnya lebih menarik.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting untuk bab ini tentang klien adalah:

- Dapat digunakan untuk menemukan dan memanggil fitur di server.
- Dapat memulai server saat dirinya sendiri dimulai (seperti dalam bab ini) tetapi klien juga dapat terhubung ke server yang sedang berjalan.
- Merupakan cara yang bagus untuk menguji kemampuan server selain alternatif seperti Inspector seperti yang dijelaskan di bab sebelumnya.

## Sumber Daya Tambahan

- [Membangun klien di MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Apa Selanjutnya

- Selanjutnya: [Membuat klien dengan LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.