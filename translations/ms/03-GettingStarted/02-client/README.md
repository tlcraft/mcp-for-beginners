<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:02:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ms"
}
-->
Dalam kod sebelum ini kami:

- Mengimport perpustakaan
- Membuat satu contoh klien dan menyambungkannya menggunakan stdio untuk pengangkutan.
- Menyenaraikan arahan, sumber dan alat serta memanggil kesemuanya.

Itulah dia, satu klien yang boleh berkomunikasi dengan MCP Server.

Mari kita luangkan masa dalam bahagian latihan seterusnya untuk memecahkan setiap petikan kod dan menerangkan apa yang sedang berlaku.

## Latihan: Menulis klien

Seperti yang disebut tadi, mari kita ambil masa untuk menerangkan kod ini, dan jangan segan untuk menulis kod bersama jika anda mahu.

### -1- Mengimport perpustakaan

Mari kita import perpustakaan yang kita perlukan, kita akan memerlukan rujukan kepada klien dan protokol pengangkutan yang dipilih, iaitu stdio. stdio adalah protokol untuk perkara yang dijalankan pada mesin tempatan anda. SSE adalah satu lagi protokol pengangkutan yang akan kami tunjukkan dalam bab akan datang tetapi itu adalah pilihan lain anda. Buat masa ini, mari teruskan dengan stdio.

Mari kita teruskan dengan penciptaan contoh.

### -2- Membuat contoh klien dan pengangkutan

Kita perlu membuat satu contoh pengangkutan dan satu contoh klien kita:

### -3- Menyenaraikan ciri-ciri server

Sekarang, kita mempunyai klien yang boleh disambungkan apabila program dijalankan. Walau bagaimanapun, ia tidak benar-benar menyenaraikan ciri-cirinya jadi mari kita lakukan itu seterusnya:

Hebat, kini kita telah menangkap semua ciri. Soalannya, bila kita akan menggunakannya? Klien ini agak mudah, mudah dalam erti kata bahawa kita perlu secara eksplisit memanggil ciri-ciri apabila kita mahu menggunakannya. Dalam bab seterusnya, kita akan mencipta klien yang lebih maju yang mempunyai akses kepada model bahasa besar sendiri, LLM. Buat masa ini, mari lihat bagaimana kita boleh memanggil ciri-ciri pada server:

### -4- Memanggil ciri-ciri

Untuk memanggil ciri-ciri tersebut kita perlu pastikan kita menyatakan argumen yang betul dan dalam beberapa kes nama apa yang kita cuba panggil.

### -5- Menjalankan klien

Untuk menjalankan klien, taip arahan berikut di terminal:

## Tugasan

Dalam tugasan ini, anda akan menggunakan apa yang telah anda pelajari dalam mencipta klien tetapi cipta klien anda sendiri.

Ini adalah server yang boleh anda gunakan yang perlu anda panggil melalui kod klien anda, cuba lihat jika anda boleh menambah lebih banyak ciri pada server untuk menjadikannya lebih menarik.

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Perkara Penting

Perkara penting untuk bab ini mengenai klien adalah seperti berikut:

- Boleh digunakan untuk mencari dan memanggil ciri-ciri pada server.
- Boleh memulakan server sambil ia sendiri bermula (seperti dalam bab ini) tetapi klien juga boleh menyambung ke server yang sedang berjalan.
- Adalah cara yang bagus untuk menguji keupayaan server berbanding alternatif seperti Inspector seperti yang diterangkan dalam bab sebelum ini.

## Sumber Tambahan

- [Membina klien dalam MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Apa Seterusnya

- Seterusnya: [Mencipta klien dengan LLM](/03-GettingStarted/03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.