<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T16:01:21+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "id"
}
-->
Mari kita bahas lebih lanjut tentang cara menggunakan antarmuka visual di bagian berikutnya.

## Pendekatan

Berikut cara kita perlu mendekati ini secara garis besar:

- Konfigurasikan sebuah file untuk menemukan MCP Server kita.
- Mulai / Sambungkan ke server tersebut agar dapat menampilkan kemampuannya.
- Gunakan kemampuan tersebut melalui antarmuka GitHub Copilot Chat.

Bagus, sekarang setelah kita memahami alurnya, mari kita coba gunakan MCP Server melalui Visual Studio Code lewat sebuah latihan.

## Latihan: Menggunakan server

Dalam latihan ini, kita akan mengonfigurasi Visual Studio Code agar dapat menemukan MCP server Anda sehingga bisa digunakan dari antarmuka GitHub Copilot Chat.

### -0- Langkah awal, aktifkan penemuan MCP Server

Anda mungkin perlu mengaktifkan penemuan MCP Server.

1. Buka `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` di file settings.json.

### -1- Buat file konfigurasi

Mulailah dengan membuat file konfigurasi di root proyek Anda, Anda memerlukan file bernama MCP.json dan meletakkannya di folder bernama .vscode. Isinya harus seperti ini:

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

Di atas adalah contoh sederhana bagaimana memulai server yang ditulis dengan Node.js, untuk runtime lain tunjukkan perintah yang tepat untuk memulai server menggunakan `command` and `args`.

### -3- Mulai server

Sekarang setelah Anda menambahkan entri, mari mulai servernya:

1. Temukan entri Anda di *mcp.json* dan pastikan Anda menemukan ikon "play":

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.id.png)  

1. Klik ikon "play", Anda harus melihat ikon alat di GitHub Copilot Chat bertambah jumlah alat yang tersedia. Jika Anda klik ikon alat tersebut, Anda akan melihat daftar alat yang terdaftar. Anda dapat mencentang/menghapus centang setiap alat tergantung apakah Anda ingin GitHub Copilot menggunakannya sebagai konteks:

  ![Memulai server di Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.id.png)

1. Untuk menjalankan sebuah alat, ketikkan prompt yang Anda tahu akan cocok dengan deskripsi salah satu alat Anda, misalnya prompt seperti ini "add 22 to 1":

  ![Menjalankan alat dari GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.id.png)

  Anda harus melihat respons yang mengatakan 23.

## Tugas

Cobalah menambahkan entri server ke file *mcp.json* Anda dan pastikan Anda bisa memulai/menghentikan server. Pastikan juga Anda dapat berkomunikasi dengan alat di server Anda melalui antarmuka GitHub Copilot Chat.

## Solusi

[Solusi](./solution/README.md)

## Poin Penting

Poin penting dari bab ini adalah sebagai berikut:

- Visual Studio Code adalah klien hebat yang memungkinkan Anda menggunakan beberapa MCP Server dan alat-alatnya.
- Antarmuka GitHub Copilot Chat adalah cara Anda berinteraksi dengan server.
- Anda dapat meminta input dari pengguna seperti API key yang dapat diteruskan ke MCP Server saat mengonfigurasi entri server di file *mcp.json*.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Dokumentasi Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Selanjutnya

- Selanjutnya: [Membuat SSE Server](/03-GettingStarted/05-sse-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.