<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T01:32:25+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "tr"
}
-->
# GitHub Copilot Agent modundan bir sunucu kullanmak

Visual Studio Code ve GitHub Copilot, bir MCP Sunucusuna istemci olarak bağlanabilir ve onu kullanabilir. Neden bunu yapmak isteyelim diye sorabilirsiniz? Çünkü bu, MCP Sunucusunun sahip olduğu tüm özelliklerin artık IDE'nizden kullanılabileceği anlamına gelir. Örneğin GitHub'ın MCP sunucusunu eklediğinizi düşünün, bu sayede terminalde belirli komutları yazmak yerine doğal dil ile GitHub'ı kontrol edebilirsiniz. Ya da genel olarak geliştirici deneyiminizi iyileştirebilecek her şey doğal dil ile kontrol edilebilir. Artık avantajı görmeye başladınız değil mi?

## Genel Bakış

Bu ders, Visual Studio Code ve GitHub Copilot'un Agent modunu MCP Sunucunuz için bir istemci olarak nasıl kullanacağınızı anlatır.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Visual Studio Code üzerinden bir MCP Sunucusunu kullanmak.
- GitHub Copilot aracılığıyla araçlar gibi yetenekleri çalıştırmak.
- Visual Studio Code'u MCP Sunucunuzu bulacak ve yönetecek şekilde yapılandırmak.

## Kullanım

MCP sunucunuzu iki farklı şekilde kontrol edebilirsiniz:

- Kullanıcı arayüzü, bunun nasıl yapıldığını bu bölümün ilerleyen kısımlarında göreceksiniz.
- Terminal, `code` çalıştırılabilir dosyasını kullanarak terminalden kontrol etmek mümkün:

  MCP sunucusunu kullanıcı profilinize eklemek için --add-mcp komut satırı seçeneğini kullanın ve JSON sunucu yapılandırmasını {\"name\":\"server-name\",\"command\":...} biçiminde sağlayın.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Ekran Görüntüleri

![Visual Studio Code'da Yönlendirilmiş MCP sunucu yapılandırması](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.tr.png)
![Her ajan oturumu için araç seçimi](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.tr.png)
![MCP geliştirme sırasında hataları kolayca hata ayıklama](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.tr.png)

Görsel arayüzü nasıl kullandığımızı sonraki bölümlerde daha detaylı konuşalım.

## Yaklaşım

Yüksek seviyede nasıl yaklaşmamız gerektiği şöyle:

- MCP Sunucumuzu bulacak bir dosya yapılandırmak.
- Sunucuyu başlatmak/bağlanmak ve yeteneklerini listelemesini sağlamak.
- Bu yetenekleri GitHub Copilot Chat arayüzü üzerinden kullanmak.

Harika, akışı anladığımıza göre, şimdi bir egzersizle Visual Studio Code üzerinden bir MCP Sunucusu kullanmayı deneyelim.

## Egzersiz: Bir sunucu kullanmak

Bu egzersizde, Visual Studio Code'u MCP sunucunuzu bulacak şekilde yapılandıracağız, böylece GitHub Copilot Chat arayüzünden kullanılabilir olacak.

### -0- Ön adım, MCP Sunucu keşfini etkinleştirme

MCP Sunucularının keşfini etkinleştirmeniz gerekebilir.

1. Visual Studio Code'da `File -> Preferences -> Settings` menüsüne gidin.

1. "MCP" araması yapın ve settings.json dosyasında `chat.mcp.discovery.enabled` seçeneğini etkinleştirin.

### -1- Yapılandırma dosyası oluşturma

Proje kök dizininizde bir yapılandırma dosyası oluşturun, MCP.json adında bir dosya ve bunu .vscode adlı bir klasöre koymanız gerekiyor. Dosya şu şekilde olmalı:

```text
.vscode
|-- mcp.json
```

Şimdi bir sunucu girişi nasıl eklenir görelim.

### -2- Sunucu yapılandırma

*mcp.json* dosyasına aşağıdaki içeriği ekleyin:

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

Yukarıda Node.js ile yazılmış bir sunucuyu başlatmak için basit bir örnek var, diğer çalışma zamanları için `command` ve `args` kullanarak sunucuyu başlatmak için uygun komutu belirtin.

### -3- Sunucuyu başlatma

Bir giriş eklediğinize göre, şimdi sunucuyu başlatalım:

1. *mcp.json* dosyanızdaki girişinizi bulun ve "play" simgesini gördüğünüzden emin olun:

  ![Visual Studio Code'da sunucu başlatma](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.tr.png)  

1. "play" simgesine tıklayın, GitHub Copilot Chat'teki araçlar simgesinin kullanılabilir araç sayısını artırdığını görmelisiniz. Bu araçlar simgesine tıklarsanız, kayıtlı araçların bir listesini göreceksiniz. GitHub Copilot'un bunları bağlam olarak kullanmasını isteyip istemediğinize göre her aracı işaretleyip kaldırabilirsiniz:

  ![Visual Studio Code'da sunucu başlatma](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.tr.png)

1. Bir aracı çalıştırmak için, araçlarınızdan birinin açıklamasıyla eşleşeceğini bildiğiniz bir komut yazın, örneğin "add 22 to 1" gibi bir komut:

  ![GitHub Copilot'dan bir aracı çalıştırma](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tr.png)

  23 cevabını görmelisiniz.

## Ödev

*mcp.json* dosyanıza bir sunucu girişi eklemeyi deneyin ve sunucuyu başlatıp durdurabildiğinizden emin olun. Ayrıca GitHub Copilot Chat arayüzü üzerinden sunucunuzdaki araçlarla iletişim kurabildiğinizi kontrol edin.

## Çözüm

[Solution](./solution/README.md)

## Önemli Noktalar

Bu bölümden çıkarılacak önemli noktalar şunlardır:

- Visual Studio Code, birden fazla MCP Sunucusunu ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- GitHub Copilot Chat arayüzü, sunucularla etkileşim kurduğunuz yerdir.
- Kullanıcıdan API anahtarları gibi girdiler isteyebilir ve bunları *mcp.json* dosyasındaki sunucu yapılandırmasına geçirebilirsiniz.

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Visual Studio dokümanları](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Sonraki Adım

- Sonraki: [Bir SSE Sunucusu Oluşturma](../05-sse-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.