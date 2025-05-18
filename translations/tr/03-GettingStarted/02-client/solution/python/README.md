<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:01:42+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
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
python client.py
```

Benzer bir çıktı görmelisiniz:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çabalasak da, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dilindeki hali, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.