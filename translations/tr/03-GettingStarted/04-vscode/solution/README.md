<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:20:46+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tr"
}
-->
# Örneği Çalıştırma

Burada zaten çalışan bir sunucu koduna sahip olduğunuzu varsayıyoruz. Lütfen önceki bölümlerden bir sunucu bulun.

## mcp.json Dosyasını Ayarlama

Referans olarak kullanacağınız dosya burada, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Sunucunuza işaret etmek için gereken tam komut dahil olmak üzere sunucunuzun mutlak yolunu gösterecek şekilde sunucu girişini gerektiği gibi değiştirin.

Yukarıda belirtilen örnek dosyada sunucu girişi şu şekilde görünmektedir:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Bu, şu şekilde bir komut çalıştırmaya karşılık gelir: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` "3'ü 20'ye ekle" gibi bir şey yazın.

    Sohbet metin kutusunun üzerinde, aracın çalıştırılması için seçilmesi gerektiğini belirten bir araç gösterildiğini görmelisiniz. Bu görselde olduğu gibi:

    ![VS Code aracın çalıştırılmak istendiğini gösteriyor](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.tr.png)

    Aracı seçmek, daha önce belirttiğimiz gibi bir istemde bulunduysanız "23" diyen sayısal bir sonuç üretmelidir.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanılması sonucunda ortaya çıkabilecek yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.