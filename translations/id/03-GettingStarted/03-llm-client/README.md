<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:54:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
Bagus, untuk langkah selanjutnya, mari kita daftar kapabilitas di server.

### -2 Daftar kapabilitas server

Sekarang kita akan terhubung ke server dan meminta kapabilitasnya:

### -3- Ubah kapabilitas server menjadi alat LLM

Langkah berikutnya setelah mendaftar kapabilitas server adalah mengubahnya ke dalam format yang dimengerti oleh LLM. Setelah itu, kita bisa menyediakan kapabilitas ini sebagai alat untuk LLM kita.

Bagus, sekarang kita sudah siap menangani permintaan pengguna, jadi mari kita selesaikan itu berikutnya.

### -4- Tangani permintaan prompt pengguna

Di bagian kode ini, kita akan menangani permintaan dari pengguna.

Bagus, kamu berhasil!

## Tugas

Ambil kode dari latihan dan kembangkan server dengan beberapa alat tambahan. Kemudian buat klien dengan LLM, seperti pada latihan, dan uji dengan berbagai prompt untuk memastikan semua alat server kamu dapat dipanggil secara dinamis. Cara membangun klien seperti ini membuat pengalaman pengguna akhir menjadi lebih baik karena mereka bisa menggunakan prompt, bukan perintah klien yang tepat, dan tidak perlu tahu ada server MCP yang dipanggil.

## Solusi

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Poin Penting

- Menambahkan LLM ke klienmu memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan Server MCP.
- Kamu perlu mengubah respons Server MCP menjadi sesuatu yang bisa dimengerti oleh LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Selanjutnya

- Selanjutnya: [Menggunakan server dengan Visual Studio Code](../04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.