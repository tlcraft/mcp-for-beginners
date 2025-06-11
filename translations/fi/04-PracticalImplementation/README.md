<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:18:03+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fi"
}
-->
# Käytännön toteutus

Käytännön toteutus on se vaihe, jossa Model Context Protocolin (MCP) voima konkretisoituu. Vaikka MCP:n teoria ja arkkitehtuuri ovat tärkeitä ymmärtää, todellinen hyöty syntyy, kun sovellat näitä käsitteitä ratkaisujen rakentamiseen, testaamiseen ja käyttöönottoon, jotka ratkaisevat todellisia ongelmia. Tämä luku yhdistää käsitteellisen tiedon ja käytännön kehityksen, ohjaten sinua tuomaan MCP-pohjaiset sovellukset eloon.

Olitpa kehittämässä älykkäitä assistentteja, integroimassa tekoälyä liiketoimintaprosesseihin tai rakentamassa räätälöityjä työkaluja datankäsittelyyn, MCP tarjoaa joustavan perustan. Sen kieliriippumaton rakenne ja viralliset SDK:t suosituimmille ohjelmointikielille tekevät siitä helposti lähestyttävän laajalle kehittäjäjoukolle. Hyödyntämällä näitä SDK:ita voit nopeasti prototyypittää, kehittää ja skaalata ratkaisuja eri alustoilla ja ympäristöissä.

Seuraavissa osioissa löydät käytännön esimerkkejä, koodinäytteitä ja käyttöönotto-strategioita, jotka osoittavat, miten MCP toteutetaan C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa. Opit myös virheenkorjauksesta ja testauksesta MCP-palvelimilla, API-hallinnasta sekä ratkaisujen käyttöönotosta pilvessä Azurea hyödyntäen. Nämä käytännön resurssit on suunniteltu nopeuttamaan oppimistasi ja auttamaan sinua rakentamaan luotettavia, tuotantovalmiita MCP-sovelluksia itsevarmasti.

## Yleiskatsaus

Tässä oppitunnissa keskitytään MCP:n käytännön toteutukseen useilla ohjelmointikielillä. Tutustumme MCP SDK:iden käyttöön C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa, MCP-palvelimien virheenkorjaukseen ja testaamiseen sekä uudelleenkäytettävien resurssien, kehotteiden ja työkalujen luomiseen.

## Oppimistavoitteet

Oppitunnin jälkeen osaat:
- Toteuttaa MCP-ratkaisuja virallisia SDK:ita käyttäen eri ohjelmointikielillä
- Virheenkorjata ja testata MCP-palvelimia järjestelmällisesti
- Luoda ja käyttää palvelimen ominaisuuksia (Resurssit, Kehotteet ja Työkalut)
- Suunnitella tehokkaita MCP-työnkulkuja monimutkaisiin tehtäviin
- Optimoida MCP-toteutuksia suorituskyvyn ja luotettavuuden näkökulmasta

## Viralliset SDK-resurssit

Model Context Protocol tarjoaa viralliset SDK:t useille kielille:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK:iden käyttö

Tässä osiossa esitellään käytännön esimerkkejä MCP:n toteutuksesta useilla ohjelmointikielillä. Löydät esimerkkikoodit `samples`-hakemistosta, joka on järjestetty kielittäin.

### Saatavilla olevat esimerkit

Arkisto sisältää esimerkkitoteutuksia seuraavilla kielillä:

- C#
- Java
- TypeScript
- JavaScript
- Python

Jokainen esimerkki havainnollistaa keskeisiä MCP-käsitteitä ja toteutusmalleja kyseisessä kieli- ja ekosysteemissä.

## Palvelimen keskeiset ominaisuudet

MCP-palvelimet voivat toteuttaa minkä tahansa seuraavista ominaisuuksien yhdistelmistä:

### Resurssit
Resurssit tarjoavat kontekstia ja dataa käyttäjälle tai tekoälymallille:
- Dokumenttivarastot
- Tietopankit
- Rakenteelliset tietolähteet
- Tiedostojärjestelmät

### Kehotteet
Kehotteet ovat mallinnettuja viestejä ja työnkulkuja käyttäjille:
- Ennalta määritellyt keskustelumallit
- Ohjatut vuorovaikutuskuviot
- Erikoistuneet dialogirakenteet

### Työkalut
Työkalut ovat toimintoja, joita tekoälymalli voi suorittaa:
- Datan käsittelyyn liittyvät apuvälineet
- Ulkoiset API-integraatiot
- Laskennalliset toiminnot
- Hakutoiminnot

## Esimerkkitoteutukset: C#

Virallinen C# SDK -arkisto sisältää useita esimerkkitoteutuksia, jotka havainnollistavat MCP:n eri osa-alueita:

- **Perus MCP Client**: Yksinkertainen esimerkki MCP-asiakkaan luomisesta ja työkalujen kutsumisesta
- **Perus MCP Server**: Minimipalvelimen toteutus, jossa perus työkalujen rekisteröinti
- **Kehittynyt MCP Server**: Täysimittainen palvelin, jossa työkalujen rekisteröinti, autentikointi ja virheenkäsittely
- **ASP.NET-integraatio**: Esimerkkejä ASP.NET Core -integraatiosta
- **Työkalujen toteutusmallit**: Eri malleja työkalujen toteuttamiseen eri monimutkaisuustasoilla

MCP C# SDK on esikatseluvaiheessa, ja API:t voivat muuttua. Päivitämme tätä blogia jatkuvasti SDK:n kehittyessä.

### Keskeiset ominaisuudet
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Ensimmäisen [MCP-palvelimen rakentaminen](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Täydelliset C#-toteutusesimerkit löydät virallisesta [C# SDK -esimerkkivarastosta](https://github.com/modelcontextprotocol/csharp-sdk).

## Esimerkkitoteutus: Java-toteutus

Java SDK tarjoaa vahvat MCP-toteutusvaihtoehdot yritystason ominaisuuksilla.

### Keskeiset ominaisuudet

- Spring Framework -integraatio
- Vahva tyyppiturvallisuus
- Reaktiivisen ohjelmoinnin tuki
- Laaja virheenkäsittely

Täydellisen Java-toteutusesimerkin löydät tiedostosta [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) esimerkkihakemistosta.

## Esimerkkitoteutus: JavaScript-toteutus

JavaScript SDK tarjoaa kevyen ja joustavan tavan toteuttaa MCP.

### Keskeiset ominaisuudet

- Node.js- ja selainympäristötuki
- Promise-pohjainen API
- Helppo integraatio Expressin ja muiden kehysten kanssa
- WebSocket-tuki striimaukseen

Täydellisen JavaScript-esimerkin löydät tiedostosta [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) esimerkkihakemistosta.

## Esimerkkitoteutus: Python-toteutus

Python SDK tarjoaa pythonilaisen lähestymistavan MCP:n toteutukseen erinomaisilla ML-kehysintegraatioilla.

### Keskeiset ominaisuudet

- Async/await-tuki asyncio-kirjaston kanssa
- Flask- ja FastAPI-integraatiot
- Yksinkertainen työkalujen rekisteröinti
- Natiivi integraatio suosittuihin ML-kirjastoihin

Täydellisen Python-esimerkin löydät tiedostosta [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) esimerkkihakemistosta.

## API-hallinta

Azure API Management on erinomainen ratkaisu MCP-palvelimien suojaamiseen. Ajatuksena on sijoittaa Azure API Management -instanssi MCP-palvelimesi eteen ja antaa sen hoitaa ominaisuuksia, joita todennäköisesti tarvitset, kuten:

- käyttörajoitukset
- tokenien hallinta
- valvonta
- kuormantasapainotus
- tietoturva

### Azure-esimerkki

Tässä on Azure-esimerkki, joka tekee juuri tämän, eli [luo MCP-palvelimen ja suojaa sen Azure API Managementilla](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Katso, miten valtuutusprosessi tapahtuu alla olevassa kuvassa:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Edellä olevassa kuvassa tapahtuu seuraavaa:

- Todennus ja valtuutus hoidetaan Microsoft Entran avulla.
- Azure API Management toimii porttina ja käyttää politiikkoja liikenteen ohjaamiseen ja hallintaan.
- Azure Monitor kirjaa kaikki pyynnöt jatkoanalyysiä varten.

#### Valtuutusprosessi

Katsotaan valtuutusprosessia tarkemmin:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP:n valtuutuksen määrittely

Lue lisää [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) -määrittelystä.

## Etä-MCP-palvelimen käyttöönotto Azureen

Katsotaan, miten voimme ottaa käyttöön aiemmin mainitun esimerkin:

1. Kloonaa repositorio

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Rekisteröi `Microsoft.App`-resurssin tarjoaja komennolla `az provider register --namespace Microsoft.App --wait` tai PowerShellillä `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Tarkista rekisteröinnin tila komennolla `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` hetken kuluttua.

3. Suorita tämä [azd](https://aka.ms/azd) -komento varmistamaan API Management -palvelu, Function App (koodin kanssa) ja kaikki muut tarvittavat Azure-resurssit:

    ```shell
    azd up
    ```

    Tämä komento ottaa käyttöön kaikki pilviresurssit Azureen.

### Palvelimen testaus MCP Inspectorilla

1. Avaa **uusi komentorivipääte** ja asenna sekä käynnistä MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Näet käyttöliittymän, joka näyttää tältä:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fi.png)

2. CTRL-klikkaa ladataksesi MCP Inspector -verkkosovelluksen sovelluksen näyttämästä URL-osoitteesta (esim. http://127.0.0.1:6274/#resources)
3. Aseta siirtotavaksi `SSE` ja valitse **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listaa työkalut**. Klikkaa työkalua ja valitse **Run Tool**.

Jos kaikki vaiheet onnistuivat, olet nyt yhteydessä MCP-palvelimeen ja olet pystynyt kutsumaan työkalua.

## MCP-palvelimet Azureen

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tämä sarja arkistoja tarjoaa nopean aloituspohjan räätälöityjen etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Azure Functions -palvelun avulla Pythonilla, C# .NET:llä tai Node/TypeScriptillä.

Esimerkit tarjoavat täydellisen ratkaisun, jonka avulla kehittäjät voivat:

- Rakentaa ja ajaa paikallisesti: Kehittää ja virheenkorjata MCP-palvelinta paikallisella koneella
- Ottaa käyttöön Azureen: Helppo pilvikäyttöönotto yksinkertaisella azd up -komennolla
- Yhdistää asiakkailta: Yhdistää MCP-palvelimeen eri asiakasohjelmilla, kuten VS Coden Copilot agent -tilassa ja MCP Inspector -työkalulla

### Keskeiset ominaisuudet:

- Suunniteltu turvallisuus: MCP-palvelin on suojattu avaimilla ja HTTPS:llä
- Autentikointivaihtoehdot: Tukee OAuth:ta sisäänrakennetulla todennuksella ja/tai API Managementilla
- Verkkoympäristön eristys: Mahdollistaa verkkoympäristön eristämisen Azure Virtual Networks (VNET) avulla
- Palvelinless-arkkitehtuuri: Hyödyntää Azure Functions -palvelua skaalautuvaan, tapahtumapohjaiseen suoritukseen
- Paikallinen kehitys: Laaja tuki paikalliselle kehitykselle ja virheenkorjaukselle
- Yksinkertainen käyttöönotto: Virtaviivainen käyttöönotto Azureen

Arkisto sisältää kaikki tarvittavat konfiguraatiotiedostot, lähdekoodin ja infrastruktuurin määrittelyt, jotta voit nopeasti aloittaa tuotantovalmiin MCP-palvelimen toteutuksen.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) – MCP:n esimerkkitoteutus Azure Functionsilla Pythonilla

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – MCP:n esimerkkitoteutus Azure Functionsilla C# .NET:llä

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – MCP:n esimerkkitoteutus Azure Functionsilla Node/TypeScriptillä.

## Keskeiset opit

- MCP SDK:t tarjoavat kielikohtaiset työkalut vahvojen MCP-ratkaisujen toteutukseen
- Virheenkorjaus ja testaus ovat kriittisiä luotettaville MCP-sovelluksille
- Uudelleenkäytettävät kehotemallit mahdollistavat johdonmukaiset tekoälyvuorovaikutukset
- Hyvin suunnitellut työnkulut voivat orkestroida monimutkaisia tehtäviä useilla työkaluilla
- MCP-ratkaisujen toteutus vaatii huomioita tietoturvasta, suorituskyvystä ja virheenkäsittelystä

## Harjoitus

Suunnittele käytännön MCP-työnkulku, joka ratkaisee todellisen ongelman omalla alallasi:

1. Tunnista 3–4 työkalua, jotka olisivat hyödyllisiä tämän ongelman ratkaisemisessa
2. Laadi työnkulun kaavio, joka näyttää, miten nämä työkalut vuorovaikuttavat
3. Toteuta perusversio yhdestä työkaluista valitsemallasi kielellä
4. Luo kehotemalli, joka auttaa mallia käyttämään työkalua tehokkaasti

## Lisäresurssit


---

Seuraava: [Edistyneet aiheet](../05-AdvancedTopics/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on pidettävä auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.