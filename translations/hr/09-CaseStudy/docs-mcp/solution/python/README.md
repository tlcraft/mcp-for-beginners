<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:44:42+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "hr"
}
-->
# Generator plana učenja s Chainlit i Microsoft Learn Docs MCP

## Preduvjeti

- Python 3.8 ili noviji
- pip (Python upravitelj paketa)
- Internet veza za povezivanje s Microsoft Learn Docs MCP serverom

## Instalacija

1. Klonirajte ovaj repozitorij ili preuzmite datoteke projekta.
2. Instalirajte potrebne ovisnosti:

   ```bash
   pip install -r requirements.txt
   ```

## Korištenje

### Scenarij 1: Jednostavan upit prema Docs MCP
Klijent iz komandne linije koji se povezuje na Docs MCP server, šalje upit i ispisuje rezultat.

1. Pokrenite skriptu:
   ```bash
   python scenario1.py
   ```
2. Unesite svoje pitanje vezano uz dokumentaciju na upitniku.

### Scenarij 2: Generator plana učenja (Chainlit web aplikacija)
Web sučelje (koristeći Chainlit) koje korisnicima omogućuje generiranje personaliziranog, tjednog plana učenja za bilo koju tehničku temu.

1. Pokrenite Chainlit aplikaciju:
   ```bash
   chainlit run scenario2.py
   ```
2. Otvorite lokalnu URL adresu prikazanu u terminalu (npr. http://localhost:8000) u svom pregledniku.
3. U prozoru za chat unesite temu učenja i broj tjedana za koje želite učiti (npr. "AI-900 certifikacija, 8 tjedana").
4. Aplikacija će odgovoriti tjednim planom učenja, uključujući poveznice na relevantnu Microsoft Learn dokumentaciju.

**Potrebne varijable okoline:**

Za korištenje Scenarija 2 (Chainlit web aplikacija s Azure OpenAI), morate postaviti sljedeće varijable okoline u `.env` datoteci unutar `python` direktorija:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Ispunite ove vrijednosti detaljima vašeg Azure OpenAI resursa prije pokretanja aplikacije.

> **Tip:** Jednostavno možete implementirati vlastite modele koristeći [Azure AI Foundry](https://ai.azure.com/).

### Scenarij 3: Dokumentacija unutar editora s MCP serverom u VS Code

Umjesto prebacivanja između kartica preglednika za pretraživanje dokumentacije, možete Microsoft Learn Docs dovesti izravno u VS Code koristeći MCP server. To vam omogućuje:
- Pretraživanje i čitanje dokumenata unutar VS Code bez napuštanja radnog okruženja.
- Referenciranje dokumentacije i umetanje poveznica izravno u README ili datoteke tečaja.
- Korištenje GitHub Copilot i MCP zajedno za besprijekoran, AI-podržan tijek rada s dokumentacijom.

**Primjeri upotrebe:**
- Brzo dodavanje referentnih poveznica u README dok pišete dokumentaciju za tečaj ili projekt.
- Korištenje Copilota za generiranje koda i MCP-a za trenutno pronalaženje i citiranje relevantne dokumentacije.
- Ostanite fokusirani u editoru i povećajte produktivnost.

> [!IMPORTANT]
> Provjerite imate li valjanu [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) konfiguraciju u svom radnom prostoru (lokacija je `.vscode/mcp.json`).

## Zašto Chainlit za Scenarij 2?

Chainlit je moderan open-source okvir za izradu konverzacijskih web aplikacija. Omogućuje jednostavno stvaranje chat sučelja koja se povezuju s backend servisima poput Microsoft Learn Docs MCP servera. Ovaj projekt koristi Chainlit kako bi pružio jednostavan, interaktivan način za generiranje personaliziranih planova učenja u stvarnom vremenu. Korištenjem Chainlit-a brzo možete izgraditi i implementirati chat alate koji poboljšavaju produktivnost i učenje.

## Što ova aplikacija radi

Ova aplikacija omogućuje korisnicima da kreiraju personalizirani plan učenja jednostavnim unosom teme i trajanja. Aplikacija analizira vaš unos, šalje upit Microsoft Learn Docs MCP serveru za relevantni sadržaj i organizira rezultate u strukturirani, tjedni plan. Preporuke za svaki tjedan prikazuju se u chatu, što olakšava praćenje i napredak. Integracija osigurava da uvijek dobijete najnovije i najrelevantnije izvore za učenje.

## Primjeri upita

Isprobajte ove upite u chat prozoru da vidite kako aplikacija odgovara:

- `AI-900 certifikacija, 8 tjedana`
- `Nauči Azure Functions, 4 tjedna`
- `Azure DevOps, 6 tjedana`
- `Data engineering na Azureu, 10 tjedana`
- `Microsoft sigurnosni temelji, 5 tjedana`
- `Power Platform, 7 tjedana`
- `Azure AI servisi, 12 tjedana`
- `Cloud arhitektura, 9 tjedana`

Ovi primjeri pokazuju fleksibilnost aplikacije za različite ciljeve učenja i vremenske okvire.

## Reference

- [Chainlit dokumentacija](https://docs.chainlit.io/)
- [MCP dokumentacija](https://github.com/MicrosoftDocs/mcp)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.