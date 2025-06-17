<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:03:01+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ms"
}
-->
# Menjalankan contoh

Di sini kita anggap anda sudah mempunyai kod server yang berfungsi. Sila cari server daripada salah satu bab sebelumnya.

## Sediakan mcp.json

Berikut adalah fail yang anda boleh jadikan rujukan, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Tukar entri server mengikut keperluan untuk menunjukkan laluan mutlak ke server anda termasuk arahan penuh yang diperlukan untuk menjalankannya.

Dalam fail contoh yang dirujuk tadi, entri server kelihatan seperti berikut:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ini bersamaan dengan menjalankan arahan seperti ini: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` taip sesuatu seperti "add 3 to 20".

    Anda sepatutnya melihat alat dipaparkan di atas kotak teks sembang yang menunjukkan anda boleh memilih untuk menjalankan alat tersebut seperti dalam visual ini:

    ![VS Code menunjukkan ia ingin menjalankan alat](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ms.png)

    Memilih alat tersebut sepatutnya menghasilkan keputusan nombor yang mengatakan "23" jika arahan anda seperti yang kami nyatakan sebelum ini.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.