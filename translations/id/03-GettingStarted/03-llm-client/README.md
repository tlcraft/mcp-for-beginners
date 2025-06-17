<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:51:20+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
Bagus, untuk langkah selanjutnya, mari kita daftar kemampuan yang ada di server.

### -2 Daftar kemampuan server

Sekarang kita akan terhubung ke server dan meminta daftar kemampuannya:

### -3- Ubah kemampuan server menjadi alat LLM

Langkah berikutnya setelah mendata kemampuan server adalah mengubahnya ke dalam format yang dimengerti oleh LLM. Setelah itu, kita bisa menyediakan kemampuan ini sebagai alat bagi LLM kita.

Bagus, sekarang kita sudah siap untuk menangani permintaan pengguna, jadi mari kita selesaikan itu berikutnya.

### -4- Tangani permintaan prompt pengguna

Pada bagian kode ini, kita akan menangani permintaan dari pengguna.

Bagus, kamu berhasil!

## Tugas

Ambil kode dari latihan ini dan kembangkan server dengan beberapa alat tambahan. Kemudian buat klien dengan LLM, seperti pada latihan, dan uji dengan berbagai prompt untuk memastikan semua alat server kamu dapat dipanggil secara dinamis. Cara membangun klien seperti ini memberikan pengalaman pengguna yang hebat karena mereka dapat menggunakan prompt, bukan perintah klien yang tepat, dan tidak perlu tahu adanya pemanggilan server MCP.

## Solusi

[Solusi](/03-GettingStarted/03-llm-client/solution/README.md)

## Hal-hal Penting yang Dipelajari

- Menambahkan LLM ke klien kamu memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan Server MCP.
- Kamu perlu mengubah respons Server MCP menjadi sesuatu yang dapat dipahami oleh LLM.

## Contoh

- [Kalkulator Java](../samples/java/calculator/README.md)
- [Kalkulator .Net](../../../../03-GettingStarted/samples/csharp)
- [Kalkulator JavaScript](../samples/javascript/README.md)
- [Kalkulator TypeScript](../samples/typescript/README.md)
- [Kalkulator Python](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Selanjutnya

- Berikutnya: [Menggunakan server dengan Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.