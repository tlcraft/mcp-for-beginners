<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T07:57:00+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "id"
}
-->
# Menggunakan server dari mode GitHub Copilot Agent

Visual Studio Code dan GitHub Copilot dapat berperan sebagai klien dan menggunakan MCP Server. Mungkin Anda bertanya-tanya, mengapa kita ingin melakukan itu? Nah, itu berarti fitur apa pun yang dimiliki MCP Server sekarang bisa digunakan langsung dari dalam IDE Anda. Bayangkan Anda menambahkan misalnya server MCP GitHub, ini akan memungkinkan mengontrol GitHub melalui perintah alami tanpa harus mengetik perintah spesifik di terminal. Atau bayangkan hal apa pun yang bisa meningkatkan pengalaman pengembang Anda yang dikendalikan dengan bahasa alami. Sekarang Anda mulai melihat keuntungannya, bukan?

## Ikhtisar

Pelajaran ini membahas cara menggunakan Visual Studio Code dan mode Agent GitHub Copilot sebagai klien untuk MCP Server Anda.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Menggunakan MCP Server melalui Visual Studio Code.
- Menjalankan kemampuan seperti tools melalui GitHub Copilot.
- Mengonfigurasi Visual Studio Code untuk menemukan dan mengelola MCP Server Anda.

## Penggunaan

Anda dapat mengontrol MCP server Anda dengan dua cara berbeda:

- Antarmuka pengguna, Anda akan melihat bagaimana ini dilakukan nanti di bab ini.
- Terminal, Anda bisa mengontrolnya dari terminal menggunakan executable `code`:

  Untuk menambahkan MCP server ke profil pengguna Anda, gunakan opsi baris perintah --add-mcp, dan berikan konfigurasi server dalam format JSON seperti {\"name\":\"server-name\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Tangkapan Layar

![Konfigurasi server MCP terpandu di Visual Studio Code](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.id.png)
![Pemilihan tool per sesi agent](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.id.png)
![Mudah debug error saat pengembangan MCP](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.id.png)

Mari kita bahas lebih lanjut tentang penggunaan antarmuka visual di bagian berikutnya.

## Pendekatan

Berikut cara kita harus mendekatinya secara garis besar:

- Konfigurasikan file untuk menemukan MCP Server kita.
- Mulai/Koneksi ke server tersebut untuk mendapatkan daftar kemampuannya.
- Gunakan kemampuan tersebut melalui antarmuka GitHub Copilot Chat.

Bagus, sekarang kita sudah paham alurnya, mari coba gunakan MCP Server melalui Visual Studio Code lewat latihan berikut.

## Latihan: Menggunakan server

Dalam latihan ini, kita akan mengonfigurasi Visual Studio Code agar dapat menemukan MCP server Anda sehingga bisa digunakan dari antarmuka GitHub Copilot Chat.

### -0- Langkah awal, aktifkan penemuan MCP Server

Anda mungkin perlu mengaktifkan penemuan MCP Server.

1. Buka `File -> Preferences -> Settings` di Visual Studio Code.

1. Cari "MCP" dan aktifkan `chat.mcp.discovery.enabled` di file settings.json.

### -1- Buat file konfigurasi

Mulailah dengan membuat file konfigurasi di root proyek Anda, Anda perlu file bernama MCP.json dan letakkan di folder bernama .vscode. Isinya kira-kira seperti ini:

```text
.vscode
|-- mcp.json
```

Selanjutnya, mari lihat bagaimana menambahkan entri server.

### -2- Konfigurasikan server

Tambahkan konten berikut ke *mcp.json*:

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

Di atas adalah contoh sederhana bagaimana memulai server yang ditulis dengan Node.js, untuk runtime lain sesuaikan perintah yang tepat untuk memulai server menggunakan `command` dan `args`.

### -3- Mulai server

Setelah menambahkan entri, mari mulai server:

1. Temukan entri Anda di *mcp.json* dan pastikan Anda melihat ikon "play":

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.id.png)  

1. Klik ikon "play", Anda akan melihat ikon tools di GitHub Copilot Chat bertambah jumlah tools yang tersedia. Jika Anda klik ikon tools tersebut, Anda akan melihat daftar tools yang terdaftar. Anda bisa centang atau hapus centang setiap tool tergantung apakah Anda ingin GitHub Copilot menggunakannya sebagai konteks:

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.id.png)

1. Untuk menjalankan tool, ketik prompt yang Anda tahu sesuai dengan deskripsi salah satu tools Anda, misalnya prompt seperti "add 22 to 1":

  ![Menjalankan tool dari GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.id.png)

  Anda harus melihat respons yang mengatakan 23.

## Tugas

Coba tambahkan entri server ke file *mcp.json* Anda dan pastikan Anda bisa memulai/menghentikan server. Pastikan juga Anda bisa berkomunikasi dengan tools di server Anda melalui antarmuka GitHub Copilot Chat.

## Solusi

[Solution](./solution/README.md)

## Poin Penting

Poin penting dari bab ini adalah:

- Visual Studio Code adalah klien yang hebat yang memungkinkan Anda menggunakan beberapa MCP Server dan tools-nya.
- Antarmuka GitHub Copilot Chat adalah cara Anda berinteraksi dengan server.
- Anda bisa meminta input pengguna seperti API key yang dapat diteruskan ke MCP Server saat mengonfigurasi entri server di file *mcp.json*.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Selanjutnya

- Selanjutnya: [Membuat SSE Server](../05-sse-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.