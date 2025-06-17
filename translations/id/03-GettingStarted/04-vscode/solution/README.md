<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:01:30+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh

Di sini kita anggap kamu sudah memiliki kode server yang berfungsi. Silakan cari server dari salah satu bab sebelumnya.

## Menyiapkan mcp.json

Berikut adalah file yang kamu gunakan sebagai referensi, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ubah entri server sesuai kebutuhan untuk menunjuk ke path absolut server kamu termasuk perintah lengkap yang dibutuhkan untuk menjalankannya.

Pada contoh file yang disebutkan di atas, entri server terlihat seperti ini:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ini sesuai dengan menjalankan perintah seperti ini: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` ketik sesuatu seperti "add 3 to 20".

    Kamu akan melihat sebuah alat muncul di atas kotak teks chat yang menunjukkan agar kamu memilih untuk menjalankan alat tersebut seperti pada visual ini:

    ![VS Code menunjukkan bahwa ingin menjalankan alat](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.id.png)

    Memilih alat tersebut harus menghasilkan angka "23" jika prompt kamu seperti yang disebutkan sebelumnya.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.