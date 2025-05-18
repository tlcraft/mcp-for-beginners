<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:53:38+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "fi"
}
-->
# MCP-palvelimien käyttöönotto

MCP-palvelimen käyttöönotto mahdollistaa sen työkalujen ja resurssien käytön muille kuin vain paikallisessa ympäristössä. Käyttöönottoon on useita strategioita, jotka kannattaa harkita riippuen tarpeistasi skaalautuvuuden, luotettavuuden ja hallinnan helppouden suhteen. Alla on ohjeita MCP-palvelimien käyttöönottoon paikallisesti, konteissa ja pilvessä.

## Yleiskatsaus

Tämä osio käsittelee, kuinka MCP-palvelinsovelluksesi otetaan käyttöön.

## Oppimistavoitteet

Tämän osion lopussa pystyt:

- Arvioimaan erilaisia käyttöönoton lähestymistapoja.
- Ottamaan sovelluksesi käyttöön.

## Paikallinen kehitys ja käyttöönotto

Jos palvelimesi on tarkoitettu käytettäväksi käyttäjän koneella, voit seurata seuraavia vaiheita:

1. **Lataa palvelin**. Jos et ole itse kirjoittanut palvelinta, lataa se ensin koneellesi.
1. **Käynnistä palvelinprosessi**: Suorita MCP-palvelinsovellus

SSE:lle (ei tarpeen stdio-tyyppiselle palvelimelle)

1. **Verkkoasetusten konfigurointi**: Varmista, että palvelin on saavutettavissa odotetulla portilla
1. **Yhdistä asiakkaat**: Käytä paikallisia yhteys-URL-osoitteita kuten `http://localhost:3000`

## Pilvikäyttöönotto

MCP-palvelimet voidaan ottaa käyttöön eri pilvialustoilla:

- **Serverless-toiminnot**: Ota kevyet MCP-palvelimet käyttöön serverless-toimintoina
- **Konttipalvelut**: Käytä palveluja kuten Azure Container Apps, AWS ECS tai Google Cloud Run
- **Kubernetes**: Ota MCP-palvelimet käyttöön ja hallitse niitä Kubernetes-klustereissa korkean saatavuuden saavuttamiseksi

### Esimerkki: Azure Container Apps

Azure Container Apps tukee MCP-palvelimien käyttöönottoa. Se on vielä kehitysvaiheessa ja tukee tällä hetkellä SSE-palvelimia.

Näin voit toimia:

1. Kloonaa repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Suorita se paikallisesti testataksesi asioita:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Kokeillaksesi paikallisesti, luo *mcp.json* tiedosto *.vscode* hakemistoon ja lisää seuraava sisältö:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Kun SSE-palvelin on käynnistetty, voit klikata JSON-tiedoston toistoikonia, ja sinun pitäisi nyt nähdä työkalut palvelimella, jotka GitHub Copilot poimii, katso Työkaluikonia.

1. Käyttöönottoa varten suorita seuraava komento:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Siinä se, ota käyttöön paikallisesti, ota käyttöön Azureen näiden vaiheiden kautta.

## Lisäresurssit

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps -artikkeli](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP -repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Mitä seuraavaksi

- Seuraavaksi: [Käytännön toteutus](/04-PracticalImplementation/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskääntämistä. Emme ole vastuussa väärinkäsityksistä tai virheellisistä tulkinnoista, jotka johtuvat tämän käännöksen käytöstä.