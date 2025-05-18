<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:00:25+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवा

`uv` स्थापित करणे सुचवले जाते, परंतु ते आवश्यक नाही, [सूचना](https://docs.astral.sh/uv/#highlights) पहा

## -0- एक आभासी वातावरण तयार करा

```bash
python -m venv venv
```

## -1- आभासी वातावरण सक्रिय करा

```bash
venv\Scrips\activate
```

## -2- अवलंबन स्थापित करा

```bash
pip install "mcp[cli]"
```

## -3- नमुना चालवा

```bash
python client.py
```

आपल्याला खालीलप्रमाणे आउटपुट दिसेल:

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

**अस्वीकृती**:  
हे दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून अनुवादित करण्यात आले आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत मानला जावा. महत्वाच्या माहितीसाठी, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थ लावण्यास आम्ही जबाबदार नाही.