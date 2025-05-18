<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:16:18+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

`uv` kurmanız önerilir, ancak zorunlu değildir, [talimatlara](https://docs.astral.sh/uv/#highlights) bakın.

## -0- Sanal bir ortam oluşturun

```bash
python -m venv venv
```

## -1- Sanal ortamı etkinleştirin

```bash
venv\Scrips\activate
```

## -2- Bağımlılıkları yükleyin

```bash
pip install "mcp[cli]"
```

## -3- Örneği çalıştırın

```bash
mcp run server.py
```

## -4- Örneği test edin

Sunucu bir terminalde çalışırken, başka bir terminal açın ve aşağıdaki komutu çalıştırın:

```bash
mcp dev server.py
```

Bu, örneği test etmenize olanak tanıyan görsel bir arayüzle bir web sunucusunu başlatmalıdır.

Sunucu bağlandığında:

- araçları listelemeyi deneyin ve `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` onun etrafında bir sarmalayıcıdır.

Aşağıdaki komutu çalıştırarak doğrudan CLI modunda başlatabilirsiniz:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
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

Bir aracı çağırmak için yazın:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> İnspektörü CLI modunda çalıştırmak genellikle tarayıcıda çalıştırmaktan çok daha hızlıdır.
> İnspektör hakkında daha fazla bilgiyi [burada](https://github.com/modelcontextprotocol/inspector) okuyun.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.