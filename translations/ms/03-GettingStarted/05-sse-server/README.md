<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:22:04+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ms"
}
-->
Sekarang kita sudah tahu sedikit lebih banyak tentang SSE, mari bina pelayan SSE pula.

## Latihan: Mewujudkan Pelayan SSE

Untuk mencipta pelayan kita, kita perlu ingat dua perkara:

- Kita perlu menggunakan pelayan web untuk mendedahkan titik akhir bagi sambungan dan mesej.
- Bina pelayan kita seperti biasa dengan alat, sumber dan arahan apabila kita menggunakan stdio.

### -1- Cipta contoh pelayan

Untuk mencipta pelayan kita, kita gunakan jenis yang sama seperti dengan stdio. Namun, untuk pengangkutan, kita perlu memilih SSE.

Mari kita tambah laluan yang diperlukan seterusnya.

### -2- Tambah laluan

Mari tambah laluan yang mengendalikan sambungan dan mesej masuk:

Mari kita tambah keupayaan pada pelayan seterusnya.

### -3- Menambah keupayaan pelayan

Sekarang kita sudah mentakrifkan semua perkara khusus SSE, mari tambah keupayaan pelayan seperti alat, arahan dan sumber.

Kod penuh anda harus kelihatan seperti berikut:

Bagus, kita sudah ada pelayan menggunakan SSE, mari cuba jalankan pula.

## Latihan: Menyahpepijat Pelayan SSE dengan Inspector

Inspector adalah alat yang hebat yang kita lihat dalam pelajaran sebelum ini [Mewujudkan pelayan pertama anda](/03-GettingStarted/01-first-server/README.md). Mari lihat jika kita boleh gunakan Inspector di sini juga:

### -1- Menjalankan inspector

Untuk menjalankan inspector, anda mesti mempunyai pelayan SSE yang sedang berjalan, jadi mari lakukan itu dahulu:

1. Jalankan pelayan

1. Jalankan inspector

    > ![NOTE]
    > Jalankan ini di tetingkap terminal berasingan daripada pelayan yang sedang berjalan. Juga ambil perhatian, anda perlu sesuaikan arahan di bawah mengikut URL di mana pelayan anda berjalan.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Menjalankan inspector kelihatan sama dalam semua runtime. Perhatikan bagaimana kita bukannya memberikan laluan ke pelayan dan arahan untuk memulakan pelayan, tetapi sebaliknya kita berikan URL di mana pelayan berjalan dan juga nyatakan laluan `/sse`.

### -2- Mencuba alat tersebut

Sambungkan pelayan dengan memilih SSE dalam senarai lungsur dan isi medan url di mana pelayan anda berjalan, contohnya http:localhost:4321/sse. Kini klik butang "Connect". Seperti sebelum ini, pilih untuk menyenaraikan alat, pilih alat dan berikan nilai input. Anda sepatutnya melihat hasil seperti berikut:

![Pelayan SSE berjalan dalam inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ms.png)

Bagus, anda boleh bekerja dengan inspector, mari lihat bagaimana kita boleh bekerja dengan Visual Studio Code pula.

## Tugasan

Cuba bina pelayan anda dengan lebih banyak keupayaan. Lihat [laman ini](https://api.chucknorris.io/) untuk, contohnya, menambah alat yang memanggil API. Anda tentukan bagaimana rupa pelayan itu. Selamat mencuba :)

## Penyelesaian

[Penyelesaian](./solution/README.md) Berikut adalah penyelesaian yang mungkin dengan kod yang berfungsi.

## Perkara Penting

Perkara penting dari bab ini adalah seperti berikut:

- SSE adalah pengangkutan kedua yang disokong selepas stdio.
- Untuk menyokong SSE, anda perlu menguruskan sambungan masuk dan mesej menggunakan rangka kerja web.
- Anda boleh menggunakan kedua-dua Inspector dan Visual Studio Code untuk menggunakan pelayan SSE, sama seperti pelayan stdio. Perhatikan bagaimana ia berbeza sedikit antara stdio dan SSE. Untuk SSE, anda perlu memulakan pelayan secara berasingan dan kemudian jalankan alat inspector anda. Untuk alat inspector, terdapat juga beberapa perbezaan di mana anda perlu nyatakan URL.

## Sampel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Apa Seterusnya

- Seterusnya: [HTTP Streaming dengan MCP (HTTP Boleh Alir)](/03-GettingStarted/06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.