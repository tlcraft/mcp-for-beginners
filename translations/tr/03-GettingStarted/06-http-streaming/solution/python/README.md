<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:19:43+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

Klasik HTTP streaming sunucusu ve istemcisini, ayrıca MCP streaming sunucusu ve istemcisini Python kullanarak nasıl çalıştıracağınızı gösteriyoruz.

### Genel Bakış

- İşlenen öğeler ilerledikçe istemciye bildirimler gönderen bir MCP sunucusu kuracaksınız.
- İstemci, her bildirimi gerçek zamanlı olarak gösterecek.
- Bu rehber önkoşullar, kurulum, çalıştırma ve sorun giderme adımlarını kapsar.

### Önkoşullar

- Python 3.9 veya daha yenisi
- `mcp` Python paketi (yüklemek için `pip install mcp` kullanın)

### Kurulum & Ayarlar

1. Depoyu klonlayın veya çözüm dosyalarını indirin.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Bir sanal ortam oluşturun ve etkinleştirin (önerilir):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Gerekli bağımlılıkları yükleyin:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Dosyalar

- **Sunucu:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **İstemci:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Klasik HTTP Streaming Sunucusunu Çalıştırma

1. Çözüm dizinine gidin:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Klasik HTTP streaming sunucusunu başlatın:

   ```pwsh
   python server.py
   ```

3. Sunucu başlayacak ve şu çıktıyı gösterecek:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Klasik HTTP Streaming İstemcisini Çalıştırma

1. Yeni bir terminal açın (aynı sanal ortamı ve dizini etkinleştirin):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Akış halinde mesajların sırasıyla yazdırıldığını görmelisiniz:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP Streaming Sunucusunu Çalıştırma

1. Çözüm dizinine gidin:  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```  
2. Streamable-http transport ile MCP sunucusunu başlatın:  
   ```pwsh
   python server.py mcp
   ```  
3. Sunucu başlayacak ve şu çıktıyı gösterecek:  
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP Streaming İstemcisini Çalıştırma

1. Yeni bir terminal açın (aynı sanal ortamı ve dizini etkinleştirin):  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```  
2. Sunucu her öğeyi işlerken bildirimlerin gerçek zamanlı olarak yazdırıldığını görmelisiniz:  
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Temel Uygulama Adımları

1. **FastMCP kullanarak MCP sunucusunu oluşturun.**  
2. **Bir listeyi işleyen ve `ctx.info()` veya `ctx.log()` ile bildirim gönderen bir araç tanımlayın.**  
3. **Sunucuyu `transport="streamable-http"` ile çalıştırın.**  
4. **Bildirimler geldikçe göstermek için mesaj işleyicisi olan bir istemci uygulayın.**

### Kod İncelemesi
- Sunucu, ilerleme güncellemelerini göndermek için async fonksiyonlar ve MCP bağlamını kullanır.  
- İstemci, bildirimleri ve son sonucu yazdırmak için async mesaj işleyicisi uygular.

### İpuçları & Sorun Giderme

- Engelleme olmaması için `async/await` kullanın.  
- Hem sunucu hem de istemcide hataları her zaman yakalayarak sağlamlığı artırın.  
- Gerçek zamanlı güncellemeleri görmek için birden fazla istemci ile test edin.  
- Hata alırsanız, Python sürümünüzü kontrol edin ve tüm bağımlılıkların yüklü olduğundan emin olun.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.