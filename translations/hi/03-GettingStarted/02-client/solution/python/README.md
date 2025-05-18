<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:00:12+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

आपको `uv` इंस्टॉल करने की सलाह दी जाती है, लेकिन यह अनिवार्य नहीं है, [निर्देश](https://docs.astral.sh/uv/#highlights) देखें

## -0- एक वर्चुअल वातावरण बनाएं

```bash
python -m venv venv
```

## -1- वर्चुअल वातावरण सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- निर्भरता स्थापित करें

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाएं

```bash
python client.py
```

आपको इसके समान एक आउटपुट देखना चाहिए:

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

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल भाषा में मूल दस्तावेज़ को प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।