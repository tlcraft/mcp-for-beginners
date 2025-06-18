<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:16:02+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fi"
}
-->
# Käytännön toteutus

Käytännön toteutus on se vaihe, jossa Model Context Protocolin (MCP) voima konkretisoituu. Vaikka MCP:n teorian ja arkkitehtuurin ymmärtäminen on tärkeää, todellinen arvo syntyy, kun sovellat näitä käsitteitä rakentaaksesi, testataksesi ja ottaaksesi käyttöön ratkaisuja, jotka ratkaisevat todellisia ongelmia. Tämä luku yhdistää käsitteellisen tiedon ja käytännön kehityksen, ohjaten sinua MCP-pohjaisten sovellusten toteuttamisessa.

Olitpa sitten kehittämässä älykkäitä avustajia, integroimassa tekoälyä liiketoimintaprosesseihin tai rakentamassa räätälöityjä työkaluja datan käsittelyyn, MCP tarjoaa joustavan perustan. Sen kieliriippumaton rakenne ja viralliset SDK:t suosituilla ohjelmointikielillä tekevät siitä helposti lähestyttävän monille kehittäjille. Hyödyntämällä näitä SDK:ita voit nopeasti prototyypittää, kehittää ja skaalata ratkaisuja eri alustoilla ja ympäristöissä.

Seuraavissa osioissa löydät käytännön esimerkkejä, koodinäytteitä ja käyttöönotto-strategioita, jotka osoittavat, miten MCP toteutetaan C#:lla, Javalla, TypeScriptillä, JavaScriptillä ja Pythonilla. Opit myös, miten MCP-palvelimia virheenkorjataan ja testataan, API-hallintaa hoidetaan sekä ratkaisut otetaan käyttöön pilvessä Azurea hyödyntäen. Nämä käytännön materiaalit on suunniteltu nopeuttamaan oppimistasi ja auttamaan sinua rakentamaan luotettavia, tuotantovalmiita MCP-sovelluksia itsevarmasti.

## Yleiskatsaus

Tässä oppitunnissa keskitytään MCP:n käytännön toteutukseen useilla ohjelmointikielillä. Tutustumme siihen, miten MCP SDK:ita käytetään C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa vakavien sovellusten rakentamiseen, MCP-palvelimien virheenkorjaukseen ja testaamiseen sekä uudelleenkäytettävien resurssien, kehotteiden ja työkalujen luomiseen.

## Oppimistavoitteet

Oppitunnin lopussa osaat:
- Toteuttaa MCP-ratkaisuja virallisten SDK:iden avulla eri ohjelmointikielillä
- Virheenkorjata ja testata MCP-palvelimia systemaattisesti
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

Tässä osiossa esitellään käytännön esimerkkejä MCP:n toteuttamisesta eri ohjelmointikielillä. Näytekoodit löytyvät `samples`-hakemistosta kielen mukaan järjestettynä.

### Saatavilla olevat näytteet

Repositorio sisältää [näytetoteutuksia](../../../04-PracticalImplementation/samples) seuraavilla kielillä:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Jokainen näyte havainnollistaa keskeisiä MCP-konsepteja ja toteutusmalleja kyseiselle kielelle ja ekosysteemille.

## Palvelimen ydintoiminnot

MCP-palvelimet voivat toteuttaa minkä tahansa yhdistelmän seuraavista ominaisuuksista:

### Resurssit
Resurssit tarjoavat kontekstia ja dataa käyttäjälle tai tekoälymallille:
- Dokumenttivarastot
- Tietopohjat
- Rakenteiset tietolähteet
- Tiedostojärjestelmät

### Kehotteet
Kehotteet ovat mallinnettuja viestejä ja työnkulkuja käyttäjille:
- Ennalta määritellyt keskustelumallit
- Ohjatut vuorovaikutuskuviot
- Erikoistuneet dialogirakenteet

### Työkalut
Työkalut ovat toimintoja, joita tekoälymalli voi suorittaa:
- Datan käsittelytyökalut
- Ulkoiset API-integraatiot
- Laskentakyvyt
- Hakutoiminnot

## Näytetoteutukset: C#

Virallinen C# SDK -repositorio sisältää useita näytetoteutuksia, jotka demonstroivat MCP:n eri puolia:

- **Perus MCP-asiakas**: Yksinkertainen esimerkki MCP-asiakkaan luomisesta ja työkalujen kutsumisesta
- **Perus MCP-palvelin**: Minimipalvelimen toteutus perus työkalurekisteröinnillä
- **Edistynyt MCP-palvelin**: Täysimittainen palvelin työkalurekisteröinnillä, autentikoinnilla ja virheenkäsittelyllä
- **ASP.NET-integraatio**: Esimerkkejä ASP.NET Core -integraatiosta
- **Työkalujen toteutusmallit**: Eri malleja työkalujen toteuttamiseen eri vaikeustasoilla

MCP:n C# SDK on esiversiossa, ja API:t voivat muuttua. Päivitämme tätä blogia jatkuvasti SDK:n kehittyessä.

### Keskeiset ominaisuudet 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Rakennusopas [ensimmäiselle MCP-palvelimellesi](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Täydelliset C# toteutusnäytteet löydät virallisesta [C# SDK -näytekirjastosta](https://github.com/modelcontextprotocol/csharp-sdk)

## Näytetoteutus: Java

Java SDK tarjoaa vankat MCP-toteutusmahdollisuudet yritystason ominaisuuksilla.

### Keskeiset ominaisuudet

- Spring Framework -integraatio
- Vahva tyyppiturvallisuus
- Reaktiivisen ohjelmoinnin tuki
- Kattava virheenkäsittely

Täydellisen Java-toteutusnäytteen löydät tiedostosta [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) näytehakemistosta.

## Näytetoteutus: JavaScript

JavaScript SDK tarjoaa kevyen ja joustavan tavan toteuttaa MCP.

### Keskeiset ominaisuudet

- Tuki Node.js:lle ja selaimille
- Promise-pohjainen API
- Helppo integraatio Expressin ja muiden kehysten kanssa
- WebSocket-tuki suoratoistoon

Täydellisen JavaScript-toteutusnäytteen löydät tiedostosta [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) näytehakemistosta.

## Näytetoteutus: Python

Python SDK tarjoaa Python-tyylisen lähestymistavan MCP:n toteutukseen erinomaisilla ML-kehysintegraatioilla.

### Keskeiset ominaisuudet

- Async/await-tuki asyncio-kirjastolla
- Flask- ja FastAPI-integraatio
- Yksinkertainen työkalurekisteröinti
- Natiivi integraatio suosittuihin ML-kirjastoihin

Täydellisen Python-toteutusnäytteen löydät tiedostosta [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) näytehakemistosta.

## API-hallinta

Azure API Management on erinomainen ratkaisu MCP-palvelimien suojaamiseen. Ajatus on laittaa Azure API Management -instanssi MCP-palvelimesi eteen ja antaa sen hoitaa toiminnot, joita todennäköisesti tarvitset, kuten:

- nopeusrajoitukset
- token-hallinta
- valvonta
- kuormantasapainotus
- tietoturva

### Azure-esimerkki

Tässä on Azure-esimerkki, joka tekee juuri tämän, eli [luo MCP-palvelimen ja suojaa sen Azure API Managementilla](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Katso alla olevaa kuvaa, miten valtuutusprosessi etenee:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Kuvassa tapahtuu seuraavaa:

- Autentikointi ja valtuutus tapahtuvat Microsoft Entran avulla.
- Azure API Management toimii porttina ja käyttää sääntöjä liikenteen ohjaamiseen ja hallintaan.
- Azure Monitor kirjaa kaikki pyynnöt jatkoanalyysiä varten.

#### Valtuutusprosessi

Katsotaan valtuutusprosessia tarkemmin:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-valtuutuksen määritelmä

Lisätietoja [MCP Authorization -määritelmästä](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Etä-MCP-palvelimen käyttöönotto Azureen

Katsotaan, voimmeko ottaa käyttöön aiemmin mainitun näytteen:

1. Kloonaa repositorio

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Rekisteröi `Microsoft.App`:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `

    Rekisteröi myös PowerShellissä:

    Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `

    Tarkista rekisteröinnin tila hetken kuluttua komennolla `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

2. Suorita tämä [azd](https://aka.ms/azd) -komento, joka provisioi API Management -palvelun, Function Appin (koodilla) ja kaikki muut tarvittavat Azure-resurssit:

    ```shell
    azd up
    ```

    Tämä komento ottaa käyttöön kaikki pilviresurssit Azureen.

### Palvelimen testaus MCP Inspectorilla

1. Avaa **uusi komentorivipääteikkuna**, asenna ja käynnistä MCP Inspector:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Näet käyttöliittymän, joka näyttää tältä:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fi.png) 

1. CTRL-klikkaa ladataksesi MCP Inspector -web-sovelluksen sovelluksen näyttämästä URL-osoitteesta (esim. http://127.0.0.1:6274/#resources)
1. Aseta siirtotavaksi `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ja **Yhdistä**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listaa työkalut**. Klikkaa työkalua ja valitse **Suorita työkalu**.  

Jos kaikki vaiheet onnistuivat, olet nyt yhdistetty MCP-palvelimeen ja pystyt kutsumaan työkalua.

## MCP-palvelimet Azurea varten

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tämä joukko repositorioita tarjoaa nopean aloituspohjan räätälöityjen etä-MCP (Model Context Protocol) -palvelimien rakentamiseen ja käyttöönottoon Azure Functions -ympäristössä Pythonilla, C# .NET:llä tai Node/TypeScriptillä.

Näytteet tarjoavat täydellisen ratkaisun, joka mahdollistaa kehittäjille:

- Paikallisen kehityksen ja suorittamisen: Kehitä ja virheenkorjaa MCP-palvelin paikallisella koneella
- Pilveen käyttöönoton: Ota käyttöön pilvessä helposti yhdellä azd up -komennolla
- Asiakasohjelmista yhdistämisen: Yhdistä MCP-palvelimeen eri asiakkailta, mukaan lukien VS Code Copilot agent -tila ja MCP Inspector -työkalu

### Keskeiset ominaisuudet:

- Turvallisuus suunnittelusta lähtien: MCP-palvelin on suojattu avaimilla ja HTTPS-yhteydellä
- Autentikointivaihtoehdot: Tukee OAuth:ia sisäänrakennetulla autentikoinnilla ja/tai API Managementilla
- Verkkoympäristön eristäminen: Mahdollistaa verkkoympäristön eristämisen Azure Virtual Networkien (VNET) avulla
- Palvelimeton arkkitehtuuri: Hyödyntää Azure Functionsia skaalautuvaan, tapahtumapohjaiseen suoritukseen
- Paikallinen kehitys: Kattava tuki paikalliselle kehitykselle ja virheenkorjaukselle
- Helppo käyttöönotto: Virtaviivainen käyttöönotto Azureen

Repositoriossa on kaikki tarvittavat konfiguraatiotiedostot, lähdekoodi ja infrastruktuurin määritelmät, jotta tuotantovalmiin MCP-palvelimen toteutus saadaan nopeasti käyntiin.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP:n näytetoteutus Azure Functionsilla Pythonilla

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP:n näytetoteutus Azure Functionsilla C# .NET:llä

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP:n näytetoteutus Azure Functionsilla Node/TypeScriptillä.

## Keskeiset opit

- MCP SDK:t tarjoavat kielikohtaiset työkalut vahvojen MCP-ratkaisujen toteutukseen
- Virheenkorjaus- ja testausprosessi on kriittinen luotettaville MCP-sovelluksille
- Uudelleenkäytettävät kehotemallit mahdollistavat johdonmukaiset tekoälyvuorovaikutukset
- Hyvin suunnitellut työnkulut voivat orkestroida monimutkaisia tehtäviä useilla työkaluilla
- MCP-ratkaisujen toteutus vaatii huomioimaan tietoturvan, suorituskyvyn ja virheenkäsittelyn

## Harjoitus

Suunnittele käytännön MCP-työnkulku, joka ratkaisee todellisen ongelman omalla alallasi:

1. Valitse 3-4 työkalua, jotka auttaisivat tämän ongelman ratkaisemisessa
2. Luo työnkulun kaavio, joka näyttää, miten nämä työkalut toimivat yhdessä
3. Toteuta yksinkertainen versio yhdestä työkaluista haluamallasi kielellä
4. Luo kehotemalli, joka auttaa mallia käyttämään työkalua tehokkaasti

## Lisäresurssit


---

Seuraava: [Edistyneet aiheet](../05-AdvancedTopics/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, on hyvä huomioida, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.