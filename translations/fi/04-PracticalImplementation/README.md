<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:55:02+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fi"
}
-->
# Käytännön Toteutus

Käytännön toteutus on se osa, jossa Model Context Protocolin (MCP) voima tulee konkreettiseksi. Vaikka MCP:n teorian ja arkkitehtuurin ymmärtäminen on tärkeää, todellinen arvo syntyy, kun sovellat näitä käsitteitä rakentaaksesi, testataksesi ja käyttöönottaaksesi ratkaisuja, jotka ratkaisevat todellisia ongelmia. Tämä luku yhdistää käsitteellisen tiedon ja käytännön kehityksen, ohjaten sinua MCP-pohjaisten sovellusten eloon saattamisessa.

Olitpa sitten kehittämässä älykkäitä avustajia, integroimassa tekoälyä liiketoimintaprosesseihin tai rakentamassa räätälöityjä työkaluja datan käsittelyyn, MCP tarjoaa joustavan perustan. Sen kielestä riippumaton suunnittelu ja viralliset SDK:t suosituimmille ohjelmointikielille tekevät siitä saavutettavan laajalle kehittäjäjoukolle. Hyödyntämällä näitä SDK:ita voit nopeasti prototyyppata, iteroida ja laajentaa ratkaisuja eri alustoilla ja ympäristöissä.

Seuraavissa osioissa löydät käytännön esimerkkejä, mallikoodia ja käyttöönotto-strategioita, jotka osoittavat, miten MCP:tä toteutetaan C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa. Opit myös, miten debugata ja testata MCP-palvelimia, hallita API:ita ja ottaa ratkaisuja käyttöön pilvessä Azurea käyttäen. Nämä käytännön resurssit on suunniteltu nopeuttamaan oppimistasi ja auttamaan sinua rakentamaan luottavaisesti kestäviä, tuotantovalmiita MCP-sovelluksia.

## Yleiskatsaus

Tämä oppitunti keskittyy MCP:n toteutuksen käytännön näkökohtiin useilla ohjelmointikielillä. Tutustumme siihen, miten käyttää MCP SDK:ita C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa rakentaaksemme kestäviä sovelluksia, debugataksemme ja testataksemme MCP-palvelimia sekä luodaksemme uudelleenkäytettäviä resursseja, kehotteita ja työkaluja.

## Oppimistavoitteet

Oppitunnin lopussa pystyt:
- Toteuttamaan MCP-ratkaisuja virallisia SDK:ita käyttäen eri ohjelmointikielillä
- Debugata ja testata MCP-palvelimia järjestelmällisesti
- Luoda ja käyttää palvelinominaisuuksia (Resurssit, Kehotteet ja Työkalut)
- Suunnitella tehokkaita MCP-työnkulkuja monimutkaisiin tehtäviin
- Optimoida MCP-toteutuksia suorituskyvyn ja luotettavuuden kannalta

## Viralliset SDK-resurssit

Model Context Protocol tarjoaa virallisia SDK:ita useille kielille:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Työskentely MCP SDK:iden kanssa

Tämä osio tarjoaa käytännön esimerkkejä MCP:n toteutuksesta useilla ohjelmointikielillä. Löydät mallikoodia `samples` hakemistosta, joka on järjestetty kielen mukaan.

### Saatavilla olevat mallit

Tietovarasto sisältää mallitoteutuksia seuraavilla kielillä:

- C#
- Java
- TypeScript
- JavaScript
- Python

Jokainen malli havainnollistaa keskeisiä MCP-käsitteitä ja toteutusmalleja kyseiselle kielelle ja ekosysteemille.

## Keskeiset palvelinominaisuudet

MCP-palvelimet voivat toteuttaa minkä tahansa yhdistelmän näistä ominaisuuksista:

### Resurssit
Resurssit tarjoavat kontekstia ja dataa käyttäjän tai tekoälymallin käyttöön:
- Dokumenttivarastot
- Tietopankit
- Jäsennellyt tietolähteet
- Tiedostojärjestelmät

### Kehotteet
Kehotteet ovat mallinnettuja viestejä ja työnkulkuja käyttäjille:
- Ennalta määritellyt keskustelumallit
- Ohjatut vuorovaikutusmallit
- Erikoistuneet dialogirakenteet

### Työkalut
Työkalut ovat funktioita, jotka tekoälymalli voi suorittaa:
- Datan käsittelytyökalut
- Ulkoisten API:iden integraatiot
- Laskennalliset kyvykkyydet
- Hakutoiminnot

## Mallitoteutukset: C#

Virallinen C# SDK-tietovarasto sisältää useita mallitoteutuksia, jotka havainnollistavat MCP:n eri puolia:

- **Perus MCP Client**: Yksinkertainen esimerkki MCP-clientin luomisesta ja työkalujen kutsumisesta
- **Perus MCP Server**: Minimipalvelintoteutus perus työkalurekisteröinnillä
- **Edistyksellinen MCP Server**: Täysimittainen palvelin työkalurekisteröinnillä, autentikoinnilla ja virheenkäsittelyllä
- **ASP.NET Integraatio**: Esimerkkejä ASP.NET Core -integraatiosta
- **Työkalutoteutusmallit**: Erilaisia malleja työkalujen toteuttamiseen eri monimutkaisuustasoilla

MCP C# SDK on esikatselussa ja API:t voivat muuttua. Päivitämme tätä blogia jatkuvasti SDK:n kehittyessä.

### Keskeiset ominaisuudet 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Rakentaminen [ensimmäinen MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Täydelliset C#-toteutuksen mallit löydät [virallisesta C# SDK:n mallien tietovarastosta](https://github.com/modelcontextprotocol/csharp-sdk)

## Mallitoteutus: Java-toteutus

Java SDK tarjoaa vankat MCP-toteutusvaihtoehdot yritystason ominaisuuksilla.

### Keskeiset ominaisuudet

- Spring Framework -integraatio
- Vahva tyyppiturvallisuus
- Reaktiivisen ohjelmoinnin tuki
- Kattava virheenkäsittely

Täydellinen Java-toteutuksen malli löytyy [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) mallihakemistosta.

## Mallitoteutus: JavaScript-toteutus

JavaScript SDK tarjoaa kevyen ja joustavan lähestymistavan MCP-toteutukseen.

### Keskeiset ominaisuudet

- Node.js ja selaintuki
- Promise-pohjainen API
- Helppo integraatio Expressin ja muiden kehysten kanssa
- WebSocket-tuki striimaukseen

Täydellinen JavaScript-toteutuksen malli löytyy [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) mallihakemistosta.

## Mallitoteutus: Python-toteutus

Python SDK tarjoaa Python-maisen lähestymistavan MCP-toteutukseen erinomaisilla ML-kehysten integraatioilla.

### Keskeiset ominaisuudet

- Async/await-tuki asyncio:n kanssa
- Flask ja FastAPI-integraatio
- Yksinkertainen työkalurekisteröinti
- Luontainen integraatio suosittujen ML-kirjastojen kanssa

Täydellinen Python-toteutuksen malli löytyy [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) mallihakemistosta.

## API-hallinta 

Azure API Management on erinomainen ratkaisu MCP-palvelimien suojaamiseen. Ajatus on sijoittaa Azure API Management -instanssi MCP-palvelimesi eteen ja antaa sen käsitellä ominaisuuksia, joita todennäköisesti haluat, kuten:

- nopeusrajoitukset
- tunnusten hallinta
- valvonta
- kuormituksen tasapainotus
- turvallisuus

### Azure-malli

Tässä on Azure-malli, joka tekee juuri tämän, eli [luo MCP-palvelimen ja suojaa sen Azure API Managementilla](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Katso, miten autentikointivirtaus tapahtuu alla olevassa kuvassa:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Edellisessä kuvassa tapahtuu seuraavaa:

- Autentikointi/autorisointi tapahtuu Microsoft Entran avulla.
- Azure API Management toimii porttina ja käyttää politiikkoja ohjaamaan ja hallitsemaan liikennettä.
- Azure Monitor kirjaa kaikki pyynnöt lisäanalyysiä varten.

#### Autorisointivirtaus

Tarkastellaan autorisointivirtauksen yksityiskohtia:

![Sekvenssikaavio](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-autorisointimääritys

Lisätietoja [MCP-autorisointimäärityksestä](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Etä-MCP-palvelimen käyttöönotto Azureen

Katsotaan, voimmeko ottaa käyttöön aiemmin mainitun mallin:

1. Kloonaa repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Rekisteröi `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` jonkin ajan kuluttua tarkistaaksesi, onko rekisteröinti valmis.

2. Suorita tämä [azd](https://aka.ms/azd) komento provisioidaksesi API-hallintapalvelun, funktiosovelluksen (koodin kanssa) ja kaikki muut tarvittavat Azure-resurssit

    ```shell
    azd up
    ```

    Tämä komento pitäisi ottaa kaikki pilviresurssit käyttöön Azuren päällä

### Palvelimen testaaminen MCP Inspectorilla

1. **Uudessa terminaali-ikkunassa**, asenna ja suorita MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Sinun pitäisi nähdä käyttöliittymä, joka näyttää tältä:

    ![Yhdistä Node-inspektoriin](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.fi.png)

1. CTRL-napsauta ladataksesi MCP Inspector -web-sovelluksen URL-osoitteesta, jonka sovellus näyttää (esim. http://127.0.0.1:6274/#resources)
1. Aseta kuljetustyyppi `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ja **Yhdistä**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Napsauta työkalua ja **Run Tool**.  

Jos kaikki vaiheet ovat onnistuneet, sinun pitäisi nyt olla yhteydessä MCP-palvelimeen ja olet pystynyt kutsumaan työkalua.

## MCP-palvelimet Azurelle 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tämä joukko tietovarastoja on nopean aloituksen mallipohja MCP (Model Context Protocol) -palvelimien rakentamiseen ja käyttöönottoon Azure Functionsilla käyttäen Pythonia, C# .NET:iä tai Node/TypeScriptiä.

Näytteet tarjoavat täydellisen ratkaisun, joka mahdollistaa kehittäjille:

- Rakentaa ja ajaa paikallisesti: Kehittää ja debugata MCP-palvelinta paikallisella koneella
- Ottaa käyttöön Azureen: Ottaa helposti käyttöön pilveen yksinkertaisella azd up -komennolla
- Yhdistää asiakkaista: Yhdistää MCP-palvelimeen eri asiakkailta, mukaan lukien VS Code:n Copilot-agenttitila ja MCP Inspector -työkalu

### Keskeiset ominaisuudet:

- Turvallisuus suunnittelusta: MCP-palvelin on suojattu avaimilla ja HTTPS:llä
- Autentikointivaihtoehdot: Tukee OAuth:ia sisäänrakennetulla autentikoinnilla ja/tai API-hallinnalla
- Verkkoeristys: Mahdollistaa verkkoeristyksen Azure Virtual Networks (VNET) avulla
- Palvelimeton arkkitehtuuri: Hyödyntää Azure Functionsia skaalautuvaan, tapahtumapohjaiseen suoritukseen
- Paikallinen kehitys: Kattava paikallinen kehitys- ja debug-tuki
- Yksinkertainen käyttöönotto: Sujuva käyttöönotto Azureen

Tietovarasto sisältää kaikki tarvittavat konfiguraatiotiedostot, lähdekoodin ja infrastruktuurimääritykset, jotta pääset nopeasti alkuun tuotantovalmiin MCP-palvelimen toteutuksessa.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP:n näytetoteutus käyttäen Azure Functionsia Pythonilla

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP:n näytetoteutus käyttäen Azure Functionsia C# .NET:llä

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP:n näytetoteutus käyttäen Azure Functionsia Node/TypeScriptillä.

## Keskeiset opit

- MCP SDK:t tarjoavat kielikohtaisia työkaluja kestävien MCP-ratkaisujen toteuttamiseen
- Debuggaus ja testausprosessi on kriittinen luotettaville MCP-sovelluksille
- Uudelleenkäytettävät kehottemallit mahdollistavat johdonmukaiset AI-vuorovaikutukset
- Hyvin suunnitellut työnkulut voivat orkestroida monimutkaisia tehtäviä useiden työkalujen avulla
- MCP-ratkaisujen toteuttaminen vaatii turvallisuuden, suorituskyvyn ja virheenkäsittelyn huomioon ottamista

## Harjoitus

Suunnittele käytännön MCP-työnkulku, joka ratkaisee todellisen ongelman omalla alallasi:

1. Tunnista 3-4 työkalua, jotka olisivat hyödyllisiä tämän ongelman ratkaisemiseksi
2. Luo työnkulku-kaavio, joka näyttää, miten nämä työkalut vuorovaikuttavat
3. Toteuta yksi työkaluista perusversio valitsemallasi kielellä
4. Luo kehotemalli, joka auttaisi mallia käyttämään työkalusi tehokkaasti

## Lisäresurssit

---

Seuraavaksi: [Edistyneet Aiheet](../05-AdvancedTopics/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, on tärkeää olla tietoinen siitä, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virhetulkinnoista.