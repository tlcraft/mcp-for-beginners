<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:04:26+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

Doporučuje se nainstalovat `uv`, ale není to nutné, viz [pokyny](https://docs.astral.sh/uv/#highlights)

## -0- Vytvoření virtuálního prostředí

```bash
python -m venv venv
```

## -1- Aktivace virtuálního prostředí

```bash
venv\Scrips\activate
```

## -2- Instalace závislostí

```bash
pip install "mcp[cli]"
```

## -3- Spuštění příkladu

```bash
python client.py
```

Měli byste vidět výstup podobný:

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

**Prohlášení**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.