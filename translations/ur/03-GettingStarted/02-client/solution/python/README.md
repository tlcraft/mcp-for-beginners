<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T09:59:21+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "ur"
}
-->
نمونہ چلانا

آپ کو `uv` انسٹال کرنے کی سفارش کی جاتی ہے لیکن یہ ضروری نہیں ہے، دیکھیں [ہدایات](https://docs.astral.sh/uv/#highlights)

## -0- ایک ورچوئل ماحول بنائیں

```bash
python -m venv venv
```

## -1- ورچوئل ماحول کو فعال کریں

```bash
venv\Scrips\activate
```

## -2- ضروریات انسٹال کریں

```bash
pip install "mcp[cli]"
```

## -3- نمونہ چلائیں

```bash
python client.py
```

آپ کو اس جیسا آؤٹ پٹ نظر آنا چاہیے:

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

**دستبرداری**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستگیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ذریعہ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔