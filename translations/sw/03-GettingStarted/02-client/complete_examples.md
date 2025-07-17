<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:35:05+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "sw"
}
-->
# Mifano Kamili ya Mteja wa MCP

Kabrasha hili lina mifano kamili, inayofanya kazi ya wateja wa MCP katika lugha mbalimbali za programu. Kila mteja unaonyesha utendaji kamili ulioelezwa katika mafunzo makuu ya README.md.

## Wateja Wanaopatikana

### 1. Mteja wa Java (`client_example_java.java`)
- **Usafirishaji**: SSE (Matukio Yanayotumwa na Server) kupitia HTTP
- **Server Lengwa**: `http://localhost:8080`
- **Sifa**: 
  - Kuanzisha muunganisho na ping
  - Orodha ya zana
  - Operesheni za kalkuleta (ongeza, toa, zidisha, gawanya, msaada)
  - Kushughulikia makosa na kutoa matokeo

**Ili kuendesha:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Mteja wa C# (`client_example_csharp.cs`)
- **Usafirishaji**: Stdio (Ingizo/Tokeo la Kawaida)
- **Server Lengwa**: Server ya MCP ya .NET ya ndani kupitia dotnet run
- **Sifa**:
  - Kuanzisha server moja kwa moja kupitia usafirishaji wa stdio
  - Orodha ya zana na rasilimali
  - Operesheni za kalkuleta
  - Kuchambua matokeo ya JSON
  - Kushughulikia makosa kwa kina

**Ili kuendesha:**
```bash
dotnet run
```

### 3. Mteja wa TypeScript (`client_example_typescript.ts`)
- **Usafirishaji**: Stdio (Ingizo/Tokeo la Kawaida)
- **Server Lengwa**: Server ya MCP ya Node.js ya ndani
- **Sifa**:
  - Msaada kamili wa itifaki ya MCP
  - Operesheni za zana, rasilimali, na maelekezo
  - Operesheni za kalkuleta
  - Kusoma rasilimali na kutekeleza maelekezo
  - Kushughulikia makosa kwa nguvu

**Ili kuendesha:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Mteja wa Python (`client_example_python.py`)
- **Usafirishaji**: Stdio (Ingizo/Tokeo la Kawaida)  
- **Server Lengwa**: Server ya MCP ya Python ya ndani
- **Sifa**:
  - Mfano wa async/await kwa operesheni
  - Ugunduzi wa zana na rasilimali
  - Kupima operesheni za kalkuleta
  - Kusoma maudhui ya rasilimali
  - Muundo wa darasa

**Ili kuendesha:**
```bash
python client_example_python.py
```

## Sifa Zaidi Zinazopatikana Kwenye Wateja Wote

Kila utekelezaji wa mteja unaonyesha:

1. **Usimamizi wa Muunganisho**
   - Kuanzisha muunganisho na server ya MCP
   - Kushughulikia makosa ya muunganisho
   - Usafishaji sahihi na usimamizi wa rasilimali

2. **Ugunduzi wa Server**
   - Orodha ya zana zinazopatikana
   - Orodha ya rasilimali zinazopatikana (ambapo zinasaidiwa)
   - Orodha ya maelekezo yanayopatikana (ambapo zinasaidiwa)

3. **Kuitisha Zana**
   - Operesheni za msingi za kalkuleta (ongeza, toa, zidisha, gawanya)
   - Amri ya msaada kwa taarifa za server
   - Kupitisha hoja kwa usahihi na kushughulikia matokeo

4. **Kushughulikia Makosa**
   - Makosa ya muunganisho
   - Makosa ya utekelezaji wa zana
   - Kushindwa kwa heshima na mrejesho kwa mtumiaji

5. **Usindikaji wa Matokeo**
   - Kutoa maudhui ya maandishi kutoka kwa majibu
   - Kuandaa matokeo kwa usomaji rahisi
   - Kushughulikia aina tofauti za majibu

## Mahitaji Kabla ya Kuendesha

Kabla ya kuendesha wateja hawa, hakikisha umefanya:

1. **Server husika ya MCP inafanya kazi** (kutoka `../01-first-server/`)
2. **Maktaba zinazohitajika zimewekwa** kwa lugha uliyochagua
3. **Muunganisho wa mtandao uko sawa** (kwa usafirishaji wa HTTP)

## Tofauti Muhimu Kati ya Utekelezaji

| Lugha      | Usafirishaji | Kuanzisha Server | Mfano wa Async | Maktaba Muhimu |
|------------|--------------|------------------|---------------|----------------|
| Java       | SSE/HTTP     | Nje             | Synchronous   | WebFlux, MCP SDK |
| C#         | Stdio        | Moja kwa moja    | Async/Await   | .NET MCP SDK   |
| TypeScript | Stdio        | Moja kwa moja    | Async/Await   | Node MCP SDK   |
| Python     | Stdio        | Moja kwa moja    | AsyncIO       | Python MCP SDK |

## Hatua Zifuatazo

Baada ya kuchunguza mifano hii ya wateja:

1. **Badilisha wateja** kuongeza sifa mpya au operesheni
2. **Tengeneza server yako mwenyewe** na uiteste na wateja hawa
3. **Jaribu usafirishaji tofauti** (SSE dhidi ya Stdio)
4. **Jenga programu tata zaidi** inayojumuisha utendaji wa MCP

## Utatuzi wa Matatizo

### Masuala ya Kawaida

1. **Muunganisho umekataliwa**: Hakikisha server ya MCP inafanya kazi kwenye bandari/ njia inayotarajiwa
2. **Moduli haipatikani**: Sakinisha MCP SDK inayohitajika kwa lugha yako
3. **Ruhusa imekataliwa**: Angalia ruhusa za faili kwa usafirishaji wa stdio
4. **Zana haipatikani**: Hakikisha server inatekeleza zana zinazotarajiwa

### Vidokezo vya Kurekebisha

1. **Washa ufuatiliaji wa kina** katika MCP SDK yako
2. **Angalia kumbukumbu za server** kwa ujumbe wa makosa
3. **Thibitisha majina na saini za zana** zilingane kati ya mteja na server
4. **Jaribu kwanza na MCP Inspector** kuthibitisha utendaji wa server

## Nyaraka Zinazohusiana

- [Mafunzo Makuu ya Mteja](./README.md)
- [Mifano ya Server ya MCP](../../../../03-GettingStarted/01-first-server)
- [MCP na Uunganisho wa LLM](../../../../03-GettingStarted/03-llm-client)
- [Nyaraka Rasmi za MCP](https://modelcontextprotocol.io/)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.