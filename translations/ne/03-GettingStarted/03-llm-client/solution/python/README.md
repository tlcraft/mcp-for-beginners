<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:47:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

तपाईंलाई `uv` स्थापना गर्न सिफारिस गरिन्छ तर यो अनिवार्य छैन, [निर्देशनहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्

## -0- भर्चुअल वातावरण बनाउनुहोस्

```bash
python -m venv venv
```

## -1- भर्चुअल वातावरण सक्रिय गर्नुहोस्

```bash
venv\Scrips\activate
```

## -2- आवश्यकताहरू स्थापना गर्नुहोस्

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- नमूना चलाउनुहोस्

```bash
python client.py
```

तपाईंले निम्न जस्तै आउटपुट देख्नु पर्छ:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
Tool {'a': {'title': 'A', 'type': 'integer'}, 'b': {'title': 'B', 'type': 'integer'}}
CALLING LLM
TOOL:  {'function': {'arguments': '{"a":2,"b":20}', 'name': 'add'}, 'id': 'call_BCbyoCcMgq0jDwR8AuAF9QY3', 'type': 'function'}
[05/08/25 21:04:55] INFO     Processing request of type CallToolRequest                                                                                server.py:534
TOOLS result:  [TextContent(type='text', text='22', annotations=None)]
```

**अस्वीकरण**: 
यो कागजात एआई अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी यथासम्भव सही अनुवाद गर्न प्रयास गर्छौं, तर कृपया बुझ्नुस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको कागजातलाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीका लागि, व्यावसायिक मानव अनुवादको सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुनेछैनौं।