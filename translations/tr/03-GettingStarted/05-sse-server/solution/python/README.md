<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:02:47+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

`uv` yüklemeniz önerilir, ancak zorunlu değildir, [talimatlara](https://docs.astral.sh/uv/#highlights) bakın

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

Bu, örneği test etmenize olanak tanıyan görsel arayüzlü bir web sunucusu başlatmalıdır.

Sunucu bağlandığında:

- araçları listelemeyi deneyin ve `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` bunun etrafında bir sarmalayıcıdır.

Aşağıdaki komutu çalıştırarak doğrudan CLI modunda başlatabilirsiniz:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Genellikle ispector'ı tarayıcıda çalıştırmaktan çok CLI modunda çalıştırmak daha hızlıdır.
> İnspektör hakkında daha fazla bilgiyi [buradan](https://github.com/modelcontextprotocol/inspector) okuyun.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul etmiyoruz.