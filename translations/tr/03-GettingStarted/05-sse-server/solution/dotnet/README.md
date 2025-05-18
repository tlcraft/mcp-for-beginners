<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:55:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

## -1- Bağımlılıkları yükleyin

```bash
dotnet run
```

## -2- Örneği çalıştırın

```bash
dotnet run
```

## -3- Örneği test edin

Aşağıdakileri çalıştırmadan önce ayrı bir terminal başlatın (sunucunun hala çalıştığından emin olun).

Sunucu bir terminalde çalışırken, başka bir terminal açın ve aşağıdaki komutu çalıştırın:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Bu, örneği test etmenizi sağlayan görsel bir arayüze sahip bir web sunucusunu başlatmalıdır.

Sunucu bağlandığında:

- Araçları listelemeyi deneyin ve `add` komutunu 2 ve 4 argümanlarıyla çalıştırın, sonuçta 6 görmelisiniz.
- Kaynaklara ve kaynak şablonuna gidin ve "greeting" çağrısını yapın, bir isim girin ve sağladığınız isimle bir selamlama görmelisiniz.

### CLI modunda test etme

Aşağıdaki komutu çalıştırarak doğrudan CLI modunda başlatabilirsiniz:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Bu, sunucuda mevcut olan tüm araçları listeleyecektir. Aşağıdaki çıktıyı görmelisiniz:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Bir aracı çağırmak için şunu yazın:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Aşağıdaki çıktıyı görmelisiniz:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Genellikle ispector'ı CLI modunda çalıştırmak tarayıcıdan daha hızlıdır.
> Müfettiş hakkında daha fazla bilgi [burada](https://github.com/modelcontextprotocol/inspector) bulunabilir.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.