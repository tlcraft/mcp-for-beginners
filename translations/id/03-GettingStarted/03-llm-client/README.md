<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:34:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
Bagus, untuk langkah berikutnya, mari kita daftarkan kemampuan di server.

### -2 Daftar kemampuan server

Sekarang kita akan menghubungkan ke server dan meminta kemampuannya:

### -3- Ubah kemampuan server menjadi alat LLM

Langkah berikutnya setelah mendaftar kemampuan server adalah mengubahnya ke dalam format yang dipahami oleh LLM. Setelah itu, kita bisa menyediakan kemampuan ini sebagai alat untuk LLM kita.

Bagus, sekarang kita sudah siap menangani permintaan pengguna, jadi mari kita lanjutkan.

### -4- Tangani permintaan prompt pengguna

Di bagian kode ini, kita akan menangani permintaan dari pengguna.

Bagus, kamu berhasil!

## Tugas

Ambil kode dari latihan ini dan bangun server dengan beberapa alat tambahan. Kemudian buat klien dengan LLM, seperti pada latihan, dan uji dengan berbagai prompt untuk memastikan semua alat servermu dipanggil secara dinamis. Cara membangun klien seperti ini membuat pengguna akhir mendapatkan pengalaman yang lebih baik karena mereka bisa menggunakan prompt, bukan perintah klien yang tepat, dan tidak perlu tahu ada server MCP yang dipanggil.

## Solusi

[Solusi](/03-GettingStarted/03-llm-client/solution/README.md)

## Poin Penting

- Menambahkan LLM ke klienmu memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan MCP Server.
- Kamu perlu mengubah respons MCP Server menjadi sesuatu yang bisa dipahami oleh LLM.

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
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau kesalahan interpretasi yang timbul dari penggunaan terjemahan ini.