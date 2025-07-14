<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:39:51+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ms"
}
-->
Mari kita bincangkan lebih lanjut tentang cara kita menggunakan antara muka visual dalam bahagian seterusnya.

## Pendekatan

Berikut adalah cara kita perlu mendekati ini pada tahap tinggi:

- Konfigurasikan fail untuk mencari MCP Server kita.
- Mulakan/Sambungkan ke server tersebut untuk mendapatkan senarai keupayaannya.
- Gunakan keupayaan tersebut melalui antara muka GitHub Copilot Chat.

Bagus, sekarang kita faham alirannya, mari cuba gunakan MCP Server melalui Visual Studio Code melalui satu latihan.

## Latihan: Menggunakan server

Dalam latihan ini, kita akan konfigurasikan Visual Studio Code untuk mencari MCP server anda supaya ia boleh digunakan dari antara muka GitHub Copilot Chat.

### -0- Langkah awal, aktifkan penemuan MCP Server

Anda mungkin perlu mengaktifkan penemuan MCP Server.

1. Pergi ke `File -> Preferences -> Settings` dalam Visual Studio Code.

1. Cari "MCP" dan aktifkan `chat.mcp.discovery.enabled` dalam fail settings.json.

### -1- Cipta fail konfigurasi

Mula dengan mencipta fail konfigurasi di akar projek anda, anda perlu fail bernama MCP.json dan letakkan ia dalam folder bernama .vscode. Ia harus kelihatan seperti berikut:

```text
.vscode
|-- mcp.json
```

Seterusnya, mari lihat bagaimana kita boleh tambah entri server.

### -2- Konfigurasikan server

Tambah kandungan berikut ke *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Di atas adalah contoh mudah bagaimana untuk memulakan server yang ditulis dalam Node.js, untuk runtime lain nyatakan arahan yang betul untuk memulakan server menggunakan `command` dan `args`.

### -3- Mulakan server

Sekarang anda telah menambah entri, mari mulakan server:

1. Cari entri anda dalam *mcp.json* dan pastikan anda melihat ikon "play":

  ![Memulakan server dalam Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ms.png)  

1. Klik ikon "play", anda sepatutnya melihat ikon alat dalam GitHub Copilot Chat bertambah bilangan alat yang tersedia. Jika anda klik ikon alat tersebut, anda akan melihat senarai alat yang didaftarkan. Anda boleh tandakan/nyah-tandakan setiap alat bergantung pada sama ada anda mahu GitHub Copilot menggunakannya sebagai konteks:

  ![Memulakan server dalam Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ms.png)

1. Untuk menjalankan alat, taip arahan yang anda tahu akan sepadan dengan penerangan salah satu alat anda, contohnya arahan seperti "add 22 to 1":

  ![Menjalankan alat dari GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ms.png)

  Anda sepatutnya melihat respons yang mengatakan 23.

## Tugasan

Cuba tambah entri server ke dalam fail *mcp.json* anda dan pastikan anda boleh mulakan/hentikan server. Pastikan anda juga boleh berkomunikasi dengan alat pada server anda melalui antara muka GitHub Copilot Chat.

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Perkara Penting

Perkara penting dari bab ini adalah seperti berikut:

- Visual Studio Code adalah klien yang hebat yang membolehkan anda menggunakan beberapa MCP Server dan alat mereka.
- Antara muka GitHub Copilot Chat adalah cara anda berinteraksi dengan server.
- Anda boleh meminta pengguna untuk input seperti kunci API yang boleh dihantar ke MCP Server apabila mengkonfigurasi entri server dalam fail *mcp.json*.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Dokumen Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Apa Seterusnya

- Seterusnya: [Mencipta SSE Server](../05-sse-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.