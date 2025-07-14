<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:44:54+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "sl"
}
-->
# Generator študijskega načrta z Chainlit & Microsoft Learn Docs MCP

## Zahteve

- Python 3.8 ali novejši
- pip (upravljalnik paketov za Python)
- Dostop do interneta za povezavo s strežnikom Microsoft Learn Docs MCP

## Namestitev

1. Klonirajte ta repozitorij ali prenesite datoteke projekta.
2. Namestite potrebne odvisnosti:

   ```bash
   pip install -r requirements.txt
   ```

## Uporaba

### Scenarij 1: Preprosto poizvedovanje na Docs MCP  
Ukazna vrstica, ki se poveže s strežnikom Docs MCP, pošlje poizvedbo in izpiše rezultat.

1. Zaženite skripto:  
   ```bash
   python scenario1.py
   ```  
2. Vnesite svoje vprašanje o dokumentaciji na poziv.

### Scenarij 2: Generator študijskega načrta (Chainlit spletna aplikacija)  
Spletni vmesnik (uporaba Chainlit), ki uporabnikom omogoča ustvarjanje osebnega, tedenskega študijskega načrta za katerokoli tehnično temo.

1. Zaženite Chainlit aplikacijo:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Odprite lokalni URL, ki je prikazan v terminalu (npr. http://localhost:8000) v svojem brskalniku.  
3. V oknu klepeta vnesite svojo študijsko temo in število tednov, koliko želite študirati (npr. "AI-900 certification, 8 weeks").  
4. Aplikacija bo odgovorila s tedenskim študijskim načrtom, vključno s povezavami do ustrezne Microsoft Learn dokumentacije.

**Zahtevane okoljske spremenljivke:**  

Za uporabo scenarija 2 (Chainlit spletna aplikacija z Azure OpenAI) morate v mapi `python` ustvariti `.env` datoteko in nastaviti naslednje okoljske spremenljivke:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Pred zagonom aplikacije vnesite svoje podatke o Azure OpenAI viru.

> **Namig:** S pomočjo [Azure AI Foundry](https://ai.azure.com/) lahko enostavno namestite svoje modele.

### Scenarij 3: Dokumentacija v urejevalniku z MCP strežnikom v VS Code

Namesto preklapljanja med zavihki brskalnika za iskanje dokumentacije lahko Microsoft Learn Docs pripeljete neposredno v VS Code z uporabo MCP strežnika. To omogoča:  
- Iskanje in branje dokumentacije znotraj VS Code brez zapuščanja razvojnega okolja.  
- Vstavljanje referenčnih povezav neposredno v README ali datoteke tečajev.  
- Uporabo GitHub Copilot in MCP skupaj za nemoteno, AI-podprto delo z dokumentacijo.

**Primeri uporabe:**  
- Hitro dodajanje referenčnih povezav v README med pisanjem dokumentacije za tečaj ali projekt.  
- Uporaba Copilota za generiranje kode in MCP za takojšnje iskanje ter citiranje ustrezne dokumentacije.  
- Osredotočanje na delo v urejevalniku in povečanje produktivnosti.

> [!IMPORTANT]  
> Poskrbite, da imate v svojem delovnem prostoru veljavno konfiguracijo [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) (lokacija je `.vscode/mcp.json`).

## Zakaj Chainlit za scenarij 2?

Chainlit je sodoben odprtokodni okvir za izdelavo pogovornih spletnih aplikacij. Omogoča enostavno ustvarjanje klepetalnih uporabniških vmesnikov, ki se povezujejo z backend storitvami, kot je Microsoft Learn Docs MCP strežnik. Ta projekt uporablja Chainlit za preprost in interaktiven način ustvarjanja osebnih študijskih načrtov v realnem času. Z uporabo Chainlit lahko hitro razvijete in uvedete klepetalne pripomočke, ki izboljšajo produktivnost in učenje.

## Kaj ta aplikacija počne

Aplikacija uporabnikom omogoča ustvarjanje osebnega študijskega načrta z enostavnim vnosom teme in trajanja. Aplikacija obdela vaš vnos, pošlje poizvedbo na Microsoft Learn Docs MCP strežnik za ustrezno vsebino in rezultate organizira v strukturiran, tedenski načrt. Priporočila za vsak teden so prikazana v klepetu, kar omogoča enostavno sledenje in napredek. Integracija zagotavlja, da vedno prejmete najnovejše in najbolj relevantne učne vire.

## Primeri poizvedb

Preizkusite te poizvedbe v klepetalnem oknu in poglejte, kako aplikacija odgovori:

- `AI-900 certification, 8 weeks`  
- `Learn Azure Functions, 4 weeks`  
- `Azure DevOps, 6 weeks`  
- `Data engineering on Azure, 10 weeks`  
- `Microsoft security fundamentals, 5 weeks`  
- `Power Platform, 7 weeks`  
- `Azure AI services, 12 weeks`  
- `Cloud architecture, 9 weeks`

Ti primeri prikazujejo prilagodljivost aplikacije za različne učne cilje in časovne okvire.

## Viri

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.