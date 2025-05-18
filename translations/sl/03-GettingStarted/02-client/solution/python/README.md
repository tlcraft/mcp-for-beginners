<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:05:30+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon tega vzorca

Priporočamo, da namestite `uv`, vendar ni nujno, glejte [navodila](https://docs.astral.sh/uv/#highlights)

## -0- Ustvarite virtualno okolje

```bash
python -m venv venv
```

## -1- Aktivirajte virtualno okolje

```bash
venv\Scrips\activate
```

## -2- Namestite odvisnosti

```bash
pip install "mcp[cli]"
```

## -3- Zaženite vzorec

```bash
python client.py
```

Videti bi morali izhod, podoben temu:

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

**Omejitev odgovornosti**:  
Ta dokument je bil preveden s storitvijo AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije se priporoča profesionalni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.