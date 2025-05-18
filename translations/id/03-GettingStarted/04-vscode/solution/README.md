<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:22:40+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "id"
}
-->
# Menjalankan Contoh

Di sini kami mengasumsikan Anda sudah memiliki kode server yang berfungsi. Silakan temukan server dari salah satu bab sebelumnya.

## Mengatur mcp.json

Berikut adalah file yang Anda gunakan sebagai referensi, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ubah entri server sesuai kebutuhan untuk menunjukkan jalur absolut ke server Anda termasuk perintah lengkap yang diperlukan untuk menjalankannya.

Dalam contoh file yang disebutkan di atas, entri server terlihat seperti ini:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Ini sesuai dengan menjalankan perintah seperti ini: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` ketik sesuatu seperti "add 3 to 20".

Anda seharusnya melihat alat yang ditampilkan di atas kotak teks obrolan yang menunjukkan kepada Anda untuk memilih menjalankan alat seperti dalam visual ini:

![VS Code menunjukkan ingin menjalankan alat](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.id.png)

Memilih alat tersebut seharusnya menghasilkan hasil numerik yang mengatakan "23" jika prompt Anda seperti yang kami sebutkan sebelumnya.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk memberikan terjemahan yang akurat, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang kritis, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.