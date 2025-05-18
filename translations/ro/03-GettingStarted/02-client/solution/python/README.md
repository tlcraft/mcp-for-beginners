<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:04:51+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Se recomandă să instalați `uv`, dar nu este obligatoriu, vedeți [instrucțiunile](https://docs.astral.sh/uv/#highlights)

## -0- Creați un mediu virtual

```bash
python -m venv venv
```

## -1- Activați mediul virtual

```bash
venv\Scrips\activate
```

## -2- Instalați dependențele

```bash
pip install "mcp[cli]"
```

## -3- Rulați exemplul

```bash
python client.py
```

Ar trebui să vedeți un output similar cu:

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

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea umană profesională. Nu suntem responsabili pentru neînțelegerile sau interpretările greșite care decurg din utilizarea acestei traduceri.