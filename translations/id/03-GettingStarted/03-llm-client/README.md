<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:25:11+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
# Membuat klien dengan LLM

Sejauh ini, Anda telah melihat cara membuat server dan klien. Klien dapat memanggil server secara eksplisit untuk mencantumkan alat, sumber daya, dan prompt-nya. Namun, ini bukan pendekatan yang praktis. Pengguna Anda hidup di era agen dan mengharapkan untuk menggunakan prompt dan berkomunikasi dengan LLM untuk melakukannya. Bagi pengguna Anda, tidak masalah jika Anda menggunakan MCP atau tidak untuk menyimpan kemampuan Anda, tetapi mereka mengharapkan untuk menggunakan bahasa alami untuk berinteraksi. Jadi bagaimana kita menyelesaikan ini? Solusinya adalah dengan menambahkan LLM ke klien.

## Ikhtisar

Dalam pelajaran ini, kita akan fokus pada penambahan LLM ke klien Anda dan menunjukkan bagaimana ini memberikan pengalaman yang jauh lebih baik bagi pengguna Anda.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Membuat klien dengan LLM.
- Berinteraksi dengan mulus dengan server MCP menggunakan LLM.
- Memberikan pengalaman pengguna akhir yang lebih baik di sisi klien.

## Pendekatan

Mari kita coba memahami pendekatan yang perlu kita ambil. Menambahkan LLM terdengar sederhana, tetapi apakah kita benar-benar akan melakukannya?

Berikut cara klien akan berinteraksi dengan server:

1. Membangun koneksi dengan server.

1. Mencantumkan kemampuan, prompt, sumber daya, dan alat, serta menyimpan skema mereka.

1. Menambahkan LLM dan meneruskan kemampuan yang disimpan serta skema mereka dalam format yang dipahami LLM.

1. Menangani prompt pengguna dengan meneruskannya ke LLM bersama dengan alat yang terdaftar oleh klien.

Bagus, sekarang kita mengerti bagaimana kita bisa melakukannya pada tingkat tinggi, mari kita coba dalam latihan di bawah ini.

## Latihan: Membuat klien dengan LLM

Dalam latihan ini, kita akan belajar menambahkan LLM ke klien kita.

### -1- Terhubung ke server

Mari kita buat klien kita terlebih dahulu:
Anda dilatih pada data hingga Oktober 2023.

Bagus, untuk langkah selanjutnya, mari kita daftar kemampuan di server.

### -2 Daftar kemampuan server

Sekarang kita akan terhubung ke server dan meminta kemampuannya:

### -3- Konversi kemampuan server ke alat LLM

Langkah selanjutnya setelah mencantumkan kemampuan server adalah mengonversinya ke dalam format yang dipahami LLM. Setelah kita melakukannya, kita dapat menyediakan kemampuan ini sebagai alat untuk LLM kita.

Bagus, kita belum siap menangani permintaan pengguna, jadi mari kita selesaikan itu selanjutnya.

### -4- Menangani permintaan prompt pengguna

Dalam bagian kode ini, kita akan menangani permintaan pengguna.

Bagus, Anda berhasil!

## Tugas

Ambil kode dari latihan dan bangun server dengan beberapa alat lagi. Kemudian buat klien dengan LLM, seperti dalam latihan, dan uji dengan berbagai prompt untuk memastikan semua alat server Anda dipanggil secara dinamis. Cara membangun klien ini berarti pengguna akhir akan memiliki pengalaman pengguna yang hebat karena mereka dapat menggunakan prompt, bukan perintah klien yang tepat, dan tidak menyadari adanya server MCP yang dipanggil.

## Solusi

[Solusi](/03-GettingStarted/03-llm-client/solution/README.md)

## Poin Penting

- Menambahkan LLM ke klien Anda memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan Server MCP.
- Anda perlu mengonversi respons Server MCP menjadi sesuatu yang dapat dipahami oleh LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Daya Tambahan

## Apa Selanjutnya

- Selanjutnya: [Mengonsumsi server menggunakan Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan terjemahan yang akurat, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan jasa penerjemah profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.