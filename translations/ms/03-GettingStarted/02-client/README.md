<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:45:02+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ms"
}
-->
# Membuat klien

Klien adalah aplikasi atau skrip khusus yang berkomunikasi secara langsung dengan Server MCP untuk meminta sumber, alat, dan arahan. Berbeza dengan menggunakan alat pemeriksa yang menyediakan antaramuka grafik untuk berinteraksi dengan server, menulis klien anda sendiri membolehkan interaksi secara programatik dan automatik. Ini membolehkan pembangun mengintegrasikan keupayaan MCP ke dalam aliran kerja mereka sendiri, mengotomasi tugas, dan membina penyelesaian khusus yang disesuaikan untuk keperluan tertentu.

## Gambaran Keseluruhan

Pelajaran ini memperkenalkan konsep klien dalam ekosistem Model Context Protocol (MCP). Anda akan belajar cara menulis klien anda sendiri dan menghubungkannya ke Server MCP.

## Objektif Pembelajaran

Pada akhir pelajaran ini, anda akan dapat:

- Memahami apa yang boleh dilakukan oleh klien.
- Menulis klien anda sendiri.
- Menghubungkan dan menguji klien dengan server MCP untuk memastikan ia berfungsi seperti yang diharapkan.

## Apa yang diperlukan dalam menulis klien?

Untuk menulis klien, anda perlu melakukan perkara berikut:

- **Import perpustakaan yang betul**. Anda akan menggunakan perpustakaan yang sama seperti sebelum ini, cuma dengan binaan yang berbeza.
- **Cipta instans klien**. Ini akan melibatkan penciptaan instans klien dan menghubungkannya ke kaedah pengangkutan yang dipilih.
- **Tentukan sumber mana yang ingin disenaraikan**. Server MCP anda datang dengan sumber, alat dan arahan, anda perlu memutuskan yang mana satu untuk disenaraikan.
- **Integrasikan klien ke aplikasi hos**. Setelah anda mengetahui keupayaan server, anda perlu mengintegrasikannya ke aplikasi hos anda supaya jika pengguna menaip arahan atau perintah lain, ciri server yang sepadan dipanggil.

Sekarang kita memahami secara keseluruhan apa yang akan kita lakukan, mari kita lihat contoh seterusnya.

### Contoh klien

Mari kita lihat contoh klien ini:
Anda dilatih pada data sehingga Oktober 2023.

Dalam kod sebelumnya kita:

- Import perpustakaan
- Cipta instans klien dan sambungkannya menggunakan stdio untuk pengangkutan.
- Senaraikan arahan, sumber dan alat dan panggil semuanya.

Itulah dia, klien yang boleh berkomunikasi dengan Server MCP.

Mari kita ambil masa kita dalam bahagian latihan seterusnya dan pecahkan setiap potongan kod dan terangkan apa yang sedang berlaku.

## Latihan: Menulis klien

Seperti yang dikatakan di atas, mari kita ambil masa kita menjelaskan kod, dan jangan ragu untuk menulis kod jika anda mahu.

### -1- Import perpustakaan

Mari kita import perpustakaan yang kita perlukan, kita akan memerlukan rujukan kepada klien dan protokol pengangkutan yang dipilih, stdio. stdio adalah protokol untuk perkara yang dimaksudkan untuk dijalankan pada mesin tempatan anda. SSE adalah protokol pengangkutan lain yang akan kita tunjukkan dalam bab-bab akan datang tetapi itulah pilihan lain anda. Buat masa ini, mari kita teruskan dengan stdio.

Mari kita teruskan ke instansiasi.

### -2- Menginstansikan klien dan pengangkutan

Kita perlu mencipta instans pengangkutan dan instans klien kita:

### -3- Menyenaraikan ciri-ciri server

Sekarang, kita mempunyai klien yang boleh berhubung sekiranya program dijalankan. Walau bagaimanapun, ia sebenarnya tidak menyenaraikan ciri-cirinya jadi mari kita lakukan itu seterusnya:

Bagus, sekarang kita telah menangkap semua ciri-ciri. Sekarang persoalannya bila kita akan menggunakannya? Nah, klien ini cukup mudah, mudah dalam erti kata bahawa kita perlu memanggil ciri-ciri secara eksplisit apabila kita mahukannya. Dalam bab seterusnya, kita akan mencipta klien yang lebih maju yang mempunyai akses kepada model bahasa besar, LLM sendiri. Buat masa ini, mari kita lihat bagaimana kita boleh memanggil ciri-ciri pada server:

### -4- Memanggil ciri-ciri

Untuk memanggil ciri-ciri kita perlu memastikan kita menyatakan hujah yang betul dan dalam beberapa kes nama apa yang kita cuba panggil.

### -5- Jalankan klien

Untuk menjalankan klien, taipkan perintah berikut di terminal:

## Tugasan

Dalam tugasan ini, anda akan menggunakan apa yang anda pelajari dalam mencipta klien tetapi mencipta klien anda sendiri.

Berikut adalah server yang boleh anda gunakan yang perlu anda panggil melalui kod klien anda, lihat jika anda boleh menambah lebih banyak ciri kepada server untuk menjadikannya lebih menarik.

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Poin Penting

Poin penting untuk bab ini adalah seperti berikut tentang klien:

- Boleh digunakan untuk kedua-dua penemuan dan pemanggilan ciri-ciri pada server.
- Boleh memulakan server semasa ia memulakan dirinya (seperti dalam bab ini) tetapi klien juga boleh menyambung ke server yang sedang berjalan.
- Adalah cara yang hebat untuk menguji keupayaan server berbanding alternatif seperti Pemeriksa seperti yang diterangkan dalam bab sebelumnya.

## Sumber Tambahan

- [Membina klien dalam MCP](https://modelcontextprotocol.io/quickstart/client)

## Sampel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Apa Seterusnya

- Seterusnya: [Mencipta klien dengan LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**: 
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.