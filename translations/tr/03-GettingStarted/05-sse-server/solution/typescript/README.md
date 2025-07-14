<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:20:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

## -1- Bağımlılıkları yükleyin

```bash
npm install
```

## -3- Örneği çalıştırın

```bash
npm run build
```

## -4- Örneği test edin

Sunucu bir terminalde çalışırken, başka bir terminal açın ve aşağıdaki komutu çalıştırın:

```bash
npm run inspector
```

Bu, örneği test etmenize olanak tanıyan görsel arayüze sahip bir web sunucusu başlatmalıdır.

Sunucu bağlandıktan sonra:

- araçları listelemeyi deneyin ve `add` komutunu, argüman olarak 2 ve 4 ile çalıştırın, sonuçta 6 görmelisiniz.
- resources ve resource template bölümüne gidin, "greeting" çağırın, bir isim yazın ve verdiğiniz isimle bir selamlama görmelisiniz.

### CLI modunda test etme

Çalıştırdığınız inspector aslında bir Node.js uygulaması ve `mcp dev` bunun etrafında bir sarmalayıcıdır.

- Sunucuyu `npm run build` komutuyla başlatın.

- Ayrı bir terminalde aşağıdaki komutu çalıştırın:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Bu, sunucuda mevcut olan tüm araçları listeleyecektir. Aşağıdaki çıktıyı görmelisiniz:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- Bir araç türünü çağırmak için aşağıdaki komutu yazın:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Aşağıdaki çıktıyı görmelisiniz:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Inspector'ı tarayıcıda çalıştırmaktansa CLI modunda çalıştırmak genellikle çok daha hızlıdır.
> Inspector hakkında daha fazla bilgi için [buraya](https://github.com/modelcontextprotocol/inspector) bakabilirsiniz.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.