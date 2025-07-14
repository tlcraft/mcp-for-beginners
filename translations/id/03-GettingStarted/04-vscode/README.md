<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-13T19:32:57+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "id"
}
-->
Mari kita bahas lebih lanjut tentang cara menggunakan antarmuka visual di bagian berikutnya.

## Pendekatan

Berikut cara kita perlu mendekati ini secara garis besar:

- Konfigurasikan sebuah file untuk menemukan MCP Server kita.
- Mulai/Koneksi ke server tersebut untuk mendapatkan daftar kapabilitasnya.
- Gunakan kapabilitas tersebut melalui antarmuka GitHub Copilot Chat.

Bagus, sekarang kita sudah memahami alurnya, mari coba gunakan MCP Server melalui Visual Studio Code lewat sebuah latihan.

## Latihan: Menggunakan server

Dalam latihan ini, kita akan mengonfigurasi Visual Studio Code agar dapat menemukan MCP server Anda sehingga bisa digunakan dari antarmuka GitHub Copilot Chat.

### -0- Langkah awal, aktifkan penemuan MCP Server

Anda mungkin perlu mengaktifkan penemuan MCP Server.

1. Buka `File -> Preferences -> Settings` di Visual Studio Code.

2. Cari "MCP" dan aktifkan `chat.mcp.discovery.enabled` di file settings.json.

### -1- Buat file konfigurasi

Mulailah dengan membuat file konfigurasi di root proyek Anda, Anda perlu sebuah file bernama MCP.json dan menaruhnya di folder bernama .vscode. Isinya kira-kira seperti ini:

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

Setelah Anda menambahkan entri, mari mulai server:

1. Temukan entri Anda di *mcp.json* dan pastikan Anda melihat ikon "play":

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.id.png)  

2. Klik ikon "play", Anda akan melihat ikon tools di GitHub Copilot Chat bertambah jumlah tools yang tersedia. Jika Anda klik ikon tools tersebut, Anda akan melihat daftar tools yang terdaftar. Anda bisa centang atau hapus centang setiap tool tergantung apakah Anda ingin GitHub Copilot menggunakannya sebagai konteks:

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.id.png)

3. Untuk menjalankan sebuah tool, ketik prompt yang Anda tahu sesuai dengan deskripsi salah satu tools Anda, misalnya prompt seperti "add 22 to 1":

  ![Menjalankan tool dari GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.id.png)

  Anda akan melihat respons yang mengatakan 23.

## Tugas

Coba tambahkan entri server ke file *mcp.json* Anda dan pastikan Anda bisa memulai/menghentikan server. Pastikan juga Anda bisa berkomunikasi dengan tools di server Anda melalui antarmuka GitHub Copilot Chat.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini adalah sebagai berikut:

- Visual Studio Code adalah klien yang hebat yang memungkinkan Anda menggunakan beberapa MCP Server dan tools mereka.
- Antarmuka GitHub Copilot Chat adalah cara Anda berinteraksi dengan server.
- Anda bisa meminta input dari pengguna seperti API key yang dapat diteruskan ke MCP Server saat mengonfigurasi entri server di file *mcp.json*.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Dokumentasi Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Selanjutnya

- Selanjutnya: [Membuat SSE Server](../05-sse-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.