<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:35:56+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "sk"
}
-->
# Kompletné príklady MCP klientov

Tento adresár obsahuje kompletné, funkčné príklady MCP klientov v rôznych programovacích jazykoch. Každý klient demonštruje plnú funkcionalitu popísanú v hlavnom návode README.md.

## Dostupní klienti

### 1. Java klient (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) cez HTTP
- **Cieľový server**: `http://localhost:8080`
- **Funkcie**: 
  - Nadviazanie spojenia a ping
  - Zoznam nástrojov
  - Operácie kalkulačky (sčítanie, odčítanie, násobenie, delenie, pomoc)
  - Spracovanie chýb a extrakcia výsledkov

**Spustenie:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# klient (`client_example_csharp.cs`)
- **Transport**: Stdio (štandardný vstup/výstup)
- **Cieľový server**: Lokálny .NET MCP server cez dotnet run
- **Funkcie**:
  - Automatické spustenie servera cez stdio transport
  - Zoznam nástrojov a zdrojov
  - Operácie kalkulačky
  - Parsovanie JSON výsledkov
  - Komplexné spracovanie chýb

**Spustenie:**
```bash
dotnet run
```

### 3. TypeScript klient (`client_example_typescript.ts`)
- **Transport**: Stdio (štandardný vstup/výstup)
- **Cieľový server**: Lokálny Node.js MCP server
- **Funkcie**:
  - Plná podpora MCP protokolu
  - Operácie s nástrojmi, zdrojmi a promptmi
  - Operácie kalkulačky
  - Čítanie zdrojov a vykonávanie promptov
  - Spoľahlivé spracovanie chýb

**Spustenie:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python klient (`client_example_python.py`)
- **Transport**: Stdio (štandardný vstup/výstup)  
- **Cieľový server**: Lokálny Python MCP server
- **Funkcie**:
  - Použitie async/await pre operácie
  - Objavovanie nástrojov a zdrojov
  - Testovanie operácií kalkulačky
  - Čítanie obsahu zdrojov
  - Organizácia v triedach

**Spustenie:**
```bash
python client_example_python.py
```

## Spoločné vlastnosti všetkých klientov

Každá implementácia klienta demonštruje:

1. **Správa spojenia**
   - Nadviazanie spojenia s MCP serverom
   - Riešenie chýb spojenia
   - Správne uvoľnenie zdrojov a čistenie

2. **Objavovanie servera**
   - Zoznam dostupných nástrojov
   - Zoznam dostupných zdrojov (ak je podporované)
   - Zoznam dostupných promptov (ak je podporované)

3. **Volanie nástrojov**
   - Základné operácie kalkulačky (sčítanie, odčítanie, násobenie, delenie)
   - Príkaz pomoc pre informácie o serveri
   - Správne odovzdávanie argumentov a spracovanie výsledkov

4. **Spracovanie chýb**
   - Chyby spojenia
   - Chyby pri vykonávaní nástrojov
   - Elegantné zlyhanie a spätná väzba pre používateľa

5. **Spracovanie výsledkov**
   - Extrakcia textového obsahu z odpovedí
   - Formátovanie výstupu pre lepšiu čitateľnosť
   - Riešenie rôznych formátov odpovedí

## Predpoklady

Pred spustením týchto klientov sa uistite, že máte:

1. **Bežiaci príslušný MCP server** (z `../01-first-server/`)
2. **Nainštalované potrebné závislosti** pre váš vybraný jazyk
3. **Správne sieťové pripojenie** (pre HTTP transporty)

## Kľúčové rozdiely medzi implementáciami

| Jazyk      | Transport | Spustenie servera | Asynchrónny model | Kľúčové knižnice |
|------------|-----------|-------------------|-------------------|------------------|
| Java       | SSE/HTTP  | Externé           | Synchrónny        | WebFlux, MCP SDK |
| C#         | Stdio     | Automatické       | Async/Await       | .NET MCP SDK     |
| TypeScript | Stdio     | Automatické       | Async/Await       | Node MCP SDK     |
| Python     | Stdio     | Automatické       | AsyncIO           | Python MCP SDK   |

## Ďalšie kroky

Po preskúmaní týchto príkladov klientov:

1. **Upravte klientov** a pridajte nové funkcie alebo operácie
2. **Vytvorte si vlastný server** a otestujte ho s týmito klientmi
3. **Experimentujte s rôznymi transportmi** (SSE vs. Stdio)
4. **Vytvorte zložitejšiu aplikáciu**, ktorá integruje MCP funkcionalitu

## Riešenie problémov

### Bežné problémy

1. **Pripojenie odmietnuté**: Skontrolujte, či MCP server beží na očakávanom porte/ceste
2. **Modul nenájdený**: Nainštalujte potrebný MCP SDK pre váš jazyk
3. **Prístup zamietnutý**: Skontrolujte oprávnenia súborov pre stdio transport
4. **Nástroj nenájdený**: Overte, či server implementuje očakávané nástroje

### Tipy na ladenie

1. **Zapnite podrobné logovanie** vo vašom MCP SDK
2. **Skontrolujte logy servera** pre chybové hlásenia
3. **Overte názvy a podpisy nástrojov**, či zodpovedajú medzi klientom a serverom
4. **Najskôr otestujte s MCP Inspectorom** na overenie funkčnosti servera

## Súvisiaca dokumentácia

- [Hlavný návod pre klienta](./README.md)
- [Príklady MCP serverov](../../../../03-GettingStarted/01-first-server)
- [MCP s integráciou LLM](../../../../03-GettingStarted/03-llm-client)
- [Oficiálna MCP dokumentácia](https://modelcontextprotocol.io/)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.