<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:12:41+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "sr"
}
-->
## Testiranje i ispravljanje grešaka

Pre nego što počnete sa testiranjem vašeg MCP servera, važno je da razumete dostupne alate i najbolje prakse za ispravljanje grešaka. Efikasno testiranje osigurava da vaš server radi kako se očekuje i pomaže vam da brzo identifikujete i rešite probleme. Sledeći odeljak daje preporučene pristupe za validaciju vaše MCP implementacije.

## Pregled

Ova lekcija obuhvata kako izabrati pravi pristup testiranju i najučinkovitiji alat za testiranje.

## Ciljevi učenja

Na kraju ove lekcije, bićete u stanju da:

- Opišete različite pristupe testiranju.
- Koristite različite alate za efikasno testiranje vašeg koda.

## Testiranje MCP servera

MCP pruža alate koji vam pomažu da testirate i ispravljate greške na vašim serverima:

- **MCP Inspector**: alat iz komandne linije koji se može koristiti i kao CLI i kao vizuelni alat.
- **Ručno testiranje**: možete koristiti alat poput curl za pokretanje web zahteva, ali bilo koji alat sposoban za HTTP će biti dovoljan.
- **Jedinično testiranje**: moguće je koristiti vaš omiljeni testni okvir za testiranje funkcionalnosti kako servera, tako i klijenta.

### Korišćenje MCP Inspector-a

Opisali smo upotrebu ovog alata u prethodnim lekcijama, ali hajde da ga ukratko predstavimo. To je alat napravljen u Node.js i možete ga koristiti pozivom izvršne datoteke `npx` koja će privremeno preuzeti i instalirati alat i očistiti se nakon izvršenja vašeg zahteva.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) vam pomaže da:

- **Otkrivate mogućnosti servera**: Automatski detektuje dostupne resurse, alate i upite
- **Testirate izvršavanje alata**: Isprobajte različite parametre i pratite odgovore u realnom vremenu
- **Pregledate metapodatke servera**: Ispitajte informacije o serveru, šeme i konfiguracije

Tipično pokretanje alata izgleda ovako:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Gornja komanda pokreće MCP i njegov vizuelni interfejs, kao i lokalni web interfejs u vašem pregledaču. Očekujte da vidite kontrolnu tablu sa registrovanim MCP serverima, njihovim dostupnim alatima, resursima i upitima. Interfejs vam omogućava interaktivno testiranje izvršenja alata, pregled metapodataka servera i gledanje odgovora u realnom vremenu, što olakšava validaciju i ispravljanje grešaka u implementacijama MCP servera.

Ovako to može izgledati: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sr.png)

Takođe možete pokrenuti ovaj alat u CLI režimu dodavanjem atributa `--cli`. Evo primera pokretanja alata u "CLI" režimu koji prikazuje sve alate na serveru:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Ručno testiranje

Pored korišćenja inspektora za testiranje mogućnosti servera, sličan pristup je korišćenje klijenta sposoban za HTTP, na primer curl.

Sa curl-om možete direktno testirati MCP servere koristeći HTTP zahteve:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kao što vidite iz primera korišćenja curl-a, koristite POST zahtev da pozovete alat sa payload-om koji sadrži ime alata i njegove parametre. Koristite pristup koji vam najviše odgovara. CLI alati su uglavnom brži za korišćenje i lako se mogu skriptovati, što može biti korisno u CI/CD okruženju.

### Jedinično testiranje

Kreirajte jedinične testove za vaše alate i resurse kako biste osigurali da rade kako treba. Evo primera test koda.

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

Gore navedeni kod radi sledeće:

- Koristi pytest framework koji omogućava kreiranje testova kao funkcija i korišćenje assert izraza.
- Kreira MCP Server sa dva različita alata.
- Koristi `assert` izraz da proveri da li su određeni uslovi ispunjeni.

Pogledajte [cela datoteka ovde](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Na osnovu ove datoteke, možete testirati sopstveni server da biste osigurali da su mogućnosti kreirane kako treba.

Svi glavni SDK-ovi imaju slične sekcije za testiranje, tako da ih možete prilagoditi vašem runtime okruženju.

## Primeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Šta sledi

- Sledeće: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати коришћењем овог превода.