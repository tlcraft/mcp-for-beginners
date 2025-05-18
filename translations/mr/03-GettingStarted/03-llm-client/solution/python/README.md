<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:47:07+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवा

तुम्हाला `uv` स्थापित करण्याची शिफारस केली जाते पण ते आवश्यक नाही, [सूचना](https://docs.astral.sh/uv/#highlights) पहा

## -0- एक वर्च्युअल वातावरण तयार करा

```bash
python -m venv venv
```

## -1- वर्च्युअल वातावरण सक्रिय करा

```bash
venv\Scrips\activate
```

## -2- अवलंबन स्थापित करा

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- नमुना चालवा

```bash
python client.py
```

तुम्हाला यासारखा आउटपुट दिसायला हवा:

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

**अस्वीकृती**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादात त्रुटी किंवा अचूकतेची कमतरता असू शकते. मूळ भाषेतील दस्तऐवज हा अधिकारिक स्रोत मानला पाहिजे. महत्त्वपूर्ण माहितीकरिता, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थाबद्दल आम्ही जबाबदार नाही.