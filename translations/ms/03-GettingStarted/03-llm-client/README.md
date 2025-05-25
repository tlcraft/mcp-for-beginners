<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:25:38+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ms"
}
-->
# Mencipta klien dengan LLM

Setakat ini, anda telah melihat bagaimana untuk mencipta server dan klien. Klien telah dapat memanggil server secara eksplisit untuk menyenaraikan alat, sumber dan arahan. Walau bagaimanapun, pendekatan ini tidak begitu praktikal. Pengguna anda hidup dalam era agen dan mengharapkan untuk menggunakan arahan dan berkomunikasi dengan LLM untuk melakukannya. Bagi pengguna anda, ia tidak penting jika anda menggunakan MCP atau tidak untuk menyimpan keupayaan anda tetapi mereka mengharapkan untuk menggunakan bahasa semula jadi untuk berinteraksi. Jadi bagaimana kita menyelesaikan ini? Penyelesaiannya adalah dengan menambah LLM kepada klien.

## Gambaran Keseluruhan

Dalam pelajaran ini, kami memberi tumpuan kepada menambah LLM kepada klien anda dan menunjukkan bagaimana ini memberikan pengalaman yang jauh lebih baik untuk pengguna anda.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Mencipta klien dengan LLM.
- Berinteraksi dengan lancar dengan server MCP menggunakan LLM.
- Memberikan pengalaman pengguna akhir yang lebih baik di sisi klien.

## Pendekatan

Mari cuba memahami pendekatan yang perlu kita ambil. Menambah LLM kedengaran mudah, tetapi adakah kita benar-benar akan melakukannya?

Beginilah cara klien akan berinteraksi dengan server:

1. Menjalin hubungan dengan server.

2. Senaraikan keupayaan, arahan, sumber dan alat, dan simpan skema mereka.

3. Tambah LLM dan hantar keupayaan yang disimpan dan skema mereka dalam format yang difahami oleh LLM.

4. Tangani arahan pengguna dengan menghantarnya kepada LLM bersama-sama dengan alat yang disenaraikan oleh klien.

Bagus, sekarang kita faham bagaimana kita boleh melakukan ini pada tahap tinggi, mari kita cuba dalam latihan di bawah.

## Latihan: Mencipta klien dengan LLM

Dalam latihan ini, kita akan belajar untuk menambah LLM kepada klien kita.

### -1- Sambung ke server

Mari kita buat klien kita dahulu:
Anda dilatih dengan data sehingga Oktober 2023.

Hebat, untuk langkah seterusnya, mari kita senaraikan keupayaan di server.

### -2 Senaraikan keupayaan server

Sekarang kita akan sambung ke server dan minta keupayaannya:

### -3- Tukar keupayaan server kepada alat LLM

Langkah seterusnya selepas menyenaraikan keupayaan server adalah untuk menukarnya kepada format yang difahami oleh LLM. Setelah kita melakukannya, kita boleh memberikan keupayaan ini sebagai alat kepada LLM kita.

Hebat, kita belum bersedia untuk menangani sebarang permintaan pengguna, jadi mari kita selesaikan itu seterusnya.

### -4- Tangani permintaan arahan pengguna

Dalam bahagian kod ini, kita akan menangani permintaan pengguna.

Hebat, anda melakukannya!

## Tugasan

Ambil kod dari latihan dan bina server dengan lebih banyak alat. Kemudian buat klien dengan LLM, seperti dalam latihan, dan uji dengan arahan yang berbeza untuk memastikan semua alat server anda dipanggil secara dinamik. Cara membina klien ini bermakna pengguna akhir akan mendapat pengalaman pengguna yang hebat kerana mereka dapat menggunakan arahan, bukan perintah klien yang tepat, dan tidak sedar tentang sebarang server MCP yang dipanggil.

## Penyelesaian

[Penyelesaian](/03-GettingStarted/03-llm-client/solution/README.md)

## Pengajaran Utama

- Menambah LLM kepada klien anda menyediakan cara yang lebih baik untuk pengguna berinteraksi dengan Server MCP.
- Anda perlu menukar respons Server MCP kepada sesuatu yang boleh difahami oleh LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Apa yang Seterusnya

- Seterusnya: [Menggunakan server menggunakan Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Penafian**: 
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.