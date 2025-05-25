<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:42:56+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "it"
}
-->
## Test e debug

Prima di iniziare a testare il tuo server MCP, è importante comprendere gli strumenti disponibili e le migliori pratiche per il debug. Un test efficace garantisce che il tuo server si comporti come previsto e ti aiuta a identificare e risolvere rapidamente i problemi. La sezione seguente delinea gli approcci consigliati per validare la tua implementazione MCP.

## Panoramica

Questa lezione copre come selezionare l'approccio di test giusto e lo strumento di test più efficace.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Descrivere vari approcci per il test.
- Utilizzare diversi strumenti per testare efficacemente il tuo codice.

## Test dei server MCP

MCP fornisce strumenti per aiutarti a testare e debugare i tuoi server:

- **MCP Inspector**: Uno strumento da linea di comando che può essere eseguito sia come strumento CLI che come strumento visivo.
- **Test manuale**: Puoi utilizzare uno strumento come curl per eseguire richieste web, ma qualsiasi strumento capace di eseguire HTTP andrà bene.
- **Test unitari**: È possibile utilizzare il tuo framework di test preferito per testare le funzionalità sia del server che del client.

### Utilizzo di MCP Inspector

Abbiamo descritto l'utilizzo di questo strumento nelle lezioni precedenti, ma parliamone un po' a livello generale. È uno strumento costruito in Node.js e puoi utilizzarlo chiamando l'eseguibile `npx` che scaricherà e installerà temporaneamente lo strumento stesso e si pulirà una volta terminato l'esecuzione della tua richiesta.

Il [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ti aiuta a:

- **Scoprire le capacità del server**: Rileva automaticamente risorse, strumenti e prompt disponibili
- **Testare l'esecuzione degli strumenti**: Prova diversi parametri e vedi le risposte in tempo reale
- **Visualizzare i metadati del server**: Esamina informazioni sul server, schemi e configurazioni

Una tipica esecuzione dello strumento appare così:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Il comando sopra avvia un MCP e la sua interfaccia visiva e lancia un'interfaccia web locale nel tuo browser. Puoi aspettarti di vedere un dashboard che visualizza i tuoi server MCP registrati, i loro strumenti disponibili, risorse e prompt. L'interfaccia ti consente di testare interattivamente l'esecuzione degli strumenti, ispezionare i metadati del server e visualizzare risposte in tempo reale, rendendo più facile validare e debugare le implementazioni del tuo server MCP.

Ecco come può apparire: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.it.png)

Puoi anche eseguire questo strumento in modalità CLI nel qual caso aggiungi l'attributo `--cli`. Ecco un esempio di esecuzione dello strumento in modalità "CLI" che elenca tutti gli strumenti sul server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Test manuale

Oltre a eseguire lo strumento inspector per testare le capacità del server, un altro approccio simile è eseguire un client capace di utilizzare HTTP, come per esempio curl.

Con curl, puoi testare i server MCP direttamente utilizzando richieste HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Come puoi vedere dall'uso sopra di curl, usi una richiesta POST per invocare uno strumento utilizzando un payload composto dal nome dello strumento e dai suoi parametri. Usa l'approccio che si adatta meglio a te. Gli strumenti CLI in generale tendono ad essere più veloci da usare e si prestano ad essere scriptati, il che può essere utile in un ambiente CI/CD.

### Test unitari

Crea test unitari per i tuoi strumenti e risorse per assicurarti che funzionino come previsto. Ecco un esempio di codice di test.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Il codice precedente fa quanto segue:

- Utilizza il framework pytest che ti permette di creare test come funzioni e usare affermazioni assert.
- Crea un server MCP con due strumenti diversi.
- Usa l'affermazione `assert` per verificare che certe condizioni siano soddisfatte.

Dai un'occhiata al [file completo qui](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Dato il file sopra, puoi testare il tuo server per assicurarti che le capacità siano create come dovrebbero.

Tutti i principali SDK hanno sezioni di test simili, quindi puoi adattarti al runtime scelto.

## Esempi

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Risorse aggiuntive

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Cosa c'è dopo

- Prossimo: [Deployment](/03-GettingStarted/08-deployment/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.