<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:37:55+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
Bagus, untuk langkah selanjutnya, mari kita daftarkan kemampuan di server.

### -2 Daftar kemampuan server

Sekarang kita akan terhubung ke server dan menanyakan kemampuannya:

### -3- Ubah kemampuan server menjadi alat LLM

Langkah berikutnya setelah mendaftar kemampuan server adalah mengubahnya ke dalam format yang dipahami oleh LLM. Setelah itu, kita bisa menyediakan kemampuan ini sebagai alat untuk LLM kita.

Bagus, sekarang kita sudah siap menangani permintaan pengguna, jadi mari kita selesaikan itu selanjutnya.

### -4- Tangani permintaan prompt pengguna

Di bagian kode ini, kita akan menangani permintaan dari pengguna.

Bagus, kamu berhasil!

## Tugas

Ambil kode dari latihan dan kembangkan server dengan beberapa alat tambahan. Kemudian buat klien dengan LLM, seperti pada latihan, dan uji dengan berbagai prompt untuk memastikan semua alat servermu dipanggil secara dinamis. Cara membangun klien seperti ini memastikan pengguna akhir mendapatkan pengalaman yang baik karena mereka bisa menggunakan prompt, bukan perintah klien yang tepat, dan tidak perlu tahu bahwa ada server MCP yang dipanggil.

## Solusi

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Poin Penting

- Menambahkan LLM ke klienmu memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan Server MCP.
- Kamu perlu mengubah respons Server MCP menjadi sesuatu yang dapat dipahami oleh LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Selanjutnya

- Berikutnya: [Menggunakan server dengan Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.