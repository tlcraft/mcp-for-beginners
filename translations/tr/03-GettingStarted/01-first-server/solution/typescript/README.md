<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:23:28+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

`uv` kurmanız önerilir, ancak zorunlu değildir, bkz. [talimatlar](https://docs.astral.sh/uv/#highlights)

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

Bu, örneği test etmenizi sağlayacak görsel bir arayüze sahip bir web sunucusunu başlatmalıdır.

Sunucu bağlandıktan sonra:

- Araçları listelemeyi deneyin ve `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` onun etrafında bir sarmalayıcıdır.

Aşağıdaki komutu çalıştırarak doğrudan CLI modunda başlatabilirsiniz:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Bu, sunucuda bulunan tüm araçları listeleyecektir. Aşağıdaki çıktıyı görmelisiniz:

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

Bir aracı çağırmak için yazın:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> İnspektörü tarayıcıda çalıştırmaktansa CLI modunda çalıştırmak genellikle çok daha hızlıdır.
> İnspektör hakkında daha fazla bilgi için [buraya](https://github.com/modelcontextprotocol/inspector) bakın.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki versiyonu yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.