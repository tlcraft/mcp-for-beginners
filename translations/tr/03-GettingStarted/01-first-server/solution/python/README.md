<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-13T18:00:06+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

`uv` kurmanız önerilir ancak zorunlu değildir, detaylar için [talimatlara](https://docs.astral.sh/uv/#highlights) bakabilirsiniz.

## -0- Sanal ortam oluşturma

```bash
python -m venv venv
```

## -1- Sanal ortamı aktifleştirme

```bash
venv\Scrips\activate
```

## -2- Bağımlılıkları yükleme

```bash
pip install "mcp[cli]"
```

## -3- Örneği çalıştırma

```bash
mcp run server.py
```

## -4- Örneği test etme

Sunucu bir terminalde çalışırken, başka bir terminal açın ve aşağıdaki komutu çalıştırın:

```bash
mcp dev server.py
```

Bu, örneği test etmenize olanak sağlayan görsel arayüze sahip bir web sunucusunu başlatmalıdır.

Sunucu bağlandıktan sonra:

- araçları listelemeyi deneyin ve `add` komutunu, argüman olarak 2 ve 4 ile çalıştırın, sonuçta 6 görmelisiniz.

- resources ve resource template kısmına gidin, get_greeting fonksiyonunu çağırın, bir isim yazın ve verdiğiniz isimle bir selamlama görmelisiniz.

### CLI modunda test etme

Çalıştırdığınız inspector aslında bir Node.js uygulamasıdır ve `mcp dev` bunun etrafında bir sarmalayıcıdır.

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

Bir aracı çağırmak için şunu yazın:

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
> Inspector'ı tarayıcıda çalıştırmaktansa CLI modunda çalıştırmak genellikle çok daha hızlıdır.
> Inspector hakkında daha fazla bilgi için [buraya](https://github.com/modelcontextprotocol/inspector) bakabilirsiniz.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.