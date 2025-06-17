<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:46:28+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tr"
}
-->
# Örnek çalıştırma

Burada, zaten çalışan bir sunucu kodunuzun olduğunu varsayıyoruz. Lütfen önceki bölümlerden birindeki sunucuyu bulun.

## mcp.json dosyasını ayarlama

Referans olarak kullanabileceğiniz bir dosya burada, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Sunucu girişini, sunucunuza giden mutlak yolu ve çalıştırmak için gereken tam komutu içerecek şekilde gerektiği gibi değiştirin.

Yukarıda bahsedilen örnek dosyada sunucu girişi şu şekilde görünür:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Bu, aşağıdaki gibi bir komut çalıştırmaya karşılık gelir: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` ve "add 3 to 20" gibi bir şey yazın.

    Sohbet metin kutusunun üzerinde, aracı çalıştırmak için seçmeniz gerektiğini belirten bir araç gösterildiğini görmelisiniz, şöyle bir görseldeki gibi:

    ![VS Code araç çalıştırmak istediğini belirtiyor](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tr.png)

    Aracı seçmek, eğer daha önce belirttiğimiz gibi bir istem kullandıysanız, "23" diyen sayısal bir sonuç üretmelidir.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yanlış yorumlamadan sorumlu değiliz.