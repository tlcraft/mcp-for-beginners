<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:01:14+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "pt"
}
-->
# Executando este exemplo

Recomenda-se instalar `uv`, mas não é obrigatório, veja [instruções](https://docs.astral.sh/uv/#highlights)

## -0- Criar um ambiente virtual

```bash
python -m venv venv
```

## -1- Ativar o ambiente virtual

```bash
venv\Scrips\activate
```

## -2- Instalar as dependências

```bash
pip install "mcp[cli]"
```

## -3- Executar o exemplo

```bash
python client.py
```

Você deve ver uma saída semelhante a:

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

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.