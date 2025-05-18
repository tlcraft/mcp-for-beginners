<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:01:27+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "fi"
}
-->
# Peruslaskin MCP-palvelu

Tämä palvelu tarjoaa peruslaskutoimituksia Model Context Protocolin (MCP) kautta. Se on suunniteltu yksinkertaiseksi esimerkiksi aloittelijoille, jotka opettelevat MCP-toteutuksia.

Lisätietoja löytyy [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Ominaisuudet

Tämä laskinpalvelu tarjoaa seuraavat toiminnot:

1. **Peruslaskutoimitukset**:
   - Kahden luvun yhteenlasku
   - Yhden luvun vähennys toisesta
   - Kahden luvun kertolasku
   - Yhden luvun jakaminen toisella (sisältää nollalla jakamisen tarkistuksen)

## `stdio` Tyypin käyttö

## Konfigurointi

1. **MCP-palvelimien konfigurointi**:
   - Avaa työtilasi VS Code -ohjelmassa.
   - Luo `.vscode/mcp.json`-tiedosto työtilasi kansioon MCP-palvelimien konfigurointia varten. Esimerkki konfiguraatiosta:
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
   - Korvaa polku projektisi polulla. Polun tulee olla absoluuttinen eikä suhteellinen työtilan kansioon. (Esimerkki: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Palvelun käyttö

Palvelu tarjoaa seuraavat API-päätepisteet MCP-protokollan kautta:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` Docker Hub -käyttäjänimelläsi:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Kun kuva on rakennettu, ladataan se Docker Hubiin. Suorita seuraava komento:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerisoidun version käyttö

1. `.vscode/mcp.json`-tiedostossa korvaa palvelimen konfiguraatio seuraavalla:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Kun tarkastelet konfiguraatiota, näet, että komento on `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, ja aivan kuten aiemmin, voit pyytää laskinpalvelua tekemään matematiikkaa puolestasi.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälykäännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.